using iTextSharp.text;
using iTextSharp.text.pdf;
using MongoDB.Bson;
using MongoDB.Driver;
using MSSQLEntityModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using MongoDbModel;
using SqLiteModel;
using System.Data.OleDb;

namespace SupermarketManagement
{
    class Reports
    {
        const string REPORT_TITLE = "Aggregated Sales Report";

        const string HEADER_PRODUCT_COLUMN_NAME = "Product";

        const string HEADER_QUANTITY_COLUMN_NAME = "Quantity";

        const string HEADER_UNIT_PRICE_COLUMN_NAME = "Unit Price";

        const string HEADER_LOCATION_COLUMN_NAME = "Location";

        const string HEADER_SUM_COLUMN_NAME = "Sum";

        public static void SalesToPdf()
        {
            var document = new Document();

            string pdfExportPath = Settings.Default.PdfExportPath;
            var output = new FileStream(pdfExportPath + "/AggregatedSalesReport.pdf", FileMode.OpenOrCreate);
            var writer = PdfWriter.GetInstance(document, output);

            document.Open();

            PdfPTable mainTable = new PdfPTable(5);
            AddNewCell(mainTable, REPORT_TITLE, 5, 1);


            using (SupermarketsEntities1 mssqlContext = new SupermarketsEntities1())
            {
                var aggregatedSalesReport =
                    from s in mssqlContext.Supermarkets
                    join r in mssqlContext.Reports
                        on s.SupermarketId equals r.SupermarketId
                    join rd in mssqlContext.ReportDetails
                        on r.ReportId equals rd.ReportId
                    join p in mssqlContext.Products
                        on rd.ProductId equals p.ProductsId
                    join m in mssqlContext.Measures
                        on p.MeasureId equals m.MeasureId
                    select new
                    {
                        supermarketName = s.SupermarketName.TrimEnd(),
                        reportDate = r.ReportDate,
                        quantity = rd.Quantity,
                        unitPrice = rd.UnitPrice,
                        unitTotalPrice = rd.Quantity * rd.UnitPrice,
                        productName = p.ProductName.TrimEnd(),
                        mesureName = m.MeasureName.TrimEnd()
                    };

                var aggregatedSalesReportGrouped = aggregatedSalesReport.GroupBy(x => x.reportDate);

                foreach (var dateGroup in aggregatedSalesReportGrouped)
                {
                    string groupDateAsString = string.Format("{0:d-MMM-yyyy}", dateGroup.Key);
                    AddNewCell(mainTable, "Date: " + groupDateAsString, 5, 0, "Gray");

                    AddHeaderRow(mainTable);

                    foreach (var reportDetail in dateGroup)
                    {
                        mainTable.AddCell(reportDetail.productName);
                        AddNewCell(mainTable, reportDetail.quantity + " " + reportDetail.mesureName, 1, 1);
                        AddNewCell(mainTable, reportDetail.unitPrice.ToString(), 1, 1);
                        mainTable.AddCell(reportDetail.supermarketName);
                        AddNewCell(mainTable, reportDetail.unitTotalPrice.ToString("F2"), 1, 2);
                    }

                    AddNewCell(mainTable, "Total sum for " + groupDateAsString + ":", 4, 2);

                    decimal totalSum = dateGroup.Sum(x => x.unitTotalPrice);
                    AddNewCell(mainTable, totalSum.ToString("F2"), 1, 2);
                }

                decimal grandTotal = aggregatedSalesReport.Sum(x => x.unitTotalPrice);
                AddNewCell(mainTable, "Grand total:", 4, 2);
                AddNewCell(mainTable, grandTotal.ToString("F2"), 1, 2);
            }

            document.Add(mainTable);
            document.Close();
        }

        public static void SalesToJson()
        {
            string mongoDbConnectionString = Settings.Default.MongoDbConnectionString;
            MongoDatabase mongoDb = Connector.GetDb(mongoDbConnectionString, "Supermarkets");
            MongoCollection productVendorSalesMongoDb = mongoDb.GetCollection("ProductVendorSales");

            using (SupermarketsEntities1 mssqlContext = new SupermarketsEntities1())
            {
                var aggregatedSalesReport =
                    from rd in mssqlContext.ReportDetails
                    join p in mssqlContext.Products
                        on rd.ProductId equals p.ProductsId
                    join v in mssqlContext.Vendors
                        on p.VendorId equals v.VendorId
                    select new
                    {
                        productId = p.ProductsId,
                        productName = p.ProductName.TrimEnd(),
                        vendorName = v.VendorName.TrimEnd(),
                        quantitySold = rd.Quantity,
                        incomes = rd.Quantity * rd.UnitPrice
                    };

                var groupedByProduct = aggregatedSalesReport.GroupBy(x => new
                {
                    productId = x.productId,
                    productName = x.productName,
                    vendorName = x.vendorName
                });

                foreach (var productGroup in groupedByProduct)
                {
                    ProductVendorSales newSales = new ProductVendorSales()
                    {
                        ProductId = productGroup.Key.productId,
                        ProductName = productGroup.Key.productName,
                        VendorName = productGroup.Key.vendorName,
                        TotalQuantitySold = productGroup.Sum(x => x.quantitySold),
                        TotalIncomes = productGroup.Sum(x => x.incomes)
                    };

                    string newJson = JsonConvert.SerializeObject(newSales);

                    BsonDocument document = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>(newJson);
                    productVendorSalesMongoDb.Insert(document);

                    //var ProductVendorSalesResults = mongoDb.GetCollection("ProductVendorSales").FindAll();

                    string jsonExportPath = Settings.Default.JsonExportPath;
                    using (StreamWriter writer = new StreamWriter(jsonExportPath + "\\" + productGroup.Key.productId + ".json"))
                    {
                        writer.Write(newJson);
                    }
                }
            }
        }

        public static void VendorsTotalReport(DateTime forDate)
        {
            //TransferFromMongoDbToSqLite();

            using (SupermarketsSqLiteEntities sqlLiteContext = new SupermarketsSqLiteEntities())
            {
                var vendorProductSalesAndTaxes =
                    from ps in sqlLiteContext.ProductSalesReports
                    join pt in sqlLiteContext.ProductTaxes
                        on ps.ProductName equals pt.ProductName
                    select new
                    {
                        vendorName = ps.VendorName,
                        productTotalIncomes = ps.TotalIncomes,
                        productTotalTaxes = ps.TotalIncomes * pt.Tax
                    };

                var vendorSalesAndTaxes =
                    (from vst in vendorProductSalesAndTaxes
                     group vst by vst.vendorName into vendorGroup
                     select new
                     {
                         vendorName = vendorGroup.Key,
                         vendorTotalIncomes = vendorGroup.Sum(x => x.productTotalIncomes),
                         vendorTotalTaxes = vendorGroup.Sum(x => x.productTotalTaxes)
                     }).ToArray();

                using (SupermarketsEntities1 mssqlContext = new SupermarketsEntities1())
                {
                    var vendorExpences =
                        (from vs in mssqlContext.VendorSales
                         join v in mssqlContext.Vendors
                             on vs.VendorId equals v.VendorId
                         where ((vs.Date.Year == forDate.Year) && (vs.Date.Month == forDate.Month))
                         select new
                         {
                             vendorExpences = vs.Expenses,
                             vendorName = v.VendorName.TrimEnd()
                         }).ToArray();

                    var vendorFinancialResult =
                        from ve in vendorExpences
                        join vst in vendorSalesAndTaxes
                            on ve.vendorName equals vst.vendorName
                        select new
                        {
                            vendorName = vst.vendorName,
                            vendorTotalIncomes = vst.vendorTotalIncomes,
                            vendorTotalTaxes = vst.vendorTotalTaxes,
                            vendorExpences = ve.vendorExpences,
                            vendorFinancialResult = vst.vendorTotalIncomes - ve.vendorExpences - vst.vendorTotalTaxes
                        };

                    //System.IO.DirectoryInfo zipReportsExportDirectoryInfo = new DirectoryInfo(zipReportsExportPath);
                    string excelFilePath = Settings.Default.ExcelExportTotalProductReportPath;
                    System.IO.FileInfo excelFile = new FileInfo(excelFilePath);

                    excelFile.Delete();

                    string excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelFilePath + ";Extended Properties='Excel 12.0 XML;HDR=YES'";
                    OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);

                    using (excelConnection)
                    {
                        excelConnection.Open();
                        OleDbCommand createTable = new OleDbCommand(
                            "CREATE TABLE [Sheet1] ([Vendor] varchar(255), [Incomes] number, [Expenses] number, [Taxes] number, [Financial Result] number)"
                            , excelConnection);

                        createTable.ExecuteNonQuery();

                        OleDbCommand setExcelSheetData = new OleDbCommand(
                            "INSERT INTO [Sheet1$] ([Vendor], [Incomes], [Expenses], [Taxes], [Financial Result]) " +
                            "VALUES (@vendorName, @invomes, @expenses, @taxes, @financialResult)", excelConnection);

                        foreach (var vendorFinancialRecord in vendorFinancialResult)
                        {
                            setExcelSheetData.Parameters.AddWithValue("@vendorName", vendorFinancialRecord.vendorName);
                            setExcelSheetData.Parameters.AddWithValue("@invomes", vendorFinancialRecord.vendorTotalIncomes);
                            setExcelSheetData.Parameters.AddWithValue("@expenses", vendorFinancialRecord.vendorExpences);
                            setExcelSheetData.Parameters.AddWithValue("@taxes", vendorFinancialRecord.vendorTotalTaxes);
                            setExcelSheetData.Parameters.AddWithValue("@financialResult", vendorFinancialRecord.vendorFinancialResult);

                            setExcelSheetData.ExecuteNonQuery();                           
                        }
                    }
                }
            }
        }

        private static void TransferFromMongoDbToSqLite()
        {
            string mongoDbConnectionString = Settings.Default.MongoDbConnectionString;
            MongoDatabase mongoDb = Connector.GetDb(mongoDbConnectionString, "Supermarkets");
            var productVendorSalesRecords = mongoDb.GetCollection("ProductVendorSales").FindAll();

            using (SupermarketsSqLiteEntities sqlLiteContext = new SupermarketsSqLiteEntities())
            {
                foreach (var productVendorSalesRecord in productVendorSalesRecords)
                {
                    ProductSalesReport newProductSalesReport = new ProductSalesReport()
                    {
                        ProductId = long.Parse(productVendorSalesRecord.GetValue("product-id").ToString()),
                        ProductName = productVendorSalesRecord.GetValue("product-name").ToString(),
                        VendorName = productVendorSalesRecord.GetValue("vendor-name").ToString(),
                        TotalQuantitySold = long.Parse(productVendorSalesRecord.GetValue("total-quantity-sold").ToString()),
                        TotalIncomes = decimal.Parse(productVendorSalesRecord.GetValue("total-incomes").ToString()),
                    };

                    sqlLiteContext.ProductSalesReports.Add(newProductSalesReport);

                    Console.WriteLine(productVendorSalesRecord.GetValue("product-id"));
                };

                sqlLiteContext.SaveChanges();
            }
        }

        private static void AddHeaderRow(PdfPTable mainTable)
        {
            AddNewCell(mainTable, HEADER_PRODUCT_COLUMN_NAME, 1, 0, "Gray");
            AddNewCell(mainTable, HEADER_QUANTITY_COLUMN_NAME, 1, 0, "Gray");
            AddNewCell(mainTable, HEADER_UNIT_PRICE_COLUMN_NAME, 1, 0, "Gray");
            AddNewCell(mainTable, HEADER_LOCATION_COLUMN_NAME, 1, 0, "Gray");
            AddNewCell(mainTable, HEADER_SUM_COLUMN_NAME, 1, 0, "Gray");
        }

        private static void AddNewCell(PdfPTable mainTable, string cellValue, int cellColSpan, int cellAlignment, string colorName = null)
        {
            PdfPCell titleCell = new PdfPCell(new Phrase(cellValue));
            if (cellColSpan > 1)
            {
                titleCell.Colspan = cellColSpan;
            }
            if (new List<int> { 0, 1, 2 }.Contains(cellAlignment))
            {
                titleCell.HorizontalAlignment = cellAlignment;
            }

            switch (colorName)
            {
                case "Gray":
                    titleCell.BackgroundColor = new iTextSharp.text.BaseColor(150, 150, 150);
                    break;
                default:
                    break;
            }

            mainTable.AddCell(titleCell);
        }
    }
}

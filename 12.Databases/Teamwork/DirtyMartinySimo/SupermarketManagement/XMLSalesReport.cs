using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using MSSQLEntityModel;
using System.Globalization;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDbModel;
using Newtonsoft.Json;
namespace SupermarketManagement
{
    public class XMLSalesReport
    {
        // Task 3
        public static void importReportToXML()
        {
            using (var db = new SupermarketsEntities1())
            {

                var products = from v in db.Vendors
                               join p in db.Products
                                    on v.VendorId equals p.VendorId
                               join rd in db.ReportDetails
                                    on p.ProductsId equals rd.ProductId
                               join r in db.Reports
                                    on rd.ReportId equals r.ReportId
                               select new
                               {
                                   reportDate = r.ReportDate,
                                   productPrice = rd.UnitPrice * rd.Quantity,
                                   vendor = v.VendorName.TrimEnd()
                               };

                var groupedByVendor = products.GroupBy(x => x.vendor);
                XElement salesXml = new XElement("sales");
                foreach (var vendorGrouped in groupedByVendor)
                {
                    XElement sale = new XElement("sale");
                    //sale.Attribute("vendor").Value = "dddd";//vendorGrouped.Key.ToString();
                    sale.Add(new XAttribute("vendor", vendorGrouped.Key));
                    var groupedByDate = vendorGrouped.GroupBy(x => x.reportDate);
                    foreach (var dateGroup in groupedByDate)
                    {
                        var totalSum = dateGroup.Sum(x => x.productPrice);
                        XElement summary = new XElement("summary");
                        summary.Add(new XAttribute("total-sum", totalSum.ToString("F2")));
                        summary.Add(new XAttribute("date", string.Format("{0:d-MMM-yyyy}",dateGroup.Key)));
                         
                        sale.Add(summary);
                    }
                    salesXml.Add(sale);

                }

                string xmlReportExtractPath = Settings.Default.XmlReportExtractPath;
                salesXml.Save(xmlReportExtractPath);
            }
        }

        // Task 5
        public static void ExportFromXml()
        {
            string mongoDbConnectionString = Settings.Default.MongoDbConnectionString;
            MongoDatabase mongoDb = Connector.GetDb(mongoDbConnectionString, "Supermarkets");
            MongoCollection vendorSalesMongoDb = mongoDb.GetCollection("VendorSales");

            //TODO : To take it from setting file
            string path = @"../../XmlExports/expenses.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode rootNode = doc.DocumentElement;
            using (var context = new SupermarketsEntities1())
            {
                foreach (XmlNode node in rootNode.ChildNodes)
                {
                    var vendor = node.Attributes["vendor"].Value;
                    var vendorId = context.Vendors.First(v => v.VendorName == vendor).VendorId;

                    foreach (XmlNode childNode in node.ChildNodes)
                    {
                        // MSSQL Server import
                        var month = childNode.Attributes["month"].Value;
                        var expenseSum = decimal.Parse(childNode.InnerText);
                        DateTime date = DateTime.ParseExact(month, "MMM-yyyy", CultureInfo.InvariantCulture);
                        VendorSale newVendorSale = new VendorSale
                        {
                            Date = date,
                            Expenses = expenseSum,
                            VendorId = vendorId
                        };
                        context.VendorSales.Add(newVendorSale);

                        // MongoDb import
                        var newVendorSaleJson = new
                        {
                            date = date,
                            expenses = expenseSum,
                            vendorId = vendorId
                        };
                        string newJson = JsonConvert.SerializeObject(newVendorSaleJson);

                        BsonDocument document = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>(newJson);
                        vendorSalesMongoDb.Insert(document);

                        //var VendorSalesResults = mongoDb.GetCollection("VendorSales").FindAll();
                    }
                }
                context.SaveChanges();
            }
        }
    }
}

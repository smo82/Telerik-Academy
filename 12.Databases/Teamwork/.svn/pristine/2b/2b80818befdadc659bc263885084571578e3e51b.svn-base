using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MSSQLEntityModel;
using Ionic.Zip;
using System.Globalization;
using System.Data.OleDb;
using OpenAccessModelSupermarkets;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace SupermarketManagement
{
    class DataTransfer
    {
        public static void MySqlToMSSQLTransfer()
        {
            //using (SupermarketsEntities1 mssqlSupermarketContext = new SupermarketsEntities1())
            //{
            //    string[] tablesToDelete = new string[] { "VendorSales", "Vendors", "Measures", "Supermarkets", "Reports", "ReportDetails", "Products" };

            //    string delQuery = "TRUNCATE TABLE Measures";
            //    var rowsDelete = (mssqlSupermarketContext as IObjectContextAdapter).ObjectContext.ExecuteStoreQuery<int>(delQuery);


            //    //foreach (var table in tablesToDelete)
            //    //{
            //    //    string delQuery = "DELETE " + table;
            //    //    var rowsDelete = (mssqlSupermarketContext as IObjectContextAdapter).ObjectContext.ExecuteStoreQuery<int>(delQuery);
            //    //}
            //}

            using (EntitiesModel mysqlSupermarketContext = new EntitiesModel())
            {
                using (SupermarketsEntities1 mssqlSupermarketContext = new SupermarketsEntities1())
                {
                    mssqlSupermarketContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Vendors OFF");
                }

                using (SupermarketsEntities1 mssqlSupermarketContext = new SupermarketsEntities1())
                {
                    mssqlSupermarketContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Measures OFF");
                }

                using (SupermarketsEntities1 mssqlSupermarketContext = new SupermarketsEntities1())
                {
                    mssqlSupermarketContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Products OFF");
                }

                using (SupermarketsEntities1 mssqlSupermarketContext = new SupermarketsEntities1())
                {
                    foreach (var vendor in mysqlSupermarketContext.Vendors)
                    {
                        mssqlSupermarketContext.Vendors.Add(ConvertMySqlToMSSQL.ConvertMySqlToMSSQLVendor(vendor));
                    }

                    foreach (var measure in mysqlSupermarketContext.Measures)
                    {
                        mssqlSupermarketContext.Measures.Add(ConvertMySqlToMSSQL.ConvertMySqlToMSSQLMeasure(measure));
                    }

                    foreach (var product in mysqlSupermarketContext.Products)
                    {
                        mssqlSupermarketContext.Products.Add(ConvertMySqlToMSSQL.ConvertMySqlToMSSQLProduct(product));
                    }

                    mssqlSupermarketContext.SaveChanges();
                }

                using (SupermarketsEntities1 mssqlSupermarketContext = new SupermarketsEntities1())
                {
                    mssqlSupermarketContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Vendors ON");
                }

                using (SupermarketsEntities1 mssqlSupermarketContext = new SupermarketsEntities1())
                {
                    mssqlSupermarketContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Measures ON");
                }

                using (SupermarketsEntities1 mssqlSupermarketContext = new SupermarketsEntities1())
                {
                    mssqlSupermarketContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Products ON");
                }
            } 
        }

        public static void ReadReportsToMSSQL()
        {
            string zipReportsPath = Settings.Default.ZipReportsPath;
            string zipReportsExportPath = Settings.Default.ZipReportsExtractPath;

            using (ZipFile zip = ZipFile.Read(zipReportsPath))
            {
                foreach (ZipEntry zipEntry in zip)
                {
                    zipEntry.Extract(zipReportsExportPath, ExtractExistingFileAction.OverwriteSilently);
                }
            }


            using (SupermarketsEntities1 mssqlSupermarketContext = new SupermarketsEntities1())
            {
                Dictionary<string, Supermarket> supermarketsInTheDB = new Dictionary<string, Supermarket>();
                foreach (MSSQLEntityModel.Supermarket supermarket in mssqlSupermarketContext.Supermarkets)
                {
                    supermarketsInTheDB.Add(supermarket.SupermarketName.TrimEnd(), supermarket);
                }

                string[] dirReportExport = Directory.GetDirectories(zipReportsExportPath);
                foreach (string dir in dirReportExport)
                {
                    int indexOfLastSlash = dir.LastIndexOf("\\");
                    string dirName = dir.Substring(indexOfLastSlash + 1, dir.Length - indexOfLastSlash - 1);

                    CultureInfo provider = CultureInfo.InvariantCulture;
                    DateTime currentDate = DateTime.ParseExact(dirName, "dd-MMM-yyyy", provider);                  
                   
                    string[] currentDirFiles = Directory.GetFiles(dir, "*.xls");
                    foreach (string currentFile in currentDirFiles)
                    {
                        ExportExcelFileData(mssqlSupermarketContext, currentDate, currentFile, supermarketsInTheDB);
                    }
                }

                mssqlSupermarketContext.SaveChanges();

                System.IO.DirectoryInfo zipReportsExportDirectoryInfo = new DirectoryInfo(zipReportsExportPath);

                foreach (DirectoryInfo innerDir in zipReportsExportDirectoryInfo.GetDirectories())
                {
                    innerDir.Delete(true);
                }
            }
        }

        private static void ExportExcelFileData(SupermarketsEntities1 mssqlSupermarketContext, DateTime currentDate, string currentFile, Dictionary<string, Supermarket> supermarketsInTheDB)
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + currentFile + ";Extended Properties=Excel 12.0;";
            OleDbConnection excelConnection = new OleDbConnection(connectionString);

            excelConnection.Open();
            using (excelConnection)
            {
                OleDbCommand getExcelSheetData = new OleDbCommand(
                    "SELECT * " +
                    "FROM [Sales$]", excelConnection);

                OleDbDataReader reader = getExcelSheetData.ExecuteReader();
                using (reader)
                {
                    bool headerRow = true;
                    Report newReport = null;
                    while (reader.Read())
                    {
                        var firstColumnValue = reader[0];
                        if (headerRow)
                        {
                            string supermarketNameFull = (string)firstColumnValue;
                            int indexFirstQuote = supermarketNameFull.IndexOf('“');
                            int indexSecondQuote = supermarketNameFull.IndexOf('”');
                            string supermarketName = supermarketNameFull.Substring(indexFirstQuote + 1, indexSecondQuote - indexFirstQuote - 1);
                            
                            Supermarket currentSupermarket;

                            if (supermarketsInTheDB.ContainsKey(supermarketName))
                            {
                                currentSupermarket = supermarketsInTheDB[supermarketName];
                            }
                            else
                            {
                                currentSupermarket = new Supermarket();
                                currentSupermarket.SupermarketName = supermarketName;
                                mssqlSupermarketContext.Supermarkets.Add(currentSupermarket);

                                supermarketsInTheDB[supermarketName] = currentSupermarket;
                            }
                            

                            newReport = new Report();
                            newReport.ReportDate = currentDate;

                            currentSupermarket.Reports.Add(newReport);

                            headerRow = false;
                        };

                        int productId;
                        if (int.TryParse((string)firstColumnValue, out productId))
                        {
                            ReportDetail newReportDetail = new ReportDetail();

                            string secondColumnValue = reader[1].ToString();
                            newReportDetail.Quantity = int.Parse(secondColumnValue);
                            string thirdColumnValue = reader[2].ToString();
                            newReportDetail.UnitPrice = decimal.Parse(thirdColumnValue);
                            newReport.ReportDetails.Add(newReportDetail);

                            MSSQLEntityModel.Product currentProduct = mssqlSupermarketContext.Products.Find(productId);
                            currentProduct.ReportDetails.Add(newReportDetail);
                        }
                    }
                }
            }
        }
    }
}

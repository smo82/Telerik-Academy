using MSSQLEntityModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDbModel;
using MongoDB.Driver;

namespace SupermarketManagement
{
    class ManagementMain
    {
        static void Main()
        {
            //DataTransfer.MySqlToMSSQLTransfer();

            //DataTransfer.ReadReportsToMSSQL();

            XMLSalesReport.importReportToXML();

            //SupermarketManagement.Reports.SalesToPdf();

            //SupermarketManagement.Reports.SalesToJson();

            //XMLSalesReport.ExportFromXml();

            //SupermarketManagement.Reports.VendorsTotalReport(DateTime.Now);
        }
    }
}

using CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Data
{
    public class SearchLogDAL
    {
        public static void WriteQueryInLog(string queryXml)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SearchLogContext>());
            SearchLogContext context = new SearchLogContext();

            SearchLog newLog = new SearchLog()
            {
                Date = DateTime.Now,
                QueryXml = queryXml
            };

            context.SearchLogs.Add(newLog);
            context.SaveChanges();
        }

    }
}

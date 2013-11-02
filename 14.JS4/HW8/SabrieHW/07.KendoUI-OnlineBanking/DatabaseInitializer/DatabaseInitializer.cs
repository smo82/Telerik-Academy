using OnlineBanking.Context;
using OnlineBanking.Context.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseInitializer
{
    public class DatabaseInitializer
    {
        static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<OnlineBankContext, Configuration>());

            using (var context = new OnlineBankContext())
            {
                context.Database.Initialize(true);
            }
        }
    }
}

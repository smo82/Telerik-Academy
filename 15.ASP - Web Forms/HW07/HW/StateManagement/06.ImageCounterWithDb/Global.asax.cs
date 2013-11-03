using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using ImageCounter.DataLayer;
using System.Data.Entity;
using ImageCounter.DataLayer.Migrations;

namespace _06.ImageCounterWithDb
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ImageCounterContext, Configuration>());
        }

    }
}
namespace OnlineBanking.Context.Migrations
{
    using OnlineBanking.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<OnlineBanking.Context.OnlineBankContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(OnlineBanking.Context.OnlineBankContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            User user = new User
            {
                Username = "Nakov",
                AuthCode = "****************************************",
                FullName = "Svetlin Nakov"
            };
            Account account = new Account
            {
                Balance = 20000,
                CreatedOn = DateTime.Now,
                ExpireDate = DateTime.Now.AddYears(5),
                Owner = user

            };
            
            user.Accounts.Add(account);
            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}

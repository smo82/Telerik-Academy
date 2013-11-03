namespace Exam.Data.Migrations
{
    using Exam.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (context.Tickets.Count() > 0)
            {
                return;
            }

            Random rand = new Random();
            Random randCommentNumber = new Random();
            ApplicationUser user = new ApplicationUser() { UserName = "TestUser" };

            context.Users.Add(user);
            context.SaveChanges();

            for (int i = 0; i < 10; i++)
            {
                Category category = new Category
                {
                    Name = "Category" + i,
                };

                for (int j = 0; j < 10; j++)
                {
                    Ticket ticket = new Ticket
                    {
                        Author = user,
                        Category = category,
                        Description = "Ticket description" + rand.Next(1, 100),
                        Priority = (Priority)rand.Next(0, 3),
                        ScreenShotURL = "http://www.palantir.com/wp-content/static/techblog/2007/08/screenshots/thumbs/hh2-200.png",
                        Title = "The home page is not working!" + rand.Next(1, 1000)
                    };

                    int numberOfComments = randCommentNumber.Next(0, 20) + rand.Next(1, 4);
                    for (int k = 0; k < numberOfComments; k++)
                    {
                        Comment comment = new Comment
                        {
                            Content = "This is a major bug!" + i,
                            User = user
                        };

                        ticket.Comments.Add(comment);
                    }

                    category.Tickets.Add(ticket);
                }

                context.Categories.Add(category);
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}

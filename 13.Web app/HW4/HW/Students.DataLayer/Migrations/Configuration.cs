namespace Students.DataLayer.Migrations
{
    using Students.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Students.DataLayer.StudentsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
        
        protected override void Seed(Students.DataLayer.StudentsContext context)
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

            // Empty database
            List<Mark> marks = context.Marks.ToList();

            foreach (Mark mark in marks)
            {
                context.Marks.Remove(mark);
            }

            List<Student> students = context.Students.ToList();

            foreach (Student student in students)
            {
                context.Students.Remove(student);
            }

            List<School> schools = context.Schools.ToList();

            foreach (School school in schools)
            {
                context.Schools.Remove(school);
            }


            // Fill database
            School newSchool = new School(){
                Name = "School",
                Location = "Sofia"
            };

            for (int i = 0; i < 10; i++)
            {
                Student newStudent = new Student()
                {
                    FirstName = "Test",
                    LastName = i.ToString(),
                    Age = 15,
                    Grade = 7,
                    Marks = new List<Mark>()
                    {
                        new Mark(){
                            Subject = "math",
                            Value = i % 5 + 2
                        }
                    }
                };

                newSchool.Students.Add(newStudent);
            }

            context.Schools.Add(newSchool);
            context.SaveChanges();
        }
    }
}

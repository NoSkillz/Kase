namespace Kase.Migrations
{
    using Data;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KaseDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(KaseDbContext context)
        {
            context.Projects.AddOrUpdate(p => p.Id,
                new Project
                {
                    Id = 1,
                    Name = "Kase"
                },
                new Project
                {
                    Id = 2,
                    Name = "VisualStudio"
                });
            context.SaveChanges();

            context.Areas.AddOrUpdate(p => p.Id,
                new Area
                {
                    Id = 1,
                    Name = "Account management",
                    Project = context.Projects.Where(p => p.Name == "Kase").FirstOrDefault()
                },
                new Area
                {
                    Id = 2,
                    Name = "Test case management",
                    Project = context.Projects.Where(p => p.Name == "Kase").FirstOrDefault()
                },
                new Area
                {
                    Id = 3,
                    Name = "Testing area",
                    Project = context.Projects.Where(p => p.Name == "Visual Studio").FirstOrDefault()
                });
            context.SaveChanges();
            
            context.Features.AddOrUpdate(p => p.Id,
                new Feature
                {
                    Id = 1,
                    Name = "Account creation",
                    Area = context.Areas.Where(a => a.Name == "Account management").FirstOrDefault()
                },
                new Feature
                {
                    Id = 2,
                    Name = "Account modification",
                    Area = context.Areas.Where(a => a.Name == "Account management").FirstOrDefault()
                },
                new Feature
                {
                    Id = 3,
                    Name = "Test feature",
                    Area = context.Areas.Where(a => a.Name == "Testing area").FirstOrDefault()
                });
            context.SaveChanges();
        }
    }
}

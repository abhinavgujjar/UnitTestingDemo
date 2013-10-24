namespace Tax.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Tax.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<Tax.DataAccess.TaxDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Tax.DataAccess.TaxDbContext context)
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

            context.SlabRates.AddOrUpdate(
                p => new { p.StartRange, p.EndRange, p.IsFemale },

                new SlabRate()
                {
                    Id = 1,
                    IsFemale = true,
                    StartRange = 0.0M,
                    EndRange = 300000.0M,
                    Rate = 13.0M
                },
                new SlabRate()
                {
                    Id = 2,
                    IsFemale = true,
                    StartRange = 300000.0M,
                    EndRange = 500000.0M,
                    Rate = 15.0M
                },
                new SlabRate()
                {
                    Id = 3,
                    IsFemale = true,
                    StartRange = 500000.0M,
                    EndRange = 800000.0M,
                    Rate = 16.0M
                },
                new SlabRate()
                {
                    Id = 4,
                    IsFemale = true,
                    StartRange = 800000.0M,
                    EndRange = 1600000.0M,
                    Rate = 30.0M
                },
                new SlabRate()
                {
                    Id = 5,
                    IsFemale = true,
                    StartRange = 1600000.0M,
                    EndRange = 9000000.0M,
                    Rate = 35.0M
                },
                new SlabRate()
                {
                    Id = 6,
                    IsFemale = false,
                    StartRange = 0.0M,
                    EndRange = 300000.0M,
                    Rate = 13.0M
                },
                new SlabRate()
                {
                    Id = 10,
                    IsFemale = false,
                    StartRange = 300000.0M,
                    EndRange = 500000.0M,
                    Rate = 15.0M
                },
                new SlabRate()
                {
                    Id = 7,
                    IsFemale = false,
                    StartRange = 500000.0M,
                    EndRange = 800000.0M,
                    Rate = 16.0M
                },
                new SlabRate()
                {
                    Id = 8,
                    IsFemale = false,
                    StartRange = 800000.0M,
                    EndRange = 1600000.0M,
                    Rate = 30.0M
                },
                new SlabRate()
                {
                    Id = 9,
                    IsFemale = false,
                    StartRange = 1600000.0M,
                    EndRange = 9000000.0M,
                    Rate = 35.0M
                }

                );

            context.People.AddOrUpdate(
               p => p.Name,
               new Person(DateTime.Now.AddYears(-60))
               {
                   Name = "R K Narayan",
                   Income = 700000.0M,
                   isFemale = false
               },
               new Person(DateTime.Now.AddYears(-35))
               {
                   Name = "Anita Desai",
                   Income = 1200000.0M,
                   isFemale = true
               },
               new Person(DateTime.Now.AddYears(-60))
               {
                   Name = "Doesteyevsky",
                   Income = 600000.0M,
                   isFemale = false
               }
               );


        }
    }
}

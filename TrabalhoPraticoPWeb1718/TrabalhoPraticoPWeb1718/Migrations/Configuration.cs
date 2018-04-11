namespace TrabalhoPraticoPWeb1718.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TrabalhoPraticoPWeb1718.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TrabalhoPraticoPWeb1718.Models.ApplicationDbContext context)
        {

        }
    }
}

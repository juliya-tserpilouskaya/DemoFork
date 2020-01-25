namespace BulbaCourses.TextMaterials_Presentations.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BulbaCourses.TextMaterials_Presentations.Data.PresentationsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "BulbaCourses.TextMaterials_Presentations.Data.PresentationsContext";
        }

        protected override void Seed(BulbaCourses.TextMaterials_Presentations.Data.PresentationsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}

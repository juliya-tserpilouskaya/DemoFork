using BulbaCourses.PracticalMaterialsTests.Data.DbMapping.Join;
using BulbaCourses.PracticalMaterialsTests.Data.DbMapping.Users;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Questions;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Tests;
using BulbaCourses.PracticalMaterialsTests.Data.Models.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbaCourses.PracticalMaterialsTests.Data.Context
{
    public class PracticalMaterialsTestsContext : DbContext
    {
        public PracticalMaterialsTestsContext() : base("BookConnection")
        {
            Database.Log = s => Debug.WriteLine(s);
        }

        public DbSet<MUserDb> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Mapping_User());
        }
    }
}

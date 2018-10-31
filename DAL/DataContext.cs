using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using JSGridWebAPISample.Models;

namespace JSGridWebAPISample.DAL {

    public class DataContext: DbContext {

        /// <summary>
        /// It is always recommended to EXPLICITLY define the name of connectionstring as not defining connectionstring gives issues in VS 2015 and above
        /// </summary>
        public DataContext() : base("name=DefaultConnection")
        {

        }

        public DbSet<Client> Client { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

}
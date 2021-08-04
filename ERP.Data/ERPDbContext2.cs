using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ERP.Domain;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.DataAnnotations.Schema;
using ERP.Utility;


namespace ERP.Data
{
    public class ERPDbContext2: DbContext
    {
        #region Constructors and Destructors

        public ERPDbContext2()
            : base("SysConn2")
        {

        }

        //public ERPDbContext() : base("SysConn")
        //{

        //}

        //public ERPDbContext(string connectionName) : base(connectionName)
        //{

        //}

        #endregion

        #region Public properties

        public DbSet<TransactionLog> TransactionLogs { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<MasterFileLog> MasterFileLogs { get; set; }


        #endregion

       
        #region Methods
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ERPDbContext2>());

            //****if any one uncomment this, please dont commit****
            //Database.SetInitializer(new ERPDbContextInitializer2());

            Database.SetInitializer<ERPDbContext2>(null); 

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Properties<decimal>()
            //    .Configure(x => x.HasPrecision(18, ERP.Utility.Common.decimalPointsCurrency));

            //modelBuilder.Properties<decimal>()
            //    .Where(prop => prop.Name.Contains("Qty"))
            //    //.Configure(config => config.IsKey());
            //    .Configure(x => x.HasPrecision(18, ERP.Utility.Common.decimalPointsQty));

            //modelBuilder.Entity<Territory>()
            //            .HasRequired(t => t.Area)
            //            .WithMany(p => p.Terriotories)
            //            .HasForeignKey(t => t.AreaID)
            //            .WillCascadeOnDelete(false);

            //modelBuilder.Entity<InvSalesPerson>()
            //            .HasRequired(t => t.CommissionSchema)
            //            .WithMany(p => p.InvSalesmans)
            //            .HasForeignKey(t => t.CommissionSchemaID)
            //            .WillCascadeOnDelete(false);

            
          

        }
        #endregion


        public string GetConnection()
        {

            ERPDbContext2 context2 = new Data.ERPDbContext2();
            //System.Data.EntityClient.EntityConnection c = (System.Data.EntityClient.EntityConnection)context.Database.Connection;

            System.Data.Entity.Core.EntityClient.EntityConnection c = (System.Data.Entity.Core.EntityClient.EntityConnection)context2.Database.Connection;
            
            return c.StoreConnection.ConnectionString;
            
        }
      
    }
}

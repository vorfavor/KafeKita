using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace KafeKita.Model
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=KafeKitaContext")
        {
            Database.SetInitializer<DataContext>(null);
        }
        public DbSet<MstMember> mstMember { get; set; }
        public DbSet<MstItem> mstItem { get; set; }
        public DbSet<MstOfficer> mstOfficer { get; set; }
        public DbSet<MstSupplier> mstSupplier { get; set; }
        public DbSet<TrsBuying> trsBuying { get; set; }
        public DbSet<TrsBuyingDetail> trsBuyingDetail { get; set; }
        public DbSet<TrsLogin> trsLogin { get; set; }
        public DbSet<MstRole> mstRole  { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}

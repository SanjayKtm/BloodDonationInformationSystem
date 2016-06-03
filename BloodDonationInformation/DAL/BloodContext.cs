using BloodDonationInformation.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace BloodDonationInformation.DAL
{
    public class BloodContext : DbContext
    {
        public BloodContext()
            : base("BloodContext")
        {
        }

        public DbSet<Donor> Donors { get; set; }
        public DbSet<DonationDetail> DonationDetails { get; set; }
        public DbSet<BloodBank> BloodBanks { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}


using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentalCar.Models.BranchRental;

namespace RentalCar.Data
{
    public class RentalCarDataContext : IdentityDbContext<IdentityUser>
    {
        public RentalCarDataContext(DbContextOptions<RentalCarDataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<CategoriBranch> CategoriBranches { get; set;}
        public DbSet<DetailBranch> DetailBranches { get; set; }
        public DbSet<FotoBranch> FotoBranches { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Keranjang> Keranjang { get; set; }
    }
}

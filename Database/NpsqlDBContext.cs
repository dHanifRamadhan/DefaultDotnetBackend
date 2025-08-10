using DefaultDotnetBackend.Entities;
using Microsoft.EntityFrameworkCore;

namespace DefaultDotnetBackend.Database
{
    public class NpsqlDBContext : DbContext
    {
        public NpsqlDBContext(DbContextOptions<NpsqlDBContext> options) : base(options) { }

        // TODO Schema [MASTER]
        // DbSet<Countries> Countries { get; set; }
        // DbSet<Provinces> Provinces { get; set; }
        // DbSet<Cities> Cities { get; set; }
        // DbSet<Districts> Districts { get; set; }

        // DbSet<Accesses> Accesses { get; set; }
        // DbSet<Roles> Roles { get; set; }
        // DbSet<Users> Users { get; set; }
        // DbSet<UserMetas> UserMetas { get; set; }

        // DbSet<Settings> Settings { get; set; }
        // END Schema [MASTER]

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // builder.Entity<Provinces>()
            // .HasOne(x => x.Country)
            // .WithMany()
            // .HasForeignKey(x => x.CountryId)
            // .HasPrincipalKey(x => x.CountryId);

            // builder.Entity<Cities>()
            // .HasOne(x => x.Province)
            // .WithMany()
            // .HasForeignKey(x => x.ProvinceId)
            // .HasPrincipalKey(x => x.ProvinceId);

            // builder.Entity<Districts>()
            // .HasOne(x => x.City)
            // .WithMany()
            // .HasForeignKey(x => x.CityId)
            // .HasPrincipalKey(x => x.CityId);

            // builder.Entity<Roles>()
            // .HasMany(x => x.Accesses)
            // .WithOne(x => x.Role)
            // .HasForeignKey(x => x.RoleId);

            // builder.Entity<Users>()
            // .HasOne(x => x.Role)
            // .WithMany()
            // .HasForeignKey(x => x.RoleId)
            // .HasPrincipalKey(x => x.RoleId);
        } 
    }
}
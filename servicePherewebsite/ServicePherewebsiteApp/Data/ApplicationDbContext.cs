using Microsoft.EntityFrameworkCore;
using ServicePherewebsiteApp.Models;

namespace ServicePherewebsiteApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        // basic configuration
       

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options): base(options) 
        {
            // constructor
            // 

        }

        public DbSet<ServiceCategory> Service_Categories { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServiceCategory>().HasData(
                  new ServiceCategory { CategoryId = 1, Name = "Beauty & Personal Care", Description = "Services related to personal grooming and beauty, such as hair styling, manicures, pedicures, and makeup services.", CreatedAt =DateTime.Parse("2024-10-01 14:30:00") },
                  new ServiceCategory { CategoryId = 2, Name = "Plumbing", Description = "Services for electrical installations, repairs, and maintenance, such as fixing electrical faults, installing new wiring, and setting up lighting systems.", CreatedAt = DateTime.Parse("2024-10-01 14:30:00") },
                  new ServiceCategory { CategoryId = 3, Name = "Health & Fitness", Description = "Services related to health and wellness, including personal training, yoga instruction, physiotherapy, nutrition advice, and wellness coaching.", CreatedAt = DateTime.Parse("2024-10-01 14:30:00") },
                  new ServiceCategory { CategoryId = 4, Name = "Construction & Renovation", Description = "Includes building, remodeling, and renovation services for homes and commercial properties, covering carpentry, masonry, painting, and flooring.",CreatedAt= DateTime.Parse("2024-10-01 14:30:00") }


                  );
        }

    }
}

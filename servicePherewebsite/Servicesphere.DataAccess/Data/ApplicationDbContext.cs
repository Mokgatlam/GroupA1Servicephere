using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ServiceSphere.Models;



namespace Servicesphere.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        // basic configuration


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            // constructor
            // 

        }

        public DbSet<ServiceCategory> Service_Categories { get; set; }
        public DbSet<ServiceProduct> Service_Products { get; set; }
        public DbSet<ApplicationUser>ApplicationUsers{ get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ServiceCategory>().HasData(
                  new ServiceCategory { CategoryId = 1, Name = "Beauty & Personal Care", Description = "personal grooming and beauty,hair styling, manicures, pedicures, and makeup services.", CreatedAt = DateTime.Parse("2024-10-01 14:30:00") },
                  new ServiceCategory { CategoryId = 2, Name = "Electrical", Description = "Services for electrical installations, repairs, and maintenance, such as fixing electrical faults, installing new wiring, and setting up lighting systems.", CreatedAt = DateTime.Parse("2024-10-01 14:30:00") },
                  new ServiceCategory { CategoryId = 3, Name = "Health & Fitness", Description = "Services related to health and wellness, including personal training, yoga instruction, physiotherapy, nutrition advice, and wellness coaching.", CreatedAt = DateTime.Parse("2024-10-01 14:30:00") },
                  new ServiceCategory { CategoryId = 4, Name = "Construction & Renovation", Description = "Includes building, remodeling, and renovation services for homes and commercial properties, covering carpentry, masonry, painting, and flooring.", CreatedAt = DateTime.Parse("2024-10-01 14:30:00") }


                  );

                modelBuilder.Entity<ServiceProduct>().HasData(

                     new ServiceProduct
                            {
                                  SProductId = 1,
                                     Name = "Child Hair Plaiting",
                                         Description = "Professional plaiting services for children, perfect for school and special occasions.",
                                     Price = 150.00,
                    CategoryId = 1, // Assuming a category with Id 1 exists
                    CreatedAt = DateTime.Parse("2024-10-01 14:30:00"),
                    UpdatedAt = DateTime.Parse("2024-10-01 14:30:00"),
                    IsActive = true,
                    Location = "Bloemfontein",
                    IsVerified = true,
                    ImageUrls = "url1.jpg,url2.jpg,url3.jpg"
                        },

                 new ServiceProduct
                 {
                     SProductId = 2,
                     Name = "Electrical Repairs",
                     Description = "Expert electrical repairs and installations.",
                     Price = 800.00,
                     CategoryId = 3, // Assuming a category with Id 3 exists
                     CreatedAt = DateTime.Parse("2024-10-01 14:30:00"),
                     UpdatedAt = DateTime.Parse("2024-10-01 14:30:00"),
                     IsActive = true,
                     Location = "Bloemfontein",
                     IsVerified = false,
                     ImageUrls = "electric1.jpg,electric2.jpg"
                 },

                  new ServiceProduct
                  {
                      SProductId = 3,
                      Name = "Facial Treatment",
                      Description = "Relaxing and rejuvenating facial treatment with natural products.",
                      Price = 450.00,
                      CategoryId = 1, // Assuming a category for beauty services
                      CreatedAt = DateTime.Parse("2024-10-01 14:30:00"),
                      UpdatedAt = DateTime.Parse("2024-10-01 14:30:00"),
                      IsActive = true,
                      Location = "Bloemfontein",
                      IsVerified = false,
                      ImageUrls = "facial1.jpg,facial2.jpg"
                  }


                );

        
        
        }

    }

}


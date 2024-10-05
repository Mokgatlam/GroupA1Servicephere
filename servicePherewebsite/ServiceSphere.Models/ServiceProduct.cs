using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ServiceSphere.Models
{
    public class ServiceProduct
    {

        [Key]
        public int SProductId { get; set; }
        [Required(ErrorMessage = "Service Name is required.")]
        [MaxLength(50, ErrorMessage = "Service Name cannot be longer than 50 characters.")]
        [DisplayName("Service Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Service Description is required.")]
        [MaxLength(300, ErrorMessage = "The Service Description cannot be longer than 300 characters.")]
        [DisplayName(" Service Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.0,10000, ErrorMessage = "Price must be a positive value.")]
        [DisplayName("Price in Rands")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Choose a category is required.")]
        [DisplayName("Service Category")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public virtual ServiceCategory Category { get; set; }
        
        


        [DisplayName("Created At")]
        public DateTime CreatedAt { get; set; }

        [DisplayName("Updated At")]
        public DateTime? UpdatedAt { get; set; }

        [DisplayName("Is Active")]
        public bool IsActive { get; set; } = true;

        [DisplayName("Location")]
        [MaxLength(200, ErrorMessage = "Location cannot be longer than 200 characters.")]
        public string Location { get; set; }

        [DisplayName("Is Verified")]
        public bool IsVerified { get; set; } = false; // Default to false until verification

        [DisplayName("Images")]
        [ValidateNever]
        public string ImageUrls { get; set; } // This could store a comma-separated list of image URLs



        // Constructor to set default values
        public ServiceProduct()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

       

        // Custom method to deactivate product
        public void DeactivateProduct()
        {
            this.IsActive = false;
            this.UpdatedAt = DateTime.Now;
        }

        public void VerifyServiceProduct()
        {
            this.IsVerified = true;
        }

    }
}

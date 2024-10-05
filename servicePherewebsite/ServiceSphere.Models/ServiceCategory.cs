using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ServiceSphere.Models
{
    public class ServiceCategory
    {
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Category Name is required.")]
        [MaxLength(50, ErrorMessage = "Category Name cannot be longer than 50 characters.")]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Category Description is required.")]
        [MaxLength(500, ErrorMessage = "Category Description cannot be longer than 500 characters.")]
        [DisplayName("Category Description")]
        public string Description { get; set; }

        [DisplayName("Created At")]
        [CustomValidation(typeof(ServiceCategory), nameof(ValidateCreatedAt))]
        public DateTime CreatedAt { get; set; }

        // Constructor to set default value
        public ServiceCategory() => CreatedAt = DateTime.Now; // Default to current date and time

        // Custom validation method
        public static ValidationResult ValidateCreatedAt(DateTime createdAt, ValidationContext context)
        {
            if (createdAt > DateTime.Now)
            {
                return new ValidationResult("Created At cannot be set to a future date.");
            }
            return ValidationResult.Success;
        }

    }
}

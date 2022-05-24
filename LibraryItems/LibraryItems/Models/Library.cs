using System.ComponentModel.DataAnnotations;

namespace LibraryItems.Models
{
    public class Library
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Library Name is required")]
        [MaxLength(64, ErrorMessage = "Length of name cannot be greater than 64 characters")]
        [MinLength(2, ErrorMessage = "Length of name cannot be less than 2 characters")]
        public string? LibraryName { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MaxLength(64, ErrorMessage = "Length of description cannot be greater than 64 characters")]
        [MinLength(2, ErrorMessage = "Length of description cannot be less than 2 characters")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public string? Location { get; set; }



        //[Required(ErrorMessage = "Length of booking is required")]
        //public int? LengthOfBooking { get; set; }
    }
}

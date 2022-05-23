using System.ComponentModel.DataAnnotations;

namespace LibraryItems.Models
{
    public class LibraryItem
    {
        //what do i want info do i need for my db?

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(64, ErrorMessage = "Length of name cannot be greater than 64 characters")]
        [MinLength(2, ErrorMessage = "Length of name cannot be less than 2 characters")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MaxLength(64, ErrorMessage = "Length of description cannot be greater than 64 characters")]
        [MinLength(2, ErrorMessage = "Length of description cannot be less than 2 characters")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public string? Location { get; set; }



        /* is email and length of booking required if the are adding a lib item tho? */

        [Required(ErrorMessage = "Length of booking is required")]
        public int? LengthOfBooking { get; set; }

        //[Required(ErrorMessage = "Email is required")]
        //[MaxLength(64, ErrorMessage = "Length of email cannot be greater than 64 characters")]
        //[MinLength(2, ErrorMessage = "Length of email cannot be less than 2 characters")]
        //public string? Email { get; set; }






    }
}

using System.ComponentModel.DataAnnotations;

namespace Zaliczenie.Model
{
    public class Kolekcje
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter Title name" )]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Please enter Title name min 5 characters and maximum 60 characters ")]
        public string Title { get; set; }
        [Display(Name ="Author Name")]
        [Required(ErrorMessage = "Please enter Author name")]
        public string Authorname { get; set; }
        [Display(Name = "Release date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [RegularExpression(@"^(10|[1-9])$", ErrorMessage = "Rating must be between 1 to 10")]
        [Required(ErrorMessage = "Please enter Book Rating")]
        public string Rating { get; set; }

    }
}

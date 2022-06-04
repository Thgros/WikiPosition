using System.ComponentModel.DataAnnotations;

namespace WikiPosition.Pages.Models
{
    public class WikipediaQueryInputModel
    {
        [Required]
        [Range(-90, 90, ErrorMessage = "Input is not a valid latitude value")]
        public double Latitude { get; set; }

        [Required]
        [Range(-180, 180, ErrorMessage = "Input is not a valid longitude value")]
        public double Longitude { get; set; }
    }
}
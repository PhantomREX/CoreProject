using System.ComponentModel.DataAnnotations;

namespace CoreProject.Data.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        [Required(ErrorMessage = "Not Empty")]
        [StringLength(30, ErrorMessage = "You must enter at least four letters and max 30 characters", MinimumLength = 3)]

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public int Stock { get; set; }
        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }


    }
}

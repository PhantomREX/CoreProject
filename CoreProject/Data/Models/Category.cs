using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreProject.Data.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "Not Empty")]
        [StringLength(11, ErrorMessage = "You must enter at least four letters and max 11 characters", MinimumLength = 3)]
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public bool IsApprovedStatu { get; set; }
        public List<Item> Items { get; set; }
    }
}



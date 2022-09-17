﻿using Microsoft.AspNetCore.Http;

namespace CoreProject.Data.Models
{
    public class AddItem
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public IFormFile ImageURL { get; set; }
        public int Stock { get; set; }
        public int CategoryID { get; set; }

    }
}

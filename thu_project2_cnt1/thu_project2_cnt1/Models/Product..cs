﻿
namespace thu_project2_cnt1.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
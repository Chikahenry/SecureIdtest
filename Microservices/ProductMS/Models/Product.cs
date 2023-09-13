﻿namespace ProductMS.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int MerchantId { get; set; } 
        public bool IsActive { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}

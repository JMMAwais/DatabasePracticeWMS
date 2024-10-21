namespace DatabasePracticeWMS.Models
{
    public class AllItemDetails
    {
        public Guid RowGuid { get; set; } 
        public string? ImageUrl { get; set; } 
        public string? ItemNameEnglish { get; set; }
        public string? ItemNameArabic { get; set; }
        public long? SKU { get; set; }
        public bool Expirable { get; set; } 
        public int? ExpiryDays { get; set; } 
        public int? ThresholdPoint { get; set; } 
        public string? Lenght { get; set; } 
        public decimal? Width { get; set; } 
        public decimal? Height { get; set; } 
        public string? UnitOfDimension { get; set; } 
        public string? Weight { get; set; } 
        public string? UnitOfWeight { get; set; } 
        public string? DescriptionEnglish { get; set; } 
        public string? DescriptionArabic { get; set; } 
        public string? Name { get; set; } 
        public int? InhandQuantity { get; set; }
        public int? DamageQuantity { get; set; }
        public bool ISLIFO { get; set; }
    }
}

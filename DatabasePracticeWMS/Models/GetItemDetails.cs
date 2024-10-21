namespace DatabasePracticeWMS.Models
{
    public class GetItemDetails
    {
        public Guid? RowGUID { get; set; }
        public string? ImageUrl { get; set; }
        public string? ItemNameEnglish { get; set; }
        public string? SKU { get; set; }
        public string? Name { get; set; }
        public int? Inventry { get; set; } 
        public decimal? Capacity { get; set; } 
        public string? Lenght { get; set; } 
        public string? Width { get; set; } 
        public decimal? Height { get; set; } 
        public bool? Expirable { get; set; }
        public string? UnitOfDimension { get; set; }
    }
}

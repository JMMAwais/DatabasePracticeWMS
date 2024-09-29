namespace DatabasePracticeWMS.Models
{
    public class GetItemDetails
    {
        public string? ImageUrl { get; set; }
        public string? ItemNameEnglish { get; set; }
        public string? SKU { get; set; }
        public string? MerchantName { get; set; }
        public int? Inventry { get; set; } 
        public decimal? Capacity { get; set; } 
        public decimal? Length { get; set; } 
        public decimal? Width { get; set; } 
        public decimal? Height { get; set; } 
        public bool? Expirable { get; set; }
    }
}

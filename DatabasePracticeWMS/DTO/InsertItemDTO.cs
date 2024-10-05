using System.ComponentModel.DataAnnotations;

namespace DatabasePracticeWMS.DTO
{
    public class InsertItemDTO
    {
        public long Id { get; set; }
        public string? ImageUrl { get; set; }
        public string? ItemNameEnglish { get; set; }
        public string? ItemNameArabic { get; set; }
        public bool? Expirable { get; set; }
        public long? MerchantId { get; set; }
        public long? SKU { get; set; }
        public int? Capacity { get; set; }
        public decimal? ThresholdPoint { get; set; }
        public long? ExpiryDays { get; set; }
        public string? Lenght { get; set; }
        public string? Width { get; set; }
        public string? Height { get; set; }
        public decimal? Weight { get; set; }
        public string? UnitOfDimension { get; set; }
        public string? UnitOfWeight { get; set; }
        public byte? ISLIFO { get; set; }
        public string? DescriptionEnglish { get; set; }
        public string? DescriptionArabic { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}

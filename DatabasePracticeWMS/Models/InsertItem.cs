using System.ComponentModel.DataAnnotations;

namespace DatabasePracticeWMS.Models
{
    public class InsertItem
    {

      
        [Required]
        public IFormFile? ImageUrl { get; set; }

        [Required(ErrorMessage = "This Field is required!")]
        public string? ItemNameEnglish { get; set; }
        public string? ItemNameArabic { get; set; }
        public bool? Expirable { get; set; }
        public long? MerchantId { get; set; }

        [Required(ErrorMessage = "This Field is required!")]
        public long? SKU { get; set; }

        [Required(ErrorMessage = "This Field is required!")]
        public int? Capacity { get; set; }

        [Required(ErrorMessage = "This Field is required!")]
        public decimal? ThresholdPoint { get; set; }
        public long? ExpiryDays { get; set; }

        [Required(ErrorMessage = "This Field is required!")]
        public string? Lenght { get; set; }

        [Required(ErrorMessage = "This Field is required!")]
        public string? Width { get; set; }

        [Required(ErrorMessage = "This Field is required!")]
        public string? Height { get; set; }

        [Required(ErrorMessage = "This Field is required!")]
        public decimal? Weight { get; set; }

        [Required(ErrorMessage = "This Field is required!")]
        public string? UnitOfDimension { get; set; }

        [Required(ErrorMessage = "This Field is required!")]
        public string? UnitOfWeight { get; set; }
        public byte? ISLIFO { get; set; }

        [Required(ErrorMessage = "This Field is required!")]
        public string? DescriptionEnglish { get; set; }
        public string? DescriptionArabic { get; set; }
       // public DateTime? CreatedDate { get; set; }
    }
}

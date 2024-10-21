using System.Reflection.Metadata.Ecma335;

namespace DatabasePracticeWMS.Models.Storage
{
    public class StorageDetails
    {
        public long? Id { get; set; }
        public Guid? RowGuid { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public long? WarhouseId { get; set; }
        public string? Volume { get; set; }
        public decimal? Weight { get; set; }
        public string? NameArabic { get; set; }
        public int? Length { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public string? UnitofWeight { get; set; }
        public string? UnitofDimension { get; set; }
    }
}

namespace DatabasePracticeWMS.Models.Storage
{
    public class StockLocation
    {
        public int? Id { get; set; }
        public string? StorageLocationId { get; set; }
        public string? Prefix { get; set; }
        public long? MerchantId  { get; set; }
        public long? OccupiedSpace { get; set; }
    }
}

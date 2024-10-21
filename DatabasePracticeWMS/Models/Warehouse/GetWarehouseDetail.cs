namespace DatabasePracticeWMS.Models.Warehouse
{
    public class GetWarehouseDetail
    {
        public long Id { get; set; }
        public Guid? RowGuid { get; set; }
        public string? Name { get; set; }
        public string? CityName { get; set; }
        public long? CityId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}

namespace DatabasePracticeWMS.Models.Warehouse
{
    public class EditWarehouse
    {
        public long? Id { get; set; }
        public Guid? RowGuid { get; set; }
        public string? Name { get; set; }
        public long? CityId { get; set; }
        public string? CityName { get; set; }
    }
}

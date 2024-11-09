using DatabasePracticeWMS.Models.Storage;

namespace DatabasePracticeWMS.Repository
{
    public interface IStorageRepository
    {
        Task<IEnumerable<StorageDetails>> StorageDetails();
        Task<IEnumerable<StockLocation>> GetStockLocations(int Id);
    }
}

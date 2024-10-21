using DatabasePracticeWMS.Models.Storage;

namespace DatabasePracticeWMS.Repository
{
    public interface IStorageRepository
    {
        Task<IEnumerable<StorageDetails>> StorageDetails();
    }
}

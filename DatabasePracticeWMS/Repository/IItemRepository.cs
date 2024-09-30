using DatabasePracticeWMS.Models;

namespace DatabasePracticeWMS.Repository
{
    public interface IItemRepository
    {
        Task<IEnumerable<GetItemDetails>> GetItemDetails();
    }
}

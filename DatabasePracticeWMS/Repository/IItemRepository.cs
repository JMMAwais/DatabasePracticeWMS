using DatabasePracticeWMS.DTO;
using DatabasePracticeWMS.Models;

namespace DatabasePracticeWMS.Repository
{
    public interface IItemRepository
    {
        Task<IEnumerable<GetItemDetails>> GetItemDetails();
        Task InsertItem(InsertItemDTO item);
        Task<IEnumerable<Merchant>> GetMerchant();
        Task<IEnumerable<EditItemDTO>> GetItemBySKU(long sku);
        Task UpdateItem(InsertItemDTO model);
    }
}

using DatabasePracticeWMS.DTO;
using DatabasePracticeWMS.Filters;
using DatabasePracticeWMS.Models;
using DatabasePracticeWMS.Models.Storage;

namespace DatabasePracticeWMS.Repository
{
    public interface IItemRepository
    {
        Task<IEnumerable<GetItemDetails>> GetItemDetails();
        Task InsertItem(InsertItemDTO item);
        Task<IEnumerable<Merchant>> GetMerchant();
        Task<IEnumerable<EditItemDTO>> GetItemBySKU(long sku);
        Task UpdateItem(InsertItemDTO model);
        Task<AllItemDetails> GetAllItemDetails(Guid rowGuid);
        Task DeleteItemBySKU(long sku);
        Task<IEnumerable<StockLocationFormula>> GetItemByMechantId(long Id);
    }
}

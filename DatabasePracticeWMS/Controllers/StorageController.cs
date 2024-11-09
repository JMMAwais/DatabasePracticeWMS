using DatabasePracticeWMS.Models.Storage;
using DatabasePracticeWMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DatabasePracticeWMS.Controllers
{
    public class StorageController : Controller
    {
        private readonly IStorageRepository _storageRepository;
        private readonly IItemRepository _itemRepository;
        public StorageController(IStorageRepository storageRepository, IItemRepository itemRepository)
        {
            _storageRepository = storageRepository;
            _itemRepository = itemRepository;
        }
        public async Task<IActionResult> StorageIndex()
        {
           var storage =await _storageRepository.StorageDetails();
            return View(storage);
        }

        public async Task<IActionResult> StockLocation( int Id)
        {
            var stloc = await _storageRepository.GetStockLocations(Id);
            var merchantId = stloc.First().MerchantId;
            var result = await _itemRepository.GetItemByMechantId(Id);
            var quantity = result.FirstOrDefault().InhandQuantity;
            var capacity = result.FirstOrDefault().Capacity;
            var storage = await _storageRepository.StorageDetails();
            var re = storage.First(x => x.Id == Id);
            var total = capacity * quantity / 5;
            stloc.First().OccupiedSpace = total;
            StockLocationVM stl = new StockLocationVM
            {
                StorageDetails=re,
                StockLocations=stloc.ToList()
            };           
            return View(stl);          
        }

        public async Task<IActionResult> GetStorageLocation()
        {
            //var storagelocation = await _storageRepository.
            return View();
        }

    }
}

using DatabasePracticeWMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DatabasePracticeWMS.Controllers
{
    public class InventryController : Controller
    {
        private readonly IItemRepository _itemRepository;
        public InventryController(IItemRepository itemRepository)
        {
                _itemRepository = itemRepository;
        }
        public async Task<IActionResult> Index()
        {
            var items =await _itemRepository.GetItemDetails();
            return View(items);
        }
    }
}

using DatabasePracticeWMS.Models;
using DatabasePracticeWMS.Models.Warehouse;
using DatabasePracticeWMS.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DatabasePracticeWMS.Controllers
{
    public class WarehouseController : Controller
    {
        private readonly IWarehouseRepository _warehouseRepository;
        public WarehouseController(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _warehouseRepository.GetCities();


            ViewBag.Merchant = list;

            var warehouse = await _warehouseRepository.GetWarehouseDetails();
            return View(warehouse);
        }

        [HttpPost]
        [Route("AddWarehouse")]
        [Route("Warehouse/AddWarehouse")]
        public async Task<IActionResult> AddWarehouse(AddWarehouse model)
        {
            await _warehouseRepository.AddWarehouseWithCity(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Route("Warehouse/Edit/{Guid}")]
        public async Task<IActionResult> Edit(Guid Guid, AddWarehouse model)
        {
            var warehouse = await _warehouseRepository.GetWarehouseByGuid(Guid);
            warehouse.Name = model.Name;
            warehouse.CityId = model.CityId;

            await _warehouseRepository.UpdateWarehouse(warehouse);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteWarehouse(int Id)
        {
          await  _warehouseRepository.DeleteWarehouse(Id);  
            return RedirectToAction(nameof(Index)); 
        }
    }
}

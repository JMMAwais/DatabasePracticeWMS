using DatabasePracticeWMS.DTO;
using DatabasePracticeWMS.Models;
using DatabasePracticeWMS.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DatabasePracticeWMS.Controllers
{
    public class InventryController : Controller
    {
        private readonly IItemRepository _itemRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public InventryController(IItemRepository itemRepository, IWebHostEnvironment webHostEnvironment)
        {
            _itemRepository = itemRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var items = await _itemRepository.GetItemDetails();
            return View(items);
        }



        [HttpGet]
        public async Task<IActionResult> InsertItem()
        {

            var list = await _itemRepository.GetMerchant();
            ViewBag.Merchant = list;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> InsertItems(InsertItem model)
        {


            var picture = UploadedFile(model);
            var item = new InsertItemDTO
            {
                ImageUrl = picture,
                ItemNameEnglish = model.ItemNameEnglish,
                ItemNameArabic = model.ItemNameArabic,
                Expirable = model.Expirable,
                MerchantId = model.MerchantId,
                SKU = model.SKU,
                Capacity = model.Capacity,
                ThresholdPoint = model.ThresholdPoint,
                ExpiryDays = model.ExpiryDays,
                Lenght = model.Lenght,
                Width = model.Width,
                Height = model.Height,
                Weight = model.Weight,
                UnitOfDimension = model.UnitOfDimension,
                UnitOfWeight = model.UnitOfWeight,
                ISLIFO = model.ISLIFO,
                DescriptionEnglish = model.DescriptionEnglish,
                DescriptionArabic = model?.DescriptionArabic
            };



            await _itemRepository.InsertItem(item);
            return RedirectToAction("Index");
        }

        private string UploadedFile(InsertItem model)
        {
            string ImageName = null;
            if (model.ImageUrl != null)
            {

                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                ImageName = Guid.NewGuid().ToString() + "_" + model.ImageUrl.FileName;
                string filePath = Path.Combine(uploadsFolder, ImageName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImageUrl.CopyTo(fileStream);
                }
            }
            return ImageName;
        }

  
        [HttpGet]
        [Route("Inventry/EditItem/{SKU}")]

        public async Task<IActionResult> EditItem( long SKU)
        {
            var list = await _itemRepository.GetMerchant();
            ViewBag.Merchant = list;

            var updateItem =await _itemRepository.GetItemBySKU(SKU);
            var model = updateItem.FirstOrDefault();
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> EditItem(InsertItem model)
            {
            var picture = UploadedFile(model);
            var sku =(long)model.SKU;
            var Item = await _itemRepository.GetItemBySKU(sku);
            var picUrl = Item.FirstOrDefault().ImageUrl;
            var item = new InsertItemDTO
            {
                ImageUrl = picture??picUrl,
                ItemNameEnglish = model.ItemNameEnglish,
                ItemNameArabic = model.ItemNameArabic,
                Expirable = model.Expirable,
                MerchantId = model.MerchantId,
                SKU = model.SKU,
                Capacity = model.Capacity,
                ThresholdPoint = model.ThresholdPoint,
                ExpiryDays = model.ExpiryDays,
                Lenght = model.Lenght,
                Width = model.Width,
                Height = model.Height,
                Weight = model.Weight,
                UnitOfDimension = model.UnitOfDimension,
                UnitOfWeight = model.UnitOfWeight,
                ISLIFO = model.ISLIFO,
                DescriptionEnglish = model.DescriptionEnglish,
                DescriptionArabic = model?.DescriptionArabic
            };
            await _itemRepository.UpdateItem(item).ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        [Route("Inventry/ItemDetail/{RowGuid}")]
        public async Task<IActionResult> ItemDetail(Guid RowGuid)
        {
            var allItems = await _itemRepository.GetAllItemDetails(RowGuid);
            return View(allItems);
        }

        
        [Route("Inventry/ItemDelete/{SKU}")]
        public async Task<IActionResult> ItemDelete(long SKU)
        {
            await _itemRepository.DeleteItemBySKU(SKU);
            return RedirectToAction(nameof(Index));
        }

    }
}

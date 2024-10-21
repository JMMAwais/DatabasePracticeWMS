using Microsoft.AspNetCore.Mvc;

namespace DatabasePracticeWMS.Controllers
{
    public class StorageController : Controller
    {

        public IActionResult StorageIndex()
        {
            return View();
        }
    }
}

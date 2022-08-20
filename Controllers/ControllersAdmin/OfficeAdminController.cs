using Microsoft.AspNetCore.Mvc;
using Room_Productivity.Models;
using Room_Productivity.Services;
using Room_Productivity.Services.Interfaces;

namespace Room_Productivity.Controllers.ControllersAdmin
{
    public class OfficeAdminController : Controller
    {
        private IOfficeService _service;

        public OfficeAdminController(IOfficeService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
        

        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetOffice()
        {
            try
            {
                var resp = await _service.GetOffice();
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        public ActionResult CreateOffice()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOffice(Oficce parametros)
        {
            try
            {
                var resp = await _service.CreateOffice(parametros);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);

            }
        }

    }
}

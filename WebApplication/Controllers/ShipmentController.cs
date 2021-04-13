using Microsoft.AspNetCore.Mvc;
using WebApplication.DTO;
using WebApplication.Service;

namespace WebApplication.Controllers
{
    public class ShipmentController : Controller
    {
        private ICalculatorService _calculatorService;

        public ShipmentController(ICalculatorService calculatorService)
        {
            this._calculatorService = calculatorService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Calculator()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculator(Shipment shipment)
        {
            var result = _calculatorService.GetFee(shipment);
            return Content(result.ToString());
        }
    }
}

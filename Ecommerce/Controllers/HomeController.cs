using Ecommerce.Models;
using Ecommerce.Services.Definicion;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductosInterface _productosInterface;

        public HomeController(ILogger<HomeController> logger, IProductosInterface productosInterface)
        {
            _logger = logger;
            _productosInterface = productosInterface;
            Inicializer();
        }

        private void Inicializer()
        {
            ViewBag.Index = "";
            ViewBag.Productos = "";
            ViewBag.Contacto = "";
            ViewBag.About = "";
        }
        public IActionResult Index()
        {
            ViewBag.Index = "active";
            return View(_productosInterface.ProductosPantallaPrincipal());
        }
        public IActionResult Productos()
        {
            ViewBag.Productos = "active";
            return View();

            //return View(_productosInterface.ProductosPantallaPrincipal());
        }
        public IActionResult Details(Guid Id)
        {
            var vistaProducto = _productosInterface.ProductoDetail(Id);



            return View(vistaProducto);
        }   
        public IActionResult About()
        {
            ViewBag.About = "active";
            return View();
        }
        public IActionResult Contacto()
        {
            ViewBag.Contacto = "active";
            return View();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

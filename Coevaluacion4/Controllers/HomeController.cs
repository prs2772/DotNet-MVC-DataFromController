using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Coevaluacion4.Models;

namespace Coevaluacion4.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult StoreAdd(int? id)
    {
        return View(Datos.ObtenProducto(id));
    }

    public IActionResult StoreSummary(int? idToRemove)
    {
        Datos.DeleteaProducto(idToRemove);
        return View(Datos.Productos());
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

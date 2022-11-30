using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Coevaluacion4.Models;
using System.Text;

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
    if (HttpMethods.IsPost(Request.Method))
    {
      StringBuilder valido = new StringBuilder();
      StringBuilder recuperado = new StringBuilder();//Almacena variables del formulario
      int idNw;
      string productoNw;
      float precioNw;

      //1) Id
      recuperado.Clear();
      recuperado.Append(Request.Form[$"idNuevo"].ToString());
      valido.Append(int.TryParse(recuperado.ToString(), out idNw) ? string.Empty : "!SLN!->La id debe ser un número");
      //2) Nombre
      recuperado.Clear();
      recuperado.Append(Request.Form[$"productoNuevo"].ToString());
      productoNw = recuperado.ToString();
      //3 Precio
      recuperado.Clear();
      recuperado.Append(Request.Form[$"precioNuevo"].ToString());
      valido.Append(float.TryParse(recuperado.ToString(), out precioNw) ? string.Empty : "!SLN!->El precio debe ser un número flotante");

      //4) Validamos que la ID no se repita
      if (valido.Length == 0)
      {
        foreach (ProductoViewModel producto in Datos.Productos())
        {
          if (producto.Id == idNw)
          {
            valido.Append("!SLN!->¡Ya existe un artículo con esa ID, no se pueden repetir!");
            break;
          }
        }
      }

      //Pasamos a devolver si fue válido y agregar; o si no lo es le avisamos las razones
      if (valido.Length == 0)
      {
        Datos.Productos().Add(new ProductoViewModel(idNw, productoNw, "", precioNw, 0f));
      }
      else
      {
        valido.Insert(0, "No se ha podido agregar el producto, los datos ingresados no son válidos:!SLN!");
        ViewData["PostAdding"] = valido.ToString();
      }
      return View("StoreSummary", Datos.Productos());
    }
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

internal static class Datos
{
  public enum Operation
  {
    Add, Delete
  }
  private static List<ProductoViewModel> productos = new ProductoViewModel[]{
    new ProductoViewModel(1,"Cheetos", "Son de queso", 13, 8),
    new ProductoViewModel(3,"Doritos Incógnita", "Son una incógnita", 15, 9),
    new ProductoViewModel(5,"Sabritones", "Chicharrones grandes", 19, 11)
  }.ToList();

  public static List<ProductoViewModel> Productos()
  {
    return productos;
  }
  public static void DeleteaProducto(int? idToRemove)
  {
    productos.RemoveAll(presunto => presunto.Id == idToRemove);
  }
  public static ProductoViewModel? ObtenProducto(int? id)
  {
     return productos.Find(presunto => presunto.Id == id);
  }
}
using System.ComponentModel.DataAnnotations;
public class ProductoViewModel
{
  [Key]
  public int Id { get; set; }
  public string? Nombre { get; set; }
  public string? Descripcion { get; set; }
  public float Precio { get; set; }
  public float Envio { get; set; }

  public ProductoViewModel(int id, string? nombre, string? descripcion, float precio, float envio)
  {
    Id = id;
    Nombre = nombre;
    Descripcion = descripcion;
    Precio = precio;
    Envio = envio;
  }
}
namespace GasApp.Models;

// Datos de ejemplo para el Home. Más adelante se llenarán desde la API.
public class EstacionResumen
{
    public string Nombre { get; set; } = string.Empty;
    public string Direccion { get; set; } = string.Empty;
    public string Distancia { get; set; } = string.Empty;
    public string PrecioMagna { get; set; } = string.Empty;
    public string PrecioPremium { get; set; } = string.Empty;
    public string Calificacion { get; set; } = string.Empty;
}

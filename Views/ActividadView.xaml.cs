using GasApp.Models;

namespace GasApp.Views;

public partial class ActividadView : ContentPage
{
    public ActividadView()
    {
        InitializeComponent();
        CargarHistorial();
    }

    // TODO: reemplazar por la llamada a la API cuando esté conectada.
    private void CargarHistorial()
    {
        var estaciones = new[] { "Gasolinera Centro", "Servicio Las Flores", "Estación Norte" };
        var combustibles = new[] { "Magna", "Premium", "Diésel" };
        var hoy = DateTime.Now;

        var registros = Enumerable.Range(1, 20).Select(i => new HistorialPuntos
        {
            Id = i,
            Iduser = 1,
            IdComercio = (i % 3) + 1,
            Detalle = $"{estaciones[i % 3]} · {20 + i} L {combustibles[i % 3]}",
            Cantidad = (20 + i) * 3,
            FechaReg = hoy.AddDays(-i * 2).AddHours(-i),
            IduserReg = 1
        });

        HistorialCollection.ItemsSource = registros
            .OrderByDescending(r => r.FechaReg)
            .Take(15)
            .ToList();
    }
}

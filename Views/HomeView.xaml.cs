using GasApp.Models;

namespace GasApp.Views;

public partial class HomeView : ContentPage
{
    public HomeView()
    {
        InitializeComponent();
        CargarDatosDeEjemplo();
    }

    // TODO: reemplazar por datos de la API cuando esté conectada.
    private void CargarDatosDeEjemplo()
    {
        BindableLayout.SetItemsSource(EstacionesLayout, new List<EstacionResumen>
        {
            new() { Nombre = "Gasolinera Centro", Direccion = "Av. Juárez 120, Centro", Distancia = "0.8 km", PrecioMagna = "$23.49", PrecioPremium = "$25.89", Calificacion = "4.6" },
            new() { Nombre = "Servicio Las Flores", Direccion = "Blvd. Las Flores 455", Distancia = "1.5 km", PrecioMagna = "$23.29", PrecioPremium = "$25.69", Calificacion = "4.3" },
            new() { Nombre = "Estación Norte", Direccion = "Carretera Federal km 12", Distancia = "3.2 km", PrecioMagna = "$23.59", PrecioPremium = "$25.99", Calificacion = "4.8" },
        });

        BindableLayout.SetItemsSource(MovimientosLayout, new List<MovimientoPuntos>
        {
            new() { Estacion = "Gasolinera Centro", Fecha = "18 oct", Detalle = "40 L Magna", Puntos = "+120" },
            new() { Estacion = "Estación Norte", Fecha = "12 oct", Detalle = "35 L Premium", Puntos = "+210" },
            new() { Estacion = "Servicio Las Flores", Fecha = "5 oct", Detalle = "30 L Magna", Puntos = "+90" },
        });
    }

    private async void OnMostrarCodigoClicked(object? sender, EventArgs e)
        => await DisplayAlertAsync("Mi código", "Aquí se mostrará tu código QR para acumular puntos.", "OK");

    // Mapa es la segunda pestaña inferior del FlyoutItem "Home"
    private void OnMapaTapped(object? sender, TappedEventArgs e)
    {
        var item = Shell.Current?.CurrentItem;
        if (item is not null && item.Items.Count > 1)
            item.CurrentItem = item.Items[1];
    }

    private async void OnRecompensasTapped(object? sender, TappedEventArgs e)
        => await Navigation.PushAsync(new RecompensasView());

    private async void OnReviewsTapped(object? sender, TappedEventArgs e)
        => await Navigation.PushAsync(new ReviewsView());

    private async void OnAyudaTapped(object? sender, TappedEventArgs e)
        => await Navigation.PushAsync(new AyudaView());

    private async void OnVerHistorialTapped(object? sender, TappedEventArgs e)
    {        
        await Navigation.PushAsync(new ActividadView());
    }

    string nombreuser = "";
    protected override void OnAppearing()
    {
        nombreuser = Preferences.Default.Get("nombreuser", nombreuser);
        SaludoLabel.Text = "¡Hola, "+nombreuser+"! 👋";
    }


}

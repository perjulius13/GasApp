using GasApp.Models;
using GasApp.Servicios;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace GasApp.Views;

public partial class MapaView : ContentPage
{
	public MapaView()
	{
		InitializeComponent();

        
        
    }


    Pin marker = new Pin();
    List<ComercioClass> lista = new List<ComercioClass>();

    protected override async void OnAppearing()
    {
        getLocation();
        llenarmarcadores(); 
    }




    public async void getLocation()
    {

        var request = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(10));
        using var cts = new CancellationTokenSource();
        Location location = await Geolocation.Default.GetLocationAsync(request, cts.Token);

        if (location != null)
        {            
            map.MoveToRegion(MapSpan.FromCenterAndRadius(location, Distance.FromKilometers(0.3)));
            addmarker(location.Latitude, location.Longitude, "Ubicacion predeterminada");
            //TODO: ubicar las 10 gasolinerias mas cercanas al usuario             
        }

    }

    public void addmarker(double lat, double longi, string titulo)
    {
        marker = new Pin
        {
            Label = titulo,
            Type = PinType.Place,
            Location = new Location(lat, longi),
        };

        map.Pins.Add(marker);
    }


    public async void llenarmarcadores()
    {
        var servicio = new ApiService(); 
        lista = await servicio.ListarComercios();

        foreach (var item in lista)
        {
            addmarker(item.Latitud, item.Longitud, item.IdComer.ToString());
        }
    }




}
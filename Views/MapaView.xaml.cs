using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace GasApp.Views;

public partial class MapaView : ContentPage
{
	public MapaView()
	{
		InitializeComponent();

        getLocation();
        
    }




    Pin marker = new Pin();




    public async void getLocation()
    {

        var request = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(10));
        using var cts = new CancellationTokenSource();
        Location location = await Geolocation.Default.GetLocationAsync(request, cts.Token);

        if (location != null)
        {
            //txtlatitud.Text = location.Latitude.ToString();
            //txtlongitud.Text = location.Longitude.ToString();
            map.MoveToRegion(MapSpan.FromCenterAndRadius(location, Distance.FromKilometers(0.3)));
            addmarker(location.Latitude, location.Longitude, "Ubicacion predeterminada");

            
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








}
using GasApp.Models;

namespace GasApp.Views;

public partial class RecompensasView : ContentPage
{
    public RecompensasView()
    {
        InitializeComponent();
        CargarRecompensas();
    }

    // TODO: reemplazar por la llamada a la API cuando esté conectada.
    private void CargarRecompensas()
    {
        var inicio = DateTime.Today;
        var fin = DateTime.Today.AddMonths(2);

        RecompensasCollection.ItemsSource = new List<RecompensasClass>
        {
            new() { IdRecompensa = 1, Titulo = "Anticongelante 1 L", Detalle = "Anticongelante/refrigerante listo para usar.", CostoPuntos = 450, fechainicio = inicio, fechafin = fin, idcomercio = 1 },
            new() { IdRecompensa = 2, Titulo = "Aceite para motor 1 L", Detalle = "Aceite multigrado para motor a gasolina.", CostoPuntos = 600, fechainicio = inicio, fechafin = fin, idcomercio = 1 },
            new() { IdRecompensa = 3, Titulo = "Aditivo para gasolina", Detalle = "Limpia inyectores y mejora el rendimiento.", CostoPuntos = 350, fechainicio = inicio, fechafin = fin, idcomercio = 2 },
            new() { IdRecompensa = 4, Titulo = "Gorra", Detalle = "Gorra ajustable con logo de la estación.", CostoPuntos = 300, fechainicio = inicio, fechafin = fin, idcomercio = 2 },
            new() { IdRecompensa = 5, Titulo = "Playera", Detalle = "Playera de algodón, tallas CH a XG.", CostoPuntos = 500, fechainicio = inicio, fechafin = fin, idcomercio = 3 },
            new() { IdRecompensa = 6, Titulo = "Termo", Detalle = "Termo de acero inoxidable de 500 ml.", CostoPuntos = 800, fechainicio = inicio, fechafin = fin, idcomercio = 3 },
        };
    }

    private async void OnCanjearClicked(object? sender, EventArgs e)
    {
        if (sender is not Button { CommandParameter: RecompensasClass recompensa })
            return;

        bool confirmar = await DisplayAlertAsync(
            "Canjear recompensa",
            $"¿Canjear \"{recompensa.Titulo}\" por {recompensa.CostoPuntos} puntos?",
            "Canjear", "Cancelar");

        if (confirmar)
            await DisplayAlertAsync("Listo", "Canje simulado. Muestra tu código en la estación para recoger tu recompensa.", "OK");
    }
}

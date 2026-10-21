using System.Collections.ObjectModel;
using GasApp.Models;

namespace GasApp.Views;

public partial class ReviewsView : ContentPage
{
    // TODO: recibir la estación y el usuario reales cuando se conecte la API / login.
    private const int IdComercioActual = 1;
    private const int IdUsuarioActual = 99;

    private readonly ObservableCollection<ReviewsClass> _reviews = new();
    private readonly Label[] _estrellas;
    private int _calificacion;

    private static readonly string[] TextosCalificacion =
        { "", "Muy mala", "Mala", "Regular", "Buena", "Excelente" };

    public ReviewsView()
    {
        InitializeComponent();
        _estrellas = new[] { Estrella1, Estrella2, Estrella3, Estrella4, Estrella5 };
        ReviewsCollection.ItemsSource = _reviews;
        CargarReviewsDeEjemplo();
    }

    // TODO: reemplazar por la llamada a la API.
    private void CargarReviewsDeEjemplo()
    {
        var hoy = DateTime.Today;
        var ejemplos = new List<ReviewsClass>
        {
            new() { idReview = 1, idcomercio = IdComercioActual, IdUserReg = 12, estrellas = 5, fechareg = hoy.AddDays(-1),  Review = "Atención muy rápida y los baños limpios. Siempre cargo aquí." },
            new() { idReview = 2, idcomercio = IdComercioActual, IdUserReg = 7,  estrellas = 4, fechareg = hoy.AddDays(-3),  Review = "Buen servicio, aunque a veces hay fila en la tarde." },
            new() { idReview = 3, idcomercio = IdComercioActual, IdUserReg = 31, estrellas = 5, fechareg = hoy.AddDays(-6),  Review = "" },
            new() { idReview = 4, idcomercio = IdComercioActual, IdUserReg = 18, estrellas = 3, fechareg = hoy.AddDays(-10), Review = "Litros completos, pero la tienda tenía poco surtido." },
            new() { idReview = 5, idcomercio = IdComercioActual, IdUserReg = 4,  estrellas = 2, fechareg = hoy.AddDays(-15), Review = "Tardaron en atenderme y no aceptaban tarjeta ese día." },
            new() { idReview = 6, idcomercio = IdComercioActual, IdUserReg = 25, estrellas = 4, fechareg = hoy.AddDays(-21), Review = "" },
        };

        foreach (var r in ejemplos.OrderByDescending(r => r.fechareg))
            _reviews.Add(r);

        ActualizarResumen();
    }

    private void OnEstrellaTapped(object? sender, TappedEventArgs e)
    {
        if (e.Parameter is string texto && int.TryParse(texto, out var valor))
            SeleccionarCalificacion(valor);
    }

    private void SeleccionarCalificacion(int valor)
    {
        _calificacion = valor;
        for (int i = 0; i < _estrellas.Length; i++)
            _estrellas[i].Text = i < valor ? "★" : "☆";

        CalificacionTextoLabel.Text = valor == 0 ? "Toca las estrellas para calificar" : TextosCalificacion[valor];
        PublicarButton.IsEnabled = valor > 0;
    }

    private async void OnPublicarClicked(object? sender, EventArgs e)
    {
        if (_calificacion == 0)
            return;

        var nueva = new ReviewsClass
        {
            idReview = _reviews.Count == 0 ? 1 : _reviews.Max(r => r.idReview) + 1,
            idcomercio = IdComercioActual,
            IdUserReg = IdUsuarioActual,
            estrellas = _calificacion,
            Review = ReviewEditor.Text?.Trim() ?? string.Empty,
            fechareg = DateTime.Now
        };

        // TODO: enviar "nueva" a la API.
        _reviews.Insert(0, nueva);
        ActualizarResumen();

        ReviewEditor.Text = string.Empty;
        SeleccionarCalificacion(0);

        await DisplayAlertAsync("¡Gracias!", "Tu reseña fue publicada.", "OK");
    }

    private void ActualizarResumen()
    {
        var total = _reviews.Count;
        var promedio = total == 0 ? 0 : _reviews.Average(r => r.estrellas);

        PromedioLabel.Text = promedio.ToString("0.0");
        PromedioEstrellasLabel.Text = new Converters.EstrellasConverter()
            .Convert((float)promedio, typeof(string), null, System.Globalization.CultureInfo.CurrentCulture) as string;
        TotalReviewsLabel.Text = total == 1 ? "1 reseña" : $"{total} reseñas";
    }
}

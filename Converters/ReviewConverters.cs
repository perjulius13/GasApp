using System.Globalization;

namespace GasApp.Converters;

// Convierte la calificación (1 a 5) en texto de estrellas: 4 → "★★★★☆"
public class EstrellasConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var estrellas = value is float f ? (int)Math.Round(f) : 0;
        estrellas = Math.Clamp(estrellas, 0, 5);
        return new string('★', estrellas) + new string('☆', 5 - estrellas);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotImplementedException();
}

// true si el texto no está vacío (para ocultar reseñas sin comentario)
public class TextoNoVacioConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        => !string.IsNullOrWhiteSpace(value as string);

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotImplementedException();
}

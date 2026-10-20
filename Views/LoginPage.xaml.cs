namespace GasApp.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private void OnMostrarContrasenaTapped(object? sender, TappedEventArgs e)
    {
        ContrasenaEntry.IsPassword = !ContrasenaEntry.IsPassword;
        MostrarContrasenaLabel.Text = ContrasenaEntry.IsPassword ? "Mostrar" : "Ocultar";
    }

    private async void OnIngresarClicked(object? sender, EventArgs e)
    {
        ErrorBorder.IsVisible = false;

        //simular accion de login 
        App.Current.MainPage = new AppShell();


        //if (string.IsNullOrWhiteSpace(CorreoEntry.Text) || string.IsNullOrWhiteSpace(ContrasenaEntry.Text))
        //{
        //    ErrorLabel.Text = "Ingresa tu correo y tu contraseña.";
        //    ErrorBorder.IsVisible = true;
        //    return;
        //}

        // TODO: reemplazar por la llamada a la API cuando esté disponible.

    }

    private async void OnOlvideContrasenaTapped(object? sender, TappedEventArgs e)
        => await DisplayAlertAsync("GasApp", "Recuperación de contraseña pendiente.", "OK");

    private async void OnRegistrateTapped(object? sender, TappedEventArgs e)
        => await DisplayAlertAsync("GasApp", "Pantalla de registro pendiente.", "OK");

    private void SetCargando(bool cargando)
    {
        IngresarButton.Text = cargando ? string.Empty : "Ingresar";
        IngresarButton.IsEnabled = !cargando;
        CargandoIndicator.IsVisible = cargando;
        CargandoIndicator.IsRunning = cargando;
    }
}

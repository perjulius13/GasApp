using GasApp.Models;
using GasApp.Servicios;

namespace GasApp.Views;

public partial class LoginPage : ContentPage
{
    private const string ClaveUsuarioRecordado = "usuario_recordado";
    private readonly ApiService _api = new();


    UsuarioClass user = new UsuarioClass(); 

    public LoginPage()
    {
        InitializeComponent();

        // Si el usuario marcó "Recordarme", se precarga su nombre de usuario (nunca la contraseña).
        var recordado = Preferences.Default.Get(ClaveUsuarioRecordado, string.Empty);
        if (!string.IsNullOrEmpty(recordado))
        {
            UsuarioEntry.Text = recordado;
            RecordarmeCheck.IsChecked = true;
        }
    }

    private void OnMostrarContrasenaTapped(object? sender, TappedEventArgs e)
    {
        ContrasenaEntry.IsPassword = !ContrasenaEntry.IsPassword;
        MostrarContrasenaLabel.Text = ContrasenaEntry.IsPassword ? "Mostrar" : "Ocultar";
    }

    private void OnUsuarioCompleted(object? sender, EventArgs e) => ContrasenaEntry.Focus();

    private async void OnIngresarClicked(object? sender, EventArgs e)
    {
        if (!IngresarButton.IsEnabled)
            return; // ya hay un login en curso

        ErrorBorder.IsVisible = false;

        var username = UsuarioEntry.Text?.Trim();
        var contra = ContrasenaEntry.Text;

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrEmpty(contra))
        {
            MostrarError("Ingresa tu usuario y tu contraseña.");
            return;
        }

        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        {
            MostrarError("No hay conexión a internet. Revisa tu conexión e intenta de nuevo.");
            return;
        }

        SetCargando(true);
        bool loginCorrecto = false;
        try
        {
            user = await _api.Login(new UsuarioClass { Username = username, Contra = contra });
            if(user.Username == username && user.Contra == contra)
            {
                loginCorrecto = true;   
            }
        }
        finally
        {
            SetCargando(false);
        }


        if (!loginCorrecto)
        {
            MostrarError("Usuario o contraseña incorrectos.");
            ContrasenaEntry.Text = string.Empty;
            return;
        }

        //guardar algunos campos 
        if (loginCorrecto)
        {
            Preferences.Default.Set("idusuario", user.Id);
            Preferences.Default.Set("username", user.Username);
            Preferences.Default.Set("tipousuario", user.TipoUser);
            Preferences.Default.Set("nombreuser", user.Nombre);
        }

        if (RecordarmeCheck.IsChecked)
            Preferences.Default.Set(ClaveUsuarioRecordado, username);
        else
            Preferences.Default.Remove(ClaveUsuarioRecordado);

        if (Application.Current?.Windows.Count > 0)
            Application.Current.Windows[0].Page = new AppShell();
    }

    private void MostrarError(string mensaje)
    {
        ErrorLabel.Text = mensaje;
        ErrorBorder.IsVisible = true;
    }

    private async void OnOlvideContrasenaTapped(object? sender, TappedEventArgs e)
        => await DisplayAlertAsync("GasApp", "Recuperación de contraseña pendiente.", "OK");

    private async void OnRegistrateTapped(object? sender, TappedEventArgs e)
        => await DisplayAlertAsync("GasApp", "Pantalla de registro pendiente.", "OK");

    private void SetCargando(bool cargando)
    {
        IngresarButton.Text = cargando ? string.Empty : "Ingresar";
        IngresarButton.IsEnabled = !cargando;
        UsuarioEntry.IsEnabled = !cargando;
        ContrasenaEntry.IsEnabled = !cargando;
        CargandoIndicator.IsVisible = cargando;
        CargandoIndicator.IsRunning = cargando;
    }
}

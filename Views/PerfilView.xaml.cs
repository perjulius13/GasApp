using GasApp.Models;

namespace GasApp.Views;

public partial class PerfilView : ContentPage
{
    private UsuarioClass _usuario = new();
    private UsuarioClass? _respaldo;   // copia para "Cancelar"
    private bool _editando;

    public PerfilView()
    {
        InitializeComponent();
        CargarUsuarioDeEjemplo();
    }

    // TODO: reemplazar por el usuario que regrese la API al iniciar sesión.
    private void CargarUsuarioDeEjemplo()
    {
        _usuario = new UsuarioClass
        {
            Id = 1024,
            Username = "jperez",
            Nombre = "Juan",
            Paterno = "Pérez",
            Materno = "López",
            Genero = "Masculino",
            Telefono = "2221234567",
            Email = "juan.perez@ejemplo.com",
            Fechaalta = new DateTime(2025, 3, 15),
            TipoUser = 1,
            Habilitado = true
        };
        MostrarUsuario();
    }

    private void MostrarUsuario()
    {
        BindingContext = null;          // fuerza a refrescar los bindings
        BindingContext = _usuario;

        var nombreCompleto = string.Join(" ", new[] { _usuario.Nombre, _usuario.Paterno, _usuario.Materno }
            .Where(s => !string.IsNullOrWhiteSpace(s)));
        NombreCompletoLabel.Text = string.IsNullOrWhiteSpace(nombreCompleto) ? "Usuario" : nombreCompleto;

        var iniciales = $"{Inicial(_usuario.Nombre)}{Inicial(_usuario.Paterno)}";
        InicialesLabel.Text = string.IsNullOrEmpty(iniciales) ? "?" : iniciales;

        EstadoLabel.Text = _usuario.Habilitado ? "● Activo" : "● Inactivo";
        EstadoLabel.TextColor = _usuario.Habilitado ? Color.FromArgb("#16A34A") : Color.FromArgb("#DC2626");
        EstadoBorder.BackgroundColor = _usuario.Habilitado ? Color.FromArgb("#E7F6EC") : Color.FromArgb("#FDECEC");
    }

    private static string Inicial(string? texto)
        => string.IsNullOrWhiteSpace(texto) ? string.Empty : texto.Trim()[0].ToString().ToUpper();

    private void OnEditarTapped(object? sender, TappedEventArgs e)
    {
        if (_editando) return;
        _respaldo = Copiar(_usuario);
        CambiarModoEdicion(true);
        NombreEntry.Focus();
    }

    private void OnCancelarClicked(object? sender, EventArgs e)
    {
        if (_respaldo is not null)
            _usuario = _respaldo;
        CambiarModoEdicion(false);
        MostrarUsuario();
    }

    private async void OnGuardarClicked(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(_usuario.Nombre))
        {
            await DisplayAlertAsync("Mi perfil", "El nombre es obligatorio.", "OK");
            return;
        }
        if (string.IsNullOrWhiteSpace(_usuario.Email) || !_usuario.Email.Contains('@'))
        {
            await DisplayAlertAsync("Mi perfil", "Ingresa un correo electrónico válido.", "OK");
            return;
        }

        // TODO: enviar _usuario a la API para guardar los cambios.
        CambiarModoEdicion(false);
        MostrarUsuario();
        await DisplayAlertAsync("Mi perfil", "Tus datos se guardaron correctamente.", "OK");
    }

    private void CambiarModoEdicion(bool editar)
    {
        _editando = editar;
        foreach (var entry in new[] { NombreEntry, PaternoEntry, MaternoEntry, TelefonoEntry, EmailEntry })
            entry.IsReadOnly = !editar;
        GeneroPicker.IsEnabled = editar;
        BotonesEdicion.IsVisible = editar;
        EditarLabel.IsVisible = !editar;
    }

    private async void OnCambiarContrasenaTapped(object? sender, TappedEventArgs e)
        => await DisplayAlertAsync("Cambiar contraseña", "Pantalla de cambio de contraseña pendiente.", "OK");

    private async void OnCerrarSesionTapped(object? sender, TappedEventArgs e)
    {
        bool salir = await DisplayAlertAsync("Cerrar sesión", "¿Deseas cerrar tu sesión?", "Sí, salir", "Cancelar");
        if (salir && Application.Current?.Windows.Count > 0)
            Application.Current.Windows[0].Page = new LoginPage();
    }

    private static UsuarioClass Copiar(UsuarioClass u) => new()
    {
        Id = u.Id, Username = u.Username, Contra = u.Contra, Nombre = u.Nombre,
        Paterno = u.Paterno, Materno = u.Materno, Genero = u.Genero, Telefono = u.Telefono,
        Email = u.Email, Fechaalta = u.Fechaalta, Usuarioreg = u.Usuarioreg,
        TipoUser = u.TipoUser, Habilitado = u.Habilitado
    };
}

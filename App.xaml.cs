using Microsoft.Extensions.DependencyInjection;

namespace GasApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            // La app siempre inicia en el login; al autenticarse se cambia a AppShell.
            return new Window(new Views.LoginPage());
        }
    }
}
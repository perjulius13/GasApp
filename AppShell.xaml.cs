using GasApp.Views; 

namespace GasApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();


            BottomMenu();

            generales();

        }


        public void BottomMenu()
        {

            menutabs.Items.Add(new ShellContent
            {
                Title = "Home",
                Icon = "casini.png",
                ContentTemplate = new DataTemplate(typeof(HomeView)),
            });

            menutabs.Items.Add(new ShellContent
            {
                Title = "Mapa",
                Icon = "mapa.png",
                ContentTemplate = new DataTemplate(typeof(MapaView)),
            });

            menutabs.Items.Add(new ShellContent
            {
                Title = "Actividad",
                Icon = "list.png",
                ContentTemplate = new DataTemplate(typeof(ActividadView)),
            });

            menutabs.Items.Add(new ShellContent
            {
                Title = "Recompensas",
                Icon = "recompensa.png",
                ContentTemplate = new DataTemplate(typeof(RecompensasView)),
            });


        }




        public void generales()
        {
            this.Items.Add(
                new ShellContent
                {
                    Title = "Mi Perfil",
                    Icon = "profile.png",
                    ContentTemplate = new DataTemplate(typeof(PerfilView))
                });

            this.Items.Add(
              new ShellContent
              {
                  Title = "Ayuda",
                  Icon = "info.png",
                  ContentTemplate = new DataTemplate(typeof(AyudaView))
              });

        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            if (Application.Current?.Windows.Count > 0)
                Application.Current.Windows[0].Page = new LoginPage();
        }







    }
}

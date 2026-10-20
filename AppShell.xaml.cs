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
                Icon = "hogar.png",
                ContentTemplate = new DataTemplate(typeof(HomeView)),
            });

            menutabs.Items.Add(new ShellContent
            {
                Title = "Mapa",
                Icon = "plaza.png",
                ContentTemplate = new DataTemplate(typeof(MapaView)),
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
                  Icon = "informacion.png",
                  ContentTemplate = new DataTemplate(typeof(AyudaView))
              });

        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new LoginPage();
        }







    }
}

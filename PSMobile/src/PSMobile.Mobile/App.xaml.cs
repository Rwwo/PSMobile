namespace PSMobile.Mobile;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new NavigationPage(new MainPage())
        {
            BarBackgroundColor = Colors.Transparent, // Cor de fundo transparente
            BarTextColor = Colors.Black, // Cor do texto
        };

        NavigationPage.SetHasNavigationBar(this, false);
    }

}

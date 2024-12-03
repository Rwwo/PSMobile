using PSMobile.SharedUI.Components.MauiPages.Values;

namespace PSMobile.Mobile;

public partial class App : Application
{
    public App(BarcodeResultsStates results)
    {
        InitializeComponent();
        MainPage = new NavigationPage(new MainPage(results))
        {
            BarBackgroundColor = Colors.Transparent, // Cor de fundo transparente
            BarTextColor = Colors.Black, // Cor do texto
        };

        NavigationPage.SetHasNavigationBar(this, false);
    }

}

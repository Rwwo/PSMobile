using PSMobile.SharedUI.Components.MauiPages.Values;

namespace PSMobile.Mobile;

public partial class MainPage : ContentPage
{
    private readonly BarcodeResultsStates _results;
    public MainPage(BarcodeResultsStates results)
    {
        InitializeComponent();

        _results = results;
        BindingContext = _results;

        NavigationPage.SetHasNavigationBar(this, false);
    }

}

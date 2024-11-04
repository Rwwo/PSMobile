
using PSMobile.SharedKernel.Utilities.Interfaces;

namespace PSMobile.Mobile.Services;

public class NavigationService : INavigationService
{
    public async Task PushAsync(ContentPage page)
    {
        if (App.Current.MainPage is NavigationPage navigationPage)
            await navigationPage.PushAsync(page);
    }

    public async Task PopAsync()
    {
        if (App.Current.MainPage is NavigationPage navigationPage)
            await navigationPage.PopAsync();
    }
}


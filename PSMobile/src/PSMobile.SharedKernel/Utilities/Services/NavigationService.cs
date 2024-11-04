
using PSMobile.SharedKernel.Utilities.Interfaces;

namespace PSMobile.SharedKernel.Utilities.Services;

public class NavigationService : INavigationService
{
    public async Task PushAsync(ContentPage page)
    {
        if (Application.Current.MainPage is NavigationPage navigationPage)
            await navigationPage.PushAsync(page);
    }

    public async Task PopAsync()
    {
        if (Application.Current.MainPage is NavigationPage navigationPage)
            await navigationPage.PopAsync();
    }
}


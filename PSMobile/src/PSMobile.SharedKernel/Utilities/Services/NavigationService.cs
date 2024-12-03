

using PSMobile.SharedKernel.Utilities.Interfaces;

namespace PSMobile.SharedKernel.Utilities.Services;

public class NavigationService : INavigationService
{
    public async Task<ZXing.Net.Maui.BarcodeResult[]> PushAsync(ContentPage page)
    {
        var tcs = new TaskCompletionSource< ZXing.Net.Maui.BarcodeResult[]>();

        if (Application.Current.MainPage is NavigationPage navigationPage)
            await navigationPage.PushAsync(page);

        return await tcs.Task;
    }

    public async Task PopAsync()
    {
        if (Application.Current.MainPage is NavigationPage navigationPage)
            await navigationPage.PopAsync();
    }
}


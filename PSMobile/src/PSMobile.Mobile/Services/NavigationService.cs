using PSMobile.SharedKernel.Utilities.Interfaces;
using PSMobile.SharedUI.Components.MauiPages;

namespace PSMobile.Mobile.Services;

public class NavigationService : INavigationService
{

    private TaskCompletionSource<ZXing.Net.Maui.BarcodeResult[]> tcs;
    public async Task<ZXing.Net.Maui.BarcodeResult[]> PushAsync(ContentPage page)
    {
        tcs = new TaskCompletionSource<ZXing.Net.Maui.BarcodeResult[]>();

        if (App.Current.MainPage is NavigationPage navigationPage)
        {
            await navigationPage.PushAsync(page);

            if (page is CameraPage cameraPage)
            {
                // Subscreva-se ao evento
                cameraPage.BarcodesDetectedEvent += results =>
                {
                    tcs.TrySetResult(results); // Define o resultado na TaskCompletionSource
                };
            }
        }

        return await tcs.Task;
    }

    public async Task PopAsync()
    {
        if (App.Current.MainPage is NavigationPage navigationPage)
            await navigationPage.PopAsync();
    }
}



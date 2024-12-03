


namespace PSMobile.SharedKernel.Utilities.Interfaces;

public interface INavigationService
{
    Task<ZXing.Net.Maui.BarcodeResult[]> PushAsync(ContentPage page);
    Task PopAsync();
}

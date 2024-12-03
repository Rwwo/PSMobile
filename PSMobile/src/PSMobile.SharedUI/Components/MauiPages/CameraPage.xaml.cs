using ZXing.Net.Maui;

namespace PSMobile.SharedUI.Components.MauiPages;

public partial class CameraPage : ContentPage
{
    
    public event Action<BarcodeResult[]> BarcodesDetectedEvent;


    public CameraPage()
    {
        InitializeComponent();

        barcodeView.Options = new BarcodeReaderOptions
        {
            Formats = BarcodeFormats.All,
            AutoRotate = true,
            Multiple = true
        };
    }

    protected void BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {    
        BarcodesDetectedEvent?.Invoke(e.Results);
        Dispatcher.Dispatch(async () => await Navigation.PopAsync());
    }

    void SwitchCameraButton_Clicked(object sender, EventArgs e)
    {
        barcodeView.CameraLocation = barcodeView.CameraLocation == CameraLocation.Rear ? CameraLocation.Front : CameraLocation.Rear;
    }

    void TorchButton_Clicked(object sender, EventArgs e)
    {
        barcodeView.IsTorchOn = !barcodeView.IsTorchOn;
    }

}
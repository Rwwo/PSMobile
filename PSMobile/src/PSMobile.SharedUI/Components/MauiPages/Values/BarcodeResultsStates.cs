using System.ComponentModel;

using ZXing.Net.Maui;

namespace PSMobile.SharedUI.Components.MauiPages.Values;
public class BarcodeResultsStates : INotifyPropertyChanged
{

    private BarcodeResult[] _results;
    public BarcodeResult[] Results
    {
        get => _results;
        set
        {
            _results = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Results)));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

}

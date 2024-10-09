using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;


namespace ZXingBlazor.Components;

public partial class BarcodeReader : IAsyncDisposable
{

    [Inject]
    [NotNull]
    private IJSRuntime? JSRuntime { get; set; }

    private IJSObjectReference? Module { get; set; }

    private DotNetObjectReference<BarcodeReader>? Instance { get; set; }

    [NotNull]
    private StorageService? Storage { get; set; }


    [Parameter]
    public string ScanBtnTitle { get; set; } = "ScanBtnTitle";

    [Parameter]
    public string ResetBtnTitle { get; set; } = "ResetBtnTitle";

    [Parameter]
    public string CloseBtnTitle { get; set; } = "CloseBtnTitle";

    [Parameter]
    public string SelectDeviceBtnTitle { get; set; } = "SelectDeviceBtnTitle";

    [Parameter]
    public EventCallback<string> ScanResult { get; set; }

    [Parameter]
    public EventCallback Close { get; set; }
    [Parameter]
    public Func<string, Task>? OnError { get; set; }

    [Parameter] public bool UseBuiltinDiv { get; set; } = true;

    [Parameter] public ZXingBlazorStyle Style { get; set; } = ZXingBlazorStyle.Modal;

    [Parameter]
    public bool Pdf417Only { get; set; }

    [Parameter]
    public bool Decodeonce { get; set; } = true;

    [Parameter]
    public bool DecodeAllFormats { get; set; }

    [Parameter]
    public ZXingOptions? Options { get; set; }
    public ElementReference Element { get; set; }
    [Parameter]
    public string? DeviceID { get; set; }
    [Parameter]
    public bool SaveDeviceID { get; set; } = true;
    [Parameter]
    public bool Screenshot { get; set; }
    [Parameter]
    public bool StreamFromZxing { get; set; }

    // To prevent making JavaScript interop calls during prerendering
    protected async Task OnAfterRenderAsync(bool firstRender)
    {
        try
        {
            if (!firstRender)
                return;
            Storage ??= new StorageService(JSRuntime);
            Module = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/ZXingBlazor/BarcodeReader.razor.js" + "?v=" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);
            Instance = DotNetObjectReference.Create(this);
            try
            {
                if (SaveDeviceID)
                    DeviceID = await Storage.GetValue("CamsDeviceID", DeviceID);
            }
            catch (Exception)
            {

            }
            Options ??= new()
            {
                Pdf417 = Pdf417Only,
                Decodeonce = Decodeonce,
                DecodeAllFormats = DecodeAllFormats,
                Screenshot = Screenshot,
                StreamFromZxing = StreamFromZxing,
                DeviceID = DeviceID,
                //TRY_HARDER = true
            };
            await Module.InvokeVoidAsync("init", Instance, Element, Element.Id, Options, DeviceID);
        }
        catch (Exception e)
        {
            if (OnError != null)
                await OnError.Invoke(e.Message);
        }

    }

    public async Task Start()
    {
        await Module!.InvokeVoidAsync("start", Element.Id);
    }

    public async Task Stop()
    {
        await Module!.InvokeVoidAsync("stop", Element.Id);
    }

    public async Task Reload()
    {
        await Module!.InvokeVoidAsync("reload", Element.Id);
    }

    [JSInvokable]
    public async Task GetResult(string val) => await ScanResult.InvokeAsync(val);

    [JSInvokable]
    public async Task CloseScan() => await Close.InvokeAsync();

    [JSInvokable]
    public async Task GetError(string err)
    {
        if (OnError != null)
            await OnError.Invoke(err);
    }

    async ValueTask IAsyncDisposable.DisposeAsync()
    {
        await Module!.InvokeVoidAsync("destroy", Element.Id);
        Instance?.Dispose();
        if (Module is not null)
        {
            await Module.DisposeAsync();
        }
    }

    [JSInvokable]
    public async Task SelectDeviceID(string deviceID, string deviceName)
    {
        try
        {
            if (SaveDeviceID)
            {
                await Storage.SetValue("CamsDeviceID", deviceID);
                await Storage.SetValue("CamsDeviceName", deviceName);
            }
        }
        catch
        {
        }
    }

    #region StorageService
    private class StorageService
    {
        private readonly IJSRuntime JSRuntime;

        public StorageService(IJSRuntime jsRuntime)
        {
            JSRuntime = jsRuntime;
        }

        public async Task SetValue<TValue>(string key, TValue value)
        {
            await JSRuntime.InvokeVoidAsync("eval", $"localStorage.setItem('{key}', '{value}')");
        }

        public async Task<TValue?> GetValue<TValue>(string key, TValue? def)
        {
            try
            {
                var cValue = await JSRuntime.InvokeAsync<TValue>("eval", $"localStorage.getItem('{key}');");
                return cValue ?? def;
            }
            catch
            {
                var cValue = await JSRuntime.InvokeAsync<string>("eval", $"localStorage.getItem('{key}');");
                if (cValue == null)
                    return def;

                var newValue = GetValueI<TValue>(cValue);
                return newValue ?? def;

            }
        }

        public static T? GetValueI<T>(string value)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
            if (converter != null)
            {
                return (T?)converter.ConvertFrom(value);
            }
            return default;
            //return (T)Convert.ChangeType(value, typeof(T));
        }

        public async Task RemoveValue(string key)
        {
            await JSRuntime.InvokeVoidAsync("eval", $"localStorage.removeItem('{key}')");
        }


    }
    #endregion
}

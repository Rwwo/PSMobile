using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;

namespace PSMobile.Mobile.Platforms.Android;
[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Habilitar o ajuste da tela ao teclado subir
        Window.SetSoftInputMode(SoftInput.AdjustResize);
    }
}

namespace PSMobile.Mobile;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // Captura de exceções não tratadas no UI Thread
        AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

        // Captura de exceções não tratadas em tarefas de segundo plano (Task)
        TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;


        MainPage = new MainPage();
    }

    // Manipulador de exceção para UI Thread
    private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        if (e.ExceptionObject is Exception exception)
        {
            // Log ou manejo de exceção
            HandleGlobalException(exception);
        }
    }

    // Manipulador de exceção para tarefas de segundo plano
    private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
    {
        // Log ou manejo de exceção
        HandleGlobalException(e.Exception);

        // Marcar a exceção como observada
        e.SetObserved();
    }

    // Método de manejo de exceção global
    private void HandleGlobalException(Exception ex)
    {
        // Aqui você pode registrar o erro em logs, exibir uma mensagem para o usuário, etc.
        Console.WriteLine($"Exceção capturada: {ex.Message}");

        // Exemplo: Mostrar uma mensagem de erro
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            //await Application.Current.MainPage.DisplayAlert("Erro", $"Ocorreu um erro: {ex.Message}", "OK");
        });
    }
}

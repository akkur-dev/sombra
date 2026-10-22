using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Sombra.Wpf.ViewModels;
using Sombra.Wpf.Views;
using System.Windows;

namespace Sombra.Wpf;

/// <summary>
/// Логика взаимодействия для App.xaml
/// </summary>
public partial class App : Application
{
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// Путь к файлу лога текущей сессии
    /// </summary>
    private const string LOG_FILE_PATH = "Logs/sombra-.log";

    /// <summary>
    /// Формат вывода в лог
    /// </summary>
    private const string LOG_TEMPLATE = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}";

    /// <summary>
    /// Максимально допустимый размер файла лога
    /// </summary>
    private const int MAX_LOG_FILE_SIZE = 10 * 1024 * 1024;

    /// <summary>
    /// Предоставляет новый экземпляр <see cref="App"/>
    /// </summary>
    public App()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File(
                path: LOG_FILE_PATH,
                rollingInterval: RollingInterval.Day,
                rollOnFileSizeLimit: true,
                fileSizeLimitBytes: MAX_LOG_FILE_SIZE,
                outputTemplate: LOG_TEMPLATE)
            .CreateLogger();

        var services = new ServiceCollection();

        services.AddLogging(builder =>
        {
            builder.ClearProviders();
            builder.AddSerilog(dispose: true);
        });

        services.AddSingleton<IMessenger>(WeakReferenceMessenger.Default);
        services.AddSingleton<MainViewModel>();
        services.AddSingleton<MainView>();

        _serviceProvider = services.BuildServiceProvider();
    }

    /// <inheritdoc/>
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        Log.Information("Запуск приложения");

        try
        {
            var mainView = _serviceProvider.GetRequiredService<MainView>();

            mainView.DataContext = _serviceProvider.GetRequiredService<MainViewModel>();
            mainView.Show();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Ошибка при запуске приложения");
            Shutdown();
        }
    }

    /// <inheritdoc/>
    protected override void OnExit(ExitEventArgs e)
    {
        Log.Information("Завершение работы приложения\n\n");
        Log.CloseAndFlush();

        base.OnExit(e);
    }
}

// See https://aka.ms/new-console-template for more information
using GameApplication;
using GameApplication.Games;
using GameApplication.Interaction;
using GameApplication.Utilities;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

// Настройка конфигурации
IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // Подключение файла JSON
    .Build();

var settings = new Settings();
configuration.GetSection("GameSettings").Bind(settings);
// Настройка DI контейнера
var services = new ServiceCollection()
    .AddSingleton(settings)
    .AddSingleton<IRandomNumberGenerator, RandomNumberGenerator>() 
    .AddSingleton<IInputValidator, InputValidator>()              
    .AddSingleton<IUserInteraction, ConsoleUserInteraction>()      
    .AddTransient<IGame, GuessNumberGame>()                        
    .BuildServiceProvider();

// Запуск игры
var game = services.GetRequiredService<IGame>();
game.Start();


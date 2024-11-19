// See https://aka.ms/new-console-template for more information
using GameApplication;
using Microsoft.Extensions.Configuration;

// Настройка конфигурации
IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // Подключение файла JSON
    .Build();

// Загрузка настроек
var settings = configuration.GetSection("GameSettings").Get<Settings>();

IRandomNumberGenerator randomNumberGenerator = new RandomNumberGenerator();
IInputValidator inputValidator = new InputValidator();
IUserInteraction userInteraction = new ConsoleUserInteraction();
IGame game = new GuessNumberGame(randomNumberGenerator, inputValidator, userInteraction, settings);

game.Start();


// See https://aka.ms/new-console-template for more information
using GameApplication;

var settings = new Settings(1, 100, 10);
IRandomNumberGenerator randomNumberGenerator = new RandomNumberGenerator();
IInputValidator inputValidator = new InputValidator();
IGame game = new GuessNumberGame(randomNumberGenerator, inputValidator, settings);

game.Start();


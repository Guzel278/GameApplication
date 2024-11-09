using System;
namespace GameApplication
{
	public class GuessNumberGame : IGame
	{
		private readonly IRandomNumberGenerator _randomNumberGenerator;
		private readonly IInputValidator _inputValidator;
		private readonly Settings _settings;

		public GuessNumberGame(IRandomNumberGenerator randomNumberGenerator,
                         IInputValidator inputValidator,
                         Settings settings)
		{
			_randomNumberGenerator = randomNumberGenerator;
			_inputValidator = inputValidator;
			_settings = settings;
		}
        public void Start()
        {
            var _targetNumber = _randomNumberGenerator.Generate(_settings.MinRange, _settings.MaxRange);
            Console.WriteLine($"Game started! Guess number from {_settings.MinRange} to {_settings.MaxRange}." +
                $" You have {_settings.MaxAttempts} attempts");
            for (int attempt = 1; attempt <= _settings.MaxAttempts; attempt++)
            {
                Console.Write($"Attempt {attempt}: ");
                string userInput = Console.ReadLine();

                if (_inputValidator.Validate(userInput, _settings.MinRange, _settings.MaxRange, out int guessedNumber))
                {
                    if (guessedNumber == _targetNumber)
                    {
                        Console.WriteLine("Congratulations! You guess number.");
                        return;
                    }
                    else if (guessedNumber < _targetNumber)
                    {
                        Console.WriteLine("The number guessed is higher.");
                    }
                    else
                    {
                        Console.WriteLine("The number guessed is less.");
                    }
                }
            }
            Console.WriteLine($"You have exhausted all attempts. The number you were trying to guess was: {_targetNumber}.");
        }
	}
}


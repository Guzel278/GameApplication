using GameApplication.Utilities;
using GameApplication.Interaction;

namespace GameApplication.Games
{
    public class GuessNumberGame : IGame
    {
        private readonly IRandomNumberGenerator _randomNumberGenerator;
        private readonly IInputValidator _inputValidator;
        private readonly IUserInteraction _userInteraction;
        private readonly Settings _settings;
        private int _targetNumber;

        public GuessNumberGame(
            IRandomNumberGenerator randomNumberGenerator,
            IInputValidator inputValidator,
            IUserInteraction userInteraction,
            Settings settings)
        {
            _randomNumberGenerator = randomNumberGenerator;
            _inputValidator = inputValidator;
            _userInteraction = userInteraction;
            _settings = settings;
        }

        public void Start()
        {
            _targetNumber = _randomNumberGenerator.Generate(_settings.MinRange, _settings.MaxRange);
            _userInteraction.WriteMessage($"Game started! Guess number from {_settings.MinRange} to {_settings.MaxRange}. " +
                                          $"You have {_settings.MaxAttempts} attempts.");

            for (int attempt = 1; attempt <= _settings.MaxAttempts; attempt++)
            {
                _userInteraction.WriteMessage($"Attempt {attempt}: ");
                string userInput = _userInteraction.ReadInput();

                if (_inputValidator.Validate(userInput, _settings.MinRange, _settings.MaxRange, out int guessedNumber))
                {
                    if (guessedNumber == _targetNumber)
                    {
                        _userInteraction.WriteMessage("Congratulations! You guessed the number.");
                        return;
                    }

                    _userInteraction.WriteMessage(guessedNumber < _targetNumber
                        ? "The number is higher."
                        : "The number is lower.");
                }
            }

            _userInteraction.WriteMessage($"You have exhausted all attempts. The correct number was: {_targetNumber}.");
        }
    }
}
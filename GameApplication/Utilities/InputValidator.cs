using GameApplication.Interaction;
using GameApplication.Utilities;

public class InputValidator : IInputValidator
{
    private readonly IUserInteraction _userInteraction;

    public InputValidator(IUserInteraction userInteraction)
    {
        _userInteraction = userInteraction;
    }

    public bool Validate(string input, int min, int max, out int number)
    {
        bool isValid = int.TryParse(input, out number) && number >= min && number <= max;
        if (!isValid)
        {
            _userInteraction.WriteMessage($"Write number from {min} to {max}.");
        }
        return isValid;
    }
}

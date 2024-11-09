using System;
namespace GameApplication
{
    public class InputValidator : IInputValidator
    {
        public bool Validate(string input, int min, int max, out int number)
        {
            bool isValid = int.TryParse(input, out number) && number >= min && number <= max;
            if (!isValid)
            {
                Console.WriteLine($"Введите число в диапазоне от {min} до {max}.");
            }
            return isValid;
        }
    }
}


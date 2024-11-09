using System;
namespace GameApplication
{
    public interface IInputValidator
    {
        bool Validate(string input, int min, int max, out int number);
    }
}


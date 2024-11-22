using System;
namespace GameApplication.Utilities
{
	public interface IRandomNumberGenerator
	{
        int Generate(int min, int max);
    }
}


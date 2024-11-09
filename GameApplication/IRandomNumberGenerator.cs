using System;
namespace GameApplication
{
	public interface IRandomNumberGenerator
	{
        int Generate(int min, int max);
    }
}


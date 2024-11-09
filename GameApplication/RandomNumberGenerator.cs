using System;
namespace GameApplication
{
	public class RandomNumberGenerator : IRandomNumberGenerator
	{
		private readonly Random _random = new Random();
		public int Generate(int min, int max) => _random.Next(min, max + 1);
	}
}


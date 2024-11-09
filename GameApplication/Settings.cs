using System;
namespace GameApplication
{
	public class Settings
	{
		public int MinRange { get; set; }
		public int MaxRange { get; set; }
		public int MaxAttempts { get; set; }

		public Settings(int minRange, int maxRange, int maxAttempts)
		{
			MinRange = minRange;
			MaxRange = maxRange;
			MaxAttempts = maxAttempts;
		}
	}
}


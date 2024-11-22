using System;
namespace GameApplication.Interaction
{
	public interface IUserInteraction
	{
        void WriteMessage(string message);
        string ReadInput();
    }
}


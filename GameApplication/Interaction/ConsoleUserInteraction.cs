using System;

namespace GameApplication.Interaction
{
    public class ConsoleUserInteraction : IUserInteraction
    {
        public void WriteMessage(string message) => Console.WriteLine(message);
        public string ReadInput() => Console.ReadLine();
    }
}


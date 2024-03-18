using System.Reflection;

namespace CardGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Card Games Application";
            Game game = new Game();
            game.Start();
        }
    }
}

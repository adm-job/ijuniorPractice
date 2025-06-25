namespace ijuniorPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Renderer renderer = new Renderer();
            Player player = new Player(30, 20, '$');

            renderer.Draw(player.X, player.Y, player.Chacter);
        }
    }

    class Player
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public char Chacter { get; private set; }


        public Player(int x, int y, char chacter)
        {
            X = x;
            Y = y;
            Chacter = chacter;
        }
    }

    public class Renderer
    {
        public void Draw(int x, int y, char chacter)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(chacter);
            Console.ReadKey();
        }
    }
}
using NumberGame.Controllers;

namespace NumberGame
{
    class Program
    {
        static void Main(string[] args)
        {
            GameController.PresentMe();
            GameController.Play();
            while (GameController.Replay())
            {
                GameController.Play();
            }
        }
    }
}

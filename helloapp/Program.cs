// See https://aka.ms/new-console-template for more information

using System.ComponentModel;
using System.Text;

namespace BlackJack
{
    public class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            User user = new();
            Dealer dealer = new();
            Deck deckNew = new();
            TextOutput textOut = new TextOutput();

            Menu gameMenu = new Menu();

            gameMenu.StartGame(user, dealer, deckNew, textOut);

        }
    }
}

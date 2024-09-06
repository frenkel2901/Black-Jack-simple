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

            Console.Write("Enter your name: ");
            string nameInput;
            do
            {
                nameInput = Console.ReadLine()!;
            } while (nameInput.Length == 0);

            TextOutput textOut = new TextOutput();
            User user = new User { userName = nameInput };
            Dealer dealer = new Dealer { userName = $"{nameInput}'s Dealer" };
            Deck deckNew = new();
            user.AddCard(deckNew.GiveCard());
            dealer.AddCard(deckNew.GiveCard());

            textOut.StartPhrase();
            user.SeeCards();
            textOut.ChoisePhrase();

            string userCommand = Console.ReadLine()!;

            while (userCommand != "0")
            {
                switch (userCommand)
                {
                    case "1":
                        dealer.DealerChoise(deckNew, textOut);
                        textOut.ChoisePhrase();
                        userCommand = Console.ReadLine()!;
                        break;
                    case "2":
                        dealer.DealerChoise(deckNew, textOut);
                        if (user.CardsCount() < 3)
                        {
                            user.AddCard(deckNew.GiveCard());
                            textOut.StartPhrase();
                            user.SeeCards();
                            textOut.ChoisePhrase();
                            userCommand = Console.ReadLine()!;
                        }
                        else
                        {
                            Console.WriteLine("U already have 3 cards! Lets Open!");
                            deckNew.WinnerGratz(user, dealer);
                            userCommand = deckNew.AnotherDeckCommand(user, dealer, textOut);
                        }
                        break;
                    case "3":
                        dealer.DealerChoise(deckNew, textOut);
                        deckNew.WinnerGratz(user, dealer);
                        userCommand = deckNew.AnotherDeckCommand(user, dealer, textOut);
                        break;
                    default:
                        textOut.ChoisePhrase();
                        userCommand = Console.ReadLine()!;
                        break;
                }

            }
        }
    }
}

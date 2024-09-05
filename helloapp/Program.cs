// See https://aka.ms/new-console-template for more information

using System.ComponentModel;

namespace BlackJack
{
    public class Program
    {
        static void Main()
        {

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
                        if (dealer.CardsSum() < 17 && dealer.CardsCount() < 3)
                        {
                            dealer.AddCard(deckNew.GiveCard());
                        }
                        textOut.DealerThink();
                        textOut.ChoisePhrase();
                        userCommand = Console.ReadLine()!;
                        break;
                    case "2":
                        if (dealer.CardsSum() < 17 && dealer.CardsCount() < 3)
                        {
                            dealer.AddCard(deckNew.GiveCard());
                        }
                        textOut.DealerThink();
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
                            userCommand = deckNew.WhoWins(user, dealer, textOut);
                        }
                        break;
                    case "3":
                        if (dealer.CardsSum() < 17 && dealer.CardsCount() < 3)
                        {
                            dealer.AddCard(deckNew.GiveCard());
                        }
                        textOut.DealerThink();
                        userCommand = deckNew.WhoWins(user, dealer, textOut);
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

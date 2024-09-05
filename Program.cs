// See https://aka.ms/new-console-template for more information

using System.ComponentModel;

namespace BlackJack
{
    class Program
    {
        static void Main()
        {

            Console.Write("Enter your name: ");
            string nameInput;
            do
            {
                nameInput = Console.ReadLine()!;
            } while (nameInput.Length == 0);

            User user = new User { userName = nameInput };
            Dealer dealer = new Dealer { userName = $"{nameInput}'s Dealer" };
            Deck deckNew = new();
            user.AddCard(deckNew.GiveCard());
            dealer.AddCard(deckNew.GiveCard());

            Console.WriteLine("ヽ(o ^ ▽ ^ o)/     ヽ(o ^ ▽ ^ o)>\nYour cards: ");
            user.SeeCards();
            Console.WriteLine("1) Skip\n2) Add card\n3) Open cards\n0) End game");

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
                        Console.WriteLine("Dealer is thinking... ");
                        Thread.Sleep(1000);
                        Console.WriteLine("1) Skip\n2) Add card\n3) Open cards\n0) End game");
                        userCommand = Console.ReadLine()!;
                        break;
                    case "2":
                        if (dealer.CardsSum() < 17 && dealer.CardsCount() < 3)
                        {
                            dealer.AddCard(deckNew.GiveCard());
                        }
                        Console.WriteLine("Dealer is thinking... ");
                        Thread.Sleep(1000);
                        if (user.CardsCount() < 3)
                        {
                            user.AddCard(deckNew.GiveCard());
                            Console.WriteLine("ヽ(o ^ ▽ ^ o)/     ヽ(o ^ ▽ ^ o)>\nYour cards: ");
                            user.SeeCards();
                            Console.WriteLine("1) Skip\n2) Add card\n3) Open cards\n0) End game");
                            userCommand = Console.ReadLine()!;
                        }
                        else
                        {
                            Console.WriteLine("U already have 3 cards! Lets Open!");
                            userCommand = deckNew.WhoWins(user, dealer);
                        }
                        break;
                    case "3":
                        if (dealer.CardsSum() < 17 && dealer.CardsCount() < 3)
                        {
                            dealer.AddCard(deckNew.GiveCard());
                        }
                        Console.WriteLine("Dealer is thinking... ");
                        Thread.Sleep(1000);
                        userCommand = deckNew.WhoWins(user, dealer);
                        break;
                    default:
                        Console.WriteLine("1) Skip\n2) Add card\n3) Open cards\n0) End game");
                        userCommand = Console.ReadLine()!;
                        break;
                }

            }
        }
    }
}

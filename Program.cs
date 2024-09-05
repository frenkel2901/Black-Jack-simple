// See https://aka.ms/new-console-template for more information

using System.ComponentModel;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deckNew = new();
            Console.Write("Enter your name: ");
            string userName;
            
            do {
                userName = Console.ReadLine()!;
            } while (userName.Length == 0);
            
            User user = new(userName);
            Console.WriteLine($"{user.GetName()} {user.GetBank()}");

            user.SetBank(25);
            Console.WriteLine($"{user.GetName()} {user.GetBank()}");

            user.SeeCards();

            var tuple = Tuple.Create("11", "cba");

            user.AddCard(tuple);
            user.SeeCards();

            for (int i = 0; i < 15; ++i) {
                deckNew.GiveCard();
            }

        }
    }
}

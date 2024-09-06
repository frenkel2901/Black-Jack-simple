
namespace BlackJack
{
    public class Menu
    {
        public Menu() { }
        public void StartGame(User user, Dealer dealer, Deck deckNew, TextOutput textOut)
        {
            Console.Write("Enter your name: ");
            string nameInput;
            do
            {
                nameInput = Console.ReadLine()!;
            } while (nameInput.Length == 0);

            user.userName = nameInput;
            dealer.userName = $"{nameInput}'s Dealer";
            user.AddCard(deckNew.GiveCard());
            dealer.AddCard(deckNew.GiveCard());

            textOut.StartPhrase();
            user.SeeCards();
            textOut.ChoisePhrase();
            GameCycle(user, dealer, deckNew, textOut);
        }

        public void GameCycle(User user, Dealer dealer, Deck deckNew, TextOutput textOut)
        {
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

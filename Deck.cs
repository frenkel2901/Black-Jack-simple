namespace BlackJack
{
    class Deck
    {

        private string[] cardValue = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        private string[] cardSuite = { "♧", "♡", "♤", "♢" };

        private List<Tuple<string, string>> alreadyGivedCards = [];

        public Tuple<string, string> GiveCard()
        {
            Tuple<string, string> tuple;

            do
            {
                Random rand = new();
                int cardValueIndex = rand.Next(cardValue.Length);
                int cardSuiteIndex = rand.Next(cardSuite.Length);
                tuple = Tuple.Create(cardValue[cardValueIndex], cardSuite[cardSuiteIndex]);
            } while (alreadyGivedCards.Contains(tuple));
            alreadyGivedCards.Add(tuple);
            return tuple;
        }

        public void ClearDeck()
        {
            alreadyGivedCards.Clear();
        }

        public string WhoWins(User user, Dealer dealer)
        {
            string userCommand;
            Console.WriteLine($"Dealer cards sum -- {dealer.CardsSum()}");
            dealer.SeeCards();
            Console.WriteLine($"Your cards sum -- {user.CardsSum()}");
            user.SeeCards();

            int userDiff = 21 - user.CardsSum();
            int dealerDiff = 21 - dealer.CardsSum();
            int diff = userDiff - dealerDiff;
            if (dealerDiff < 0 || (diff < 0 && userDiff >= 0 && dealerDiff >= 0))
            {
                user.SetBank(10);
                dealer.SetBank(-10);
                Console.WriteLine($"You win! Your bank $ : {user.GetBank()}");
            }
            else if (userDiff == dealerDiff)
            {
                Console.Write($"Draw! Your bank $ : {user.GetBank()}");
                user.GetBank();
            }
            else
            {
                user.SetBank(-10);
                dealer.SetBank(10);
                Console.WriteLine($"You loose :_( Your bank $ : {user.GetBank()}");
                user.GetBank();
            }

            ClearDeck();
            user.ClearHands();
            dealer.ClearHands();
            Console.WriteLine("One more time? y/n");
            if (Console.ReadLine()! == "y")
            {
                user.AddCard(GiveCard());
                dealer.AddCard(GiveCard());
                Console.WriteLine("ヽ(o ^ ▽ ^ o)/     ヽ(o ^ ▽ ^ o)>\nYour cards: ");
                user.SeeCards();
                Console.WriteLine("1) Skip\n2) Add card\n3) Open cards\n0) End game");
                userCommand = Console.ReadLine()!;
            }
            else
            {
                userCommand = "0";
            }

            return userCommand;
        }

    }
}

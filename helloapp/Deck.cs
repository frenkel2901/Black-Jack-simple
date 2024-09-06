namespace BlackJack
{
    public class Deck
    {

        private string[] cardValue = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        private string[] cardSuite = { "♧", "♡", "♤", "♢" };
        private Random rand;

        private List<Tuple<string, string>> alreadyGivedCards = [];

        public Deck()
        {
            rand = new Random();
        }

        public Tuple<string, string> GiveCard()
        {
            Tuple<string, string> tuple;
            do
            {
                int cardValueIndex = rand.Next(cardValue.Length);
                int cardSuiteIndex = rand.Next(cardSuite.Length);
                tuple = Tuple.Create(cardValue[cardValueIndex], cardSuite[cardSuiteIndex]);
            } while (alreadyGivedCards.Contains(tuple));
            alreadyGivedCards.Add(tuple);
            return tuple;
        }

        public void ClearDeck(User user, Dealer dealer)
        {
            alreadyGivedCards.Clear();
            user.ClearHands();
            dealer.ClearHands();
        }


        public void StartDeck(User user, Dealer dealer, TextOutput textOutput)
        {
            user.AddCard(GiveCard());
            dealer.AddCard(GiveCard());
            textOutput.StartPhrase();
            user.SeeCards();
            textOutput.ChoisePhrase();
        }

        public string AnotherDeckCommand(User user, Dealer dealer, TextOutput textOutput)
        {
            ClearDeck(user, dealer);
            string userCommand;

            Console.WriteLine("One more time? y/n");
            if (Console.ReadLine()! == "y")
            {
                StartDeck(user, dealer, textOutput);
                userCommand = Console.ReadLine()!;
            }
            else
            {
                userCommand = "0";
            }

            return userCommand;
        }

        public string WhoWins(User user, Dealer dealer, TextOutput textOutput)
        {
            string userCommand;
            int dealerCardSum = dealer.CardsSum();
            int userCardSum = user.CardsSum();
            int dealerDiff = 21 - dealerCardSum;
            int userDiff = 21 - userCardSum;
            int diff = userDiff - dealerDiff;

            Console.WriteLine($"Dealer cards sum -- {dealerCardSum}");
            dealer.SeeCards();
            Console.WriteLine($"Your cards sum -- {userCardSum}");
            user.SeeCards();

            if (dealerDiff < 0 || (diff < 0 && userDiff >= 0 && dealerDiff >= 0))
            {
                user.SetBank(10);
                dealer.SetBank(-10);
                Console.WriteLine($"You win! Your bank $ : {user.GetBank()}");
            }
            else if (userDiff == dealerDiff)
            {
                Console.WriteLine($"Draw! Your bank $ : {user.GetBank()}");
            }
            else
            {
                user.SetBank(-10);
                dealer.SetBank(10);
                Console.WriteLine($"You loose :_( Your bank $ : {user.GetBank()}");
            }

            userCommand = AnotherDeckCommand(user, dealer, textOutput);

            return userCommand;
        }

    }
}

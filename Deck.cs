namespace BlackJack
{
    class Deck
    {

        private string[] cardValue = { "1", "2", "3", "4"};
        // private string[] cardValue = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        private string[] cardSuite = { "♧", "♡", "♤", "♢" };

        private List<Tuple<string, string>> alreadyGivedCards = [];

        // public Tuple<string, string> GiveCard()
        public void GiveCard()
        {
            Tuple<string, string> tuple;

            do {
                Random rand = new();
            int cardValueIndex = rand.Next(cardValue.Length);
            int cardSuiteIndex = rand.Next(cardSuite.Length);
            tuple = Tuple.Create(cardValue[cardValueIndex], cardSuite[cardSuiteIndex]);
            Console.WriteLine($"Given? {alreadyGivedCards.Contains(tuple)}");
            } while (alreadyGivedCards.Contains(tuple));
            alreadyGivedCards.Add(tuple);
            Console.WriteLine($"{tuple.Item1} {tuple.Item2}");
            // return tuple;
        }

    }
}

namespace BlackJack
{
    public struct TextOutput
    {
        public string startGame;
        public string choise;
        public string dealerThink;
        public string alreadyThreeCards;

        public TextOutput()
        {
            startGame = "ヽ(o ^ ▽ ^ o)/     ヽ(o ^ ▽ ^ o)>\nYour cards: ";
            choise = "1) Skip\n2) Add card\n3) Open cards\n0) End game";
            dealerThink = "Dealer is thinking... ";
            alreadyThreeCards = "U already have 3 cards! Lets Open!";
        }

        public readonly void StartPhrase()
        {
            Console.WriteLine(startGame);
        }

        public readonly void ChoisePhrase()
        {
            Console.WriteLine(choise);
        }

        public readonly void DealerThink()
        {
            Console.WriteLine(dealerThink);
            Thread.Sleep(1000);
        }
    };
}
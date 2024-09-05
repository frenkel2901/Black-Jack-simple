using Microsoft.VisualBasic;

namespace BlackJack
{
    class User(string newName)
    {
        private readonly string name = newName;
        private int bank = 100;
        // private int sum = 0;

        private List<Tuple<string, string>> cardsOnHand = [];

        public string GetName()
        {
            return name;
        }

        public int GetBank()
        {
            return bank;
        }

        public void SetBank(int money)
        {
            bank += money;
        }

        public void SeeCards()
        {
            for (int i = 0; i < cardsOnHand.Count; ++i) {
                Console.WriteLine($"{cardsOnHand[i].Item1} {cardsOnHand[i].Item2}");
            }
        }
        public void AddCard(Tuple<string, string> card)
        {
            cardsOnHand.Add(card);
        }
    }
}
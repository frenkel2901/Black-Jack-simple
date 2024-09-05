using System.Dynamic;
using System.Linq;

namespace BlackJack
{
    public class User
    {
        private string name = "";
        private int bank = 100;

        private int sum = 0;

        private List<Tuple<string, string>> cardsOnHand = new List<Tuple<string, string>>();

        public string userName
        {
            get { return name; }
            set { name = value; }
        }

        public string GetName()
        {
            return userName;
        }

        public void ClearHands()
        {
            cardsOnHand.Clear();
            sum = 0;
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
            for (int i = 0; i < cardsOnHand.Count; ++i)
            {
                Console.WriteLine($"{cardsOnHand[i].Item1} {cardsOnHand[i].Item2}");
            }
        }

        public void AddCard(Tuple<string, string> card)
        {
            if (cardsOnHand.Count < 3)
            {
                cardsOnHand.Add(card);
            }
        }

        public int CardsCount()
        {
            return cardsOnHand.Count;
        }

        private int GetCardValue(Tuple<string, string> card)
        {
            string cardValue = card.Item1;
            if (new[] { "J", "Q", "K" }.Contains(cardValue))
            {
                return 10;
            }
            else if (cardValue == "A")
            {
                return 1;
            }
            else
            {
                return Int32.Parse(cardValue);
            }
        }

        public void AllCardsSum()
        {
            if (CardsCount() > 0)
            {
                sum = 0;
                bool aceCount = false;
                foreach (var card in cardsOnHand)
                {
                    int cardValue = GetCardValue(card);
                    sum += cardValue;
                    if (card.Item1 == "A")
                    {
                        aceCount = true;
                    }
                }

                if (aceCount && sum <= (21 - 10))
                {
                    sum += 10;
                }
            }
        }

        public int CardsSum()
        {
            AllCardsSum();
            return sum;
        }
    }
}
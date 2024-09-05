using System.Dynamic;
using System.Linq;

namespace BlackJack
{
    public class User
    {
        private string name = "";
        private int bank = 100;

        private int sum = 0;

        private List<Tuple<string, string>> cardsOnHand = [];

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

        public void AllCardsSum()
        {
            if (CardsCount() > 0)
            {
                sum = 0;
                bool flagHasA = false;
                string[] cardWithPicValue = { "J", "Q", "K" };
                for (int i = 0; i < cardsOnHand.Count; i++)
                {
                    if (cardWithPicValue.Contains(cardsOnHand[i].Item1))
                    {
                        sum += 10;
                    }
                    else if (cardsOnHand[i].Item1 == "A")
                    {
                        sum += 11;
                        flagHasA = true;
                    }
                    else
                    {
                        sum += Int32.Parse(cardsOnHand[i].Item1);
                    }
                }

                if (flagHasA && sum > 21)
                {
                    sum -= 10;
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
namespace BlackJack
{
    public class Dealer : User
    {

        public Dealer() { }

        public void DealerChoise(Deck deck, TextOutput textOutput)
        {
            if (CardsSum() < 17 && CardsCount() < 3)
            {
                AddCard(deck.GiveCard());
            }
            textOutput.DealerThink();
        }

    }
}
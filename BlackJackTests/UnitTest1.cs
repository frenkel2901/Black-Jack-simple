using NUnit.Framework;
using BlackJack;
using System.Linq;

namespace BlackJackTests
{
    public class DeckTests
    {
        private Deck deck;

        [SetUp]
        public void Setup()
        {
            deck = new Deck();
        }

        [Test]
        public void GiveCard_ShouldReturnUniqueCard()
        {
            // Arrange
            var card1 = deck.GiveCard();
            var card2 = deck.GiveCard();

            // Act & Assert
            Assert.That(card1, Is.Not.EqualTo(card2));
        }

        [Test]
        public void ClearDeck_ShouldResetDeck()
        {
            // Arrange
            deck.GiveCard();
            deck.GiveCard();

            // Act
            deck.ClearDeck();
            var newCard = deck.GiveCard();

            // Assert
            Assert.That(newCard, Is.Not.Null);
        }
    }
}

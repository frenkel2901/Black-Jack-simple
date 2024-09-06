using NUnit.Framework;
using BlackJack;

namespace BlackJackTests
{
    public class DeckTests
    {
        private Deck deck;
        private User user;
        private Dealer dealer;
        private TextOutput textOutput;

        [SetUp]
        public void Setup()
        {
            deck = new Deck();
            user = new User();
            dealer = new Dealer();
            textOutput = new TextOutput();
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
        public void GiveNewCard_ShouldExist()
        {
            // Act
            var newCard = deck.GiveCard();

            // Assert
            Assert.That(newCard, Is.Not.Null);
        }


        [Test]
        public void ClearDeck_ShouldResetDeck()
        {
            // Arrange
            deck.StartDeck(user, dealer, textOutput);

            // Act
            deck.ClearDeck(user, dealer);

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(user.CardsSum(), Is.EqualTo(0));
                Assert.That(dealer.CardsSum(), Is.EqualTo(0));
            });
        }

        [Test]
        public void CheckWinnerBank_ShouldDealerWin()
        {
            // Arrange
            var uCard1 = Tuple.Create("5", "♤");
            var uCard2 = Tuple.Create("5", "♢");
            var dCard1 = Tuple.Create("10", "♤");
            var dCard2 = Tuple.Create("10", "♢");
            user.AddCard(uCard1);
            user.AddCard(uCard2);
            dealer.AddCard(dCard1);
            dealer.AddCard(dCard2);

            // Act
            deck.WinnerGratz(user, dealer);

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(user.GetBank(), Is.EqualTo(90));
                Assert.That(dealer.GetBank(), Is.EqualTo(110));
            });
        }

        [Test]
        public void CheckWinnerBank_ShouldDraw()
        {
            // Arrange
            var uCard1 = Tuple.Create("10", "♤");
            var uCard2 = Tuple.Create("5", "♢");
            var dCard1 = Tuple.Create("5", "♤");
            var dCard2 = Tuple.Create("10", "♢");
            user.AddCard(uCard1);
            user.AddCard(uCard2);
            dealer.AddCard(dCard1);
            dealer.AddCard(dCard2);

            // Act
            deck.WinnerGratz(user, dealer);

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(user.GetBank(), Is.EqualTo(100));
                Assert.That(dealer.GetBank(), Is.EqualTo(100));
            });
        }

        [Test]
        public void CheckWinnerBank_ShouldUserWin()
        {
            // Arrange
            var uCard1 = Tuple.Create("10", "♤");
            var uCard2 = Tuple.Create("10", "♢");
            var dCard1 = Tuple.Create("5", "♤");
            var dCard2 = Tuple.Create("5", "♢");
            user.AddCard(uCard1);
            user.AddCard(uCard2);
            dealer.AddCard(dCard1);
            dealer.AddCard(dCard2);

            // Act
            deck.WinnerGratz(user, dealer);

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(user.GetBank(), Is.EqualTo(110));
                Assert.That(dealer.GetBank(), Is.EqualTo(90));
            });
        }
    }
}

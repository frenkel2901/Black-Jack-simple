using NUnit.Framework;
using BlackJack;

namespace BlackJackTests
{
    public class UserTests
    {
        private User user;

        [SetUp]
        public void Setup()
        {
            user = new User();
        }

        [Test]
        public void AddCard_ShouldIncreaseCardsCount()
        {
            // Arrange
            var card = Tuple.Create("10", "♤");

            // Act
            user.AddCard(card);

            // Assert
            Assert.That(user.CardsCount(), Is.EqualTo(1));
        }

        [Test]
        public void CardsSum_ShouldReturnCorrectSum()
        {
            // Arrange
            var card1 = Tuple.Create("10", "♤");
            var card2 = Tuple.Create("5", "♢");
            user.AddCard(card1);
            user.AddCard(card2);

            // Act
            var sum = user.CardsSum();

            // Assert
            Assert.That(sum, Is.EqualTo(15));
        }

        [Test]
        public void ClearHands_ShouldResetCardsCount()
        {
            // Arrange
            user.AddCard(Tuple.Create("10", "♤"));

            // Act
            user.ClearHands();

            // Assert
            Assert.That(user.CardsCount(), Is.EqualTo(0));
        }

        [Test]
        public void SetBank_ShouldIncreaseBank()
        {
            // Arrange
            int initialBank = user.GetBank();

            // Act
            user.SetBank(50);

            // Assert
            Assert.That(user.GetBank(), Is.EqualTo(initialBank + 50));
        }
    }
}

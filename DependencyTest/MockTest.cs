using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CUT;
using Moq;

namespace DependencyTest
{
    // Przykłady z wykładów
    [TestClass]
    public class AgeValidatorTest
    {
        public class MockLogger : ILogger
        {
            public void Log(string message) { }
        }

        [TestMethod]
        public void AgeLessThanZero_MoqObjectAsMock()
        {
            // Tworzymy obiekt Mock.
            // Testownie polega na sprawdzeniu, 
            // czy na obiekcie wykonano pewną operację.
            // Do tego celu służy metoda Verify()
            // W tym przypadku obiekt Mock z biblioteki Moq 
            // pełni rolę mock-a (terminologia z wykładu)
            var mock = new Mock<ILogger>();
            var ageValidator = new AgeValidator(mock.Object);
            bool actual = ageValidator.Validate(-1);

            mock.Verify(x => x.Log("Age is less than zero"), Times.Once);
            mock.Verify(x => x.Log(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void AgeLessThanZero_MoqObjectAsDummy()
        {
            // Tworzymy obiekt typu Mock.
            // W trakcie testu nie wykonujemy jednak na nim żadnej operacji
            // Do testu wystarczy, żeby istniał jakikolwiek obiekt o interfejsie ILogger
            // W tym przypadku obiekt typu Mock pełni rolę Dummy
            var mock = new Mock<ILogger>();
            var ageValidator = new AgeValidator(mock.Object);
            bool actual = ageValidator.Validate(-1);
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void PrepareGreetings_MoqObjectAsStub()
        {
            // Tworzymy obiekt Mock.
            // Konfigurujemy metodę GetNameById() na obiekcie Mock w taki sposób,
            // aby dla dowolonego argumentu zwracała "John"
            // W tym przypadku obiekt Mock z biblioteki Moq pełni rolę Stub-a 
            var mock = new Mock<ICustomerRepository>();
            mock.Setup(x => x.GetNameById(It.IsAny<long>())).Returns("John");
            var grettings = new Grettings(mock.Object);
            string actual = grettings.PrepareGrettings(1);

            Assert.AreEqual("Hello John!", actual);
        }

        [TestMethod]
        public void PrepareGreetings_MoqObjectAsFake()
        {
            // Generalnie Mock z biblioteki Moq nie może pełnić roli Fake-a.
            // Biblioteka umożliwia jednak konfigurowanie wartości zwracanej przez metody
            // dla każdego kolejnego wywołania metody oddzielnie.
            // Daje to ciekawe możliwości testowania 
            // Dzięki temu udało się zaimplementować 
            // identyczny scenariusz jak z wykorzystaniem Fake-a

            long initialScore = 0;
            long firstScore = 98;
            long secondScore = 99;

            var mock = new Mock<IScoreRepository>();
            mock.SetupSequence(x => x.GetScoreById(It.IsAny<long>()))
                .Returns(initialScore)      // will be returned on 1st invocation
                .Returns(firstScore)        // will be returned on 2nd invocation
                .Returns(secondScore);      // will be returned on 3rd invocation


            var sut = new ScoreManager(mock.Object);
            bool actual = sut.UpdateScore(1, firstScore);
            Assert.IsTrue(actual);
            actual = sut.UpdateScore(1, secondScore);
            Assert.IsTrue(actual);
            actual = sut.UpdateScore(1, firstScore);
            Assert.IsFalse(actual);
        }
    }
}

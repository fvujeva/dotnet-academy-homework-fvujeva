using FluentAssertions;
using Library.FilipVujeva.Contracts.Entities;
using Library.FilipVujeva.Contracts.Mocks;
using Xunit;

namespace Library.FilipVujeva.Contracts.Tests
{
    public class BookTests
    {
        [Fact]
        public void ConstructBook_WhenParamsAreValid_ThenSuccesfully()
        {
            // arrange
            int id = 0;
            string title = "Test";
            string authors = "Test";
            Genre genre = Genre.Classics;
            int quantity = 1;

            // act
            Action create = () => new Book(id, title, authors, genre, quantity);

            // assert
            create.Should().NotThrow();
        }

        [Fact]
        public void IsAvaliable_WhenQuantityIsGreaterThan0_ThenReturnTrue()
        {
            // arrange
            var book = BookMock.Build(2);

            // act
            bool isAvailable = book.IsAvailable();

            // assert
            isAvailable.Should().BeTrue();
        }

        [Fact]
        public void IsAvaliable_WhenQuantityIsEqualTo0_ThenReturnFalse()
        {
            // arrange
            var book = BookMock.Build(0);

            // act
            bool isAvailable = book.IsAvailable();

            // assert
            isAvailable.Should().BeFalse();
        }

        [Fact]
        public void RemoveFomShelf_WhenNotAvaliable_ThenThrowException()
        {
            // arrange
            var book = BookMock.Build(0);

            // act
            Action remove = () => book.RemoveFromShelf();

            // assert
            remove.Should().Throw<Exception>().WithMessage("Insufficient number of Books!");
        }

        [Fact]
        public void RemoveFomShelf_WhenOneAvaliable_ThenReturnSuccessfully()
        {
            // arrange
            var book = BookMock.Build(1);

            // act
            book.RemoveFromShelf();

            // assert
            book.Quantity.Should().Be(0);
        }
    }
}

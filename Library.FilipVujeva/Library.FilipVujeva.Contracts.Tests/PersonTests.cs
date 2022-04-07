using FluentAssertions;
using Library.FilipVujeva.API.Exceptions;
using Library.FilipVujeva.Contracts.Entities;
using Library.FilipVujeva.Contracts.Mocks;
using Xunit;

namespace Library.FilipVujeva.Contracts.Tests
{
    public class PersonTests
    {
        [Fact]
        public void RentBook_WhenBookNotAvalible_ThenThrowException()
        {
            // arrange
            var book = BookMock.Build(0);
            var person = PersonMock.Build();

            // act
            Action rent = () => person.RentBook(book);

            // assert
            rent.Should().Throw<BookNotAvailableException>().WithMessage($"Book {book.Title} is not available");
        }

        [Fact]
        public void RentBook_WhenBookAvaliable_DecresesBookQuantity()
        {
            // arrange
            const int quantity = 5;
            var book = BookMock.Build(quantity);
            var person = PersonMock.Build();

            // act
            person.RentBook(book);

            // assert
            book.Quantity.Should().BeLessThanOrEqualTo(quantity - 1);
        }

        [Fact]
        public void RentBook_WhenBookAlreadyRented_ThenThrowException()
        {
            // arrange
            var book = BookMock.Build(2);
            var person = PersonMock.Build();
            person.RentBook(book);

            // act
            Action rent = () => person.RentBook(book);

            // assert
            rent.Should().Throw<RentLimitException>().WithMessage("You can't rent two of the same books at once!");
        }

        [Fact]
        public void RentBook_WhenBookLimitReached_ThenThrowException()
        {
            // arrange
            var book = BookMock.Build();
            var person = PersonMock.Build();
            var books = BookMock.BuildMore(4);
            foreach (var item in books)
            {
                person.RentBook(item);
            }

            // act
            Action rent = () => person.RentBook(book);

            // assert
            rent.Should().Throw<RentLimitException>().WithMessage("Maximum number of rented books at one time exceeded!");
        }

        [Fact]
        public void ReturnBook_WhenBookNotRented_ThenThrowException()
        {
            // arrange
            var book = BookMock.Build(1);
            var person = PersonMock.Build();

            // act
            Action rent = () => person.ReturnBook(book.Id);

            // assert
            rent.Should().Throw<EntityNotFoundException>().WithMessage("Oops, it looks like you are trying to return a book you didn't rent!");
        }
    }
}

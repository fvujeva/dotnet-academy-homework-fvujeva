using FluentAssertions;
using Library.FilipVujeva.API.Exceptions;
using Library.FilipVujeva.Contracts.Dtos;
using Library.FilipVujeva.Contracts.Entities;
using Library.FilipVujeva.Contracts.Mocks;
using Library.FilipVujeva.Contracts.Repositories;
using Moq;
using Xunit;

namespace Library.FilipVujeva.Services.Tests
{
    public class LibraryServiceTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly LibraryService _sut;

        public LibraryServiceTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _sut = new LibraryService(_unitOfWorkMock.Object);
        }

        [Fact]
        public async void GetAllBooks_WhenRepositoryReturnsData_ThenMapToDto()
        {
            // arrange
            var book = BookMock.Build();

            var books = new[] { book };

            _unitOfWorkMock.Setup(m => m.Books.GetAllAsync()).ReturnsAsync(books);

            var expectedResult = new[]
            {
                new BookCatalogDTO
                {
                    Id = book.Id,
                    Title = book.Title,
                    Authors = book.Authors,
                    Genre = book.Genre.ToString(),
                    Quantity = book.Quantity,
                },
            };

            // act
            var actualResult = await _sut.GetAllBooks();

            // assert
            expectedResult.Should().BeEquivalentTo(actualResult);
        }

        [Fact]
        public async void GetMyBooks_WhenRepositoryReturnsData_ThenMapToDto()
        {
            // arrange
            var book = BookMock.Build();
            var person = PersonMock.Build();
            person.RentBook(book);


            _unitOfWorkMock.Setup(m => m.People.GetWithRentedBooksById(person.Id))
                .ReturnsAsync(person);

            var expectedResult = new[]
            {
                new BookCatalogDTO
                {
                    Id = book.Id,
                    Title = book.Title,
                    Authors = book.Authors,
                    Genre = book.Genre.ToString(),
                    Quantity = book.Quantity,
                },
            };

            // act
            var actualResult = await _sut.GetMyBooks(person.Id);

            // assert
            expectedResult.Should().BeEquivalentTo(actualResult);
        }

        [Fact]
        public void RentBook_WhenRepositoryCanNotFindBook_ThanThrowException()
        {
            // arrange
            var person = PersonMock.Build();
            var book = BookMock.Build();

            _unitOfWorkMock.Setup(m => m.Books.GetAsync(book.Id))
                .ThrowsAsync(new EntityNotFoundException("That books does not exist in our library!"));

            // act
            Action rent = () => _sut.RentBook(person.Id, book.Id).Wait();

            // assert
            rent.Should().Throw<EntityNotFoundException>().WithMessage("That books does not exist in our library!");
        }

        [Fact]
        public void RentBook_WhenRepositoryCanNotFindPerson_ThenThrowException()
        {
            // arrange
            var person = PersonMock.Build();
            var book = BookMock.Build();
            var personFound = new Person();
            personFound = null;

            _unitOfWorkMock.Setup(m => m.Books.GetAsync(book.Id))
                .ReturnsAsync(book);
            _unitOfWorkMock.Setup(m => m.People.GetWithRentedBooksById(person.Id))
                .ReturnsAsync(personFound);

            // act
            Action rent = () => _sut.RentBook(person.Id, book.Id).Wait();

            // assert
            rent.Should().Throw<EntityNotFoundException>().WithMessage("That person does not exist in our library!");
        }

        [Fact]
        public void ReturnBook_WhenRepositoryCanNotFindPerson_ThenThrowException()
        {
            // arrange
            var person = PersonMock.Build();
            var book = BookMock.Build();
            var personFound = new Person();
            personFound = null;

            _unitOfWorkMock.Setup(m => m.Books.GetAsync(book.Id))
                .ReturnsAsync(book);
            _unitOfWorkMock.Setup(m => m.People.GetWithRentedBooksById(person.Id))
                .ReturnsAsync(personFound);

            // act
            Action retrn = () => _sut.ReturnBook(person.Id, book.Id).Wait();

            // assert
            retrn.Should().Throw<EntityNotFoundException>().WithMessage("That person does not exist in our library!");
        }

        [Fact]
        public void ReturnBook_WhenPersonDidNotRentThatBook_ThenThrowException()
        {
            // arrange
            var person = PersonMock.Build();
            var book = BookMock.Build();

            _unitOfWorkMock.Setup(m => m.Books.GetAsync(book.Id))
                .ReturnsAsync(book);
            _unitOfWorkMock.Setup(m => m.People.GetWithRentedBooksById(person.Id))
                .ReturnsAsync(person);

            // act
            Action retrn = () => _sut.ReturnBook(person.Id, book.Id).Wait();

            // assert
            retrn.Should().Throw<EntityNotFoundException>().WithMessage("Oops, it looks like you are trying to return a book you didn't rent!");
        }
    }
}

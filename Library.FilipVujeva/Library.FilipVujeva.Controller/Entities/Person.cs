//-----------------------------------------------------------------------
// <copyright file="Person.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <author>Filip Vujeva</author>
//-----------------------------------------------------------------------
using Library.FilipVujeva.API.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace Library.FilipVujeva.Contracts.Entities
{
    /// <summary>
    /// Person entity, represents smallest entity in hierarchy and has just the basic attributes.
    /// </summary>
    public class Person : IdentityUser<int>
    {
        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public Address Adress { get; set; } = default!;

        public string FullName => $"{FirstName} {LastName}";

        public List<Book> RentedBooks { get; }

        public Person()
        {
            if (RentedBooks == null)
            {
                RentedBooks = new List<Book>();
            }
        }

        public Person(string firstName, string lastName, string email, string street, string city, string country)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address adress = new(street, city, country, this);
            this.Adress = adress;
            UserName = firstName;
            if (RentedBooks == null)
            {
                RentedBooks = new List<Book>();
            }
        }

        public void RentBook(Book book)
        {
            const int maxNumberOfBooks = 4;

            if (!book.IsAvailable())
            {
                throw new BookNotAvailableException(book);
            }

            if (RentedBooks.Contains(book))
            {
                throw new RentLimitException("You can't rent two of the same books at once!");
            }

            if (RentedBooks.Count() >= maxNumberOfBooks)
            {
                throw new RentLimitException("Maximum number of rented books at one time exceeded!");
            }
            else
            {
                RentedBooks.Add(book);
                book.RemoveFromShelf();
            }
        }

        public void ReturnBook(int bookId)
        {
            var book = RentedBooks.Find(x => x.Id == bookId);
            if (book == null)
            {
                throw new EntityNotFoundException("Oops, it looks like you are trying to return a book you didn't rent!");
            }

            RentedBooks.Remove(book);
            book.AddToShelf();
        }
    }
}

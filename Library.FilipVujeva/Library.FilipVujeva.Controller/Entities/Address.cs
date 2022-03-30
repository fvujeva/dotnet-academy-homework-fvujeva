//-----------------------------------------------------------------------
// <copyright file="Adress.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <author>Filip Vujeva</author>
//-----------------------------------------------------------------------

namespace Library.FilipVujeva.Contracts.Entities
{
    /// <summary>
    /// Adress entity.
    /// </summary>
    public class Address
    {
        public int Id { get; set; }

        public Person Person { get; set; } = default!;
        public string Street { get; set; } = default!;
        public string City { get; set; } = default!;
        public string Country { get; set; } = default!;

        public Address(string street, string city, string country, Person person)
        {
            this.Street = street;
            this.City = city;
            this.Country = country;
            this.Person = person;
        }

        public Address()
        {
        }
    }
}

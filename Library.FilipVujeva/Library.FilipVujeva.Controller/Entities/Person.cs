//-----------------------------------------------------------------------
// <copyright file="Person.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <author>Filip Vujeva</author>
//-----------------------------------------------------------------------
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

        public Person()
        {
        }

        public Person(string firstName, string lastName, string email, string street, string city, string country)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Address adress = new(street, city, country, this);
            this.Adress = adress;
            UserName = firstName;
        }
    }
}

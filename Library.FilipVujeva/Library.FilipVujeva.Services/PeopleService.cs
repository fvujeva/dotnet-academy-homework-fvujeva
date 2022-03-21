//-----------------------------------------------------------------------
// <copyright file="PeopleService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <author>Filip Vujeva</author>
//-----------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.FilipVujeva.Contracts.Dtos;
using Library.FilipVujeva.Contracts.Entities;
using Library.FilipVujeva.Contracts.Services;

namespace Library.FilipVujeva.Services
{
    /// <summary>
    /// DTO for person Entity, used in POST requests in PeopleController.
    /// </summary>
    public class PeopleService : IPeopleService
    {
        private readonly List<Person> context;
        private int ids;

        /// <summary>
        /// Initializes a new instance of the <see cref="PeopleService"/> class.
        /// </summary>
        public PeopleService()
        {
            this.context = ContextInitializer();
            this.ids = 0;
        }

        /// <inheritdoc/>
        public void AddPerson(PersonDTO personDTO)
        {
            // Mapping DTO to Person entity
            var person = new Person
            {
                Id = this.ids,
                FirstName = personDTO.FirstName,
                LastName = personDTO.LastName,
            };
            this.context.Add(person);
            this.ids++;
        }

        /// <inheritdoc/>
        public List<Person> GetAllPeople()
        {
            return this.context;
        }

        /// <inheritdoc/>
        public List<Person> GetPersonByCity(string city)
        {
            List<Person> myQuery = this.context.AsQueryable().Where((person) => person.Adress.City.Equals(city)).ToList();

            return myQuery;
        }

        /// <inheritdoc/>
        public Person GetPersonById(int id)
        {
            Person myQuery = context.AsQueryable().Where((person) => person.Id.Equals(id)).FirstOrDefault();

            return myQuery;
        }

        private static List<Person> ContextInitializer()
        {
            List<Person> list = new List<Person>();
            Person p1 = new Person()
            {
                Id = 12,
                FirstName = "Pero",
                LastName = "Peric",
            };
            Adress adress1 = new Adress()
            {
                Street = "Ilica",
                City = "Zagreb",
                Country = "Hrvatska",
            };
            p1.Adress = adress1;

            Person p2 = new Person() {
                Id = 13,
                FirstName = "Ivo",
                LastName = "Ivic",
            };
            Adress adress2 = new Adress()
            {
                Street = "Bosutska",
                City = "Vinkovci",
                Country = "Hrvatska",
            };
            p2.Adress = adress2;

            list.Add(p1);
            list.Add(p2);
            return list;
        }
    }
}
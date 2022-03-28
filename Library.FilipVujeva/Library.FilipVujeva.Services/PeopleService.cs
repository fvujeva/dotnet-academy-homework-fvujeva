//-----------------------------------------------------------------------
// <copyright file="PeopleService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <author>Filip Vujeva</author>
//-----------------------------------------------------------------------
using Library.FilipVujeva.Contracts.Dtos;
using Library.FilipVujeva.Contracts.Entities;
using Library.FilipVujeva.Contracts.Repositories;
using Library.FilipVujeva.Contracts.Services;

namespace Library.FilipVujeva.Services
{
    /// <summary>
    /// DTO for person Entity, used in POST requests in PeopleController.
    /// </summary>
    public class PeopleService : IPeopleService
    {
        private readonly IUnitOfWork context;
        private int ids;

        /// <summary>
        /// Initializes a new instance of the <see cref="PeopleService"/> class.
        /// </summary>
        public PeopleService(IUnitOfWork unitOfWork)
        {
            this.context = unitOfWork;
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
            this.context.People.Add(person);
            this.ids++;
        }

        /// <inheritdoc/>
        public async Task<IList<Person>> GetAllPeople()
        {
            var allPeople = await this.context.People.GetAllAsync();

            return allPeople;
        }

        /// <inheritdoc/>
        public async Task<IList<Person>> GetPersonByCity(string city)
        {
            var allPeople = await this.context.People.GetAllAsync();

            return allPeople.AsQueryable().Where((person) => person.Adress.City.Equals(city)).ToList();
        }

        /// <inheritdoc/>
        public async Task<Person> GetPersonById(int id)
        {
            var allPeople = await this.context.People.GetAllAsync();

            return allPeople.AsQueryable().Where((person) => person.Id.Equals(id)).FirstOrDefault();
        }
    }
}

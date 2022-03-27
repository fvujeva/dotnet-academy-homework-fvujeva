//-----------------------------------------------------------------------
// <copyright file="IPeopleService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <author>Filip Vujeva</author>
//-----------------------------------------------------------------------
using Library.FilipVujeva.Contracts.Dtos;
using Library.FilipVujeva.Contracts.Entities;

namespace Library.FilipVujeva.Contracts.Services
{
    /// <summary>
    /// Interface describing People Service.
    /// </summary>
    public interface IPeopleService
    {
        /// <summary name = "GetAllPeople"> Gets all people from DB context.</summary>
        /// <returns>Returns List of Person.</returns>
        public List<Person> GetAllPeople();

        /// <summary name = "GetPersonById"> Gets all people from DB context with int id.</summary>
        /// <param name="id">Accepts int id as parameter.</param>
        /// <returns>Returns Person.</returns>
        public Person GetPersonById(int id);

        /// <summary name = "GetPersonByCity"> Gets all people from DB context with string city.</summary>
        /// <param name="city">Accepts string city as parameter.</param>
        /// <returns>Returns List of Person.</returns>
        public List<Person> GetPersonByCity(string city);

        /// <summary name = "AddPerson"> Puts PersonDTO in DB context.</summary>
        /// <param name="personDTO">Accepts PersonDTO as parameter.</param>
        public void AddPerson(PersonDTO personDTO);
    }
}

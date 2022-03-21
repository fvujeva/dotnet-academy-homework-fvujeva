//-----------------------------------------------------------------------
// <copyright file="PeopleController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <author>Filip Vujeva</author>
//-----------------------------------------------------------------------
using Library.FilipVujeva.Contracts.Dtos;
using Library.FilipVujeva.Contracts.Services;
using Library.FilipVujeva.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace Library.FilipVujeva.API.Controllers
{
    /// <summary>
    /// Manages HTTP requests and handles data from dependency injected _peopleService.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService peopleService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PeopleController"/> class.
        /// </summary>
        /// <param name="peopleService">Dependency injected peopleService instance.</param>
        public PeopleController(IPeopleService peopleService)
        {
            this.peopleService = peopleService;
        }

        // GET: api/<ValuesController>

        /// <summary> Gets all people from DB service.</summary>
        /// <returns>Returns IActionResult.</returns>
        [HttpGet("all")]
        public IActionResult GetAllPeople()
        {
            var allPeople = this.peopleService.GetAllPeople();
            return this.Ok(allPeople);
        }

        // GET api/<ValuesController>/5

        /// <summary> Gets all people from DB service with given Id.</summary>
        /// <param name="id">Accepts int id as parameter.</param>
        /// <returns>Returns IActionResult.</returns>
        [HttpGet("{id}")]
        public IActionResult GetWithId([FromRoute] int id)
        {
            var personQuery = this.peopleService.GetPersonById(id);
            return this.Ok(personQuery);
        }

        // GET api/<ValuesController>/5

        /// <summary> Gets all people from DB service from given city.</summary>
        /// <param name="city">Accepts int id as parameterfrom Query.</param>
        /// <returns>Returns IActionResult.</returns>
        [HttpGet]
        public IActionResult GetWithCity([FromQuery] string city)
        {
            var personQuery = this.peopleService.GetPersonByCity(city);
            return this.Ok(personQuery);
        }

        // POST api/<ValuesController>

        /// <summary> Puts given DTO in DB service.</summary>
        /// <param name="personDTO">Accepts JSON as parameter in shape of PersonDTO.</param>
        [HttpPost]
        public void Post([FromBody] PersonDTO personDTO)
        {
            if (personDTO == null)
            {
                return;
            }
            else
            {
                this.peopleService.AddPerson(personDTO);
            }
        }
    }
}

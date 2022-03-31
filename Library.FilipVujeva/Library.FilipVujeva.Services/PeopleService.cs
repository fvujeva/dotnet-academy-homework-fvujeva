using Library.FilipVujeva.Contracts.Dtos;
using Library.FilipVujeva.Contracts.Entities;
using Library.FilipVujeva.Contracts.Repositories;
using Library.FilipVujeva.Contracts.Services;

namespace Library.FilipVujeva.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IUnitOfWork context;
        private int ids;

        public PeopleService(IUnitOfWork unitOfWork)
        {
            this.context = unitOfWork;
        }

        public void AddPerson(PersonDTO personDTO)
        {
            var person = new Person
            {
                Id = this.ids,
                FirstName = personDTO.FirstName,
                LastName = personDTO.LastName,
            };
            this.context.People.Add(person);
            this.ids++;
        }

        public async Task<IList<Person>> GetAllPeople()
        {
            var allPeople = await this.context.People.GetAllAsync();

            return allPeople;
        }

        public async Task<IList<Person>> GetPersonByCity(string city)
        {
            var allPeople = await this.context.People.GetAllAsync();

            return allPeople.AsQueryable().Where((person) => person.Adress.City.Equals(city)).ToList();
        }

        public async Task<Person> GetPersonById(int id)
        {
            var allPeople = await this.context.People.GetAllAsync();

            return allPeople.AsQueryable().Where((person) => person.Id.Equals(id)).FirstOrDefault();
        }
    }
}

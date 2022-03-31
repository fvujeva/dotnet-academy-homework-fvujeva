using Library.FilipVujeva.Contracts.Dtos;
using Library.FilipVujeva.Contracts.Entities;

namespace Library.FilipVujeva.Contracts.Services
{
    public interface IPeopleService
    {
        public Task<IList<Person>> GetAllPeople();

        public Task<Person> GetPersonById(int id);

        public Task<IList<Person>> GetPersonByCity(string city);

        public void AddPerson(PersonDTO personDTO);
    }
}

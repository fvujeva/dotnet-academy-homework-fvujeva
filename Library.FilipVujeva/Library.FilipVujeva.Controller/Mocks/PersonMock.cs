using Library.FilipVujeva.Contracts.Entities;

namespace Library.FilipVujeva.Contracts.Mocks
{
    public static class PersonMock
    {
        public static Person Build()
        {
            return new Person("Test", "Test", "test@example.com", "Test street", "Test city", "Test country");
        }
    }
}

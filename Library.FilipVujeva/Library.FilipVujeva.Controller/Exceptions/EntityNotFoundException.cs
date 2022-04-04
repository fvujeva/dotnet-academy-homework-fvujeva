namespace Library.FilipVujeva.API.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string? message = "Entity not found in System") : base(message)
        {
        }
    }
}

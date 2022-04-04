namespace Library.FilipVujeva.API.Exceptions
{
    public class RentLimitException : Exception
    {
        public RentLimitException(string? message = "Rent limit exceeded!") : base(message)
        {
        }
    }
}

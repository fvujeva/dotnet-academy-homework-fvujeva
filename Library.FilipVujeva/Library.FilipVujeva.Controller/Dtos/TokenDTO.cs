namespace Library.FilipVujeva.Contracts.Dtos
{
    public class TokenDTO
    {
        public string Token { get; set; } = default!;
        public DateTime ExpiresAt { get; set; } = default!;
    }
}

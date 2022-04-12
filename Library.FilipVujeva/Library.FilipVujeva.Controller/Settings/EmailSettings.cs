namespace Library.FilipVujeva.Contracts.Settings
{
    public class EmailSettings
    {
        public const string Settings = "EmailSettings";

        public string Key { get; set; } = string.Empty;
        public string From { get; set; } = string.Empty;
    }
}

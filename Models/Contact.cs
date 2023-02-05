namespace Adressbok
{
    interface IContact
    {
        string? FirstName { get; set; }
        string? LastName { get; set; }
        string Email { get; set; }
        string? PhoneNumber { get; set; }
        string? Adress { get; set; }
        string? PostalCode { get; set; }
        string? Locality { get; set; }
    }
    internal class Contact : IContact
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string? Adress { get; set; }
        public string? PostalCode { get; set; }
        public string? Locality { get; set; }
    }

}

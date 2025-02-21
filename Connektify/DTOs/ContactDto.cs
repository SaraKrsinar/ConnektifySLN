namespace Connektify.DTOs
{
    public class ContactDto
    {
        public int ContactId { get; set; }
        public string? ContactName { get; set; }
        public int CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public int CountryId { get; set; }
        public string? CountryName { get; set; }
    }
}

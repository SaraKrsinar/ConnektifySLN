namespace Connektify.DTOs
{
    public class CountryDto
    {
        public int CountryId { get; set; }
        public string? CountryName { get; set; }
        public List<string> ContactNames { get; set; } = new List<string>();
    }
}

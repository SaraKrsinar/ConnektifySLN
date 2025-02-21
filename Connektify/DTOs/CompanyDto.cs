namespace Connektify.DTOs
{
    public class CompanyDto
    {
        public int CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public List<string> ContactNames { get; set; } = new List<string>();
    }
}

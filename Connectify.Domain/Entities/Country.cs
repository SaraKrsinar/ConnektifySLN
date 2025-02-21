using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connektify.Domain.Entities
{
    public class Country
    {
        [Required]
        public int CountryId { get; set; }
        
        [Required]
        public string? CountryName { get; set; }

        public ICollection<Contact>? Contacts { get; set; }
    }
}

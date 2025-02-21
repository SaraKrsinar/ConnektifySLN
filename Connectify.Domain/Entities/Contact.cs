using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connektify.Domain.Entities
{
    public class Contact
    {
        [Required]
        public int ContactId { get; set; }

        [Required]
        public string? ContactName { get; set; }

        public int CompanyId { get; set; }
        public Company? Company { get; set; }

        public int CountryId { get; set; }
        public Country? Country { get; set; }
    }
}

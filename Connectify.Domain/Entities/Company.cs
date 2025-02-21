using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connektify.Domain.Entities
{
    public class Company
    {
        [Required]
        public int CompanyId { get; set; }

        [Required]
        public string? CompanyName { get; set; }

        public ICollection<Contact>? Contacts { get; set; }
    }
}

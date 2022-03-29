using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampHomework3_4.Domain.Entities
{
    public class Company:BaseEntity
    {
        public string CompanyName { get; set; }
        public string CompanyAdress { get; set; }
        public int CompanyEmployeeCount { get; set; }

        public ICollection<User> Users { get; set; }
    }
}

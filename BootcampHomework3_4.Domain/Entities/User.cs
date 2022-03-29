using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampHomework3_4.Domain.Entities
{
    public class User:BaseEntity
    {
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public int UserAge { get; set; }
        public Gender UserGender { get; set; }
        public string Password { get; set; }
        public int CompanyID { get; set; }
        public Company Company { get; set; }
    }
    public enum Gender
    {
        Male,
        Female
    }
}

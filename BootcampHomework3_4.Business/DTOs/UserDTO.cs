using BootcampHomework3_4.Domain.Entities;

namespace BootcampHomework3_4.Business.DTOs
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public int UserAge { get; set; }
        public Gender UserGender { get; set; }
        public string UserPassword { get; set; }
        public int CompanyID { get; set; }
    }
}

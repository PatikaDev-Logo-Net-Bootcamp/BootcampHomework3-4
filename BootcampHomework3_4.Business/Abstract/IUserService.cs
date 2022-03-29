using BootcampHomework3_4.Domain.Entities;
using System.Collections.Generic;

namespace BootcampHomework3_4.Business.Abstract
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}

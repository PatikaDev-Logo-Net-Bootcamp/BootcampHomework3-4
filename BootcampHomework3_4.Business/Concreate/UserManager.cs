using BootcampHomework3_4.Business.Abstract;
using BootcampHomework3_4.DataAccess.Ef.Repositories.Abstract;
using BootcampHomework3_4.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BootcampHomework3_4.Business.Concreate
{
    public class UserManager : IUserService
    {
        private readonly IRepository<User> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UserManager(IRepository<User> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void AddUser(User user)
        {
            var result = _unitOfWork._context.Database.ExecuteSqlRaw("AddUserProcedure {0},{1},{2},{3},{4},{5},{6},{7},{8}", user.UserName, user.UserSurname, user.UserAge, user.Password, user.UserGender, user.CompanyID, user.CreatedDate, user.CreatedBy, user.IsDeleted = false);
            _unitOfWork.CommitAllOperations();
        }

        public void DeleteUser(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _repository.GetAll();
        }

        public void UpdateUser(User user)
        {
            _repository.Update(user);
        }
    }

}

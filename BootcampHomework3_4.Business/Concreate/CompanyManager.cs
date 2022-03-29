using BootcampHomework3_4.Business.Abstract;
using BootcampHomework3_4.DataAccess.Ef.Repositories.Abstract;
using BootcampHomework3_4.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampHomework3_4.Business.Concreate
{
    public class CompanyManager : ICompanyService
    {

        private readonly IRepository<Company> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CompanyManager(IRepository<Company> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void AddCompany(Company company)
        {
            var result = _unitOfWork._context.Database.ExecuteSqlRaw("AddCompanyProcedure {0},{1},{2},{3},{4},{5}", company.CompanyName, company.CompanyAdress, company.CompanyEmployeeCount, company.CreatedDate, company.CreatedBy, company.IsDeleted = false);
            _unitOfWork.CommitAllOperations();
        }

        public void DeleteCompany(int companyID)
        {
            _repository.Delete(companyID);
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            return _repository.GetAll();
        }

        public void UpdateCompany(Company company, int id)
        {
            _repository.Update(company);
            _unitOfWork.CommitAllOperations();
        }

        public Company Get(int id)
        {
            return _repository.Get(x => x.ID == id);
        }
    }
}

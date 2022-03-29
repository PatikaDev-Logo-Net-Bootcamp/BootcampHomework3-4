using BootcampHomework3_4.Domain.Entities;
using System.Collections.Generic;

namespace BootcampHomework3_4.Business.Abstract
{
    public interface ICompanyService
    {
        Company Get(int id);
        IEnumerable<Company> GetAllCompanies();
        void AddCompany(Company company);

        // odev 4 kısmı burası
        void UpdateCompany(Company company, int id);
        void DeleteCompany(int id);

    }
}

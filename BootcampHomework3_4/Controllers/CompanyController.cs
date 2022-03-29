using BootcampHomework3_4.Business.Abstract;
using BootcampHomework3_4.Business.DTOs;
using BootcampHomework3_4.Domain.Entities;
using BootcampHomework3_4.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BootcampHomework3_4.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        [Route("/Companies")]
        public IActionResult GetAllCompanies()
        {
            var companies = _companyService.GetAllCompanies();
            return Ok(companies);
        }

        [HttpPost]
        [Route("/Company")]
        public IActionResult AddCompany([FromBody] CompanyDTO model)
        {
            _companyService.AddCompany(new Company
            {
                CompanyName = model.CompanyName,
                CompanyAdress = model.CompanyAdress,
                CompanyEmployeeCount = model.CompanyEmployeeCount,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                CreatedBy = "Admin"
            });
            return Ok(new BaseResponseModel
            {
                Data = "Added successfully.",
                Success = true
            });
        }


        [HttpDelete]
        [Route("/Company/{id}")]
        public IActionResult DeleteCompany(int id)
        {
            _companyService.DeleteCompany(id);
            return Ok(new BaseResponseModel
            {
                Data = "Deleted successfully.",
                Success = true
            });
        }

        [HttpPut]
        [Route("/Company/{id}")]
        public IActionResult UpdateCompany([FromBody] CompanyDTO updateModel, int id)
        {
            var company = _companyService.Get(id);

            company.CompanyName = updateModel.CompanyName;
            company.CompanyAdress = updateModel.CompanyAdress;
            company.CompanyEmployeeCount = updateModel.CompanyEmployeeCount;
            _companyService.UpdateCompany(company, id);

            return Ok(new BaseResponseModel
            {
                Data = "Updated successfully.",
                Success = true
            });
        }




    }
}

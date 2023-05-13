


using CodeProject1.Business.Interfaces;
using CodeProject1.Core.Entities;
using CodeProject1.Exceptoins;
using CodeProject1.Helpers;
using CodeProject1.Implementations;

namespace CodeProject1.Business.Services;

public class CompanyService : ICompanyService
{
    public CompanyRepository companyRepository { get;}
    public CompanyService()
    {
        companyRepository=new CompanyRepository();
    }

    public void Create(string name)
    {
        var exist = companyRepository.GetByName(name);
        if (exist != null)
        {
            throw new AlReadyExistException(Helper.Errors["AlReadyExistException"]);
        }
        string name1=name.Trim();
        if(name1.Length<2)
        {
            throw new SizeException(Helper.Errors["SizeException"]);
        }
        Company company=new Company(name1);
        companyRepository.Add(company);

    }


    public void Delete(string name)
    {
        throw new NotImplementedException();
    }

    public List<Company> GetAll()
    {
        throw new NotImplementedException();
    }

    public Company GetById(int id)
    {
        throw new NotImplementedException();
    }
}

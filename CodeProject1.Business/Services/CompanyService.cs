


using CodeProject1.Business.Interfaces;
using CodeProject1.Contexts;
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
        Company company=new Company(name);
        companyRepository.Add(company);

    }


    public void Delete(string name)
    {
        var company=DBContext.Companys.Find(es=>es.Name==name);
        if(company != null)
        {
            DBContext.Companys.Remove(company);
        }
        else
        {
            throw new NotFoundException("This company doesn't exist");
        }
        var count = DBContext.Companys.Count(c => c.Name == name);
        if (count != 0)
        {
            throw new NotFoundException("This company isn't empty");
        }

    }

    public List<Company> GetAll()
    {
        return DBContext.Companys;
    }

    public Company GetById(int id)
    {
        var count=DBContext.Companys.Count();
        if(count>id)
        {
        throw new NotFoundException("no such id");

        }
        else
        {
        return DBContext.Companys.Find(cmp => cmp.CompanyId == id);

        }
    }
}

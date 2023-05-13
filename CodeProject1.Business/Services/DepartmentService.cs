
using CodeProject1.Business.Interfaces;
using CodeProject1.Core.Entities;
using CodeProject1.Exceptoins;
using CodeProject1.Helpers;
using CodeProject1.Implementations;

namespace CodeProject1.Business.Services;

public class DepartmentService : IDepartmentService
{
    public DepartmentRepository departmentRepository{ get; }
    public CompanyRepository companyRepository { get; }
    public DepartmentService()
    {
        companyRepository= new CompanyRepository();
        departmentRepository= new DepartmentRepository();
    }
    public void Create(string departmentName, string companyName, int employeeLimit)
    {
        var name=departmentName.Trim();
        if(string.IsNullOrEmpty(name) )
        {
            throw new NullReferenceException();
        }
        if(departmentRepository.GetByName(name)!=null) 
        {
            throw new AlReadyExistException(Helper.Errors["AlReadyExistException"]);
        }
        var companyName1 = companyRepository.GetByName(name);
        if(companyName1==null)
        {
            throw new NotFoundException($"{companyName} - doesn't exist");
             
        }
        if(employeeLimit<2)
        {
            throw new SizeException(Helper.Errors["SizeException"]);
        }
        Department department = new Department(departmentName, employeeLimit);
        departmentRepository.Add(department);

    }

    public void Delete(string departmentName)
    {
        throw new NotImplementedException();
    }

    public List<Department> GetAll()
    {
        throw new NotImplementedException();
    }

    public Department GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Department GetByName(string departmentName)
    {
        throw new NotImplementedException();
    }

    public void Update(int id, int EmployeeLimit)
    {
        throw new NotImplementedException();
    }
}

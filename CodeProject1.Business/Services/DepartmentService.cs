 
using CodeProject1.Business.Interfaces;
using CodeProject1.Contexts;
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
        var companyName1 = companyRepository.GetByName(companyName);
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
        var department=DBContext.Departments.Find(dpe=>dpe.Name==departmentName);
        if(department!=null)
        {
            throw new NotFoundException("Name not found");
        }
        else
        {
            DBContext.Departments.Find(dpe => dpe.Name == departmentName);
        }
        //try
        //{
        //   DBContext.Departments.Find(dpe=>dpe.Name==departmentName);

        //}
        //catch (Exception)
        //{

        //throw new NotFoundException("name not found");
         
        //}

    }

    public List<Department> GetAll()
    {
        return DBContext.Departments;
    }

    public Department GetById(int id)
    {
        var count = DBContext.Departments.Count();
        
        if (count<=id)
        {
            throw new NotFoundException("This id was not found");
        }
        else
        {
            return DBContext.Departments.Find(dep => dep.DepartmentId == id);
        }
    }
    public Department GetByName(string departmentName)
    {
             var department=DBContext.Departments.Find(ce=>ce.Name==departmentName);
        
           if(department==null)
            {
                 throw new NotFoundException("no such name");
            
            }
           else
        
        {
            return department;
        }
        

        
    }

    public void Update(int id, int EmployeeLimit)
    {

        var count = DBContext.Departments.Count();
        if (count < EmployeeLimit)
        {
            throw new NotFoundException("you cannot exceed the capacity");

        }
        else
        {
            DBContext.Departments.Find(dpe => dpe.DepartmentId == id && dpe.EmployeeLimit == EmployeeLimit);

        }
    }
}

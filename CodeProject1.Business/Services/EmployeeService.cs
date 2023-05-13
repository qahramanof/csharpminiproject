
using CodeProject1.Business.DTOs;
using CodeProject1.Business.Interfaces;
using CodeProject1.Core.Entities;
using CodeProject1.Exceptoins;
using CodeProject1.Helpers;
using CodeProject1.Implementations;

namespace CodeProject1.Business.Services;

public class EmployeeService : IEmployeeService
{
    public EmployeeRepository employeeRepository  { get;}
    public DepartmentRepository departmentRepository { get; }

    public EmployeeService()
    {
        employeeRepository= new EmployeeRepository();
        departmentRepository= new DepartmentRepository();
    }
    public void Create(EmployeeDto.EmployeeCreateDto employeeCreateDto)
    {
        var name = employeeCreateDto.name.Trim();
        if (string.IsNullOrEmpty(name))
        {
            throw new NullReferenceException();
        }
        if (!name.IsOnlyLetter())
        {
            throw new NotValidWordException(Helper.Errors["NotValidWordException"]);
        }
        var surname = employeeCreateDto.surname.Trim();
        if (!string.IsNullOrEmpty(surname))
        {
            if (!employeeCreateDto.surname.IsOnlyLetter())
            {
                throw new NotValidWordException(Helper.Errors["NotValidWordException"]);
            }
        }
        var department = departmentRepository.GetByName(employeeCreateDto.departmentName.Trim());
        if (department == null)
        {
            throw new NotFoundException($"{employeeCreateDto.departmentName} - doesn't exist");

        }
        var count=employeeRepository.GetAllByDepartmenttId(department.DepartmentId).Count; 
        if(count>=department.EmployeeLimit)
        {
            throw new CapacityNotEnoughException(Helper.Errors["CapacityNotEnoughException"]);
        }

    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<Employee> GetAll(int skip, int take)
    {
        throw new NotImplementedException();
    }

    public List<Employee> GetEmployeeByDepartmentId(int id)
    {
        throw new NotImplementedException();
    }

    public Employee GetEmployeeById(int id)
    {
        throw new NotImplementedException();
    }

    public List<Employee> GetEmployeeByName(string name)
    {
        throw new NotImplementedException();
    }

    public void Update(int id, EmployeeDto.EmployeeCreateDto employeeCreateDto)
    {
        throw new NotImplementedException();
    }
}

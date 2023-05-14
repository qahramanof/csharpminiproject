
using CodeProject1.Business.DTOs;
using CodeProject1.Business.Interfaces;
using CodeProject1.Contexts;
using CodeProject1.Core.Entities;
using CodeProject1.Exceptoins;
using CodeProject1.Helpers;
using CodeProject1.Implementations;
using static CodeProject1.Business.DTOs.EmployeeCreateDto;

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
    public void Create(EmployeeCreateDto employeeCreateDto)
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
        var employee=DBContext.Employees.Find(re=>re.EmployeeId==id);
       if(employee!=null)
        {
            DBContext.Employees.Remove(employee);
        }
       else
        {
            throw new NotValidWordException(Helper.Errors["NotValidWordException"]);
        }
    }

    public List<Employee> GetAll(int skip, int take)
    {
        return DBContext.Employees.FindAll(he => he.EmployeeId <= take && he.EmployeeId >= skip);
    }

    public List<Employee> GetEmployeeByDepartmentId(int id)
    {
        return DBContext.Employees.FindAll(fe=>fe.EmployeeId== id);
    }

    public Employee GetEmployeeById(int id)
    {
        var count = DBContext.Employees.Count();
        if(count<id)
        {
            throw new NotFoundException("not found");
        }
        return DBContext.Employees.Find(de => de.EmployeeId == id);
    }

    public List<Employee> GetEmployeeByName(string name)
    {
        var tmpname=employeeRepository.GetByName(name);
        if(tmpname==null)
        {
            throw new NotFoundException("This employee was not found");
        }
        return DBContext.Employees.FindAll(emp => emp.Name == name);
    }

    public void Update(int id, EmployeeCreateDto employeeCreateDto)
    {
        try
        {
            var employee = DBContext.Employees.Find(emp => emp.EmployeeId == id);
            if (employee != null)
            {
                employee.Name = employeeCreateDto.name;
                employee.Surname = employeeCreateDto.surname;
                employee.Salary = employeeCreateDto.salary;
            }
        }
        catch (Exception)
        {

              throw new NotFoundException("you cannot exceed the capacity");
        }
        
    }

  

   
}

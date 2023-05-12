using CodeProject1.Contexts;
using CodeProject1.Core.Entities;
using CodeProject1.Interfaces;

namespace CodeProject1.Implementations;

public class EmployeeRepository : IRepository<Employee>
{
    public void Add(Employee entity)
    {
        DBContext.Employees.Add(entity);
    }

    public void Delete(Employee entity)
    {
        DBContext.Employees.Remove(entity);
    }

    public void Update(Employee entity)
    {
        Employee empp=  DBContext.Employees.Find(emp => emp.EmployeeId == entity.EmployeeId);
        empp.Name= entity.Name;
        empp.Surname= entity.Surname;
        empp.Salary= entity.Salary;

    }
    public Employee? Get(int id)
    {
        return DBContext.Employees.Find(emp => emp.EmployeeId == id);
    }

    public List<Employee> GetAll()
    {
        return DBContext.Employees;
    }

}

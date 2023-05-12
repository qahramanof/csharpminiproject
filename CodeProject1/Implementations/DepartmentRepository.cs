using CodeProject1.Contexts;
using CodeProject1.Core.Entities;
using CodeProject1.Interfaces;

namespace CodeProject1.Implementations;

public class DepartmentRepository : IRepository<Department>
{
    public void Add(Department entity)
    {
        DBContext.Departments.Add(entity);
    }

    public void Delete(Department entity)
    {
        DBContext.Departments.Remove(entity);
    }
    public void Update(Department entity)
    {
        Department dpt = DBContext.Departments.Find(st => st.DepartmentId == entity.DepartmentId);
        dpt.EmployeeLimit= entity.EmployeeLimit;
        dpt.Name = entity.Name;
    }

    public Department? Get(int id)
    {
       return DBContext.Departments.Find(g=>g.DepartmentId== id);
    }

    public List<Department> GetAll()
    {
        return DBContext.Departments;
    }

}

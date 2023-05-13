 using CodeProject1.Core.Interfaces;

namespace CodeProject1.Core.Entities;

public class Department : IEntity
{
    private int _id;

    public string Name { get; set; }

    public int EmployeeLimit { get; set; }

    public int CompanyId { get; }

    public int DepartmentId { get; set; }

    public Department(string name, int employeelimit) 
    {
        Name = name;
        EmployeeLimit = employeelimit;
        DepartmentId = _id;
        _id++;
    }

    public override string ToString()
    {
        return $"Name:{Name} Id:{DepartmentId}";
    }
}

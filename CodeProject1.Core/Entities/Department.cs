using CodeProject1.Core.Interfaces;

namespace CodeProject1.Core.Entities;

public class Department : IEntity
{
    private int _id;

    public string Name { get; set; }

    public int EmployeeLimit { get; set; }

    public int CompanyId { get; }

    public int DepartmentId { get; set; }

    public Department()
    {
        DepartmentId = _id;
        _id++;
    }
    public Department(string name, int employeelimit) : this()
    {
        Name = name;
        EmployeeLimit = employeelimit;
    }

    public override string ToString()
    {
        return $"Name:{Name} Id:{DepartmentId}";
    }
}

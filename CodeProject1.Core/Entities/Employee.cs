using CodeProject1.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeProject1.Core.Entities;

public class Employee : IEntity
{
    private static int _id;

    public int EmployeeId { get; }
    public double Salary { get; set; }

    public string Name { get; set; }
    public string Surname { get; set; }

    public static int DepartmentId { get; set; }

    public Employee()
    {
        EmployeeId = _id;
        _id++;
    }
    public Employee(string name, string surname) : this()
    {
        Name = name;
        Surname = surname;
    }

    public override string ToString()
    {
        return $"Name:{Name} Surname:{Surname} Id:{EmployeeId}";
    }
}

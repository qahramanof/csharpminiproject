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

    public  int DepartmentId { get; set; }


    public Employee(string name, string surname,double salary,int departmentid)
    {
        Name = name;
        Surname = surname;
        Salary = salary; 
        DepartmentId = departmentid;
        EmployeeId = _id;
        _id++;

    }

    public override string ToString()
    {
        return $"Name:{Name} Surname:{Surname} Id:{EmployeeId}";
    }
}



using CodeProject1.Business.DTOs;
using CodeProject1.Business.Services;
using CodeProject1.Implementations;

EmployeeRepository employeeRepository = new EmployeeRepository();   
EmployeeService employeeService= new EmployeeService();
CompanyService companyService= new CompanyService();
DepartmentService departmentService= new DepartmentService();
companyService.Create("Kenan");

departmentService.Create("register", "Kenan", 15);
EmployeeCreateDto employeeDto1 = new("Kenan", "Qehremanov", 1000, "register");
employeeService.Create(employeeDto1);
Console.WriteLine("a");
departmentService.GetById(0);





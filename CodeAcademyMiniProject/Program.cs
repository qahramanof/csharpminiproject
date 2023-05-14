

using CodeProject1.Business.Services;

EmployeeService employeeService= new EmployeeService();
DepartmentService departmentService= new DepartmentService();
CompanyService companyService= new CompanyService();
Console.WriteLine("hilton1");
companyService.Create("Hilton");
Console.WriteLine("hilton2");
companyService.Create("Hilton");

using CodeProject1.Business.DTOs;
using CodeProject1.Business.Services;
using CodeProject1.Contexts;



EmployeeService employeeService= new EmployeeService();
CompanyService companyService= new CompanyService();
DepartmentService departmentService= new DepartmentService();
companyService.Create("hilton");
//companyService.Create("hilton");

departmentService.Create("register", "hilton", 10);

foreach (var com in DBContext.Companys)
{
    Console.WriteLine(com.Name);
}
EmployeeCreateDto EmployeeCreateDto1 = new("Kenan", "qahramanof", 2000, "register");
EmployeeCreateDto EmployeeCreateDto2= new("adil", "tehranli", 1000, "register");
EmployeeCreateDto EmployeeCreateDto3 = new("samid", "agayev", 1200, "register");

employeeService.Create(EmployeeCreateDto1);
employeeService.Create(EmployeeCreateDto2);
employeeService.Create(EmployeeCreateDto3);
foreach (var item in DBContext.Employees)
{
    Console.WriteLine(item);
}

//var asdf=employeeService.GetAll(0, 2);

foreach (var emp in employeeService.GetAll(0,2))    
{
    Console.WriteLine(emp.Salary);
}







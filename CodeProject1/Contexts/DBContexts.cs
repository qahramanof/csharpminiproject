   using CodeProject1.Core.Entities;

namespace CodeProject1.Contexts;

public static class DBContext
{
    public static List<Employee> Employees { get; set; } = new();

    public static List<Department> Departments { get; set; } = new();
                                                         
    public static List<Company> Companys { get; set; } = new();
}

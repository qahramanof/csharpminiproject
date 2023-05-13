 
namespace CodeProject1.Business.DTOs;

public class EmployeeDto
{
    public record EmployeeCreateDto(string name, string surname, double salary, string departmentName);
}

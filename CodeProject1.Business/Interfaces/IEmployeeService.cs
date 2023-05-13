using CodeProject1.Core.Entities;
using static CodeProject1.Business.DTOs.EmployeeDto;

namespace CodeProject1.Business.Interfaces;

public interface IEmployeeService
{
    void Create(EmployeeCreateDto studentCreateDto);
    void Delete(int id);
    void Update(int id, EmployeeCreateDto studentCreateDto);
    List<Employee> GetAll(int skip, int take);
    List<Employee> GetEmployeeByDepartmentId(int id);
    List<Employee> GetEmployeeByName(string name);
    Employee GetEmployeeById(int id);
}

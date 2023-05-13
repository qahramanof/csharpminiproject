

using CodeProject1.Core.Entities;

namespace CodeProject1.Business.Interfaces;

public interface ICompanyService
{
    void Create(string name);
    void Delete (string name);

    Company GetById(int id);
    List<Company> GetAll();


}

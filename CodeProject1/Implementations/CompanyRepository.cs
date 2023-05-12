using CodeProject1.Contexts;
using CodeProject1.Core.Entities;
using CodeProject1.Core.Interfaces;
using CodeProject1.Interfaces;

namespace CodeProject1.Implementations;

public class CompanyRepository : IRepository<Company>
{
    public void Add(Company entity)
    {
        DBContext.Companys.Add(entity);
    }

    public void Delete(Company entity)
    {
        DBContext.Companys.Remove(entity);
    }

    public void Update(Company entity)
    {
        Company cmp = DBContext.Companys.Find(t => t.CompanyId == entity.CompanyId);
        cmp.Name = entity.Name;

    }
    public Company? Get(int id)
    {
        return DBContext.Companys.Find(t => t.CompanyId == id);
    }

    public List<Company> GetAll()
    {
        return DBContext.Companys;
    }

}

using CodeProject1.Core.Interfaces;

namespace CodeProject1.Core.Entities;

public class Company : IEntity
{
    private static int _id;
    public string Name { get; set; }
    public int CompanyId { get; }

   
    public Company(string name)
    {
        Name = name;
        CompanyId = _id;
        _id++;
    }
}

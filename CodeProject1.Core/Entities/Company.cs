using CodeProject1.Core.Interfaces;

namespace CodeProject1.Core.Entities;

public class Company : IEntity
{
    private static int _id;
    public string Name { get; set; }
    public int CompanyId { get; }

    public Company()
    {
        CompanyId = _id;
        _id++;
    }
    public Company(string name) : this()
    {
        Name = name;
    }
}

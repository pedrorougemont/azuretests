using AzureWebAppTest.Domain.Interfaces;

namespace AzureWebAppTest.Domain.Entities;

public class Dummy(Guid? id, string name, DateTime created) : IEntity
{
    public Guid? Id { get; set; } = id;
    public string Name { get; set; } = name;
    public DateTime Created { get; set; } = created;

    public Dummy(string name) : this(Guid.NewGuid(), name, DateTime.Now) { }
}
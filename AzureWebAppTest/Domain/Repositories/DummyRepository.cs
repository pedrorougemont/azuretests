using AzureWebAppTest.Domain.Entities;
using AzureWebAppTest.Domain.Interfaces;
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

namespace AzureWebAppTest.Domain.Repositories;

public class DummyRepository : IRepository<Dummy>
{
    private readonly List<Dummy> _dummyList = [];
    
    public async Task<Dummy> SaveAsync(Dummy entity)
    {
        if (entity.Id != null) throw new ArgumentException("Id is already defined.");
        this._dummyList.Add(entity);
        return entity;
    }

    public async Task<Dummy> GetByIdAsync(Guid id)
    {
        return this._dummyList.FirstOrDefault(x => x.Id == id) ?? throw new KeyNotFoundException();
    }

    public async Task<IEnumerable<Dummy>> GetAllAsync()
    {
        return this._dummyList.ToList();
    }

    public async Task DeleteAsync(Guid id)
    {
        this._dummyList.Remove(await this.GetByIdAsync(id));
    }

    public async Task<Dummy> UpdateAsync(Dummy entity)
    {
        if (entity.Id is not { } guid) throw new ArgumentException("Id is not defined.");
        await this.DeleteAsync(guid);
        this._dummyList.Add(entity);
        return entity;
    }
}
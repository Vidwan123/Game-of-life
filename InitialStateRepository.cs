using DataLayerGameOfLife.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayerGameOfLife.Repositories;

internal sealed class InitialStateRepository : IInitialStateRepository
{
    private readonly GameOfLifeContext _context;

    public InitialStateRepository()
    {
        _context = new GameOfLifeContext();
        _context.Database.EnsureCreated();
    }

    public IEnumerable<InitialState> GetAll()
        => _context.InitialStates.ToList();

    public InitialState? Get(int id)
        => _context.InitialStates.FirstOrDefault(s => s.Id == id);

    public InitialState? Get(string name)
        => _context.InitialStates.FirstOrDefault(s => s.Name == name);

    public void Add(InitialState initialState)
    {
        _context.InitialStates.Add(initialState);
        _context.SaveChanges();
    }

    public void Update(InitialState initialState)
    {
        _context.InitialStates.Update(initialState);
        _context.SaveChanges();
    }

    public void Delete(InitialState initialState)
    {
        _context.InitialStates.Remove(initialState);
        _context.SaveChanges();
    }
}

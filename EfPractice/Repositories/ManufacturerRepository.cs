using EfPractice.Data;
using EfPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace EfPractice.Repositories;

public class ManufacturerRepository : IRepository<Manufacturer>
{
    private readonly AppDbContext _context;

    public ManufacturerRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Create(Manufacturer entity)
    {
        _context.Manufacturers.Add(entity);
        _context.SaveChanges();
    }

    public IEnumerable<Manufacturer> GetAll()
        => _context.Manufacturers.Include(m => m.Products).ToList();

    public Manufacturer? GetById(int id)
        => _context.Manufacturers.Find(id);

    public void Update(Manufacturer entity)
    {
        _context.Manufacturers.Update(entity);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var m = _context.Manufacturers.Find(id);
        if (m != null)
        {
            _context.Manufacturers.Remove(m);
            _context.SaveChanges();
        }
    }
}
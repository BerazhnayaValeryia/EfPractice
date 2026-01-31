using EfPractice.Data;
using EfPractice.Models;

namespace EfPractice.Repositories;

public class ProductRepository : IRepository<Product>
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Create(Product entity)
    {
        _context.Products.Add(entity);
        _context.SaveChanges();
    }

    public IEnumerable<Product> GetAll()
        => _context.Products.ToList();

    public Product? GetById(int id)
        => _context.Products.Find(id);

    public void Update(Product entity)
    {
        _context.Products.Update(entity);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var p = _context.Products.Find(id);
        if (p != null)
        {
            _context.Products.Remove(p);
            _context.SaveChanges();
        }
    }

    public List<Product> GetByManufacturer(int manufacturerId)
    {
        return _context.Products
            .Where(p => p.ManufacturerId == manufacturerId)
            .ToList();
    }
}
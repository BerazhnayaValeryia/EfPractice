using EfPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace EfPractice.Data;

public static class BusinessService
{
    public static void AddManufacturerWithProduct(
        string manufacturerName,
        string country,
        string productName,
        decimal price)
    {
        using var context = new AppDbContext();
        using var transaction = context.Database.BeginTransaction();

        try
        {
            var manufacturer = new Manufacturer
            {
                Name = manufacturerName,
                Country = country
            };

            context.Manufacturers.Add(manufacturer);
            context.SaveChanges();

            var product = new Product
            {
                Name = productName,
                Price = price,
                ManufacturerId = manufacturer.Id
            };

            context.Products.Add(product);
            context.SaveChanges();

            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }
}
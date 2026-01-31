using EfPractice.Models;

namespace EfPractice.Data;

public static class DataInitializer
{
    public static void Seed(AppDbContext context)
    {
        if (context.Manufacturers.Any())
            return;

        for (int i = 1; i <= 30; i++)
        {
            var manufacturer = new Manufacturer
            {
                Name = $"Manufacturer {i}",
                Country = "Germany"
            };

            manufacturer.Products.Add(new Product
            {
                Name = $"Product {i}",
                Price = 1000 + i * 100
            });

            context.Manufacturers.Add(manufacturer);
        }

        context.SaveChanges();
    }
}
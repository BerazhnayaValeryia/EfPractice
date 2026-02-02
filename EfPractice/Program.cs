using EfPractice.Data;
using EfPractice.Models;
using EfPractice.Repositories;

using var context = new AppDbContext();
context.Database.EnsureCreated();
DataInitializer.Seed(context);

var manufacturerRepo = new ManufacturerRepository(context);
var productRepo = new ProductRepository(context);

while (true)
{
    Console.WriteLine("""
    Menu
    ______________________
    1. Show manufacturers
    2. Add manufacturer
    3. Delete manufacturer
    ______________________
    4. Show products
    5. Add product
    ______________________
    6. Business operation
    ______________________
    0. Exit
    """);

    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            foreach (var m in manufacturerRepo.GetAll())
                Console.WriteLine($"{m.Id}: {m.Name}");
            break;

        case "2":
            Console.Write("Name: ");
            var name = Console.ReadLine()!;
            Console.Write("Country: ");
            var country = Console.ReadLine()!;
            manufacturerRepo.Create(new Manufacturer { Name = name, Country = country });
            break;

        case "3":
            Console.Write("Id: ");
            manufacturerRepo.Delete(int.Parse(Console.ReadLine()!));
            break;

        case "4":
            foreach (var p in productRepo.GetAll())
                Console.WriteLine($"{p.Id}: {p.Name} {p.Price}");
            break;

        case "5":
            Console.Write("Name: ");
            var pname = Console.ReadLine()!;
            Console.Write("Price: ");
            var price = decimal.Parse(Console.ReadLine()!);
            Console.Write("ManufacturerId: ");
            var mid = int.Parse(Console.ReadLine()!);
            productRepo.Create(new Product { Name = pname, Price = price, ManufacturerId = mid });
            break;

        case "6":
            BusinessService.AddManufacturerWithProduct(
                "New Manufacturer", "USA", "New Product", 5000);
            break;

        case "0":
            return;
    }
}
using System.Text.Json;
using Prettier.Extensions;

namespace Prettier.ConsoleApp;

internal class Program
{
    private static void Main()
    {
        var user = new User
        {
            Id = 1,
            Name = null,
            Gender = true,
            Address = new Address { Country = "USA", City = "New York" },
            Cars = new[]
            {
                new Car { Name = "BMW", Price = 10000 },
                new Car { Name = "Mercedes", Price = 20000 }
            }
        };
        var jsonNode = JsonSerializer.SerializeToNode(user)!;
        Console.WriteLine(jsonNode.Prettify());
    }
}
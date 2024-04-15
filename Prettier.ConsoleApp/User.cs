namespace Prettier.ConsoleApp;

internal class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool Gender { get; set; }
    public Address Address { get; set; } = null!;
    public IEnumerable<Car> Cars { get; set; } = null!;
}

internal class Address
{
    public string Country { get; set; } = null!;
    public string City { get; set; } = null!;
}

internal class Car
{
    public string Name { get; set; } = null!;
    public int Price { get; set; }
}
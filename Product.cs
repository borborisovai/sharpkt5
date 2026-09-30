namespace sharpkt5;

public class Product
{
    public Guid Id { get; init; }
    public string Name
    {
        get; set
        {
            if (value == string.Empty || value is null) throw new ArgumentException();
            field = value;
        }
    }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public string Category { get; set; }
    public bool IsAvailable => (Stock > 0);

    public Product(string name, decimal price, int stock = 0, string category = "General")
    {
        Id = Guid.NewGuid(); Name = name; Price = price; Stock = stock; Category = category;
    }

    public void AddStock(int qty)
    {
        if (qty <= 0) throw new ArgumentException();
        Stock += qty;
    }

    public bool TryReserve(int qty)
    {
        if (Stock < qty) return false;
        return true;
    }

    public void Reserve(int qty)
    {
        if (Stock < qty) throw new ArgumentOutOfRangeException();
        Stock -= qty;
    }
}

namespace sharpkt5;

public class Order
{
    public string Number {get; init;}
    public DateTime CreatedAt {get; init;}
    public OrderStatus Status {get; private set;}
    public IReadOnlyList<OrderItem> Items {get; private set;}
    public decimal Total => Items.Sum(i => i.Subtotal);
    private string? _summary;
    public string Summary
    {
        get
        {
            if (_summary is null) _summary = $"Order #{Number}: {Items.Count} items, total {Total}, status {Status}";
            return _summary;
        }
    }


}

public enum OrderStatus { Draft, Confirmed, Shipped, Cancelled }

namespace sharpkt5;

public class Order
{
    private static int _lastNumber = 0;
    public string Number { get; init; }
    public DateTime CreatedAt { get; init; }
    public OrderStatus Status { get; private set; }
    private readonly List<OrderItem> _items = new();
    public IReadOnlyList<OrderItem> Items => _items;
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

    public Order()
    {
        _lastNumber++;
        Number = _lastNumber.ToString();
        _items = new List<OrderItem>();
    }

    public void AddItem(OrderItem item)
    {
        if (Status != OrderStatus.Draft) throw new InvalidOperationException();
        if (item.Product.TryReserve(item.Quantity)) item.Product.Reserve(item.Quantity);
        else throw new ArgumentOutOfRangeException();
        _items.Add(item);
        _summary = null;
    }

    public void Confirm()
    {
        if (Status == OrderStatus.Shipped || Status == OrderStatus.Cancelled || Status == OrderStatus.Confirmed) throw new InvalidOperationException();
        Status = OrderStatus.Confirmed;
        _summary = null;
    }

    public void Ship()
    {
        if (Status == OrderStatus.Shipped || Status == OrderStatus.Cancelled || Status == OrderStatus.Draft) throw new InvalidOperationException();
        Status = OrderStatus.Shipped;
        _summary = null;
    }

    public void Cancel()
    {
        if (Status == OrderStatus.Shipped || Status == OrderStatus.Cancelled) throw new InvalidOperationException();
        Status = OrderStatus.Cancelled;
        _summary = null;
    }


}

public enum OrderStatus { Draft, Confirmed, Shipped, Cancelled }

namespace sharpkt5;

public class OrderItem
{
    public Product Product {get; init;}
    public int Quantity {get; init {
        if (value <= 0) throw new ArgumentException();
        field = value;
    }}
    public decimal Subtotal => (Product.Price * Quantity);

    public OrderItem(Product product, int quantity){
        Product = product; Quantity = quantity;
    }
}

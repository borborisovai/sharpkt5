using sharpkt5;

// Заказики
Product apple = new("Яблоко", 25, 50, "Фрукты");
Product phone = new("Смартфон Vivo", 123000, 50, "Вычислительная техника");
Product choko = new("Шоколадный заяц", 250, 642, "Сладости");

Console.WriteLine("\n\nЗаказ 1:");

Order order1 = new();
order1.AddItem(new OrderItem(apple, 50));
order1.AddItem(new OrderItem(phone, 1));

Console.WriteLine($"Общая стоимость: {order1.Total}");
Console.WriteLine(order1.Summary);

Console.WriteLine("\n\nЗаказ 2:");

Order order2 = new();
Console.WriteLine($"Кол-во до: {choko.Stock}");
try
{
    order2.AddItem(new OrderItem(choko, 700));
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
Console.WriteLine($"Кол-во после: {choko.Stock}");

Console.WriteLine("\n\nЗаказ 3:");

Order order3 = new();
order3.AddItem(new OrderItem(phone, 1));
order3.Confirm();

try
{
    order3.AddItem(new OrderItem(choko, 700));
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

order3.Ship();

Console.WriteLine("\n\nИтоги:");
Console.WriteLine(order1.Summary);
Console.WriteLine(order2.Summary);
Console.WriteLine(order3.Summary);
Console.WriteLine($"ID: {apple.Id}, Name: {apple.Name}, Stock: {apple.Stock}, IsAvalable: {(apple.IsAvailable ? "YES" : "NO")}");
Console.WriteLine($"ID: {phone.Id}, Name: {phone.Name}, Stock: {phone.Stock}, IsAvalable: {(phone.IsAvailable ? "YES" : "NO")}");
Console.WriteLine($"ID: {choko.Id}, Name: {choko.Name}, Stock: {choko.Stock}, IsAvalable: {(choko.IsAvailable ? "YES" : "NO")}");



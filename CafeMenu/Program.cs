using CafeMenu;

Order order = new Order();
order.Add(new Drink("Latte", 4.00m, "Large"));
order.Add(new Pastry("Croissant", 3.00m, true));
order.Add(new MenuItem("Blueberry Muffin", 2.50m));

foreach (string line in order.ReceiptLines())
{
    Console.WriteLine(line);
}

using System.Globalization;

namespace CafeMenu;

// Anything on the café's menu, such as a muffin at $2.50.
public class MenuItem
{
    public string Name { get; }
    public decimal BasePrice { get; }

    public MenuItem(string name, decimal basePrice)
    {
        Name = name;
        BasePrice = basePrice;
    }

    // What one of this item costs. A plain menu item costs its base price.
    public virtual decimal Price => BasePrice;

    // What several of this item cost.
    public decimal PriceFor(int quantity)
    {
        return Price * quantity;
    }

    // A line for the menu board, such as "Blueberry Muffin, $2.50".
    public override string ToString()
    {
        return $"{Name}, ${FormatMoney(Price)}";
    }

    // Writes an amount with two decimal places, such as 2.50.
    protected static string FormatMoney(decimal amount)
    {
        return amount.ToString("0.00", CultureInfo.InvariantCulture);
    }
}

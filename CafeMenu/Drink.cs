namespace CafeMenu;

// A drink comes in three sizes:
// - "Small" costs the base price,
// - "Medium" costs 50 cents more,
// - "Large" costs $1.00 more.
// On the menu board, the size comes first: "Large Latte, $5.00".
public class Drink : MenuItem
{
    // "Small", "Medium" or "Large".
    public string Size { get; }

    public Drink(string name, decimal basePrice, string size) : base(name, basePrice)
    {
        Size = size;
    }

    public override decimal Price
    {
        get
        {
            if (Size == "Large")
            {
                return BasePrice + 1.00m;
            }
            if (Size == "Medium")
            {
                return BasePrice + 0.50m;
            }
            return BasePrice;
        }
    }

    public override string ToString()
    {
        return $"{Size} {base.ToString()}";
    }
}

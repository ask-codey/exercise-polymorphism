namespace CafeMenu;

// A pastry can be warmed up, for 75 cents more.
// On the menu board, a warmed pastry ends with "(warmed)": "Croissant, $3.75 (warmed)".
public class Pastry : MenuItem
{
    public bool IsWarmed { get; }

    public Pastry(string name, decimal basePrice, bool isWarmed) : base(name, basePrice)
    {
        IsWarmed = isWarmed;
    }

    public override decimal Price => IsWarmed ? BasePrice + 0.75m : BasePrice;

    public override string ToString()
    {
        return IsWarmed ? $"{base.ToString()} (warmed)" : base.ToString();
    }
}

using System.Globalization;

namespace CafeMenu;

// One customer's order: any mix of menu items, drinks and pastries.
//
// Requirements:
// - Add puts an item on the order. The same item can be added more than once.
// - Total is what every item costs together, each at its own Price.
// - DrinkCount and PastryCount count the drinks and the pastries on the order.
// - Meal deal: for each pastry that comes with a drink, the order gets $0.50 off.
//   (Two drinks and one pastry make one deal; two drinks and three pastries make two.)
// - AmountDue is the total, less the meal-deal discount.
// - ReceiptLines lists each item's menu line, in the order they were added, then the
//   discount if there is one ("Meal deal: -$0.50"), then "Amount due: $8.25".
public class Order
{
    public const decimal MealDealDiscount = 0.50m;

    private readonly List<MenuItem> items = new List<MenuItem>();

    public int ItemCount => items.Count;

    public void Add(MenuItem item)
    {
    }

    public decimal Total
    {
        get
        {
            return 0;
        }
    }

    public int DrinkCount()
    {
        return 0;
    }

    public int PastryCount()
    {
        return 0;
    }

    public decimal Discount
    {
        get
        {
            return 0;
        }
    }

    public decimal AmountDue
    {
        get
        {
            return 0;
        }
    }

    public List<string> ReceiptLines()
    {
        List<string> lines = new List<string>();
        return lines;
    }

    // Writes an amount with two decimal places, such as 8.25.
    private static string FormatMoney(decimal amount)
    {
        return amount.ToString("0.00", CultureInfo.InvariantCulture);
    }
}

namespace CafeMenu.Tests;

[TestClass]
public class OrderTests
{
    [TestMethod]
    public void Add_PutsTheItemsOnTheOrder()
    {
        Order order = new Order();

        order.Add(new MenuItem("Blueberry Muffin", 2.50m));
        order.Add(new Drink("Latte", 4.00m, "Small"));

        Assert.AreEqual(2, order.ItemCount);
    }

    [TestMethod]
    public void Total_OfPlainItems_AddsTheirPrices()
    {
        Order order = new Order();
        order.Add(new MenuItem("Blueberry Muffin", 2.50m));
        order.Add(new MenuItem("Bagel", 1.75m));

        Assert.AreEqual(4.25m, order.Total);
    }

    [TestMethod]
    public void Total_OfMixedItems_UsesEachItemsOwnPrice()
    {
        Order order = new Order();
        order.Add(new Drink("Latte", 4.00m, "Large"));
        order.Add(new Pastry("Croissant", 3.00m, true));
        order.Add(new MenuItem("Blueberry Muffin", 2.50m));

        Assert.AreEqual(11.25m, order.Total, "A large latte is $5.00 and a warmed croissant $3.75.");
    }

    [TestMethod]
    public void Total_OfAFreeItem_IsZero()
    {
        Order order = new Order();
        order.Add(new MenuItem("Water", 0m));

        Assert.AreEqual(0m, order.Total);
        Assert.AreEqual(1, order.ItemCount);
    }

    [TestMethod]
    public void DrinkCountAndPastryCount_CountEachKind()
    {
        Order order = new Order();
        order.Add(new Drink("Latte", 4.00m, "Small"));
        order.Add(new Drink("Tea", 2.50m, "Large"));
        order.Add(new Pastry("Croissant", 3.00m, false));
        order.Add(new MenuItem("Blueberry Muffin", 2.50m));

        Assert.AreEqual(2, order.DrinkCount());
        Assert.AreEqual(1, order.PastryCount());
    }

    [TestMethod]
    [DataRow(1, 1, 0.50)]
    [DataRow(2, 1, 0.50)]
    [DataRow(2, 3, 1.00)]
    [DataRow(3, 3, 1.50)]
    public void Discount_IsFiftyCentsForEachPastryWithADrink(int drinks, int pastries, double expected)
    {
        Order order = new Order();
        for (int i = 0; i < drinks; i++)
        {
            order.Add(new Drink("Latte", 4.00m, "Small"));
        }
        for (int i = 0; i < pastries; i++)
        {
            order.Add(new Pastry("Croissant", 3.00m, false));
        }

        Assert.AreEqual((decimal)expected, order.Discount);
    }

    [TestMethod]
    public void AmountDue_IsTheTotalLessTheDiscount()
    {
        Order order = new Order();
        order.Add(new Drink("Latte", 4.00m, "Large"));
        order.Add(new Pastry("Croissant", 3.00m, true));

        Assert.AreEqual(8.25m, order.AmountDue);
    }

    [TestMethod]
    public void AmountDue_WithNoMealDeal_IsTheTotal()
    {
        Order order = new Order();
        order.Add(new Drink("Latte", 4.00m, "Large"));
        order.Add(new Drink("Tea", 2.50m, "Small"));

        Assert.AreEqual(0m, order.Discount);
        Assert.AreEqual(7.50m, order.AmountDue);
    }

    [TestMethod]
    public void ReceiptLines_ListEachItemThenTheDiscountAndAmountDue()
    {
        Order order = new Order();
        order.Add(new Drink("Latte", 4.00m, "Large"));
        order.Add(new Pastry("Croissant", 3.00m, true));
        order.Add(new MenuItem("Blueberry Muffin", 2.50m));

        List<string> lines = order.ReceiptLines();

        CollectionAssert.AreEqual(new List<string>
        {
            "Large Latte, $5.00",
            "Croissant, $3.75 (warmed)",
            "Blueberry Muffin, $2.50",
            "Meal deal: -$0.50",
            "Amount due: $10.75"
        }, lines);
    }

    [TestMethod]
    public void ReceiptLines_WithNoMealDeal_LeaveTheDiscountOut()
    {
        Order order = new Order();
        order.Add(new MenuItem("Bagel", 1.75m));

        List<string> lines = order.ReceiptLines();

        CollectionAssert.AreEqual(new List<string> { "Bagel, $1.75", "Amount due: $1.75" }, lines);
    }

    // A kind of menu item the café adds later. Order works with it without a change,
    // because it only asks each item for its Price and its ToString().
    private class Soup : MenuItem
    {
        public Soup() : base("Soup of the Day", 4.50m)
        {
        }

        public override decimal Price => BasePrice + 1.00m;
    }

    [TestMethod]
    public void Total_WorksForAKindOfItemOrderHasNeverHeardOf()
    {
        Order order = new Order();
        order.Add(new Soup());

        Assert.AreEqual(5.50m, order.Total, "Order adds each item's own Price, whatever kind it is.");
    }
}

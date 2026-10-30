# Exercise: Polymorphism

Exercise code for the lesson **Exercise: Polymorphism** in the C# Full-Stack Bootcamp on [ask-codey.com](https://www.ask-codey.com).

The café's menu is finished: `MenuItem`, `Drink` and `Pastry`, from *Exercise: Inheritance*. Now customers need to order. You'll write the `Order` class, which holds any mix of items in one `List<MenuItem>` and works out the total, a meal-deal discount and the receipt.

## What's here

- `CafeMenu/MenuItem.cs`, `Drink.cs`, `Pastry.cs`: the menu, finished and ready to use.
- `CafeMenu/Order.cs`: the order, for you to finish. The requirements are in the comment at the top.
- `CafeMenu.Tests/OrderTests.cs`: tests for `Order`. You don't need to change these.

## What to do

Finish each member of `Order`:

1. **`Add`** puts an item on the order.
2. **`Total`** adds up every item's price. A large latte costs $5.00, a warmed croissant $3.75: let each item say what it costs.
3. **`DrinkCount` and `PastryCount`** count the drinks and the pastries.
4. **`Discount`**: $0.50 off for each pastry that comes with a drink. **`AmountDue`** is the total less the discount.
5. **`ReceiptLines`** lists each item's menu line, then `Meal deal: -$0.50` if there's a discount, then `Amount due: $10.75`.

Run the program with **Ctrl+F5** to see a receipt, and the tests with **Test > Run All Tests** (or `dotnet test`).

## Tips

- Loop over `items` as `MenuItem`s. `item.Price` and `item.ToString()` run each item's own override, so a drink is priced by its size without any `if`.
- Counting drinks is the one place you need to know the kind: `if (item is Drink)`.
- One test adds a kind of item `Order` has never heard of, a `Soup`. If your `Total` uses `Price`, it passes without a change.
- `FormatMoney` is ready at the bottom of `Order`, for the receipt lines.

## Hand it in

When it works, push your solution to a public repo of your own on GitHub, then paste that repo's address into **Submit your exercise** on the lesson page at [ask-codey.com](https://www.ask-codey.com). That's what completes the lesson. The lesson page shows the Git commands, step by step.

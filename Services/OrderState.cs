using Bookstore.Models;

namespace Bookstore.Services;

public class OrderState
{
    public Order Order { get; set; }

    public event Action OnChange;

    public OrderState()
    {
        Order = new Order();
        Order.OrderItems = new List<OrderItem>();
    }

    public void AddItem(OrderItem item) // Add book to cart
    {
        Order.OrderItems.Add(item);
        OnChange?.Invoke();
    }

    public void RemoveItem(OrderItem item) // Remove book from cart
    {
        Order.OrderItems.Remove(item);
        OnChange?.Invoke();
    }

    public void ResetOrder() // after placing an order
    {
        Order = new Order();
        OnChange?.Invoke();
    }
}
public class Order
{
    public List<OrderItem> Items { get; set; }
    public decimal TotalAmount { get; set; }
    public OrderStatus Status { get; set; }
    public string TransactionId { get; set; }

    public bool IsValid() =>
        Items?.Any() == true && TotalAmount > 0;

    public bool IsPaid() =>
        Status == OrderStatus.Paid;

    public void Cancel() =>
        Status = OrderStatus.Cancelled;
}

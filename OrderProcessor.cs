public class OrderProcessor
{
    private readonly IPaymentGateway _paymentGateway;
    private readonly IInventoryService _inventoryService;
    private readonly INotificationService _notificationService;

    public OrderProcessor(
        IPaymentGateway paymentGateway,
        IInventoryService inventoryService,
        INotificationService notificationService)
    {
        _paymentGateway = paymentGateway;
        _inventoryService = inventoryService;
        _notificationService = notificationService;
    }

    public async Task<OrderResult> ProcessOrder(Order order)
    {
        ValidateOrderNotNull(order);

        if (!order.IsValid())
        {
            return OrderResult.Invalid("Order validation failed");
        }

        if (!await _inventoryService.CheckAvailability(order.Items))
        {
            return OrderResult.Failed("Insufficient inventory");
        }

        await _inventoryService.ReserveItems(order.Items);

        try
        {
            return await ProcessPaymentAndFinalizeOrder(order);
        }
        catch
        {
            await _inventoryService.ReleaseReservation(order.Items);
            throw;
        }
    }

    private async Task<OrderResult> ProcessPaymentAndFinalizeOrder(Order order)
    {
        var paymentResult = await _paymentGateway.ProcessPayment(
            order.CustomerId,
            order.TotalAmount,
            order.PaymentMethod);

        if (!paymentResult.IsSuccessful)
        {
            await _inventoryService.ReleaseReservation(order.Items);
            return OrderResult.Failed($"Payment failed: {paymentResult.ErrorMessage}");
        }

        await _inventoryService.CommitReservation(order.Items);
        await _notificationService.SendOrderConfirmation(order);

        return OrderResult.Success(paymentResult.TransactionId);
    }

    public async Task CancelOrder(string orderId)
    {
        var order = await GetOrderById(orderId);

        if (order.IsPaid())
        {
            await RefundAndRestoreInventory(order);
        }

        order.Cancel();
        await SaveOrder(order);
    }

    private async Task RefundAndRestoreInventory(Order order)
    {
        await _paymentGateway.RefundPayment(order.TransactionId);
        await _inventoryService.RestoreInventory(order.Items);
    }

    private static void ValidateOrderNotNull(Order order)
    {
        if (order == null)
        {
            throw new ArgumentNullException(nameof(order));
        }
    }

    private async Task<Order> GetOrderById(string orderId)
    {
        return await Task.FromResult(new Order());
    }

    private async Task SaveOrder(Order order)
    {
        await Task.CompletedTask;
    }
}

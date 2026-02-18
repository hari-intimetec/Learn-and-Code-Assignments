using System;
using System.Collections.Generic;

namespace Payment.Processing
{
    public class PaymentProcessor
    {
        private static readonly decimal MinAmount = 0.01m;
        private const int MaxRetries = 2;
        private const string PaymentSuccessMessage = "Payment successful";
        private const string PaymentFailedMessage  = "Payment failed";
        private readonly ILogger _logger;
        private readonly INotificationService _notifier;
        private readonly Dictionary<string, PaymentRecord> _history;

        public PaymentProcessor(
            ILogger logger,
            INotificationService notifier)
        {
            _logger = logger;
            _notifier = notifier;
            _history = new Dictionary<string, PaymentRecord>();
        }

        public PaymentResult Process(PaymentRequest request)
        {
            Validate(request);

            int attempt = 0;

            while (attempt < MaxRetries)
            {
                try
                {
                    Execute(request);
                    Record(request);
                    NotifySuccess(request);

                    return new PaymentResult(
                        true,
                        PaymentSuccessMessage,
                        GenerateId());
                }
                catch (PaymentException)
                {
                    attempt++;

                    _logger.Log($"Retry attempt: {attempt}");
                }
            }

            return new PaymentResult(
                false,
                PaymentFailedMessage,
                null);
        }
        
        private void Validate(PaymentRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.CustomerId))
            {
                throw new ArgumentException("Customer ID required");
            }

            if (request.Amount == null ||
                request.Amount < MinAmount)
            {
                throw new ArgumentException("Invalid amount");
            }
        }

        private void Execute(PaymentRequest request)
        {
            _logger.Log($"Executing payment of {request.Amount}");

            if (request.Amount > 5000m)
            {
                throw new PaymentException("Limit exceeded");
            }
        }

        private void Record(PaymentRequest request)
        {
            _history.Add(
                GenerateId(),
                new PaymentRecord(
                    request.CustomerId,
                    request.Amount,
                    DateTime.UtcNow));
        }

        private void NotifySuccess(PaymentRequest request)
        {
            _notifier.Send(
                request.CustomerId,
                $"Payment of {request.Amount} processed");
        }

        private string GenerateId()
        {
            return $"TXN-{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}";
        }
    }
}

using ofw.core;

namespace Demo.Core
{
    public class Order : CoreObject
    {
        public decimal Amount { get; set; }

        public Customer Customer { get; set; }

        public IReadOnlyList<LineItem> LineItems { get; set; }

        public int Number { get; set; }

        public IList<Payment> Payments { get; set; } = new List<Payment>();

        public PaymentStatus Status
        {
            get
            {
                if (Amount == 0)
                {
                    return PaymentStatus.Full;
                }
                if (Payments.Count == 0)
                {
                    return PaymentStatus.Open;
                }
                else if (Payments.Sum(p => p.Amount) >= Amount)
                {
                    return PaymentStatus.Full;
                }
                else
                {
                    return PaymentStatus.Partial;
                }
            }
        }

        public override string Title => Number.ToString();

        public Order(decimal amount, Customer customer, IReadOnlyList<LineItem> lineItems, int number)
        {
            Amount = amount;
            Customer = customer;
            LineItems = lineItems;
            Number = number;
        }
    }
}
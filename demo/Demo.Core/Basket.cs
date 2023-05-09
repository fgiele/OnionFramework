using ofw.core;

namespace Demo.Core
{
    public class Basket : CoreObject
    {
        public override string Title => $"{Customer.Title} Basket";

        public Customer Customer { get; set; }
        public IList<LineItem> LineItems { get; set; }

        public Basket(IList<LineItem> lineItems, Customer customer)
        {
            LineItems = lineItems;
            Customer = customer;
        }
    }
}
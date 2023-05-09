using Demo.Core;

namespace Demo.Presentation.Shared
{
    public class Basket : Core.Basket
    {
        public Basket(IList<LineItem> lineItems, Customer customer) : base(lineItems, customer)
        {
        }
    }
}
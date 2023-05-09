using ofw.core;

namespace Demo.Core
{
    public class Payment : CoreObject
    {
        public decimal Amount { get; set; }

        public override string Title => Amount.ToString();
    }
}
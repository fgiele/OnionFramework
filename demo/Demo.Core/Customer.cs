using ofw.core;

namespace Demo.Core
{
    public class Customer : CoreObject
    {
        public string Address { get; set; } = string.Empty;

        public Basket? Basket { get; set; }

        public string City { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string FullName
        {
            get
            {
                var fullname = $"{FirstName} {LastName}";
                return fullname.Trim();
            }
        }

        public string LastName { get; set; } = string.Empty;

        public IList<Order> Orders { get; set; } = new List<Order>();

        public override string Title => FullName;

        public string ZipCode { get; set; } = string.Empty;
    }
}
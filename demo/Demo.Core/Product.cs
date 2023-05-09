using ofw.core;

namespace Demo.Core
{
    public class Product : CoreObject
    {
        public string Name { get; set; }

        public override string Title => Name;

        public Product(string name)
        {
            Name = name;
        }
    }
}
using ofw.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Core
{
    public class LineItem : CoreObject
    {
        public LineItem(Product product, int number = 1)
        {
            Product = product;
            Number = number;
        }

        public Product Product { get; set; }

        public int Number { get; set; }

        public override string Title => $"{Product.Title} [{Number}]";
    }
}

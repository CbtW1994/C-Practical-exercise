using System;
using System.Collections.Generic;
using System.Text;

namespace GoodEnergyPracticalExercise.Models
{
    public class BasketLine
    {
        public BasketLine(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public Product Product { get; set; }
        public int Quantity { get; set; }

        public decimal GetLineTotal() {
            return Product.Price * Quantity;
        }
    }
}

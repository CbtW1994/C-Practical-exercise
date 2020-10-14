using System;
using System.Collections.Generic;
using System.Text;

namespace GoodEnergyPracticalExercise.Constants
{
    public static class Products
    {
        public static readonly Product Bread = new Product(name: "Bread", price: 1.1m);
        public static readonly Product Milk = new Product(name: "Milk", price: 0.5m);
        public static readonly Product Cheese = new Product(name: "Cheese", price: 0.9m);
        public static readonly Product Soup = new Product(name: "Soup", price: 0.6m);
        public static readonly Product Butter = new Product(name: "Butter", price: 1.2m);
    }
}

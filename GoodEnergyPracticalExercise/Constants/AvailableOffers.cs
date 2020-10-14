using System;
using System.Collections.Generic;
using System.Text;

namespace GoodEnergyPracticalExercise.Constants
{
    public static class AvailableOffers
    {
        public static readonly Offer BOGOFCheese = new Offer("BOGOF Cheese", Products.Cheese.Price);
        public static readonly Offer SoupAndBread = new Offer("Buy soup, get 1 half price Bread", Decimal.Divide(Products.Bread.Price, 2));
        public static readonly Offer ThirdOffButter = new Offer("3rd Off Butter", Decimal.Divide(Products.Butter.Price, 3));
    }
}

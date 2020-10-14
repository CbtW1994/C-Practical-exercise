using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using GoodEnergyPracticalExercise.Constants;

namespace GoodEnergyPracticalExercise.Models
{
    public class Basket
    {
        #region properties
        public List<BasketLine> Lines = new List<BasketLine>();

        public List<Offer> Offers = new List<Offer>() {
        AvailableOffers.BOGOFCheese,
        AvailableOffers.SoupAndBread,
        AvailableOffers.ThirdOffButter,
        };

        public decimal GetTotal()
        {
            var totalOfferReductions = Offers.Sum(offer => offer.GetTotalBasketDeduction());
            return GetSubTotal() - totalOfferReductions;
        }
        public decimal GetSubTotal()
        {
            return Lines.Sum(item => item.GetLineTotal());
        }
        #endregion

        public void AddToBasket(Product newProduct)
        {
            if (newProduct == null) return;
            var existingBakestLine = Lines.Find(item => item.Product.Equals(newProduct));
            if (existingBakestLine == default)
            {
                BasketLine newItem = new BasketLine(product: newProduct, quantity: 1);
                Lines.Add(newItem);
            }
            else
            {
                existingBakestLine.Quantity++;
            }

            ApplyCheeseOffer();
            ApplySoupBreadOffer();
            ApplyButterOffer();
        }

        public void ApplyCheeseOffer()
        {
            var cheeseLine = Lines.Find(item => item.Product == Products.Cheese);
            if (cheeseLine != default)
            {
                var cheeseOffer = Offers.Find(offer => offer.Name == AvailableOffers.BOGOFCheese.Name);
                cheeseOffer.AmountOfTimesApplied = cheeseLine.Quantity / 2;
            }
        }

        public void ApplySoupBreadOffer()
        {
            var soupLine = Lines.Find(item => item.Product == Products.Soup);
            var BreadLine = Lines.Find(item => item.Product == Products.Bread);

            // only apply offer if at least 1 bread and soup are in the basket
            if (soupLine != default && BreadLine != default)
            {
                var soupBreadOffer = Offers.Find(offer => offer.Name == AvailableOffers.SoupAndBread.Name);
                var halfPriceBreadCost = Decimal.Divide(Products.Bread.Price, 2);

                // if there are more soups than breads use the bread quantity so as to not discount items that are not in the basket.
                soupBreadOffer.AmountOfTimesApplied = soupLine.Quantity > BreadLine.Quantity ? BreadLine.Quantity : soupLine.Quantity;
            }
        }

        public void ApplyButterOffer()
        {
            var butterLine = Lines.Find(item => item.Product == Products.Butter);
            if (butterLine != default)
            {
                var thirdOfButterPrice = Decimal.Divide(Products.Butter.Price, 3);
                var butterOffer = Offers.Find(offer => offer.Name == AvailableOffers.ThirdOffButter.Name);
                butterOffer.AmountOfTimesApplied = butterLine.Quantity;
            }
        }
    }
}

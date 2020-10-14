using GoodEnergyPracticalExercise;
using GoodEnergyPracticalExercise.Constants;
using GoodEnergyPracticalExercise.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GoodEnergyPracticalExerciseTests
{
    [TestClass]
    public class BasketTests
    {
        private Basket basket;
        [TestInitialize]
        public void Startup()
        {
            basket = new Basket();
        }

        #region AddToBasket Tests

        [TestMethod]
        public void AddToBasket_NoProductsInBasketGivenNULLProduct_ProductNotAddedToBasket()
        {
            Product productToAdd = null;

            basket.AddToBasket(productToAdd);

            Assert.AreEqual(0, basket.Lines.Count);
        }

        [TestMethod]
        public void AddToBasket_GivenProductAlreadyInBasket_BasketLineCountTheSameItemQuantityIncreases()
        {
            basket.Lines.Add(new BasketLine(Products.Milk, 5));

            basket.AddToBasket(Products.Milk);

            Assert.AreEqual(1, basket.Lines.Count);
            Assert.AreEqual(6, basket.Lines.Find(line => line.Product == Products.Milk).Quantity);
        }

        [TestMethod]
        public void AddToBasket_GivenProductNotInBasket_BasketLineCountIncreasesItemQuantityIsOne()
        {
            basket.Lines.Add(new BasketLine(Products.Bread, 5));

            basket.AddToBasket(Products.Milk);

            Assert.AreEqual(2, basket.Lines.Count);
            Assert.AreEqual(1, basket.Lines.Find(line => line.Product == Products.Milk).Quantity);
        }
        #endregion

        #region ApplyCheeseOfferTests

        [TestMethod]
        public void ApplyCheeseOffer_NoCheeseLinesInBasket_CheeseOfferCountAt0()
        {
            basket.ApplyCheeseOffer();

            Assert.AreEqual(0, basket.Offers.Find(offer => offer.Name == AvailableOffers.BOGOFCheese.Name).AmountOfTimesApplied);
        }

        [TestMethod]
        public void ApplyCheeseOffer_OneCheeseInBasket_CheeseOfferCountAt0()
        {
            basket.Lines.Add(new BasketLine(Products.Cheese, 1));

            basket.ApplyCheeseOffer();

            Assert.AreEqual(0, basket.Offers.Find(offer => offer.Name == AvailableOffers.BOGOFCheese.Name).AmountOfTimesApplied);
        }

        [TestMethod]
        public void ApplyCheeseOffer_TwoCheeseInBasket_CheeseOfferCountAt1()
        {
            basket.Lines.Add(new BasketLine(Products.Cheese, 2));

            basket.ApplyCheeseOffer();

            Assert.AreEqual(1, basket.Offers.Find(offer => offer.Name == AvailableOffers.BOGOFCheese.Name).AmountOfTimesApplied);
        }

        [TestMethod]
        public void ApplyCheeseOffer_ThreeCheeseInBasket_CheeseOfferCountAt1()
        {
            basket.Lines.Add(new BasketLine(Products.Cheese, 3));

            basket.ApplyCheeseOffer();

            Assert.AreEqual(1, basket.Offers.Find(offer => offer.Name == AvailableOffers.BOGOFCheese.Name).AmountOfTimesApplied);
        }
        #endregion

        #region ApplySoupBreadOfferTests

        [TestMethod]
        public void ApplySoupBreadOffer_NoSoupOrBreadLinesInBasket_SoupBreadOfferCountAt0()
        {
            basket.Lines.Add(new BasketLine(Products.Milk, 5));

            basket.ApplySoupBreadOffer();

            Assert.AreEqual(0, basket.Offers.Find(offer => offer.Name == AvailableOffers.SoupAndBread.Name).AmountOfTimesApplied);
        }

        [TestMethod]
        public void ApplySoupBreadOffer_OneSoupNoBreadInBasket_SoupBreadOfferCountAt0()
        {
            basket.Lines.Add(new BasketLine(Products.Soup, 1));

            basket.ApplySoupBreadOffer();

            Assert.AreEqual(0, basket.Offers.Find(offer => offer.Name == AvailableOffers.SoupAndBread.Name).AmountOfTimesApplied);
        }

        [TestMethod]
        public void ApplySoupBreadOffer_NoSoupOneBreadInBasket_SoupBreadOfferCountAt0()
        {
            basket.Lines.Add(new BasketLine(Products.Bread, 1));

            basket.ApplySoupBreadOffer();

            Assert.AreEqual(0, basket.Offers.Find(offer => offer.Name == AvailableOffers.SoupAndBread.Name).AmountOfTimesApplied);
        }
        
        [TestMethod]
        public void ApplySoupBreadOffer_OneSoupOneBreadInBasket_SoupBreadOfferCountAt1()
        {
            basket.Lines.Add(new BasketLine(Products.Bread, 1));
            basket.Lines.Add(new BasketLine(Products.Soup, 1));

            basket.ApplySoupBreadOffer();

            Assert.AreEqual(1, basket.Offers.Find(offer => offer.Name == AvailableOffers.SoupAndBread.Name).AmountOfTimesApplied);
        }
        
        [TestMethod]
        public void ApplySoupBreadOffer_TwoSoupOneBreadInBasket_SoupBreadOfferCountAt1()
        {
            basket.Lines.Add(new BasketLine(Products.Bread, 1));
            basket.Lines.Add(new BasketLine(Products.Soup, 2));

            basket.ApplySoupBreadOffer();

            Assert.AreEqual(1, basket.Offers.Find(offer => offer.Name == AvailableOffers.SoupAndBread.Name).AmountOfTimesApplied);
        }
        #endregion

        #region ApplyButterOfferTests
        [TestMethod]
        public void ApplyButterOffer_NoButterLinesInBasket_ButterOfferCountAt0()
        {
            basket.ApplyButterOffer();

            Assert.AreEqual(0, basket.Offers.Find(offer => offer.Name == AvailableOffers.ThirdOffButter.Name).AmountOfTimesApplied);
        }

        [TestMethod]
        public void ApplyButterOffer_XNumberOfButtersInBasket_ButterOfferCountAtX()
        {
            Random r = new Random();
            var butterQuantity = r.Next(1, 100);
            basket.Lines.Add(new BasketLine(Products.Butter, butterQuantity));
            basket.ApplyButterOffer();

            Assert.AreEqual(butterQuantity, basket.Offers.Find(offer => offer.Name == AvailableOffers.ThirdOffButter.Name).AmountOfTimesApplied);
        }
        #endregion        
    }
}


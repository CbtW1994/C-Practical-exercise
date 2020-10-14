using GoodEnergyPracticalExercise.Constants;
using GoodEnergyPracticalExercise.Models;
using System.Collections.Generic;
using System;
using System.Globalization;
using System.Linq;

namespace GoodEnergyPracticalExercise
{
    class Program
    {
        static void Main()
        {
            Basket basket = new Basket();
            Console.WriteLine("Welcome, to add a product to your basket and to see your receipt, please enter one of the following options.");
            DisplayInputMessage();

            string userInput = "";
            while (userInput != "/")
            {
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        basket.AddToBasket(Products.Bread);
                        DisplayBill(basket);
                        break;
                    case "2":
                        basket.AddToBasket(Products.Milk);
                        DisplayBill(basket);
                        break;
                    case "3":
                        basket.AddToBasket(Products.Cheese);
                        DisplayBill(basket);
                        break;
                    case "4":
                        basket.AddToBasket(Products.Soup);
                        DisplayBill(basket);
                        break;
                    case "5":
                        basket.AddToBasket(Products.Butter);
                        DisplayBill(basket);
                        break;
                    default:
                        Console.WriteLine("Apologies we didn't recognise that options, please try again.");
                        break;
                }
            }
        }

        public static void DisplayBill(Basket basket)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("-------------------------");
            foreach (var line in basket.Lines)
            {
                Console.WriteLine($"{line.Product.Name} x {line.Quantity} - {line.GetLineTotal():C}");
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine($"Sub Total: {basket.GetSubTotal():C}");
            // only show offers applied section if there are any active offers impacting the total
            if (basket.Offers.Where(offer => offer.AmountOfTimesApplied > 0).Count() > 0)
            {
                Console.WriteLine("Offers Applied:");
                foreach (var offer in basket.Offers)
                {
                    if (offer.AmountOfTimesApplied > 0)
                    {
                        Console.WriteLine($"{offer.Name} x{offer.AmountOfTimesApplied} - {offer.GetTotalBasketDeduction():C}");
                    }
                }
            }

            Console.WriteLine($"Total: {basket.GetTotal():C}");
            Console.WriteLine("-------------------------");
            Console.WriteLine("");
        }
        public static void DisplayInputMessage()
        {
            Console.WriteLine("");
            Console.WriteLine($"1 = Bread - {Products.Bread.Price:C}");
            Console.WriteLine($"2 = Milk - {Products.Milk.Price:C}");
            Console.WriteLine($"3 = Cheese - {Products.Cheese.Price:C}");
            Console.WriteLine($"4 = Soup - {Products.Soup.Price:C}");
            Console.WriteLine($"5 = Butter - {Products.Butter.Price:C}");
            Console.WriteLine($"/ = Stop Program");
        }
    }
}

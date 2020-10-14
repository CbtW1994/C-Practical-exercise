using System;
using System.Collections.Generic;
using System.Text;

namespace GoodEnergyPracticalExercise.Constants
{
    public class Offer
    {
        public string Name { get; }
        
        public int AmountOfTimesApplied { get; set; }

        private decimal SingleDeductionAmount { get; set; }

        public Offer(string name, decimal singleDeductionAmount)
        {
            Name = name;
            AmountOfTimesApplied = 0;
            SingleDeductionAmount = singleDeductionAmount;
        }

        public decimal GetTotalBasketDeduction() 
        {
            return SingleDeductionAmount * AmountOfTimesApplied;
        }
    }
}

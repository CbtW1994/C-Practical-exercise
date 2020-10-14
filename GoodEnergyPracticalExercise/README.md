# Good Energy Practical Exercise - Charles Webb
Code written by Charles Webb for the Good Energy practical exercise.

# Description
This application allows you to add any number of the given products to a basket. It will also apply the following offers to the basket when the requirements are met. 
- Get a third off Butter!
- When you buy a Soup, you get a half price Bread!
- When you buy a Cheese, you get a second Cheese free!

It shows the ever growing list of items in the basket along with their respective quantities and overall prices. It provides a subtotal of the basket, along with a list of the active offers and the amount of times they have been applied. It will also calculate and show a grand total for the basket based off the subtotal and applying the total offers.

## Implementation decisions made
*All of the below implementation decisions would be queried of the product owner before beginning in a normal working scenario.*

1.  Offers were pre loaded into basket due to limited scope of exercise.
2. The cheese offer requirement was ambiguos, the second of the following options was implemented:
    - Should adding a single cheese to the basket automatically add another and then discount the second cheese
    - Should the offer only apply when 2 or more cheeses were in the basket.
3. The bread and soup Offer was ambiguous in a few ways:
    1. What should happen when you add a soup, the second of the below options was implemented:
        - Should a half price bread be automatically added to the basket
        - Should the offer only apply when at least 1 soup and one bread are in the basket
    2. What should happen if there are more soups than breads, the first of the below options was implemented:
        - Should the discount be applied based on the number of breads
        - should the discount be applied based on the number of soups

# Installation
1. Open Solution in Visual Studio 2019+

# Usage
When the application first starts you are presented with a list of products with a number allocated. In order to add a product to the basket enter the number associated with it and hit enter. In order to add more products repeat the process with the number associated with any product you wish to enter. After each product is entered you will be shown your list of products, the subtotal, applied offers, and grand total. To stop the application enter the termination character shown in the initial list and hit the neter key.

## Application
1. Open Project in Visual Studio 2019+
2. Set "GoodenergyPracticalExercise" to be startup project
3. Run the project using Visual Studio Debug tool
4. Alternatively run the .exe file located "\GoodEnergyPracticalExercise\GoodEnergyPracticalExercise\bin\Debug\netcoreapp3.1"

## Unit Tests
1. Use the Visual Studio "Test Explorer" to "Run Tests"

# Potential next steps
- Add the ability to remove things from the basket
- Allow the offers, and products to be dynamic to be dynamic
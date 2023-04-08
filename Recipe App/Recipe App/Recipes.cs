using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Linq;

namespace Recipe_App
{
    internal class Recipes
    {
        // Fields
        private string recipeName;

        private int ingredientAmount;
        private string[] ingredientNames;
        private double[] ingredientQuantity;
        private string[] ingredientUnits;
        private int stepAmount;
        private string[] stepDescriptions;
        private double scaleFactor;

        // Properties
        public int IngredientAmount { get => ingredientAmount; set => ingredientAmount = value; }

        public string[] IngredientNames { get => ingredientNames; set => ingredientNames = new string[ingredientAmount]; }
        public double[] IngredientQuantity { get => ingredientQuantity; set => ingredientQuantity = new double[ingredientAmount]; }
        public string[] IngredientUnits { get => ingredientUnits; set => ingredientUnits = new string[ingredientAmount]; }
        public int StepAmount { get => stepAmount; set => stepAmount = value; }
        public string[] StepDescriptions { get => stepDescriptions; set => stepDescriptions = new string[stepAmount]; }
        public string RecipeName { get => recipeName; set => recipeName = value; }
        public double ScaleFactor { get => scaleFactor; set => scaleFactor = value; }

        // Method to get ingredients
        public void GetIngredients()
        {
            // Prompt for recipe name
            Console.WriteLine("===== Input Ingredients =====");
            Console.Write("Enter recipe name: \t\t\t\t");
            RecipeName = Console.ReadLine();

            // Prompt for number of ingredients
            int amount = 0;
            Console.Write("How many ingredients would you like to add? \t");
            while (!int.TryParse(Console.ReadLine(), out ingredientAmount) || ingredientAmount <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
                Console.Write("How many ingredients would you like to add? ");
            }
            IngredientAmount = ingredientAmount;

            // Initialize arrays
            IngredientNames = new string[IngredientAmount];
            IngredientQuantity = new double[IngredientAmount];
            IngredientUnits = new string[IngredientAmount];

            // Store ingredients
            for (int i = 0; i < IngredientAmount; i++)
            {
                Console.WriteLine($"==== Ingredient {i + 1} ====");
                Console.Write($"Enter the name of ingredient {i + 1}: \t\t");
                IngredientNames[i] = Console.ReadLine();

                double quantity;
                Console.Write($"Enter the amount of {IngredientNames[i]}(s): \t\t\t");

                while (!double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out quantity) || quantity <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a positive number.");
                    Console.Write($"Enter the amount of {IngredientNames[i]}(s): ");
                }
                IngredientQuantity[i] = quantity;

                Console.Write($"Enter the unit of measurement for ingredient {i + 1} - {IngredientNames[i]}(s): ");
                IngredientUnits[i] = Console.ReadLine();
            }
        }

        // Method to get steps
        public void GetSteps()
        {
            Console.WriteLine("===== Input Steps =====");
            // Prompt for number of steps
            int amount;
            Console.Write("How many steps would you like to add? ");
            while (!int.TryParse(Console.ReadLine(), out stepAmount) || stepAmount <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
                Console.Write("How many steps would you like to add? ");
            }
            StepAmount = stepAmount;

            // Initialize array
            StepDescriptions = new string[StepAmount];

            // Store steps
            for (int i = 0; i < StepAmount; i++)
            {
                Console.Write($"Enter step {i + 1}: ");
                StepDescriptions[i] = Console.ReadLine();
            }
        }

        //Display Recipe
        public string displayRecipe(double scaleFactor = 1)
        {
            Console.WriteLine("===== Display =====");
            string display = "";

            // Check if there are any ingredients
            if (IngredientNames == null || IngredientNames.Length == 0)
            {
                display += "Error: No ingredients found for this recipe.\n";
                return display;
            }

            // Display recipe name
            display += $"Name: {RecipeName}\n\n";

            // Display ingredients
            display += "Ingredients:\n";
            for (int i = 0; i < IngredientAmount; i++)
            {
                display += $"{scaleFactor * IngredientQuantity[i]} {IngredientUnits[i]} {IngredientNames[i]}\n";
            }

            // Display steps
            display += "\nSteps:\n";
            for (int i = 0; i < StepAmount; i++)
            {
                display += $"{i + 1}. {StepDescriptions[i]}\n";
            }
            //Console.WriteLine(display);

            return display;
        }

        public void scaleRecipe()
        {
            Recipes recipe = new Recipes();
            string input = "";
            bool loop = true;
            double scale;
            // Ask user for scaling factor
            while (loop)
            {
                Console.Write("Would you like to Scale your ingredients? Enter the scaling amount OR oress the key 'N' to continue without scaling.");
                input = Console.ReadLine();

                //Assign the input to the scaleFactor variable
                if (input.ToUpper().Equals("N"))
                {
                    //Dont Scale
                    Console.WriteLine(displayRecipe());
                    loop = false;
                }
                else if (double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out scale))
                {
                    //Scale the recipe according to the user input
                    recipe.scaleFactor = scale;
                    Console.WriteLine(displayRecipe(recipe.scaleFactor));

                    loop = false;
                }
                else
                {
                    //error message
                    Console.WriteLine("Enter a Valid Input!!");

                    //Console.WriteLine(recipe.scaleFactor);
                }
            }
        }

        public void clearData()
        {
            // Reset all fields to their default values
            recipeName = null;
            ingredientAmount = 0;
            ingredientNames = null;
            ingredientQuantity = null;
            ingredientUnits = null;
            stepAmount = 0;
            stepDescriptions = null;
            scaleFactor = 1.0;

            Console.WriteLine("Data Was Cleared, you can create a new recipe");
        }
    }
}
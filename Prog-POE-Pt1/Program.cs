using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_POE_Pt1
{
    class Recipe
    {
        private string[] ingredients;
        private double[] quantities;
        private string[] units;
        private string[] steps;

        static public double factor;

        public Recipe()
        {
            // Initialize empty arrays for ingredients, quantities, units, and steps.
            ingredients = new string[0];
            quantities = new double[0];
            units = new string[0];
            steps = new string[0];
        }

        public void EnterDetails()
        {
            // Prompt the user to enter the number of ingredient the user wishes  to incorporate. 
            Console.Write("Enter the number of ingredients: ");
            int numIngredients = int.Parse(Console.ReadLine());

            // Initialize the arrays with the correct size for variables.
            ingredients = new string[numIngredients];   
            quantities = new double[numIngredients];
            units = new string[numIngredients];

            // Prompt the user to enter the details for each ingredient.
            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Enter name for ingredient #{i + 1}:");
                Console.Write("Name: ");
                ingredients[i] = Console.ReadLine();
                Console.Write("Quantity: ");
                quantities[i] = double.Parse(Console.ReadLine());
                Console.Write("Unit of Measurement: ");
                units[i] = Console.ReadLine();
            }

            // the user must enter the number of steps.
            Console.Write("Enter the number of steps to make the recipe: ");
            int numSteps = int.Parse(Console.ReadLine());

            // Initialize the array for steps with the correct size.
            steps = new string[numSteps];

            // Prompt the user to enter the details for each step.
            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"Enter step #{i + 1}: ");
                steps[i] = Console.ReadLine();
            }
        }
         
        public void DisplayRecipe()
        {
            // Display the ingredients and their quantities.
            Console.WriteLine("\nIngredients:");
            for (int i = 0; i < ingredients.Length; i++)
            {
                Console.WriteLine($"- {quantities[i]} {units[i]} {ingredients[i]}");
            }
             
            // Display the steps.
            Console.WriteLine("Steps:");
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine($"- {steps[i]}");
            }
        }

        public void ScaleRecipe()
        {
            // Multiply all the quantities by the scaling factor.
            for (int i = 0; i < quantities.Length; i++)
            {
                quantities[i] *= factor;
            }
        }

        public void ResetQuantities()
        {
            // Reset all the quantities to their original values.
            for (int i = 0; i < quantities.Length; i++)
            {
                quantities[i] /= factor;
            }
        }

        public void ClearRecipe()
        {
            Array.Clear(ingredients, 0, ingredients.Length);
            Array.Clear(quantities, 0, quantities.Length);
            Array.Clear(units, 0, units.Length);
            Array.Clear(steps, 0, steps.Length);
        }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            

            Recipe recipe = new Recipe();
            while (true)
            {
                Console.WriteLine("\n--------------- Main Menu ------------------");
                Console.WriteLine(" Enter '1' to enter recipe details.");
                Console.WriteLine(" Enter '2' to display recipe.");
                Console.WriteLine(" Enter '3' to scale recipe.");
                Console.WriteLine(" Enter '4' to reset quantities.");
                Console.WriteLine(" Enter '5' to clear recipe.");
                Console.WriteLine(" Enter '6' to exit.\n");


                string choice = Console.ReadLine();
                switch (choice)
                {

                    case "1":
                        recipe.EnterDetails();
                        break;
                    case "2":
                        recipe.DisplayRecipe();
                        break;
                    case "3":
                        while (true)
                        {
                            Console.Write("Enter scaling factor (0.5, 2, or 3): ");
                            factor = double.Parse(Console.ReadLine());
                            if (factor == 0.5)
                            { factor = 0.5;
                                break;
                            }
                            else if (factor == 2)
                            { factor = 2;
                                break;
                            }
                            else if (factor == 3)
                            { factor = 3;
                                break;
                            }
                            else
                            { Console.WriteLine("Invalid choice. Please enter a valid option."); }
                        }
                        recipe.ScaleRecipe();
                        break;
                    case "4":
                        recipe.ResetQuantities();
                        break;
                    case "5":
                        recipe.ClearRecipe();
                        break;
                    case "6":
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }
    }
}

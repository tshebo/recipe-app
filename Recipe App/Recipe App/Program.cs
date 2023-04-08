using Recipe_App;
using System.Xml.Serialization;

internal class Program
{
    //field
    private static string choice = "";

    private static bool loop = true;

    //static object
    private static Recipes recipe = new Recipes();

    private static Program program = new Program();

    private static void Main(string[] args)
    {
        while (loop)
        {
            choice = Menu();
            validateChoice(choice);
        }
    }

    public static string Menu()
    {
        Console.WriteLine("=============================Welcome to the recipe app choose between the provided options==============================");
        Console.WriteLine("\nWhat would you like to do?");
        Console.WriteLine("1. Add ingredients");
        Console.WriteLine("2. Add steps");
        Console.WriteLine("3. Display recipe ");
        Console.WriteLine("4. Clear Data ");
        Console.WriteLine("Any key to Exit");

        return Console.ReadLine();
    }

    public static void validateChoice(string choice)
    {
        int chosen = 0;

        if (Int32.TryParse(choice, out chosen))
        {
            if (chosen == 1)
            {
                recipe.GetIngredients();
            }
            else if (chosen == 2)
            {
                recipe.GetSteps();
            }
            else if (chosen == 3)
            {
                // Console.WriteLine(recipe.displayRecipe());
                recipe.scaleRecipe();
            }
            else if (chosen == 4)
            {
                recipe.clearData();
            }
            else
            {
                Console.WriteLine("Exiting the recipe app.");
                loop = false;
                Environment.Exit(0);
            }
        }
        else
        {
            Console.WriteLine("Exiting the recipe app.");
            loop = false;
            Environment.Exit(0);
        }
    }
}
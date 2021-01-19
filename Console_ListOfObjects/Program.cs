using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Console_ListOfObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            DisplayMenuScreen(animals);
        }

        static void DisplayMenuScreen(List<Animal> animals)
        {
            bool quitApplication = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Main Menu");

                Console.WriteLine("a) Add Animals");
                Console.WriteLine("b) Display Animals");
                Console.WriteLine("c) Save to Data File");
                Console.WriteLine("q) Quit Application");
                menuChoice = Console.ReadLine().ToLower();

                switch (menuChoice)
                {
                    case "a":
                        AddAnimals(animals);
                        break;

                    case "b":
                        DisplayAnimals(animals);
                        break;

                    case "c":
                        SaveToFile(animals);
                        break;

                    case "q":
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Please enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }
            } while (!quitApplication);
        }

        private static void DisplayAnimals(List<Animal> animals)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tDisplay Animals");
            Console.WriteLine();

            foreach (Animal animal in animals)
            {
                Console.WriteLine($"\tName: {animal.Name}");
                Console.WriteLine($"\tLegs: {animal.Leg}");
                Console.WriteLine($"\tDiet: {animal.Diets}");
                Console.WriteLine($"\tExtinct?: {animal.Status}");
            }

            Console.WriteLine("Press Enter to Exit.");
            Console.ReadKey();
        }

        private static void AddAnimals(List<Animal> animals)
        {
            Animal newAnimal = new Animal();

            Console.WriteLine();
            Console.WriteLine("\t\tAnimals Application");
            Console.WriteLine("\t\tAdd Animals to List Below!");
            Console.WriteLine();

            bool doneAdding = false;
            do
            {
                Console.Write("Name: ");
                newAnimal.Name = Console.ReadLine();
                Console.Write("Legs: ");
                newAnimal.Leg = int.Parse(Console.ReadLine());
                Console.Write("Diet (Carnivore, Herbivore, Omnivore?): ");
                Enum.TryParse(Console.ReadLine().ToLower(), out Animal.Diet diet);
                newAnimal.Diets = diet;
                Console.Write("Extinct? (true, false): ");
                newAnimal.Status = bool.Parse(Console.ReadLine());

                animals.Add(newAnimal);


                Console.Write("Add more animals?:");
                string userResponse = Console.ReadLine().ToLower();
                if (userResponse == "no")
                {
                    doneAdding = true;
                }

            } while (!doneAdding);

        }

        private static void SaveToFile(List<Animal> animals)
        {
            DisplayScreenHeader("Save animal info to data file");

            DisplayContinuePrompt();

            string[] animalsString = new string[animals.Count];

            for (int index = 0; index < animals.Count; index++)
            {
                string animalString =
                    animals[index].Name + "," +
                    animals[index].Leg + "," +
                    animals[index].Diets + "," +
                    animals[index].Status;

                animalsString[index] = animalString;
            }

            File.WriteAllLines("Data\\Data.txt", animalsString);
        }

        #region HELPER METHODS

        /// <summary>
        /// display welcome screen
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tAnimal Application");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display closing screen
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using the my Animal Application!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        #endregion
    }
}

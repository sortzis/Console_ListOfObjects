using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_ListOfObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            AddAnimals(animals);
            DisplayAnimals(animals);
        }

        private static void DisplayAnimals(List<Animal> animals)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tDisplay Animals");
            Console.WriteLine();

            foreach (Animal animal in animals)
            {
                Console.WriteLine($"Animal Name: {animal.Name}");
            }

        }

        private static void AddAnimals(List<Animal> animals)
        {
            Animal animal = new Animal();

            Console.WriteLine();
            Console.WriteLine("\t\tAnimals Application");
            Console.WriteLine("\t\tAdd Animals to List Below!");
            Console.WriteLine();

            bool doneAdding = false;
            do
            {
                Console.Write("Name: ");
                animal.Name = Console.ReadLine();
                Console.Write("Legs: ");
                animal.Leg = int.Parse(Console.ReadLine());
                Console.Write("Diet (Carnivore, Herbivore, Omnivore?): ");
                Enum.TryParse(Console.ReadLine().ToLower(), out Animal.Diet diet);
                animal.Diets = diet;

                animals.Add(animal);

                Console.Write("Add more animals?:");
                string userResponse = Console.ReadLine().ToLower();
                if (userResponse == "no")
                {
                    doneAdding = true;
                }

            } while (!doneAdding);

        }
    }
}

using System;
namespace CK
{
    public class Specie
    {
        private static Dictionary<string, List<Animal>> speciesAnimals = new();

        public static void addSpecie(string species)
        {
            if (!speciesAnimals.ContainsKey(species))
            {
                speciesAnimals[species] = new List<Animal>();
            }
            else
            {
            }
        }

        public static void AddAnimalToSpecie(string species, Animal animal)
        {
            if (speciesAnimals.ContainsKey(species))
            {
                speciesAnimals[species].Add(animal);
            }
            else
            {
                Console.WriteLine("Loài không tồn tại, vui lòng thêm loài trước.");
            }
        }

        public static void DisplaySpecies()
        {
            int i = 1;
            foreach (var specie in speciesAnimals.Keys)
            {
                Console.WriteLine($"{i}. {specie}");
                i++;
            }
        }

        public static void DisplayAnimalsBySpecie(string specie)
        {
            if (speciesAnimals.ContainsKey(specie))
            {
                Console.WriteLine($"Danh sách con vật thuộc loài {specie}:");
                foreach (var animal in speciesAnimals[specie])
                {
                    animal.displayInfo();
                }
            }
            else
            {
                Console.WriteLine($"Không có loài '{specie}' trong hệ thống.");
            }
        }

        public static List<string> GetSpeciesList()
        {
            return new List<string>(speciesAnimals.Keys);
        }

    }
}


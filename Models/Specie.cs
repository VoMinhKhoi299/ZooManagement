using System;
namespace CK
{
    public static class Specie
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

        public static void addAnimalToSpecie(string species, Animal animal)
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

        public static void displaySpecies()
        {
            int i = 1;
            foreach (var specie in speciesAnimals.Keys)
            {
                Console.WriteLine($"{i}. {specie}");
                i++;
            }
        }

        public static void displayAnimalsBySpecie(string specie)
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

        public static List<string> getSpeciesList()
        {
            return new List<string>(speciesAnimals.Keys);
        }

        public static string getSpecieIndex(int index)
        {
            string results = speciesAnimals.Keys.ElementAt(index);
            return results;
        }

        public static int getSpecieLength()
        {
            int length = speciesAnimals.Count;
            return length;
        }
    }
}


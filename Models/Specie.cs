using System;
namespace CK
{
    public static class Specie
    {
        private static Dictionary<string, List<Animal>> speciesAnimals = new();

        public static void AddSpecie(string species)
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

        public static Dictionary<string, List<Animal>> GetSpeciesAnimals()
        {
            return speciesAnimals;
        }

        public static void DisplayAnimalsBySpecie(string specie)
        {
            if (speciesAnimals.ContainsKey(specie))
            {
                Console.WriteLine($"Danh sách con vật thuộc loài {specie}:");
                foreach (var animal in speciesAnimals[specie])
                {
                    animal.DisplayInfo();
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

        public static string GetSpecieIndex(int index)
        {
            string results = speciesAnimals.Keys.ElementAt(index);
            return results;
        }

        public static int GetSpecieLength()
        {
            int length = speciesAnimals.Count;
            return length;
        }
    }
}


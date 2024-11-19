using System;
namespace CK.Managers
{
	public class SpecieManager
	{
        public static string selectOrAddSpecie()
        {
            Console.WriteLine("Loài:");
            Console.WriteLine("1. Thêm loài mới");
            List<string> species = getSpeciesList();
            for (int i = 0; i < species.Count; i++)
            {
                Console.WriteLine($"{i + 2}. {species[i]}");
            }
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                string newSpecie = GetInput("Nhập tên loài mới: ");
                addSpecie(newSpecie);
                return newSpecie;
            }
            return species[choice - 2];
        }

        public static List<string> getSpeciesList() => Specie.getSpeciesList();
        public static void addSpecie(string specie) => Specie.addSpecie(specie);
        public static void addAnimalToSpecie(string specie, Animal animal) => Specie.addAnimalToSpecie(specie, animal);

        private static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}


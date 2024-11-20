using System;
namespace CK.Managers
{
	public static class SpecieManager
	{
        public static string SelectOrAddSpecie()
        {
            Console.WriteLine("Loài:");
            Console.WriteLine("1. Thêm loài mới");
            List<string> species = GetSpeciesList();
            for (int i = 0; i < species.Count; i++)
            {
                Console.WriteLine($"{i + 2}. {species[i]}");
            }
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                string newSpecie = GetInput("Nhập tên loài mới: ");
                AddFunction.AddSpecie(newSpecie);
                return newSpecie;
            }
            return species[choice - 2];
        }

        public static List<string> GetSpeciesList() => Specie.GetSpeciesList();

        private static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}


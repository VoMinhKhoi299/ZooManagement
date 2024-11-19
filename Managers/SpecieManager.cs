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
                string newSpecie = getInput("Nhập tên loài mới: ");
                AddFunction.addSpecie(newSpecie);
                return newSpecie;
            }
            return species[choice - 2];
        }

        public static List<string> getSpeciesList() => Specie.getSpeciesList();

        private static string getInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}


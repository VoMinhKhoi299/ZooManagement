using System;
namespace CK.Managers
{
	public class CageManager
	{
        public static Cage selectOrAddCage(string specie)
        {
            Console.WriteLine("Chuồng:");
            Console.WriteLine("1. Thêm chuồng mới");
            List<string> cages = Zoo.getCageIDs();
            for (int i = 0; i < cages.Count; i++)
            {
                Console.WriteLine($"{i + 2}. {cages[i]}");
            }
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                return addCage(specie);
            }
            return Zoo.getCage(cages[choice - 2]);
        }

        private static Cage addCage(string specie)
        {
            string id = getInput("ID Chuồng: ");
            int size = int.Parse(getInput("Kích thước (m^2): "));
            int capacity = int.Parse(getInput("Sức chứa: "));
            string cleanDate = getInput("Ngày vệ sinh: ");
            Cage cage = new Cage(id, specie, size, capacity, cleanDate);
            Zoo.addCage(cage);
            return cage;
        }

        private static string getInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}


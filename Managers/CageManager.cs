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
                return AddFunction.addCage(specie);
            }
            return Zoo.getCage(cages[choice - 2]);
        }
    }
}


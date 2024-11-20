using System;
using CK.UI;

namespace CK.Managers
{
	public static class CageManager
	{
        public static Cage SelectOrAddCage(string specie)
        {
            
                Console.WriteLine("Chuồng:");
                Console.WriteLine("1. Thêm chuồng mới");
                List<string> cages = Zoo.GetCageIDs();
                for (int i = 0; i < cages.Count; i++)
                {
                    Console.WriteLine($"{i + 2}. {cages[i]}");
                }
                int choice = Input.GetIntInput("");
                if (choice == 1)
                {
                    return AddFunction.AddCage(specie);
                }
                return Zoo.GetCage(cages[choice - 2]);
            
        }
    }
}


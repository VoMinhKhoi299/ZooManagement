
using System;
using CK.Managers;

namespace CK.Functions
{
	public static class DisplayData
	{
		public static void Display()
		{
            DataDisplayAnimalManager.ManagerDisplay();
		}

		public static void DisplayCages()
		{
			List<Cage> allCages = Zoo.GetAllCages();
			foreach (var cage in allCages)
			{
				cage.DisplayCageInfo();
			}
		}

		public static void DisplaySpecies()
		{
			Dictionary<string, List<Animal>> speciesAnimals = Specie.GetSpeciesAnimals();
            int i = 1;
            foreach (var specie in speciesAnimals.Keys)
            {
                Console.WriteLine($"{i}. {specie}");
                i++;
            }
        }

		public static void DisplayAnimalsInCage(Cage cage)
		{
			List<Animal> animalsInCage = cage.GetAnimalsInCage();
			foreach(var animal in animalsInCage){
				animal.DisplayInfo();
			}
		}

		public static void DisplayAnimalsInSpecie(string specie)
		{
            if (Specie.GetSpeciesAnimals().ContainsKey(specie))
            {
                Console.WriteLine($"Danh sách con vật thuộc loài {specie}:");
                foreach (var animal in Specie.GetSpeciesAnimals()[specie])
                {
                    animal.DisplayInfo();
                }
            }
            else
            {
                Console.WriteLine($"Không có loài '{specie}' trong hệ thống.");
            }
        }

		public static void DisplayAllAnimals(List<Cage> cages)
		{
			foreach (var cage in cages)
			{
				foreach (var animal in cage.GetAnimalsInCage())
				{
					animal.DisplayInfo();
				}
			}
		}

		public static void DisplayHealthAnimal(string healthStatus, List<Cage> cages)
		{
            foreach (var cage in cages)
            {
                foreach (var animal in cage.GetAnimalsInCage())
                {
					if (animal.GetHealthStatus() == healthStatus)
					{
						Console.WriteLine($"ID: {animal.DisplayID}, Tên: {animal.DisplayName}, Trạng thái: {animal.DisplayHealth}, Ghi chú: {animal.DisplayHealthNote}");
					}
                }
            }
        }

		public static void DisplayAnimalsSince(DateTime date, List<Cage> cages)
		{
            foreach (var cage in cages)
            {
                foreach (var animal in cage.GetAnimalsInCage())
                {
                    if (animal.GetCheckedDate().Date >= date.Date)
                    {
                        Console.WriteLine($"ID: {animal.DisplayID}, Tên: {animal.DisplayName}, Trạng thái: {animal.DisplayHealth}, Ghi chú: {animal.DisplayHealthNote}");
                    }
                }
            }
        }
	}
}


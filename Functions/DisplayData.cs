
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
            if (allCages == null || allCages.Count == 0)
            {
                Console.WriteLine("Danh sách chuồng hiện tại đang trống.");
                return;
            }

            Console.WriteLine("Danh sách các chuồng:");
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
                Console.WriteLine($"{specie}");
                i++;
            }
        }

		public static void DisplayAnimalsInCage(Cage cage)
		{
            if (cage == null)
            {
                Console.WriteLine("Chuồng không tồn tại hoặc không hợp lệ.");
                return;
            }

            List<Animal> animalsInCage = cage.GetAnimalsInCage();
            if (animalsInCage == null || animalsInCage.Count == 0)
            {
                Console.WriteLine("Chuồng hiện không có động vật.");
                return;
            }

            foreach (var animal in animalsInCage)
            {
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

        public static void DisplaySortedAnimals(List<Animal> animals)
        {
            foreach (var animal in animals)
            {
                animal.DisplayInfo();
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
                        DateTime date = animal.GetCheckedDate() ?? DateTime.MinValue;
                        Console.WriteLine($"ID: {animal.GetID()}, Tên: {animal.GetName()}, Trạng thái: {animal.GetHealthStatus()}, Ghi chú: {animal.GetHealthNote()}, Ngày khám cuối: {date.Date:dd/MM/yyyy}");
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
                    DateTime curdate = animal.GetCheckedDate() ?? DateTime.MinValue; 
                    if (curdate.Date >= date.Date)
                    {
                        DateTime dateSince = animal.GetCheckedDate() ?? DateTime.MinValue;
                        Console.WriteLine($"ID: {animal.GetID()}, Tên: {animal.GetName()}, Trạng thái: {animal.GetHealthStatus()}, Ghi chú: {animal.GetHealthNote()}, Ngày khám cuối: {dateSince.Date:dd/MM/yyyy}");
                    }
                }
            }
        }
	}
}


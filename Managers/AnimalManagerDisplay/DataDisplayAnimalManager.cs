using System;
using CK.Functions;
using CK.UI;

namespace CK.Managers
{
	public static class DataDisplayAnimalManager
	{
		public static void ManagerDisplay()
		{
			while (true)
			{
				Console.WriteLine("---------------------------------------");
                Console.WriteLine("a. Hiển thị các chuồng");
                Console.WriteLine("b. Hiển thị các loài");
                Console.WriteLine("c. Hiển thị các động vật cùng loài");
                Console.WriteLine("d. Hiển thị các con vật trong một chuồng");
                Console.WriteLine("e. Hiển thị tất cả động vật");
                Console.WriteLine("X. Thoát");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("");
				string choice = Input.GetInput("Chọn: ").ToLower();
				switch (choice)
				{
					case "a":
						DisplayData.DisplayCages();
						break;
					case "b":
						DisplayData.DisplaySpecies();
						break;
					case "c":
						string specieName = Input.GetInput("Nhập tên loài: ");
						DisplayData.DisplayAnimalsInSpecie(specieName);
						break;
					case "d":
						string cageID = Input.GetInput("Nhập ID Chuồng: ");
						Cage cage = SearchFunction.SearchCageByID(cageID, Zoo.GetAllCages());
						DisplayData.DisplayAnimalsInCage(cage);
						break;
					case "e":
						DisplayData.DisplayAllAnimals(Zoo.GetAllCages());
						break;
					case "X":
						Console.WriteLine("Thoát chức năng Hiển thị thông tin");
						break;
				}
            }
		}
	}
}


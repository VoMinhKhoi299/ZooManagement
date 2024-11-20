using System;
using CK.UI;

namespace CK.Managers.AnimalManager
{
	public static class SearchAnimalManager
	{
		public static void SearchDisplay()
		{
			bool running = true;
			while (running)
			{
				Console.WriteLine("---------------------------------------");
				Console.WriteLine("a. Tìm kiếm động vật");
				Console.WriteLine("b. Tìm kiếm chuồng ");
				Console.WriteLine("X. Thoát");
				Console.WriteLine("---------------------------------------");
				Console.WriteLine("");
				string choice = Input.GetInput("Chọn: ").ToLower();
				switch (choice)
				{
					case "a":
						SearchAnimalByRequirement();
						break;
					case "b":
						SearchCageByRequirement();
						break;
					case "x":
                        running = false;
                        Console.WriteLine("Thoát chức năng Hiển thị thông tin");
                        break;

				}
			}
		}

		private static void SearchAnimalByRequirement()
		{
			while (true)
			{
				Console.WriteLine("   A. Theo ID");
                Console.WriteLine("   B. Theo Tên ");
                Console.WriteLine("   C. Theo Giới tính ");
				Console.WriteLine("   X. Thoát ");
				while (true)
				{
                    string choice = Input.GetInput("").ToLower();

                    if (choice == "a")
					{
                        string id = Input.GetInput("ID: ");
                        SearchFunction.SearchAnimalByID(id, Zoo.GetAllCages());
						break;
                    }
					else if (choice == "b")
					{
						string name = Input.GetInput("Tên: ");
						SearchFunction.SearchAnimalsByName(name, Zoo.GetAllCages());
						break;
					}
					else if (choice == "c")
					{
						string gender = Input.GetGender();
						SearchFunction.SearchAnimalByGender(gender, Zoo.GetAllCages());
						break;
					}
					else if (choice == "x")
					{
						Console.WriteLine("Thoát tìm kiếm động vật ");
						break;
					}
					else
					{
						Console.WriteLine("Vui lòng nhập lại !!");
					}
				}
                
			}
		}

		private static void SearchCageByRequirement()
		{
            Console.WriteLine("   A. Theo ID");
            Console.WriteLine("   B. Theo Loài ");
            Console.WriteLine("   X. Thoát ");
			string choice = Input.GetInput("");
			switch (choice)
			{
				case "a":
                    string id = Input.GetInput("ID: ");
                    SearchFunction.SearchCageByID(id, Zoo.GetAllCages());
					break;
				case "b":
					string specie = Input.GetInput("Loài: ");
					SearchFunction.SearchCagesBySpecie(specie, Zoo.GetAllCages());
					break;
                case "x":
                    Console.WriteLine("Thoát tìm kiếm loài ");
                    break;
            }
        }
	}
}

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
					default:
                        Console.WriteLine("Vui lòng chọn lại ");
                        break;
                }
				if (running)
				{
                    Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
                    Console.ReadKey();
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
				string choice = Input.GetInput("").ToLower();

				if (choice == "a")
				{
					string id = Input.GetInput("ID: ");
                    Animal animal = SearchFunction.SearchAnimalByIDOptimized(id);
                    if (animal == null)
                    {
                        Console.WriteLine($"Không tìm thấy động vật với ID: {id}");
                        return; // Ngăn chặn lỗi `NullReferenceException`
                    }
                    animal.DisplayInfo();
					break;
				}
				else if (choice == "b")
				{
					string name = Input.GetInput("Tên: ");
					List<Animal> results = SearchFunction.SearchAnimalsByName(name, Zoo.GetAllCages());
					foreach (Animal animal in results)
					{
						animal.DisplayInfo();
					}
					break;
				}
				else if (choice == "c")
				{
					string gender = Input.GetGender();
					List<Animal> results = SearchFunction.SearchAnimalByGender(gender, Zoo.GetAllCages());
					foreach (Animal animal in results)
					{
						animal.DisplayInfo();
					}
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

		private static void SearchCageByRequirement()
		{
            Console.WriteLine("   A. Theo ID");
            Console.WriteLine("   B. Theo Loài ");
            Console.WriteLine("   X. Thoát ");
			string choice = Input.GetInput("").ToLower();
			switch (choice)
			{
				case "a":
                    string id = Input.GetInput("ID: ");
                    Cage cage = SearchFunction.SearchCageByID(id, Zoo.GetAllCages());
					cage.DisplayCageInfo();
					break;
				case "b":
					string specie = Input.GetInput("Loài: ");
                    List<Cage> results = SearchFunction.SearchCagesBySpecie(specie, Zoo.GetAllCages());
					foreach (Cage curCage in results)
					{
						curCage.DisplayCageInfo();
					}
					break;
                case "x":
                    Console.WriteLine("Thoát tìm kiếm loài ");
                    break;
            }
        }
	}
}

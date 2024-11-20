using System;
using CK.Functions;
using CK.UI;

namespace CK.Managers
{
	public static class DataDisplayAnimalManager
	{
		public static void ManagerDisplay()
		{
            bool running = true;
			while (running)
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
                List<Animal> currentData = new(); // Lưu dữ liệu hiển thị hiện tại
                string dataType = ""; // Lưu loại dữ liệu hiển thị
                switch (choice)
				{
					case "a":
                        List<Cage> cages = Zoo.GetAllCages();
                        DisplayData.DisplayCages();
                        SortCagesMenu(cages); // Thêm menu sắp xếp cho chuồng
                        break;
                    case "b":
						DisplayData.DisplaySpecies();
						break;
					case "c":
                        string specieName = Input.GetInput("Nhập tên loài: ");
                        currentData = Specie.GetSpeciesAnimals()[specieName];
                        DisplayData.DisplayAnimalsInSpecie(specieName);
                        dataType = "animals"; // Loại dữ liệu là động vật trong loài
                        break;
                    case "d":
                        string cageID = Input.GetInput("Nhập ID Chuồng: ");
                        Cage cage = SearchFunction.SearchCageByID(cageID, Zoo.GetAllCages());
                        if (cage == null)
                        {
                            Console.WriteLine("Không tìm thấy chuồng với ID đã nhập.");
                            break;
                        }
                        currentData = cage.GetAnimalsInCage();
                        DisplayData.DisplayAnimalsInCage(cage);
                        dataType = "animals"; // Loại dữ liệu là động vật trong chuồng
                        break;
                    case "e":
                        currentData = GetAllAnimals(Zoo.GetAllCages());
                        DisplayData.DisplayAllAnimals(Zoo.GetAllCages());
                        dataType = "animals"; // Loại dữ liệu là tất cả động vật
                        break;
                    case "X":
                        running = false;
                        Console.WriteLine("Thoát chức năng Hiển thị thông tin");
                        break;
                    default:
                        Console.WriteLine("Vui lòng nhập lại.");
                        continue;
                }
                if (dataType == "animals")
                {
                    SortAnimalsMenu(currentData);
                }

                if (running)
                {
                    Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
                    Console.ReadKey();
                }
            }
		}

        public static List<Animal> GetAllAnimals(List<Cage> cages)
        {
            List<Animal> results = new();
            foreach (var cage in cages)
            {
                foreach (var animal in cage.GetAnimalsInCage())
                {
                    results.Add(animal);
                }
            }
            return results;
        }

        public static void SortAnimalsMenu(List<Animal> animals)
        {
            bool running = true;
            while (true)
            {
                Console.WriteLine("\nBạn có muốn sắp xếp danh sách động vật không?");
                Console.WriteLine("1. Sắp xếp theo tên");
                Console.WriteLine("2. Sắp xếp theo cân nặng");
                Console.WriteLine("3. Sắp xếp theo ID");
                Console.WriteLine("X. Không sắp xếp");
                string sortChoice = Input.GetInput("Chọn: ").ToLower();

                switch (sortChoice)
                {
                    case "1":
                        SortFunction.SortAnimalsByName(animals, ascending: true);
                        Console.WriteLine("Danh sách động vật đã được sắp xếp theo tên:");
                        DisplayData.DisplaySortedAnimals(animals);
                        break;
                    case "2":
                        SortFunction.SortAnimalsByWeight(animals, ascending: true);
                        Console.WriteLine("Danh sách động vật đã được sắp xếp theo cân nặng:");
                        DisplayData.DisplaySortedAnimals(animals);
                        break;
                    case "3":
                        SortFunction.SortAnimalsByID(animals);
                        Console.WriteLine("Danh sách động vật đã được sắp xếp theo ID:");
                        DisplayData.DisplaySortedAnimals(animals);
                        break;
                    case "x":
                        running = false;
                        Console.WriteLine("Không sắp xếp.");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ.");
                        break;
                }
                if (running)
                {
                    Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
                    Console.ReadKey();
                }
            }
        }

        public static void SortCagesMenu(List<Cage> cages)
        {
            Console.WriteLine("\nBạn có muốn sắp xếp danh sách chuồng không?");
            Console.WriteLine("1. Sắp xếp theo ID chuồng");
            Console.WriteLine("2. Sắp xếp theo kích thước");
            Console.WriteLine("3. Sắp xếp theo sức chứa");
            Console.WriteLine("X. Không sắp xếp");
            string sortChoice = Input.GetInput("Chọn: ").ToLower();

            switch (sortChoice)
            {
                case "1":
                    cages.Sort((c1, c2) => c1.GetCageID().CompareTo(c2.GetCageID()));
                    Console.WriteLine("Danh sách chuồng đã được sắp xếp theo ID:");
                    DisplaySortedCages(cages);
                    break;
                case "2":
                    cages.Sort((c1, c2) => c1.GetSize().CompareTo(c2.GetSize()));
                    Console.WriteLine("Danh sách chuồng đã được sắp xếp theo kích thước:");
                    DisplaySortedCages(cages);
                    break;
                case "3":
                    cages.Sort((c1, c2) => c1.GetCapacity().CompareTo(c2.GetCapacity()));
                    Console.WriteLine("Danh sách chuồng đã được sắp xếp theo sức chứa:");
                    DisplaySortedCages(cages);
                    break;
                case "x":
                    Console.WriteLine("Không sắp xếp.");
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ.");
                    break;
            }
        }

        public static void DisplaySortedCages(List<Cage> cages)
        {
            foreach (var cage in cages)
            {
                cage.DisplayCageInfo(); // Gọi phương thức hiển thị của lớp Cage
            }
        }

    }
}


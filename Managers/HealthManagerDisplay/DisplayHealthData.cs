using System;
using System.Globalization;
using CK.Functions;
using CK.UI;

namespace CK.Managers.HealthManagerDisplay
{
	public static class DisplayHealthData
	{
		public static void Display()
		{
            bool running = true;
            while (running)
            {
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("|a. Hiển thị các động vật theo sức khoẻ         |");
                Console.WriteLine("|b. Hiển thị các động vật lần cuối khám từ ngày |");
                Console.WriteLine("|c. Hiển thị các động vật cùng loài             |");
                Console.WriteLine("|d. Hiển thị các con vật trong một chuồng       |");
                Console.WriteLine("|e. Hiển thị tất cả động vật                    |");
                Console.WriteLine("|                                     X. Thoát  |");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("");
                string choice = Input.GetInput("Chọn:✎﹏ ").ToLower();
                switch (choice)
                {
                    case "a":
                        DisplayAnimalsByHealth();
                        break;
                    case "b":
                        DisplayAnimalsByLastCheckedDay();
                        break;
                    case "c":
                        string specieName = Input.GetInput("Nhập tên loài: ");
                        DisplayData.DisplayAnimalsInSpecie(specieName);
                        break;
                    case "d":
                        string cageID = Input.GetInput("Nhập ID Chuồng: ");
                        Cage cage = SearchFunction.SearchCageByID(cageID, Zoo.GetAllCages());
                        if (cage == null)
                        {
                            Console.WriteLine("Không tìm thấy chuồng với ID đã nhập.");
                            break;
                        }
                        DisplayData.DisplayAnimalsInCage(cage);
                        break;
                    case "e":
                        DisplayData.DisplayAllAnimals(Zoo.GetAllCages());
                        break;
                    case "x":
                        running = false;
                        Console.WriteLine("Thoát chức năng Hiển thị thông tin");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }
                if (running)
                {
                    Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
                    Console.ReadKey();
                }
            }
        }

        public static void DisplayAnimalsByHealth()
        {
            while (true)
            {
                string health = Input.GetInput("Nhập trạng thái sức khoẻ: ");
                DisplayData.DisplayHealthAnimal(health, Zoo.GetAllCages());
                break;
            }
        }

        public static void DisplayAnimalsByLastCheckedDay()
        {
            while (true)
            {
                string input = Input.GetInput("Nhập ngày tháng năm (dd/mm/yyyy): ");

                try
                {
                    // Chuyển đổi chuỗi input thành kiểu DateTime
                    DateTime date = DateTime.ParseExact(input, "dd/mm/yyyy", CultureInfo.InvariantCulture);
                    DisplayData.DisplayAnimalsSince(date, Zoo.GetAllCages());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Lỗi: Định dạng ngày tháng không hợp lệ!");
                }
            }
        }
    }
}


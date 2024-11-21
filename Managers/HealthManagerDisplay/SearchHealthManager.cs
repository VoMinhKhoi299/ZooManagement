using System;
using System.Globalization;
using CK.Functions;
using CK.UI;

namespace CK.Managers.HealthManagerDisplay
{
	public static class SearchHealthManager
	{
		public static void SearchHealthManagerDisplay()
		{
            bool running = true;
            while (running)
            {
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("a. Tìm kiếm động vật");
                Console.WriteLine("b. Tìm kiếm lần khám cuối ");  
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
                        SearchAnimalByLastDayChecked();
                        break;
                    case "x":
                        running = false;
                        Console.WriteLine("Thoát chức năng Tìm kiếm thông tin");
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
                Console.WriteLine("   D. Theo Trạng thái sức khoẻ ");
                Console.WriteLine("   X. Thoát ");
               
                string choice = Input.GetInput("").ToLower();

                if (choice == "a")
                {
                    string id = Input.GetInput("ID: ");
                    Animal animal = SearchFunction.SearchAnimalByIDOptimized(id);
                    animal.DisplayHealthInfo();
                    break;
                }
                else if (choice == "b")
                {
                    string name = Input.GetInput("Tên: ");
                    List<Animal> animals =  SearchFunction.SearchAnimalsByName(name, Zoo.GetAllCages());
                    foreach (var animal in animals)
                    {
                        animal.DisplayHealthInfo();
                    }
                    break;
                }
                else if (choice == "c")
                {
                    string gender = Input.GetGender();
                    SearchFunction.SearchAnimalByGender(gender, Zoo.GetAllCages());
                    break;
                }
                else if (choice == "d")
                {
                    string healthStatus = Input.GetInput("Trạng thái: ");
                    List<Animal> animals =  HealthFunction.SearchAnimalByHealthStatus(healthStatus, Zoo.GetAllCages());
                    foreach (var animal in animals)
                    {
                        animal.DisplayHealthInfo();
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

        public static void SearchAnimalByLastDayChecked()
        {
            while (true)
            {
                string input = Input.GetInput("Nhập ngày tháng năm (dd/mm/yyyy): ");

                try
                {
                    // Chuyển đổi chuỗi input thành kiểu DateTime
                    DateTime date = DateTime.ParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    List<Animal> animals = HealthFunction.SearchAnimalByLastCheckedDate(date, Zoo.GetAllCages());
                    foreach (var animal in animals)
                    {
                        animal.DisplayHealthInfo();
                    }
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


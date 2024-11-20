using System;
using CK.Functions;

namespace CK.Managers
{
    public static class AnimalManagers
    {
        public static void ManageAnimals()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("======== MENU ========");
                Console.WriteLine("----------------------");
                Console.WriteLine("1. Hiển thị dữ liệu");
                Console.WriteLine("2. Thêm động vật");
                Console.WriteLine("3. Xoá động vật");
                Console.WriteLine("4. Tìm kiếm động vật");
                Console.WriteLine("X. Thoát");
                Console.WriteLine("----------------------");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        DisplayData.Display();
                        break;
                    case "2":
                        AddFunction.AddAnimal();
                        break;
                    case "3":
                        RemoveFunction.Remove();
                        break;
                    case "4":
                        SearchFunction.SearchAnimalManager();
                        break;
                    case "x":
                        running = false;
                        Console.WriteLine("Thoát chức năng Quản lí động vật");
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
    } 
}

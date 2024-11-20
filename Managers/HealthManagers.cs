using System;
using CK.Functions;

namespace CK.Managers
{
    public static class HealthManagers
    {
        public static void ManageHealth()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("======== MENU ========");
                Console.WriteLine("----------------------");
                Console.WriteLine("1. Hiển thị dữ liệu");
                Console.WriteLine("2. Tìm kiếm động vật");
                Console.WriteLine("3. Cập nhật sức khỏe");
                Console.WriteLine("4. Cập nhật ghi chú sức khoẻ ");
                Console.WriteLine("5. Cập nhật thời gian khám tiếp theo");
                Console.WriteLine("X. Thoát");
                Console.WriteLine("----------------------");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        HealthManagerDisplay.DisplayHealthData.Display();
                        break;
                    case "2":
                        HealthManagerDisplay.SearchHealthManager.SearchHealthManagerDisplay();
                        break;
                    case "3":
                        HealthFunction.EditHealthStatus();
                        break;
                    case "4":
                        HealthFunction.EditHealthNote();
                        break;
                    case "5":
                        HealthFunction.UpdateNextCheckup();
                        break;
                    case "x":
                        running = false;
                        Console.WriteLine("Thoát chức năng Quản lý sức khỏe động vật");
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

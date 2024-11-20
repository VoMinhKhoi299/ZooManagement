using System;
using CK.Functions;
using CK.Models;

namespace CK.Managers
{
    public static class BreedingManagerDisplay
    {
        public static void ManagerBreeding()
        {
            bool continueRunning = true;
            while (continueRunning)
            {
                Console.Clear();
                Console.WriteLine("=============== MENU ===============");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("1. Thêm sự kiện giao phối");
                Console.WriteLine("2. Hiển thị tất cả sự kiện giao phối");
                Console.WriteLine("3. Thoát");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        PerformBreeding.BreedingPerform();
                        break;
                    case "2":
                        DisplayAllBreedingEvents();
                        break;
                    case "3":
                        continueRunning = false;
                        Console.WriteLine("Thoát quản lý giao phối.");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ, vui lòng thử lại.");
                        break;
                }

                if (continueRunning)
                {
                    Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
                    Console.ReadKey();
                }
            }
        }
        private static List<Breeding> breedingEvents = BreedingData.GetBreedingEvents();
        public static void DisplayAllBreedingEvents()
        {
            if (breedingEvents.Count == 0)
            {
                Console.WriteLine("Không có sự kiện giao phối nào.");
                return;
            }

            foreach (var breeding in breedingEvents)
            {
                breeding.DisplayBreedingInfo();
            }
        }
    }
}

using System;
namespace CK.Managers
{
    public class AnimalManager
    {
        public static void ManageAnimals()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("1. Hiển thị dữ liệu");
                Console.WriteLine("2. Thêm động vật");
                Console.WriteLine("3. Xoá động vật");
                Console.WriteLine("4. Sắp xếp động vật");
                Console.WriteLine("5. Tìm kiếm động vật");
                Console.WriteLine("6. Xoá");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        break;
                    case 2:
                        AddFunction.addAnimal();
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        running = false;
                        Console.WriteLine("Thoát chương trình.");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }
            }
        }
    } 
}

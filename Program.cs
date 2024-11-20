using System;
using System.Collections.Generic;
using CK.Managers;

namespace CK
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("--  Z O O      M A N A G E M E N T --");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("========== Quản lý ========== ");
                Console.WriteLine("| 1. Quản lý động vật");
                Console.WriteLine("| 2. Quản lý sức khoẻ động vật");
                Console.WriteLine("| 3. Quản lý giao phối động vật");
                Console.WriteLine("| 4. Thoát chương trình ");
                int choice = int.Parse(Console.ReadLine());
                Cage CH001 = new Cage("CH001", "DEMO", 5, 10, "20/11/2024");
                Cage CH002 = new Cage("CH002", "SUB-DEMO", 10, 7, "19/1/2025");
                Zoo.AddCage(CH001);
                Zoo.AddCage(CH002);
                Animal demo1 = new Animal("DEMO001", "demo1", "Male", "DEMO", 70, 4, "Good", "", "", "CH001", "29/09/2005");
                Animal demo2 = new Animal("DEMO002", "demo2", "Female", "DEMO", 30, 3, "Good", "", "", "CH001", "22/07/2005");
                Animal demo3 = new Animal("DEMO003", "demo3", "Male", "SUB-DEMO", 55, 1, "Normal", "", "", "CH002", "24/09/2005");
                Animal demo4 = new Animal("DEMO004", "demo4", "Female", "DEMO", 26, 6, "Bad", "", "", "CH001", "19/05/2005");
                Animal demo5 = new Animal("DEMO005", "demo5", "Male", "SUB-DEMO", 10, 2, "Bad", "", "", "CH002", "01/01/1997");
                CH001.AddAnimalIntoCage(demo1);
                CH001.AddAnimalIntoCage(demo2);
                CH001.AddAnimalIntoCage(demo4);
                CH002.AddAnimalIntoCage(demo3);
                CH002.AddAnimalIntoCage(demo5);
                Specie.AddSpecie("DEMO");
                Specie.AddSpecie("SUB-DEMO");
                Specie.AddAnimalToSpecie("DEMO", demo1);
                Specie.AddAnimalToSpecie("DEMO", demo2);
                Specie.AddAnimalToSpecie("DEMO", demo4);
                Specie.AddAnimalToSpecie("SUB-DEMO", demo3);
                Specie.AddAnimalToSpecie("SUB-DEMO", demo5);

                SearchFunction.BuildAnimalLookup();

                switch (choice)
                {
                    case 1:
                        AnimalManagers.ManageAnimals();
                        break;
                    case 2:
                        HealthManagers.ManageHealth();
                        break;
                    case 3:
                        BreedingManagerDisplay.ManagerBreeding();
                        break;
                    case 4:
                        Console.WriteLine("Hẹn gặp lại !!! ");
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

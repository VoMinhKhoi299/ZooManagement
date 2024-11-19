using System;
using System.Collections.Generic;
using CK.UI;

namespace CK
{
    public static class RemoveFunction
    {
        public static void Remove()
        {
            Console.WriteLine("a. Xoá động vật ");
            Console.WriteLine("b. Xoá loài ");
            Console.WriteLine("c. Thoát ");
            string choice = Input.GetInput("");
            while(true)
            {
                if (choice == "a")
                {
                    string id = Input.GetInput("Nhập ID con vật cần xoá: ");
                    RemoveAnimalByID(id);
                    break;
                }
                else if (choice == "b")
                {
                    string specieName = Input.GetInput("Nhập tên loài cần xoá: ");
                    RemoveSpecie(specieName);
                    break;
                }
                else if (choice == "c")
                {
                    Console.WriteLine("Thoát chức năng xoá động vật ");
                    break;
                }
                else
                {
                    Console.WriteLine("Vui lòng chọn lại !!");
                }
            }
        }

        public static void RemoveAnimalByID(string ID)
        {
            if (string.IsNullOrEmpty(ID))
            {
                throw new ArgumentException("ID không thể để trống.", nameof(ID));
            }
            Animal animal = SearchFunction.SearchAnimalByID(ID, Zoo.GetAllCages());
            string specie = animal.GetSpecie();
            Cage cage = SearchFunction.SearchCageByAnimalID(ID);

            while (true)
            {
                string choice = Input.GetInput("Xác nhận thao tác ? (Yes/No)").ToLower();
                if (choice == "yes")
                {
                    cage.GetAnimalsInCage().Remove(animal);
                    Console.WriteLine($"Đã xoá {animal.GetID}, {animal.GetName()}");
                    break;
                }
                else if (choice == "no")
                {
                    Console.WriteLine("Đã hoàn tác");
                    break;
                }
                else
                {
                    Console.WriteLine("Yes/No. Vui lòng nhập lại");
                    break;
                }
            }
        }

        public static void RemoveSpecie(string specieName)
        {
            if (string.IsNullOrEmpty(specieName))
            {
                throw new ArgumentException("Tên loài không thể để trống hoặc rỗng.", nameof(specieName));
            }

            if (Specie.GetSpeciesAnimals().ContainsKey(specieName))
            {
                while (true)
                {
                    string choice = Input.GetInput("Bạn sẽ xoá tất cả các con vật thuộc loài này !!. Xác nhận thao tác ? (Yes/No)").ToLower();
                    if (choice == "yes")
                    {
                        Specie.GetSpeciesAnimals().Remove(specieName);

                        Console.WriteLine($"Đã xóa loài '{specieName}' và tất cả động vật thuộc loài này.");
                        break;
                    }
                    else if (choice == "no")
                    {
                        Console.WriteLine("Đã hoàn tác");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Yes/No. Vui lòng nhập lại");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine($"Loài '{specieName}' không tồn tại.");
            }
        }
    }
}

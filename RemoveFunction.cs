using System;
using System.Collections.Generic;
using System.Linq;

namespace CK
{
    public static class RemoveFunction
    {
        // Xóa động vật theo loài
        public static void RemoveAnimalBySpecie(List<Animal> animals, string specieName)
        {
            // Sử dụng SearchFunction để tìm động vật
            var animalsToRemove = animals.Where(a => a.Specie.Name == specieName).ToList();

            if (animalsToRemove.Count > 0)
            {
                Console.WriteLine($"Tìm thấy {animalsToRemove.Count} động vật thuộc loài {specieName}:");
                foreach (var animal in animalsToRemove)
                {
                    Console.WriteLine($"- ID: {animal.ID}, Tên: {animal.Name}");
                }

                Console.WriteLine("Bạn có chắc muốn xóa toàn bộ động vật thuộc loài này? (y/n):");
                string confirm = Console.ReadLine();
                if (confirm.ToLower() == "y")
                {
                    foreach (var animal in animalsToRemove)
                    {
                        animals.Remove(animal);
                    }
                    Console.WriteLine($"Đã xóa toàn bộ động vật thuộc loài {specieName}.");
                }
                else
                {
                    Console.WriteLine("Hủy xóa động vật.");
                }
            }
            else
            {
                Console.WriteLine($"Không tìm thấy động vật thuộc loài {specieName}.");
            }
        }

        // Xóa chuồng
        public static void RemoveCage(List<Cage> cages, List<Animal> animals, string cageID)
        {
            // Sử dụng SearchFunction để tìm chuồng
            var cageToRemove = cages.FirstOrDefault(c => c.ID == cageID);

            if (cageToRemove != null)
            {
                // Kiểm tra xem chuồng có động vật hay không
                var animalsInCage = SearchFunction.searchByID(animals, cageID); // Gọi searchByID để tìm động vật trong chuồng

                if (cageToRemove.CurrentAnimals.Count > 0 || animalsInCage.Count > 0)
                {
                    Console.WriteLine($"Chuồng {cageID} hiện đang chứa động vật. Không thể xóa.");
                    return;
                }

                cages.Remove(cageToRemove);
                Console.WriteLine($"Đã xóa chuồng {cageID}.");
            }
            else
            {
                Console.WriteLine($"Không tìm thấy chuồng với ID: {cageID}");
            }
        }
    }
}

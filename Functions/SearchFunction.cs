using System;
using System.Collections.Generic;
using System.Xml.Linq;
using CK.Managers.AnimalManager;

namespace CK
{
    public static class SearchFunction
    {
        public static void SearchAnimalManager()
        {
            Managers.AnimalManager.SearchAnimalManager.SearchDisplay();
        }

        public static void SearchHealthManager()
        {
            Managers.HealthManagerDisplay.SearchHealthManager.SearchHealthManagerDisplay();
        }

        // Thêm bảng tra cứu
        private static Dictionary<string, Animal> animalLookup = new();

        // Xây dựng bảng tra cứu động vật từ danh sách chuồng
        public static void BuildAnimalLookup()
        {
            animalLookup.Clear(); // Xóa bảng cũ để đảm bảo đồng bộ
            foreach (var cage in Zoo.GetAllCages())
            {
                foreach (var animal in cage.GetAnimalsInCage())
                {
                    if (!animalLookup.ContainsKey(animal.GetID()))
                        animalLookup[animal.GetID()] = animal;
                }
            }
        }

        // Tìm kiếm động vật theo ID với tra cứu nhanh
        public static Animal SearchAnimalByIDOptimized(string id)
        {
            id = id.Trim();
            if (animalLookup.Count == 0)
            {
                Console.WriteLine("Bảng tra cứu rỗng. Vui lòng xây dựng bảng tra cứu trước khi tìm kiếm.");
                return null;
            }

            if (string.IsNullOrEmpty(id))
            {
                Console.WriteLine("Lỗi: ID không được để trống.");
                return null;
            }

            if (animalLookup.TryGetValue(id, out var animal))
            {
                return animal;
            }

            Console.WriteLine($"Không tìm thấy động vật với ID: {id}");
            return null;
        }

        public static Animal SearchAnimalByID(string id, List<Cage> cages)
        {
            if (string.IsNullOrEmpty(id))
            {
                Console.WriteLine("Lỗi: ID không được để trống.");
                return null;
            }
            if (cages == null || cages.Count == 0)
            {
                Console.WriteLine("Lỗi: Danh sách chuồng trống hoặc không tồn tại.");
                return null;
            }
            foreach (var cage in cages)
            {
                foreach (var animal in cage.GetAnimalsInCage())
                {
                    if (animal.GetID() == id)
                    {
                        if (animal != null) return animal;
                    }
                   
                }
            }

            Console.WriteLine($"Không tìm thấy động vật với ID: {id}");
            return null;
        }

        // Tìm động vật theo tên (Tìm kiếm tuần tự, không phân biệt hoa thường)
        public static List<Animal> SearchAnimalsByName(string name, List<Cage> cages)
        {
            var result = new List<Animal>();
            foreach (var cage in cages)
            {
                foreach (var animal in cage.GetAnimalsInCage())
                {
                    if (animal.GetName().Equals(name, StringComparison.OrdinalIgnoreCase))
                    {
                        result.Add(animal);
                    }
                }
            }
            if (result.Count == 0)
                Console.WriteLine($"Không tìm thấy động vật với tên: {name}");
            return result;
        }

        //Tìm động vật theo giới tính
        public static List<Animal> SearchAnimalByGender(string gender, List<Cage> cages) {
            var result = new List<Animal>();
            foreach (var cage in cages)
            {
                foreach (var animal in cage.GetAnimalsInCage())
                {
                    if (animal.GetGender().Equals(gender, StringComparison.OrdinalIgnoreCase))
                    {
                        result.Add(animal);
                    }
                }
            }
            if (result.Count == 0) Console.WriteLine($"Không tìm thấy động vật có giới tính: {gender}");
            return result;
        }

       

        // Tìm chuồng theo ID (Tìm kiếm nhị phân)
        public static Cage SearchCageByID(string id, List<Cage> cages)
        {
            if (cages == null || cages.Count == 0)
            {
                Console.WriteLine("Danh sách chuồng trống.");
                return null;
            }

            // Sắp xếp danh sách chuồng trước khi tìm kiếm nhị phân
            cages.Sort((c1, c2) => c1.GetCageID().CompareTo(c2.GetCageID()));

            int left = 0, right = cages.Count - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                string midCageID = cages[mid].GetCageID();

                if (midCageID.Equals(id, StringComparison.OrdinalIgnoreCase))
                {
                    return cages[mid]; // Tìm thấy chuồng
                }
                else if (string.Compare(midCageID, id, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    left = mid + 1; // Tìm bên phải
                }
                else
                {
                    right = mid - 1; // Tìm bên trái
                }
            }

            Console.WriteLine($"Không tìm thấy chuồng với ID: {id}");
            return null; // Không tìm thấy chuồng
        }


        // Tìm chuồng theo loài (Tìm kiếm tuần tự)
        public static List<Cage> SearchCagesBySpecie(string specie, List<Cage> cages)
        {
            var result = new List<Cage>();
            foreach (var cage in cages)
            {
                if (cage.GetSpecieName().Equals(specie, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(cage);
                }
            }
            if (result.Count == 0)
                Console.WriteLine($"Không tìm thấy chuồng nào cho loài: {specie}");
            return result;
        }

        public static Cage SearchCageByAnimalID(string animalID)
        {
            if (string.IsNullOrEmpty(animalID))
                throw new ArgumentException("Animal ID cannot be null or empty.", nameof(animalID));
            foreach (var cage in Zoo.GetAllCages())
            {
                foreach (var animal in cage.GetAnimalsInCage())
                {
                    if (animal.GetID() == animalID)
                    {
                        return cage; 
                    }
                }
            }

            return null;
        }

        // Tìm tất cả động vật trong một loài (Kết hợp tuần tự)
        public static List<Animal> SearchAnimalsBySpecie(string specie, List<Cage> cages)
        {
            var result = new List<Animal>();
            foreach (var cage in cages)
            {
                if (cage.GetSpecieName().Equals(specie, StringComparison.OrdinalIgnoreCase))
                {
                    result.AddRange(cage.GetAnimalsInCage());
                }
            }
            if (result.Count == 0)
                Console.WriteLine($"Không tìm thấy động vật nào cho loài: {specie}");
            return result;
        }

        // In kết quả tìm kiếm động vật
        public static void PrintAnimalSearchResult(List<Animal> animals)
        {
            if (animals == null || animals.Count == 0)
            {
                Console.WriteLine("Không có kết quả.");
                return;
            }

            Console.WriteLine("Kết quả tìm kiếm động vật:");
            foreach (var animal in animals)
            {
                Console.WriteLine($"- {animal.GetName()} (ID: {animal.GetID()}, Loài: {animal.GetSpecie()}, Chuồng: {animal.GetCageID()})");
            }
        }

        // In kết quả tìm kiếm chuồng
        public static void PrintCageSearchResult(List<Cage> cages)
        {
            if (cages == null || cages.Count == 0)
            {
                Console.WriteLine("Không có kết quả.");
                return;
            }

            Console.WriteLine("Kết quả tìm kiếm chuồng:");
            foreach (var cage in cages)
            {
                Console.WriteLine($"- Mã chuồng: {cage.GetCageID()}, Loài: {cage.GetSpecieName()}");
            }
        }

        internal static Cage SearchCageByID(string cageID)
        {
            throw new NotImplementedException();
        }
    }
}

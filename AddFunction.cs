using System;
namespace CK
{
    public static class AddFunction
    {
        public static void AddSpecie(List<Specie> speciesList, string name, string habitat, int avgAge)
        {
            // Kiểm tra xem loài đã tồn tại chưa
            var existingSpecie = speciesList.FirstOrDefault(s => s.Name == name);
            if (existingSpecie == null)
            {
                Specie newSpecie = new Specie(name, habitat, avgAge);
                speciesList.Add(newSpecie);
                Console.WriteLine($"Đã thêm loài mới: {name}");
            }
            else
            {
                Console.WriteLine("Loài này đã tồn tại.");
            }
        }

        public static void AddCage(List<Cage> cagesList, double size, int capacity, string type, string cleaningSchedule)
        {
            Cage newCage = new Cage(size, capacity, type, cleaningSchedule);
            cagesList.Add(newCage);
            Console.WriteLine($"Đã thêm chuồng mới: {newCage.ID}");
        }

        public static void AddAnimal(
            List<Animal> animalsList, 
            List<Cage> cagesList, 
            string name, 
            string gender, 
            Specie specie, 
            double weight, 
            string healthStatus)
        {
            // Tìm chuồng phù hợp
            var suitableCages = cagesList.Where(c => c.Type == specie.Name && c.HasSpace()).ToList();

            if (suitableCages.Count > 0)
            {
                Console.WriteLine("Danh sách chuồng phù hợp:");
                for (int i = 0; i < suitableCages.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {suitableCages[i].ID} (Sức chứa còn: {suitableCages[i].RemainingCapacity()})");
                }

                Console.WriteLine("Chọn chuồng (nhập số):");
                int cageIndex = int.Parse(Console.ReadLine()) - 1;
                Cage selectedCage = suitableCages[cageIndex];

                Animal newAnimal = new Animal(name, specie, gender, weight, healthStatus, selectedCage);
                animalsList.Add(newAnimal);
                selectedCage.AddAnimal(newAnimal);

                Console.WriteLine($"Đã thêm động vật: {newAnimal.Name} (ID: {newAnimal.ID}) vào chuồng {selectedCage.ID}");
            }
            else
            {
                Console.WriteLine("Không có chuồng nào phù hợp. Yêu cầu thêm chuồng mới.");
            }
        }
    }
}

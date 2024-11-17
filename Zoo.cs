using System;
using System.Collections.Generic;
using System.Linq;

namespace CK
{
    public class Zoo
    {
        public List<Cage> Cages { get; set; }
        public List<Animal> Animals { get; set; }
        public List<Specie> Species { get; set; }

        public Zoo()
        {
            Cages = new List<Cage>();
            Animals = new List<Animal>();
            Species = new List<Specie>();
        }

        // Hiển thị danh sách động vật
        public void DisplayAnimals()
        {
            Console.WriteLine("Danh sách động vật trong sở thú:");
            foreach (var animal in Animals)
            {
                Console.WriteLine($"- ID: {animal.ID}, Tên: {animal.Name}, Loài: {animal.Specie.Name}, Chuồng: {animal.AssignedCage.ID}");
            }
        }

        // Hiển thị danh sách chuồng
        public void DisplayCages()
        {
            Console.WriteLine("Danh sách chuồng trong sở thú:");
            foreach (var cage in Cages)
            {
                Console.WriteLine($"- ID: {cage.ID}, Loại chuồng: {cage.Type}, Sức chứa: {cage.Capacity}, Đang chứa: {cage.CurrentAnimals.Count}");
            }
        }

        // Hiển thị danh sách loài
        public void DisplaySpecies()
        {
            Console.WriteLine("Danh sách các loài trong sở thú:");
            foreach (var specie in Species)
            {
                Console.WriteLine($"- Loài: {specie.Name}, Môi trường sống: {specie.Habitat}, Tuổi thọ trung bình: {specie.AvgAge}");
            }
        }

        // Gọi chức năng thêm động vật
        public void AddAnimalInteractive()
        {
            Console.WriteLine("Chức năng thêm động vật bắt đầu...");
            Console.WriteLine("Vui lòng nhập các thông tin cần thiết:");

            Console.WriteLine("Nhập tên động vật:");
            string name = Console.ReadLine();

            Console.WriteLine("Nhập giới tính (1. Male, 2. Female):");
            string gender = Console.ReadLine() == "1" ? "Male" : "Female";

            // Chọn loài
            Console.WriteLine("Chọn loài:");
            for (int i = 0; i < Species.Count; i++)
            {
                Console.WriteLine($"{i + 2}. {Species[i].Name}");
            }
            Console.WriteLine("1. Thêm loài mới");
            int choice = int.Parse(Console.ReadLine());

            Specie selectedSpecie;
            if (choice == 1)
            {
                Console.WriteLine("Nhập tên loài:");
                string specieName = Console.ReadLine();

                Console.WriteLine("Nhập môi trường sống (1. Trên cạn, 2. Dưới nước, 3. Trên cây):");
                string habitat = Console.ReadLine() switch
                {
                    "1" => "Trên cạn",
                    "2" => "Dưới nước",
                    "3" => "Trên cây",
                    _ => "Trên cạn"
                };

                Console.WriteLine("Nhập tuổi thọ trung bình của loài:");
                int avgAge = int.Parse(Console.ReadLine());

                AddFunction.AddSpecie(Species, specieName, habitat, avgAge);
                selectedSpecie = Species.Last(); // Lấy loài vừa thêm
            }
            else
            {
                selectedSpecie = Species[choice - 2];
            }

            Console.WriteLine("Nhập cân nặng (kg):");
            double weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Nhập trạng thái (1. Khỏe mạnh, 2. Mang thai):");
            string healthStatus = Console.ReadLine() == "1" ? "Khỏe mạnh" : "Mang thai";

            // Thêm động vật
            AddFunction.AddAnimal(Animals, Cages, name, gender, selectedSpecie, weight, healthStatus);
        }

        // Gọi chức năng thêm chuồng
        public void AddCageInteractive()
        {
            Console.WriteLine("Chức năng thêm chuồng bắt đầu...");
            Console.WriteLine("Vui lòng nhập các thông tin cần thiết:");

            Console.WriteLine("Nhập diện tích (m^2):");
            double size = double.Parse(Console.ReadLine());

            Console.WriteLine("Nhập sức chứa tối đa:");
            int capacity = int.Parse(Console.ReadLine());

            Console.WriteLine("Nhập loại chuồng:");
            string type = Console.ReadLine();

            Console.WriteLine("Nhập lịch vệ sinh chuồng (dd/MM/yyyy):");
            string cleaningSchedule = Console.ReadLine();

            AddFunction.AddCage(Cages, size, capacity, type, cleaningSchedule);
        }
    }
}

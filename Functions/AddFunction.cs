using System;
using CK.Managers;

namespace CK
{
    public static class AddFunction
    {
        public static void addAnimal()
        {
            string id = getInput("ID: ");
            string name = getInput("Tên: ");
            string gender = getGender();
            string specie = SpecieManager.selectOrAddSpecie();
            double weight = double.Parse(getInput("Cân nặng: "));
            int age = int.Parse(getInput("Tuổi: "));
            string health = getInput("Trạng thái: ");
            (string fatherID, string motherID) = getParentsInfo();
            Cage cage = CageManager.selectOrAddCage(specie);

            Animal animal = new Animal(id, name, gender, specie, weight, age, health, fatherID, motherID, cage.getCageID());
            addAnimalToSpecie(specie, animal);
            cage.addAnimalIntoCage(animal);

            Console.WriteLine("Thêm động vật thành công!");
        }

        private static string getGender()
        {
            Console.WriteLine("Giới tính:");
            Console.WriteLine("1. Male");
            Console.WriteLine("2. Female");
            Console.WriteLine("3. Other");
            int choice = int.Parse(Console.ReadLine());
            return choice switch
            {
                1 => "Male",
                2 => "Female",
                3 => "Other",
                _ => throw new Exception("Lựa chọn không hợp lệ!")
            };
        }

        private static (string, string) getParentsInfo()
        {
            Console.WriteLine("Nhập Cha/Mẹ (Yes/No): ");
            string option = Console.ReadLine()?.ToLower();
            if (option == "yes")
            {
                string fatherID = getInput("ID Cha: ");
                string motherID = getInput("ID Mẹ: ");
                return (fatherID, motherID);
            }
            return ("Không có", "Không có");
        }

        private static string getInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public static void addSpecie(string specie) => Specie.addSpecie(specie);

        public static void addAnimalToSpecie(string specie, Animal animal) => Specie.addAnimalToSpecie(specie, animal);

        public static Cage addCage(string specie)
        {
            string id = getInput("ID Chuồng: ");
            int size = int.Parse(getInput("Kích thước (m^2): "));
            int capacity = int.Parse(getInput("Sức chứa: "));
            string cleanDate = getInput("Ngày vệ sinh: ");
            Cage cage = new Cage(id, specie, size, capacity, cleanDate);
            Zoo.addCage(cage);
            return cage;
        }
    }
}

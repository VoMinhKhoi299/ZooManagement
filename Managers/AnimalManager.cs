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
                Console.WriteLine("1. Thêm động vật");
                Console.WriteLine("2. Thoát");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddAnimal();
                        break;
                    case 2:
                        running = false;
                        Console.WriteLine("Thoát chương trình.");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }
            }
        }

        private static void AddAnimal()
        {
            string id = GetInput("ID: ");
            string name = GetInput("Tên: ");
            string gender = GetGender();
            string specie = SpecieManager.selectOrAddSpecie();
            double weight = double.Parse(GetInput("Cân nặng: "));
            int age = int.Parse(GetInput("Tuổi: "));
            string health = GetInput("Trạng thái: ");
            (string fatherID, string motherID) = GetParentsInfo();
            Cage cage = CageManager.selectOrAddCage(specie);

            Animal animal = new Animal(id, name, gender, specie, weight, age, health, fatherID, motherID, cage.getCageID());
            SpecieManager.addAnimalToSpecie(specie, animal);
            cage.addAnimalIntoCage(animal);

            Console.WriteLine("Thêm động vật thành công!");
        }

        private static string GetGender()
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

        private static (string, string) GetParentsInfo()
        {
            Console.WriteLine("Nhập Cha/Mẹ (Yes/No): ");
            string option = Console.ReadLine()?.ToLower();
            if (option == "yes")
            {
                string fatherID = GetInput("ID Cha: ");
                string motherID = GetInput("ID Mẹ: ");
                return (fatherID, motherID);
            }
            return ("Không có", "Không có");
        }

        private static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}

using System;
using CK.Managers;
using CK.UI;

namespace CK
{
    public static class AddFunction
    {
        public static void AddAnimal()
        {
            string id;
            while (true)
            {
                id = Input.GetInput("ID: ");
                if (!string.IsNullOrEmpty(id) && Zoo.GetAllCages().SelectMany(c => c.GetAnimalsInCage()).All(a => a.GetID() != id))
                    break;
                Console.WriteLine("Lỗi: ID không hợp lệ hoặc đã tồn tại.");
            }

            string name = Input.GetInput("Tên: ");
            string gender = Input.GetGender();
            string specie = SpecieManager.SelectOrAddSpecie();
            double weight = Input.GetDoubleInput("Cân nặng: ");
            int age = Input.GetIntInput("Tuổi: ");

            string health = Input.GetInput("Trạng thái: ");
            (string fatherID, string motherID) = Input.GetParentsInfo();
            string modifiedDate = Input.GetInput("Ngày tháng năm sinh (nếu có): ");
            Cage cage;

            while (true)
            {
                cage = CageManager.SelectOrAddCage(specie);
                if (cage.GetAnimalsInCage().Count < cage.GetCapacity())
                    break;
                Console.WriteLine("Lỗi: Chuồng đã đầy. Vui lòng chọn chuồng khác.");
            }

            Animal animal = new Animal(id, name, gender, specie, weight, age, health, fatherID, motherID, cage.GetCageID(), modifiedDate);
            cage.AddAnimalIntoCage(animal);
            Specie.AddAnimalToSpecie(specie, animal);
            Console.WriteLine("Thêm động vật thành công!");
        }

        public static void AddSpecie(string specie) => Specie.AddSpecie(specie);

        public static void AddAnimalToSpecie(string specie, Animal animal) => Specie.AddAnimalToSpecie(specie, animal);

        public static Cage AddCage(string specie)
        {
            return Input.GetCageInfo(specie);
        }
    }
}

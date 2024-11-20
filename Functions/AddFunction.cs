using System;
using CK.Managers;
using CK.UI;

namespace CK
{
    public static class AddFunction
    {
        public static void AddAnimal()
        {
            string id = Input.GetInput("ID: ");
            string name = Input.GetInput("Tên: ");
            string gender = Input.GetGender();
            string specie = SpecieManager.SelectOrAddSpecie();
            double weight = double.Parse(Input.GetInput("Cân nặng: "));
            int age = int.Parse(Input.GetInput("Tuổi: "));
            string health = Input.GetInput("Trạng thái: ");
            (string fatherID, string motherID) = Input.GetParentsInfo();
            Cage cage;
            Animal animal;
            while (true)
            {
                cage = CageManager.SelectOrAddCage(specie);
                animal = new Animal(id, name, gender, specie, weight, age, health, fatherID, motherID, cage.GetCageID());
                if (!cage.AddAnimalIntoCage(animal))
                {
                    Console.WriteLine("Chọn chuồng khác ");
                }
                else
                {
                    break;
                }
            }

            Specie.AddAnimalToSpecie(specie, animal);
            
            Zoo.AddCage(cage);
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

using System;
namespace CK
{
	public class Animal
	{
        public string name { get; set; }
        public string ID { get; private set; }
        public Specie species { get; set; }
        public string gender { get; set; }
        public double weight { get; set; }
        public int age { get; set; }
        public Cage cage { get; set; }
        public int AnimalCount { get; set; }

        public Animal(string name, Specie species, string gender, double weight, int age, Cage cage)
        {
            this.name = name;
            this.species = species;
            this.gender = gender;
            this.weight = weight;
            this.age = age;
            this.cage = cage;
            // ID = 23CH001001 : 23-Năm thêm vào chuồng + CH001- Mã chuồng + 001-Số thứ tự tạo tự động khi được thêm v
        }


        public void displayInfo()
        {
            Console.WriteLine($"Con vat: {name}, ID: {ID}, Gioi tinh: {gender}, Can nang: {weight}kg, Tuoi: {age} nam");
            Console.WriteLine($"Chuong: {cage.cageID}");
        }

        public string getID()
        {
            return this.ID;
        }

        public string getGender()
        {
            return this.gender;
        }

        public string getName()
        {
            return this.name;
        }
    }
}


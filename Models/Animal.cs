using System;
namespace CK
{
    public class Animal
    {
        public string name { get; set; }
        public string ID { get; private set; }
        public string specie { get; set; }
        public string gender { get; set; }
        public double weight { get; set; }
        public int age { get; set; }
        public string health;
        public string fatherID;
        public string motherID;
        public string cageID { get; set; }


        public Animal(string ID, string name, string gender, string species, double weight, int age, string health, string fatherID, string motherID, string cageID)
        {
            this.ID = ID;
            this.name = name;
            this.specie = species;
            this.gender = gender;
            this.weight = weight;
            this.age = age;
            this.health = health;
            this.fatherID = fatherID;
            this.motherID = motherID;
            this.cageID = cageID;
        }


        public void DisplayInfo()
        {
            Console.WriteLine($"Con vat: {name}, ID: {ID}, Gioi tinh: {gender}, Can nang: {weight}kg, Tuoi: {age} nam");
            Console.WriteLine($"Chuong: {cageID}");
        }

        public string GetID()
        {
            return this.ID;
        }

        public string GetGender()
        {
            return this.gender;
        }

        public string GetName()
        { 
            return this.name;
        }

        public string GetSpecie()
        {
            return this.specie;
        }

        public string GetCageID()
        {
            return this.cageID;
        }
    }
}


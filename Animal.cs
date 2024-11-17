using System;
namespace CK
{
	public class Animal
	{
        public string Name { get; set; }
        public string ID { get; private set; }
        public Specie Species { get; set; }
        public string Gender { get; set; }
        public double Weight { get; set; }
        public int Age { get; set; }
        public Cage Cage { get; set; }

        public Animal(string name, Specie species, string gender, double weight, int age, Cage cage)
        {
            Name = name;
            Species = species;
            Gender = gender;
            Weight = weight;
            Age = age;
            Cage = cage;
            ID = CreateID(species.Name, cage.CageID);
        }

        private string CreateID(string speciesType, string cageID)
        {
            return $"23{speciesType.Substring(0, 2).ToUpper()}{cageID}";
        }

        public void DisplayAnimalInfo()
        {
            Console.WriteLine($"Con vat: {Name}, ID: {ID}, Gioi tinh: {Gender}, Can nang: {Weight}kg, Tuoi: {Age} nam");
            Console.WriteLine($"Chuong: {Cage.CageID}");
            Species.DisplaySpecieInfo();
        }
    }
}


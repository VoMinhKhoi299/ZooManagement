using System;
using System.Collections.Generic;

namespace AnimalManagement
{
    public class Specie
    {
        public string Name { get; set; }
        public string Habitat { get; set; }
        public int AvgAge { get; set; }
        public int DefaultFeedingFreq { get; set; }
        public double DefaultFoodAmt { get; set; }
        public List<string> DefaultFavFood { get; set; }

        public Specie(string name, string habitat, int avgAge, int defaultFeedingFreq, double defaultFoodAmt, List<string> defaultFavFood)
        {
            Name = name;
            Habitat = habitat;
            AvgAge = avgAge;
            DefaultFeedingFreq = defaultFeedingFreq;
            DefaultFoodAmt = defaultFoodAmt;
            DefaultFavFood = defaultFavFood;
        }

        public virtual void DisplaySpecieInfo()
        {
            Console.WriteLine($"Loai: {Name}, Moi truong song: {Habitat}, Tuoi tho trung binh: {AvgAge} nam, Tan suat an: {DefaultFeedingFreq} lan/tuan, Luong thuc an: {DefaultFoodAmt}kg/ngay");
            Console.WriteLine($"Thuc an yeu thich: {string.Join(", ", DefaultFavFood)}");
        }
    }

    public class Carnivore : Specie
    {
        public Carnivore(string name, string habitat, int avgAge, int defaultFeedingFreq, double defaultFoodAmt, List<string> defaultFavFood)
            : base(name, habitat, avgAge, defaultFeedingFreq, defaultFoodAmt, defaultFavFood) { }

        public override void DisplaySpecieInfo()
        {
            Console.WriteLine("--- Dong vat an thit ---");
            base.DisplaySpecieInfo();
        }
    }

    public class Herbivore : Specie
    {
        public Herbivore(string name, string habitat, int avgAge, int defaultFeedingFreq, double defaultFoodAmt, List<string> defaultFavFood)
            : base(name, habitat, avgAge, defaultFeedingFreq, defaultFoodAmt, defaultFavFood) { }

        public override void DisplaySpecieInfo()
        {
            Console.WriteLine("--- Dong vat an co ---");
            base.DisplaySpecieInfo();
        }
    }

    public class Cage
    {
        public string CageID { get; set; }
        public string Size { get; set; }
        public int Capacity { get; set; }
        public string Habitat { get; set; }

        public Cage(string cageID, string size, int capacity, string habitat)
        {
            CageID = cageID;
            Size = size;
            Capacity = capacity;
            Habitat = habitat;
        }

        public void DisplayCageInfo()
        {
            Console.WriteLine($"Ma chuong: {CageID}, Kich thuoc: {Size}, Suc chua: {Capacity}, Moi truong: {Habitat}");
        }
    }

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

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap thong tin chuong:");
            Console.Write("Ma chuong: ");
            string cageID = Console.ReadLine();
            Console.Write("Kich thuoc: ");
            string cageSize = Console.ReadLine();
            Console.Write("Suc chua: ");
            int cageCapacity = int.Parse(Console.ReadLine());
            Console.Write("Moi truong: ");
            string cageHabitat = Console.ReadLine();
            Cage cage = new Cage(cageID, cageSize, cageCapacity, cageHabitat);

            Console.WriteLine("\nNhap thong tin loai (An thit hoac An co):");
            Console.Write("Ten loai: ");
            string specieName = Console.ReadLine();
            Console.Write("Moi truong song: ");
            string specieHabitat = Console.ReadLine();
            Console.Write("Tuoi tho trung binh: ");
            int specieAvgAge = int.Parse(Console.ReadLine());
            Console.Write("Tan suat an (lan/ngay): ");
            int feedingFreq = int.Parse(Console.ReadLine());
            Console.Write("Luong thuc an (kg/ngay): ");
            double foodAmt = double.Parse(Console.ReadLine());
            Console.Write("Thuc an yeu thich (cach nhau bang dau phay): ");
            List<string> favoriteFoods = new List<string>(Console.ReadLine().Split(','));

            Console.Write("Loai dong vat (dv an thit/dv an co): ");
            string type = Console.ReadLine();

            Specie specie;
            if (type.ToLower() == "carnivore")
            {
                specie = new Carnivore(specieName, specieHabitat, specieAvgAge, feedingFreq, foodAmt, favoriteFoods);
            }
            else
            {
                specie = new Herbivore(specieName, specieHabitat, specieAvgAge, feedingFreq, foodAmt, favoriteFoods);
            }

            Console.WriteLine("\nNhap thong tin con vat:");
            Console.Write("Ten: ");
            string animalName = Console.ReadLine();
            Console.Write("Gioi tinh: ");
            string animalGender = Console.ReadLine();
            Console.Write("Can nang (kg): ");
            double animalWeight = double.Parse(Console.ReadLine());
            Console.Write("Tuoi: ");
            int animalAge = int.Parse(Console.ReadLine());

            Animal animal = new Animal(animalName, specie, animalGender, animalWeight, animalAge, cage);

            Console.WriteLine("\n--- Thong tin con vat ---");
            animal.DisplayAnimalInfo();
            cage.DisplayCageInfo();
        }
    }
}
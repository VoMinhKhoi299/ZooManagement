using System;
namespace CK
{
    public class Cage
    {
        protected string cageID { get; set; }
        protected int size { get; set; }
        protected int capacity { get; set; }
        protected string specie { get; set; }
        protected string setDateClean { get; set; }
        protected List<Animal> animalsInCage;

        public Cage(string cageID, string specie, int size, int capacity, string setDateClean)
        {
            this.cageID = cageID;
            this.specie = specie;
            this.size = size;
            this.capacity = capacity;
            this.setDateClean = setDateClean;
            this.animalsInCage = new();
        }

        public void displayCageInfo()
        {
            Console.WriteLine($"Ma chuong: {cageID}, Chuong: {specie}, Kich thuoc: {size}, Suc chua: {capacity}, Ngay ve sinh: {setDateClean}");
        }

        public string getCageID()
        {
            return this.cageID;
        }

        public int getSize()
        {
            return this.size;
        }

        public string getSpecieName()
        {
            return this.specie;
        }

        public void addAnimalIntoCage(Animal animal)
        {
            this.animalsInCage.Add(animal);
        }
    }
}


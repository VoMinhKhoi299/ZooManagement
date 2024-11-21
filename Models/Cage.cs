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

        public void DisplayCageInfo()
        {
            Console.WriteLine($"Mã chuồng: {cageID}, Chuồng: {specie}, Kích thước: {size}, Sức chứa: {capacity}, Ngày vệ sinh: {setDateClean}");
        }

        public string GetCageID()
        {
            return this.cageID;
        }

        public int GetSize()
        {
            return this.size;
        }

        public string GetSpecieName()
        {
            return this.specie;
        }

        public bool AddAnimalIntoCage(Animal animal)
        {
            if (animal.GetSpecie() == this.GetSpecieName())
            {
                this.animalsInCage.Add(animal);
                return true;
            }
            else
            {
                Console.WriteLine($"Loài không thích hợp ! Chuồng {this.cageID} chỉ chứa loài {this.specie}");
                return false;
            }
        }

        public List<Animal> GetAnimalsInCage()
        {
            return this.animalsInCage;
        }

        public int GetCapacity()
        {
            return this.capacity;
        }

    }
}


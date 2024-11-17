using System;
namespace CK
{
	public class Cage
	{
        public string cageID { get; set; }
        public int size { get; set; }
        public int capacity { get; set; }
        public string specie { get; set; }
        public string habitat { get; set; }

        public Cage(string cageID, string specie, int size, int capacity, string habitat)
        {
            this.cageID = cageID;
            this.specie = specie;
            this.size = size;
            this.capacity = capacity;
            this.habitat = habitat;
        }

        public void displayCageInfo()
        {
            Console.WriteLine($"Ma chuong: {cageID}, Chuong: {specie}, Kich thuoc: {size}, Suc chua: {capacity}, Moi truong: {habitat}");
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
    }
}


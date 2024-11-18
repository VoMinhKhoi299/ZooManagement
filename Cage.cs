using System;
namespace CK
{
	public class Cage
	{
        public string cageID { get; set; }
        public int size { get; set; }
        public int capacity { get; set; }
        public string specie { get; set; }
        public string setDateClean { get; set; }
       

        public Cage(string cageID, string specie, int size, int capacity, string setDateClean)
        {
            this.cageID = creCageID();
            this.specie = specie;
            this.size = size;
            this.capacity = capacity;
            this.setDateClean = setDateClean;
        }

        public string creCageID()
        {
            int nextID = 1;
            string CageId = "CH" + nextID.ToString("D3");  // "D3" tạo chuỗi 3 chữ số, ví dụ: "001", "002"
            nextID++;
            return CageId;
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
    }
}


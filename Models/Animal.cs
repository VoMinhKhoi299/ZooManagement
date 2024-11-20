using System;
using System.Xml.Linq;

namespace CK
{
    public class Animal
    {
        private string name { get; set; }
        private string ID { get; set; }
        private string specie { get; set; }
        private string gender { get; set; }
        private double weight { get; set; }
        private int age { get; set; }
        private string modifiedDate { get; set; }
        private string healthStatus { get; set; }
        private string healthNotes { get; set; }
        private DateTime? lastChecked { get; set; }
        private string fatherID { get; set; }
        private string motherID { get; set; }
        private string cageID { get; set; }


        public Animal(string ID, string name, string gender, string species, double weight, int age, string health, string fatherID, string motherID, string cageID, string modifiedDate)
        {
            this.ID = ID;
            this.name = name;
            this.specie = species;
            this.gender = gender;
            this.weight = weight;
            this.age = age;
            this.healthStatus = health;
            this.fatherID = fatherID;
            this.motherID = motherID;
            this.cageID = cageID;
            this.modifiedDate = modifiedDate;

            this.healthNotes = "";
            this.lastChecked = null;
        }


        public void DisplayInfo()
        {
            Console.WriteLine($"ID: {this.ID}, Tên: {this.name}, Loài: {this.specie}, Giới tính: {gender}, Cân nặng: {weight}kg, Tuổi: {age} năm");
            Console.WriteLine($"Ngày nhập vào: {this.modifiedDate}, Cha: {this.fatherID}, Mẹ: {this.motherID}");
            Console.WriteLine($"Trạng thái sức khoẻ: {this.healthStatus}, Ghi chú: {this.healthNotes}, Ngày khám cuối: {this.lastChecked}");
            Console.WriteLine($"Chuồng: {cageID}");
            Console.WriteLine($"*********************************");
        }

        public void DisplayHealth()
        {
            Console.Write($"Trạng thái: {this.healthStatus}");
        }

        public void DisplayID()
        {
            Console.Write($"ID: {this.ID}");
        }

        public void DisplayName()
        {
            Console.Write($"Tên: {this.name}");
        }

        public void DisplayHealthNote()
        {
            Console.Write($"Ghi : {this.healthNotes}");
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

        public double GetWeight()
        {
            return this.weight;
        }

        public string GetSpecie()
        {
            return this.specie;
        }

        public string GetCageID()
        {
            return this.cageID;
        }

        public string GetHealthStatus()
        {
            return this.healthStatus;
        }


        public void EditHealthStatus(string newHealthStatus)
        {
            this.healthStatus = newHealthStatus;
        }

        public void EditCheckedDate(DateTime date)
        {
            this.lastChecked = date;
        }

        public DateTime? GetCheckedDate()
        {
            return this.lastChecked;
        }

        public string GetHealthNote()
        {
            return this.healthNotes;
        }

        public bool IsSameSpecie(Animal other)
        {
            return this.specie == other.specie;
        }
        
    }
}


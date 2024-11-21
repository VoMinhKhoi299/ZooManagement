using System;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            string checkDate = lastChecked.HasValue
                               ? lastChecked.Value.ToString("dd/MM/yyyy")
                               : "Chưa có";
            string note = string.IsNullOrEmpty(healthNotes) ? "Chưa có" : healthNotes;
            Console.WriteLine($"ID: {this.ID}, Tên: {this.name}, Loài: {this.specie}, Giới tính: {gender}, Cân nặng: {weight}kg, Tuổi: {age} năm");
            Console.WriteLine($"Ngày nhập vào: {this.modifiedDate}, Cha: {this.fatherID}, Mẹ: {this.motherID}");
            Console.WriteLine($"Trạng thái sức khoẻ: {this.healthStatus}, Ghi chú: {note}, Kiểm tra sức khoẻ vào ngày: {checkDate}");
            Console.WriteLine($"Chuồng: {cageID}");
            Console.WriteLine($"__________________________________________________________________________________________________________________");
        }

        public void DisplayHealthInfo()
        {
            string checkDate = lastChecked.HasValue
                   ? lastChecked.Value.ToString("dd/MM/yyyy")
                   : "Chưa có";
            string note = string.IsNullOrEmpty(healthNotes) ? "Chưa có" : healthNotes;

            Console.WriteLine($"ID: {ID}, Tên: {name}, Trạng thái: {healthStatus}, Ghi chú: {note}, Kiểm tra sức khoẻ vào ngày: {checkDate}");
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
            string note = string.IsNullOrEmpty(healthNotes) ? "Chưa có" : healthNotes;
            Console.Write($"Ghi chú: {note}");
        }

        public string GetID()
        {
            return this.ID;
        }

        public int GetAge()
        {
            return this.age;
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

        public string GetFatherID()
        {
            return fatherID;
        }

        public string GetMotherID()
        {
            return motherID;
        }

        public void EditHealthStatus(string newHealthStatus)
        {
            this.healthStatus = newHealthStatus;
        }

        public void EditHealthNote(string newNote)
        {
            healthNotes = newNote;
        }

        public void EditID(string ID)
        {
            this.ID = ID;
        }

        public void EditName(string name)
        {
            this.name = name;
        }

        public void EditAge(int age)
        {
            this.age = age;
        }

        public void EditGender(string gender)
        {
            this.gender = gender;
        }

        public void EditWeight(double weight)
        {
            this.weight = weight;
        }

        public void EditSpecie(string specie)
        {
            this.specie = specie;
        }
        
        public void EditCageID(string cageID)
        {
            this.cageID = cageID;
        }

        public void EditCheckedDate(DateTime date)
        {
            lastChecked = date;
        }

        public void EditModifiedDate(string date)
        {
            modifiedDate = date;
        }

        public void EditFatherID(string fatherID)
        {
            this.fatherID = fatherID;
        }

        public void EditMotherID(string motherID)
        {
            this.motherID = motherID;
        }

        public DateTime? GetCheckedDate()
        {
            return this.lastChecked;
        }

        public string GetHealthNote()
        {
            string note = string.IsNullOrEmpty(healthNotes) ? "Chưa có" : healthNotes;
            return note;
        }

        public bool IsSameSpecie(Animal other)
        {
            return this.specie == other.specie;
        }
        
    }
}


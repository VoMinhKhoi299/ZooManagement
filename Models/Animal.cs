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
        public DateTime? modifiedDate { get; set; }
        public string healthStatus { get; set; }
        public string healthNotes { get; set; }
        public DateTime? lastChecked { get; set; }
        public string fatherID { get; set; }
        public string motherID { get; set; }
        public string cageID { get; set; }


        public Animal(string ID, string name, string gender, string species, double weight, int age, string health, string fatherID, string motherID, string cageID)
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

            this.healthNotes = "";
            this.lastChecked = null;
        }


        public void DisplayInfo()
        {
            Console.WriteLine($"ID: {this.ID}, Tên: {this.gender}, Loài: {this.specie}, Giới tính: {gender}, Cân nặng: {weight}kg, Tuổi: {age} năm");
            Console.WriteLine($"Ngày nhập vào: {this.modifiedDate}, Cha: {this.fatherID}, Mẹ: {this.motherID}");
            Console.WriteLine($"Trạng thái sức khoẻ: {this.healthStatus}, Ghi chú: {this.healthNotes}, Ngày khám cuối: {this.lastChecked}");
            Console.WriteLine($"Chuồng: {cageID}");
            Console.WriteLine($"------------------------------------");
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

        public DateTime GetCheckedDate()
        {
            return (DateTime)lastChecked;
        }

        public string GetHealthNote()
        {
            return this.healthNotes;
        }
    }
}


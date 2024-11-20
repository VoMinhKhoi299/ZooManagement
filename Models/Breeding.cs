using System;

namespace CK.Models
{
    public class Breeding
    {
        public Animal Male { get; set; }
        public Animal Female { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime BirthDate { get; set; }

        public Breeding(Animal male, Animal female, DateTime startDate, DateTime birthDate)
        {
            Male = male;
            Female = female;
            StartDate = startDate;
            BirthDate = birthDate;
        }

        public void DisplayBreedingInfo()
        {
            Console.WriteLine("---- Giao Phối ----");
            Console.WriteLine($"Con đực: {Male.GetID()}, Tên: {Male.name}");
            Console.WriteLine($"Con cái: {Female.GetID()}, Tên: {Female.name}");
            Console.WriteLine($"Ngày bắt đầu: {StartDate:dd/MM/yyyy}");
            Console.WriteLine($"Ngày sinh con: {BirthDate:dd/MM/yyyy}");
        }
    }
}

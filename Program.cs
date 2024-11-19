using System;
using System.Collections.Generic;

namespace CK
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Chức năng chính: ");
            Console.WriteLine("1. Chức năng cơ bản.");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    defaultFunction();
                    break;
            }
        }

        public static void defaultFunction()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("1. Thêm động vật");
                Console.WriteLine("2. Exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        inputAddAnimal();
                        break;
                    case 2:
                        running = false;
                        Console.WriteLine("Thoát chương trình.");
                        break;
                }
            }
        }

        public static void inputAddAnimal()
        {

            Console.WriteLine("ID: ");
            string ID = Console.ReadLine();

            Console.WriteLine("Tên: ");
            string name = Console.ReadLine();

            Console.WriteLine("Giới tính: ");
            Console.WriteLine(" 1. Male");
            Console.WriteLine(" 2. Female");
            Console.WriteLine(" 3. Other");
            int genderIndexChoice = int.Parse(Console.ReadLine());
            string gender = "";
            switch (genderIndexChoice)
            {
                case 1:
                    gender = "Male";
                    break;
                case 2:
                    gender = "Female";
                    break;
                case 3:
                    gender = "Other";
                    break;
            }

            string specie = "";
            Console.WriteLine("Loài: ");
            Console.WriteLine(" 1. Thêm loài");
            for (int i = 0; i < Specie.getSpecieLength(); i++)
            {
                Console.WriteLine($" {i + 2}. {Specie.getSpecieIndex(i)}");
            }
            int specieChoice = int.Parse(Console.ReadLine());
            if (specieChoice == 1)
            {
                Console.WriteLine(" Loài: ");
                specie = Console.ReadLine();
                Specie.addSpecie(specie);
            }
            else if (specieChoice > 2 && specieChoice < Specie.getSpecieLength() + 1) /////////////
            {
                var speciesList = Specie.getSpeciesList();
                specie = speciesList[specieChoice - 2];
            }

            Console.WriteLine("Cân nặng: ");
            double weight = Double.Parse(Console.ReadLine());

            Console.WriteLine("Tuổi: ");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("Trạng thái");
            string health = Console.ReadLine();

            Console.WriteLine("Nhập Cha/Mẹ  (Yes/No)");
            string option = Console.ReadLine().ToLower();
            string fatherID = "";
            string motherID = "";
            if (option == "yes")
            {
                Console.WriteLine("ID Cha: ");
                fatherID = Console.ReadLine();
                Console.WriteLine("ID Mẹ: ");
                motherID = Console.ReadLine();
            }
            else if (option == "no")
            {
                fatherID = "Không có";
                motherID = "Không có";
            }
            else
            {
                Console.WriteLine("Vui lòng chọn lại !");
            }

            Cage? cage = null;
            string cageID = "";
            Console.WriteLine("Chọn chuồng: ");
            Console.WriteLine(" 1. Thêm chuồng: ");
            for (int i = 0; i < Zoo.getNumberOfCages() - 1; i++)
            {
                Console.WriteLine($" {i + 2}. {Zoo.getCageIDIndex(i)}");
            }
            int cageChoice = int.Parse(Console.ReadLine());
            if (cageChoice == 1)
            {
                cage = addCage(specie);
            }
            else if (cageChoice > 1 && cageChoice < Zoo.getNumberOfCages() + 1)
            {
                cageID = Zoo.getCageIDIndex(cageChoice - 2);
                cage = Zoo.getCage(cageID);
            }
            Animal animal = new Animal(ID, name, gender, specie, weight, age, health, fatherID, motherID, cageID);
            Specie.addAnimalToSpecie(specie, animal);

            cage.addAnimalIntoCage(animal);
            Zoo.addCage(cage);
            Console.WriteLine("Success");
        }

        public static Cage addCage(string specie)
        {
            Console.WriteLine("ID Chuồng: ");
            string cageID = Console.ReadLine();

            Console.WriteLine("Kích thước(m^2): ");
            int size = int.Parse(Console.ReadLine());

            Console.WriteLine("Sức chứa: ");
            int capacity = int.Parse(Console.ReadLine());

            Console.WriteLine("Ngày vệ sinh: ");
            string setDateClean = Console.ReadLine();

            Cage newCage = new Cage(cageID, specie, size, capacity, setDateClean);
            Zoo.addCage(newCage);
            return newCage;
        }
    }
}
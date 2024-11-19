using System;
namespace CK.UI
{
	public static class Input
	{
        // Phương thức để lấy đầu vào cho một thông tin chuỗi
        public static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        // Phương thức để lấy thông tin giới tính của động vật
        public static string GetGender()
        {
            Console.WriteLine("Giới tính:");
            Console.WriteLine("1. Male");
            Console.WriteLine("2. Female");
            Console.WriteLine("3. Other");
            int choice = int.Parse(Console.ReadLine());
            return choice switch
            {
                1 => "Male",
                2 => "Female",
                3 => "Other",
                _ => throw new Exception("Lựa chọn không hợp lệ!")
            };
        }

        // Phương thức để lấy thông tin về Cha/Mẹ của động vật
        public static (string fatherID, string motherID) GetParentsInfo()
        {
            Console.WriteLine("Nhập Cha/Mẹ (Yes/No): ");
            string option = Console.ReadLine()?.ToLower();
            if (option == "yes")
            {
                string fatherID = GetInput("ID Cha: ");
                string motherID = GetInput("ID Mẹ: ");
                return (fatherID, motherID);
            }
            return ("Không có", "Không có");
        }

        // Phương thức để lấy thông tin về chuồng
        public static Cage GetCageInfo(string specie)
        {
            string id = GetInput("ID Chuồng: ");
            int size = int.Parse(GetInput("Kích thước (m^2): "));
            int capacity = int.Parse(GetInput("Sức chứa: "));
            string cleanDate = GetInput("Ngày vệ sinh: ");
            return new Cage(id, specie, size, capacity, cleanDate);
        }
    }
}


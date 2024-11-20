using System;
using System.Globalization;

namespace CK.UI
{
	public static class Input
	{
        public static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine()?.Trim();
        }

        public static int GetIntInput(string prompt)
        {
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    return int.Parse(Console.ReadLine()?.Trim() ?? string.Empty);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Lỗi: Vui lòng nhập một số nguyên hợp lệ.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi: {ex.Message}");
                }
            }
        }

        public static double GetDoubleInput(string prompt)
        {
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    return double.Parse(Console.ReadLine()?.Trim() ?? string.Empty);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Lỗi: Vui lòng nhập một số thực hợp lệ.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi: {ex.Message}");
                }
            }
        }

        public static string GetGender()
        {
            while (true)
            {
                Console.Write("Nhập giới tính (Male/Female): ");
                string input = Console.ReadLine()?.Trim().ToLower();
                if (input == "male" || input == "female")
                {
                    return char.ToUpper(input[0]) + input.Substring(1);
                }
                Console.WriteLine("Lỗi: Vui lòng nhập 'Male' hoặc 'Female'.");
            }
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

        public static DateTime GetDateInput(string prompt, string format = "dd/MM/yyyy")
        {
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    return DateTime.ParseExact(Console.ReadLine()?.Trim() ?? string.Empty, format, CultureInfo.InvariantCulture);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Lỗi: Vui lòng nhập ngày tháng theo định dạng {format}.");
                }
            }
        }
    }
}


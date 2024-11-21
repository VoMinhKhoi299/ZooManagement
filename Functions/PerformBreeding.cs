using System;
using CK.Managers;
using CK.Models;
using CK.UI;

namespace CK.Functions
{
    public class PerformBreeding
    {
        public static void BreedingPerform()
        {
            Console.WriteLine("Nhập thông tin giao phối");
            Animal male, female;
            while (true)
            {
                string maleID = Input.GetInput("Nhập ID con đực: ");
                Animal animal = SearchFunction.SearchAnimalByID(maleID, Zoo.GetAllCages());

                if (animal == null)
                {
                    Console.WriteLine($"Không tìm thấy con vật có ID {maleID}");
                    return;
                }
                if (animal.GetGender() != "Male")
                {
                    Console.WriteLine("Không phải con đực !!");
                }
                else
                {
                    male = animal;
                    Console.WriteLine($"Hiển thị: {animal.GetName()}");
                    break;
                }
            }

            while (true)
            {
                string femaleID = Input.GetInput("Nhập ID con cái: ");
                Animal animal = SearchFunction.SearchAnimalByID(femaleID, Zoo.GetAllCages());

                if (animal == null)
                {
                    Console.WriteLine($"Không tìm thấy con vật có ID {femaleID}");
                    return;
                }
                if (animal.GetGender() != "Female")
                {
                    Console.WriteLine("Không phải con đực !!");
                }
                else
                {
                    female = animal;
                    Console.WriteLine($"Hiển thị: {animal.GetName()}");
                    break;
                }
            }

            // Kiểm tra hợp lệ: cùng loài
            if (!male.IsSameSpecie(female))
            {
                Console.WriteLine("Hai con vật không cùng loài, không thể giao phối.");
                return;
            }
            //mới sửa
            string startDateInput = Input.GetInput("Nhập ngày bắt đầu giao phối (dd/MM/yyyy): ");
            if (string.IsNullOrWhiteSpace(startDateInput) ||
                !DateTime.TryParseExact(startDateInput, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime startDate))
            {
                Console.WriteLine("Ngày không hợp lệ. Định dạng đúng là dd/MM/yyyy.");
                return;
            }

            string birthDateInput = Input.GetInput("Nhập ngày sinh con (dd/MM/yyyy): ");
            if (string.IsNullOrWhiteSpace(birthDateInput) ||
                !DateTime.TryParseExact(birthDateInput, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime birthDate))
            {
                Console.WriteLine("Ngày không hợp lệ. Định dạng đúng là dd/MM/yyyy.");
                return;
            }

            if (startDate >= birthDate)
            {
                Console.WriteLine("Ngày bắt đầu giao phối phải trước ngày sinh con.");
                return;
            }

            // Tạo sự kiện giao phối
            var breeding = new Breeding(male, female, startDate, birthDate);
            BreedingData.AddBreeding(breeding); // Thêm vào danh sách sự kiện giao phối

            Console.WriteLine("Giao phối đã được thêm thành công!");
        }
    }
}

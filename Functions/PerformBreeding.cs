using System;
using CK.Managers;
using CK.Models;

namespace CK.Functions
{
    public class PerformBreeding
    {
        public static void BreedingPerform()
        {
            Console.WriteLine("Nhập thông tin giao phối");

            Console.Write("Nhập tên giao phối: ");
            string name = Console.ReadLine();

            Console.Write("Nhập ID con đực: ");
            string maleID = Console.ReadLine();
            Animal male = SearchFunction.SearchAnimalByID(maleID, Zoo.GetAllCages());

            if (male == null)
            {
                Console.WriteLine($"Không tìm thấy con vật có ID {maleID}");
                return;
            }

            Console.WriteLine($"Hiển thị: {male.name}");

            Console.Write("Nhập ID con cái: ");
            string femaleID = Console.ReadLine();
            Animal female = SearchFunction.SearchAnimalByID(femaleID, Zoo.GetAllCages());

            if (female == null)
            {
                Console.WriteLine($"Không tìm thấy con vật có ID {femaleID}");
                return;
            }

            Console.WriteLine($"Hiển thị: {female.name}");

            // Kiểm tra hợp lệ: cùng loài
            if (!male.IsSameSpecie(female))
            {
                Console.WriteLine("Hai con vật không cùng loài, không thể giao phối.");
                return;
            }
            //mới sửa
            Console.Write("Nhập ngày bắt đầu giao phối (dd/MM/yyyy): ");
            string startDateInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(startDateInput) ||
                !DateTime.TryParseExact(startDateInput, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime startDate))
            {
                Console.WriteLine("Ngày không hợp lệ. Định dạng đúng là dd/MM/yyyy.");
                return;
            }

            Console.Write("Nhập ngày sinh con (dd/MM/yyyy): ");
            string birthDateInput = Console.ReadLine();
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
            var breeding = new Breeding(name, male, female, startDate, birthDate);
            BreedingData.AddBreeding(breeding); // Thêm vào danh sách sự kiện giao phối

            Console.WriteLine("Giao phối đã được thêm thành công!");
        }
    }
}

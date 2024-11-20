using System;
using System.Collections.Generic;
using System.Globalization;
using CK.UI;

namespace CK.Functions
{
    public static class HealthFunction
    {
        public static List<Animal> SearchAnimalByHealthStatus(string healthStatus, List<Cage> cages)
        {
            var result = new List<Animal>();
            foreach (var cage in cages)
            {
                foreach (var animal in cage.GetAnimalsInCage())
                {
                    if (animal.GetName().Equals(healthStatus, StringComparison.OrdinalIgnoreCase))
                    {
                        result.Add(animal);
                    }
                }
            }
            if (result.Count == 0)
                Console.WriteLine($"Không tìm thấy động vật với trạng thái: {healthStatus}");
            return result;
        }

        public static List<Animal> SearchAnimalByLastCheckedDate(DateTime date, List<Cage> cages)
        {
            var result = new List<Animal>();
            foreach (var cage in cages)
            {
                foreach (var animal in cage.GetAnimalsInCage())
                {
                    if (animal.GetCheckedDate().Date == date.Date)
                    {
                        result.Add(animal);
                    }
                }
            }
            if (result.Count == 0)
                Console.WriteLine($"Không tìm thấy động vật với thời gian kiếm tra cuối: {date}");
            return result;
        }
        // Sửa trạng thái sức khỏe
        public static void EditHealthStatus()
        {
            string id = Input.GetInput("Nhập ID con vật: ");
            var animal = SearchFunction.SearchAnimalByID(id, Zoo.GetAllCages());
            if (animal == null)
            {
                Console.WriteLine("Không tìm thấy con vật với ID này.");
                return;
            }

            Console.WriteLine($"Trạng thái sức khỏe hiện tại: {animal.GetHealthStatus()}");
            string newStatus = Input.GetInput("Nhập trạng thái sức khỏe mới: ");
            animal.EditHealthStatus(newStatus);
            Console.WriteLine($"Trạng thái sức khỏe của {animal.GetName()} đã được cập nhật thành: {animal.GetHealthStatus()}");
        }

        // Sửa ghi chu
        public static void EditHealthNote()
        {
            string id = Input.GetInput("Nhập ID con vật: ");
            var animal = SearchFunction.SearchAnimalByID(id, Zoo.GetAllCages());
            if (animal == null)
            {
                Console.WriteLine("Không tìm thấy con vật với ID này.");
                return;
            }

            Console.WriteLine($"Ghi chú hiện tại: {animal.GetHealthNote()}");
            string newStatus = Input.GetInput("Nhập trạng thái sức khỏe mới: ");
            animal.EditHealthStatus(newStatus);
            Console.WriteLine($"Ghi chú sức khỏe của {animal.GetName()} đã được cập nhật thành: {animal.GetHealthNote()}");
        }

        // Cập nhật thời gian khám tiếp theo
        public static void UpdateNextCheckup()
        {
            string id = Input.GetInput("Nhập ID con vật: ");
            var animal = SearchFunction.SearchAnimalByID(id, Zoo.GetAllCages());
            if (animal == null)
            {
                Console.WriteLine("Không tìm thấy con vật với ID này.");
                return;
            }

            Console.WriteLine($"Tên: {animal.GetName()}, Trạng thái: {animal.GetHealthStatus()}");

            while (true)
            {
                DateTime date = Input.GetDateInput("Nhập ngày khám tiếp theo (dd/MM/yyyy): ");
                if (date > DateTime.Now)
                {
                    animal.EditCheckedDate(date);
                    Console.WriteLine($"Thời gian khám lần sau đã được cập nhật thành: {date:dd/MM/yyyy}");
                    break;
                }
                Console.WriteLine("Lỗi: Ngày khám tiếp theo phải lớn hơn ngày hiện tại.");
            }
        }
    }
}

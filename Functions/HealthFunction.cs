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
                    if (animal.GetHealthStatus().Equals(healthStatus, StringComparison.OrdinalIgnoreCase))
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
                    DateTime curDate = animal.GetCheckedDate() ?? DateTime.MinValue; 
                    if (curDate.Date == date.Date)
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
            string newNote = Input.GetInput("Nhập ghi chú mới: ");
            animal.EditHealthNote(newNote);
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
                DateTime date = Input.GetDateInput("Nhập ngày kiểm tra sức khoẻ (dd/mm/yyyy): ");
                animal.EditCheckedDate(date);
                Console.WriteLine($"Thời gian khám lần sau đã được cập nhật thành: {date:dd/MM/yyyy}");
                break;
            }
        }

        public static void AddAnimalToHealthQueue()
        {
            string id = Input.GetInput("Nhập ID động vật cần thêm vào hàng đợi khám: ");
            var animal = SearchFunction.SearchAnimalByID(id, Zoo.GetAllCages());
            if (animal == null)
            {
                Console.WriteLine("Không tìm thấy động vật với ID này.");
                return;
            }

            HealthQueue<Animal>.Enqueue(animal);
            Console.WriteLine($"Đã thêm động vật {animal.GetName()} (ID: {animal.GetID()}) vào danh sách khám sức khỏe.");
        }

        // Xử lý khám sức khỏe từ hàng đợi
        public static void ProcessHealthQueue()
        {
            if (HealthQueue<Animal>.IsEmpty())
            {
                Console.WriteLine("Danh sách khám sức khỏe trống.");
                return;
            }

            Console.WriteLine("Tiến hành khám sức khỏe:");
            while (!HealthQueue<Animal>.IsEmpty())
            {
                var animal = HealthQueue<Animal>.Dequeue();
                Console.WriteLine($"Đang khám sức khỏe cho: {animal.GetName()} (ID: {animal.GetID()})");
                string newStatus = Input.GetInput("Nhập trạng thái sức khỏe mới: ");
                animal.EditHealthStatus(newStatus);

                DateTime checkDate = DateTime.Now;
                animal.EditCheckedDate(checkDate);
                Console.WriteLine($"Đã cập nhật trạng thái sức khỏe cho {animal.GetName()} thành: {newStatus}");
                Console.WriteLine($"Ngày khám sức khỏe: {checkDate:dd/MM/yyyy}");
            }
        }
    }
}

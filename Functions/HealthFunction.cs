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
            Console.WriteLine($" Tên: {animal.DisplayName}, Trạng thái: {animal.EditHealthStatus}");
            while (true)
            {
                string input = Input.GetInput("Nhập ngày tháng năm (dd/m/yyyy): ");

                try
                {
                    // Chuyển đổi chuỗi input thành kiểu DateTime
                    DateTime date = DateTime.ParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    animal.EditCheckedDate(date);
                    Console.WriteLine($"Thời gian khám lần cuối của {animal.GetID()} đã được cập nhật thành: {date}");
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Lỗi: Định dạng ngày tháng không hợp lệ!");
                }
            }
        }

        // Đổi chuồng
        public static void ChangeCage()
        {
            string id = Input.GetInput("Nhập ID con vật: ");
            var animal = SearchFunction.SearchAnimalByID(id, Zoo.GetAllCages());
            if (animal == null)
            {
                Console.WriteLine("Không tìm thấy con vật với ID này.");
                return;
            }

            Console.WriteLine($"Con vật đang ở chuồng: {animal.cageID}");
            List<Cage> cages = SearchFunction.SearchCagesBySpecie(animal.GetSpecie(), Zoo.GetAllCages());

            Console.WriteLine("Danh sách chuồng cùng loài còn trống:");
            for (int i = 0; i < cages.Count; i++)
            {
                int availableSpace = cages[i].GetCapacity() - cages[i].GetAnimalsInCage().Count;
                Console.WriteLine($"{i + 1}. Chuồng: {cages[i].GetCageID()}, Còn chỗ: {availableSpace}");
            }

            Console.WriteLine("Chọn chuồng mới hoặc chọn thêm chuồng:");
            Console.WriteLine("a. Đổi chuồng");
            Console.WriteLine("b. Thêm chuồng mới");
            Console.WriteLine("c. Quay lại");

            string choice = Input.GetInput("Lựa chọn: ").ToLower();
            switch (choice)
            {
                case "a":
                    int cageChoice = int.Parse(Input.GetInput("Nhập số thứ tự chuồng: "));
                    var newCage = cages[cageChoice - 1];

                    Cage currentCage = Zoo.GetCage(animal.cageID);
                    currentCage.GetAnimalsInCage().Remove(animal);

                    newCage.AddAnimalIntoCage(animal);
                    animal.cageID = newCage.GetCageID();
                    Console.WriteLine($"Đã chuyển {animal.GetName()} sang chuồng {newCage.GetCageID()}.");
                    break;

                case "b":
                    var addedCage = AddFunction.AddCage(animal.GetSpecie());
                    Zoo.AddCage(addedCage);
                    Console.WriteLine($"Đã thêm chuồng mới: {addedCage.GetCageID()}");
                    break;

                case "c":
                    Console.WriteLine("Đã hủy thao tác đổi chuồng.");
                    break;

                default:
                    Console.WriteLine("Lựa chọn không hợp lệ.");
                    break;
            }
        }
    }
}

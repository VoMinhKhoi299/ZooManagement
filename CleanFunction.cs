using System;
using System.Collections.Generic;

namespace CK
{
    public static class CleanFunction
    {
        public static void CleanCage(List<Cage> cages)
        {
            // Hiển thị danh sách các chuồng
            Console.WriteLine("Danh sách các chuồng:");
            foreach (var cage in cages)
            {
                string status = DateTime.Parse(cage.setDateClean) >= DateTime.Now
                    ? "Đã vệ sinh"
                    : "Cần vệ sinh";

                Console.WriteLine($"Mã chuồng: {cage.cageID} --- {status} --- {cage.setDateClean}");
            }

            // Nhập mã chuồng cần tìm
            Console.WriteLine("\nNhập mã chuồng cần tìm:");
            string cageID = Console.ReadLine();

            // Tìm chuồng theo mã
            Cage selectedCage = cages.Find(c => c.getCageID() == cageID);

            if (selectedCage == null)
            {
                Console.WriteLine("Không tìm thấy chuồng.");
                return;
            }

            Console.WriteLine($"Chuồng đã chọn: {selectedCage.getCageID()}");
            Console.WriteLine("Nhập ngày vệ sinh mới (dd/MM/yyyy):");
            string newCleanDate = Console.ReadLine();

            // Kiểm tra ngày hợp lệ
            if (DateTime.TryParse(newCleanDate, out DateTime parsedDate))
            {
                // Cập nhật ngày vệ sinh và trạng thái
                selectedCage.setDateClean = parsedDate.ToString("dd/MM/yyyy");
                Console.WriteLine($"Cập nhật thành công! Chuồng {selectedCage.getCageID()} đã được vệ sinh vào ngày {selectedCage.setDateClean}.");
            }
            else
            {
                Console.WriteLine("Ngày nhập không hợp lệ.");
            }
        }
    }
}

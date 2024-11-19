using System;
using System.Collections.Generic;

namespace CK
{
    public static class CleanFunction
    {
        //public static void CleanCage(List<Cage> cages)
        //{
        //    Console.WriteLine("=== Quản lý vệ sinh chuồng ===");

        //    if (cages == null || cages.Count == 0)
        //    {
        //        Console.WriteLine("Hiện tại không có chuồng nào trong danh sách.");
        //        return;
        //    }

        //    // Hiển thị danh sách các chuồng
        //    Console.WriteLine("Danh sách các chuồng:");
        //    foreach (var cage in cages)
        //    {
        //        string status = DateTime.Parse(cage.setDateClean) >= DateTime.Now
        //            ? "Đã vệ sinh"
        //            : "Cần vệ sinh";

        //        Console.WriteLine($"Mã chuồng: {cage.cageID} | Loài: {cage.specie} | Trạng thái: {status} | Ngày vệ sinh: {cage.setDateClean}");
        //    }

        //    // Nhập mã chuồng cần vệ sinh
        //    Console.WriteLine("\nVui lòng nhập mã chuồng (hoặc nhập 'exit' để thoát):");
        //    string cageID = Console.ReadLine();

        //    if (cageID.ToLower() == "exit")
        //    {
        //        Console.WriteLine("Đã thoát chức năng vệ sinh chuồng.");
        //        return;
        //    }

        //    // Tìm chuồng theo mã
        //    Cage selectedCage = cages.Find(c => c.getCageID() == cageID);

        //    if (selectedCage == null)
        //    {
        //        Console.WriteLine("Không tìm thấy chuồng. Vui lòng kiểm tra mã chuồng.");
        //        return;
        //    }

        //    Console.WriteLine($"\n=== Thông tin chuồng: {selectedCage.getCageID()} ===");
        //    Console.WriteLine($"Loài: {selectedCage.specie}");
        //    Console.WriteLine($"Ngày vệ sinh hiện tại: {selectedCage.setDateClean}");

        //    // Kiểm tra nếu chuồng cần vệ sinh gấp
        //    if (DateTime.Parse(selectedCage.setDateClean) < DateTime.Now.AddDays(-7))
        //    {
        //        Console.WriteLine("Cảnh báo: Lịch vệ sinh chuồng này đã trễ hơn 7 ngày!");
        //    }

        //    // Nhập ngày vệ sinh mới
        //    Console.WriteLine("Nhập ngày vệ sinh mới (dd/MM/yyyy):");
        //    string newCleanDate = Console.ReadLine();

        //    // Kiểm tra ngày hợp lệ
        //    if (DateTime.TryParse(newCleanDate, out DateTime parsedDate))
        //    {
        //        // Cập nhật ngày vệ sinh
        //        selectedCage.setDateClean = parsedDate.ToString("dd/MM/yyyy");
        //        Console.WriteLine($"\nCập nhật thành công! Chuồng {selectedCage.getCageID()} đã được vệ sinh vào ngày {selectedCage.setDateClean}.");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Lỗi: Ngày nhập không hợp lệ. Vui lòng thử lại.");
        //    }

        //    Console.WriteLine("\n=== Hoàn tất cập nhật vệ sinh ===");
        //}
    }
}
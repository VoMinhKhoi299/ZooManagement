using System;
using CK.UI;

namespace CK.Managers.AnimalManagerDisplay
{
    public static class EditInfoDisplay
    {
        public static void EditAnimalInfo()
        {
            string id = Input.GetInput("Nhập ID động vật cần sửa: ");
            var animal = SearchFunction.SearchAnimalByID(id, Zoo.GetAllCages());
            if (animal == null)
            {
                Console.WriteLine("Không tìm thấy động vật với ID này.");
                return;
            }
            bool running = true;
            while (running)
            {
                Console.WriteLine("===> Chọn thông tin cần sửa:");
                Console.WriteLine("===========================");
                Console.WriteLine("|1. Tên                    |");
                Console.WriteLine("|2. Giới tính              |");
                Console.WriteLine("|3. Cân nặng               |");
                Console.WriteLine("|4. Tuổi                   |");
                Console.WriteLine("|5. Loài                   |");
                Console.WriteLine("|6. Chuồng                 |");
                Console.WriteLine("|7. Trạng thái sức khỏe    |");
                Console.WriteLine("|8. Cha/Mẹ                 |");
                Console.WriteLine("|9. ID                     |");
                Console.WriteLine("|                X. Thoát  |");
                Console.WriteLine("===========================");
                string choice = Input.GetInput("Lựa chọn:✎﹏ ").ToLower();

                switch (choice)
                {
                    case "1":
                        string newName = Input.GetInput("Nhập tên mới: ");
                        animal.EditName(newName);
                        Console.WriteLine($"Tên của động vật đã được đổi thành: {newName}");
                        break;

                    case "2":
                        string newGender = Input.GetGender();
                        animal.EditGender(newGender);
                        Console.WriteLine($"Giới tính đã đổi thành {animal.GetGender()}");
                        break;
                    case "3":
                        double newWeigtht = Input.GetDoubleInput("");
                        animal.EditWeight(newWeigtht);
                        Console.WriteLine($"Cân nặng đã đổi thành {animal.GetWeight()}");
                        break;
                    case "4":
                        int newAge = Input.GetIntInput("");
                        animal.EditAge(newAge);
                        Console.WriteLine($"Tuổi đã đổi thành {animal.GetAge()}");
                        break;
                    case "5":
                        string oldSpecie = animal.GetSpecie();
                        // Chọn hoặc thêm loài mới
                        string newSpecie = SpecieManager.SelectOrAddSpecie();
                        if (newSpecie == oldSpecie)
                        {
                            Console.WriteLine("Loài mới giống với loài cũ. Không có thay đổi nào được thực hiện.");
                            return;
                        }

                        // Xóa động vật khỏi loài cũ
                        var speciesAnimals = Specie.GetSpeciesAnimals();
                        if (speciesAnimals.ContainsKey(oldSpecie))
                        {
                            speciesAnimals[oldSpecie].Remove(animal);
                            Console.WriteLine($"Đã xóa động vật khỏi loài {oldSpecie}.");
                        }

                        // Cập nhật loài mới cho động vật
                        animal.EditSpecie(newSpecie);

                        // Thêm động vật vào loài mới
                        Specie.AddAnimalToSpecie(newSpecie, animal);
                        Console.WriteLine($"Động vật đã được chuyển sang loài {newSpecie}.");
                        Console.WriteLine($"Loài hiện tại của động vật: {oldSpecie}");
                        break;
                    case "6":
                        string oldCageID = animal.GetCageID();
                        Console.WriteLine($"Chuồng hiện tại của động vật: {oldCageID}");

                        // Chọn hoặc thêm chuồng mới
                        Cage newCage;
                        while (true)
                        {
                            newCage = CageManager.SelectOrAddCage(animal.GetSpecie());
                            if (newCage.GetCageID() == oldCageID)
                            {
                                Console.WriteLine("Chuồng mới giống với chuồng cũ. Vui lòng chọn chuồng khác.");
                            }
                            else if (newCage.GetAnimalsInCage().Count >= newCage.GetCapacity())
                            {
                                Console.WriteLine("Chuồng đã đầy. Vui lòng chọn chuồng khác.");
                            }
                            else
                            {
                                break;
                            }
                        }

                        // Xóa động vật khỏi chuồng cũ
                        var oldCage = Zoo.GetCage(oldCageID);
                        if (oldCage != null)
                        {
                            oldCage.GetAnimalsInCage().Remove(animal);
                            Console.WriteLine($"Đã xóa động vật khỏi chuồng {oldCageID}.");
                        }

                        // Cập nhật chuồng mới cho động vật
                        animal.EditCageID(newCage.GetCageID());

                        // Thêm động vật vào chuồng mới
                        newCage.AddAnimalIntoCage(animal);
                        Console.WriteLine($"Động vật đã được chuyển sang chuồng {newCage.GetCageID()}.");
                        break;
                    case "7":
                        string newHealthStatus = Input.GetInput("");
                        animal.EditHealthStatus(newHealthStatus);
                        Console.WriteLine($"Trạng thái sức khoẻ đã đổi thành {animal.GetHealthStatus()}");
                        break;
                    case "8":
                        Console.WriteLine("Chọn thông tin cha/mẹ cần thay đổi:");
                        Console.WriteLine("1. Thay đổi cha");
                        Console.WriteLine("2. Thay đổi mẹ");
                        Console.WriteLine("X. Thoát");
                        string curchoice = Input.GetInput("Lựa chọn: ").ToLower();

                        switch (curchoice)
                        {
                            case "1":
                                ChangeFather(animal);
                                break;

                            case "2":
                                ChangeMother(animal);
                                break;

                            case "x":
                                Console.WriteLine("Thoát thay đổi thông tin cha/mẹ.");
                                break;

                            default:
                                Console.WriteLine("Lựa chọn không hợp lệ.");
                                break;
                        }
                        break;
                    case "9":
                        id = Input.GetInput("ID: ");
                        if (!string.IsNullOrEmpty(id) && Zoo.GetAllCages().SelectMany(c => c.GetAnimalsInCage()).All(a => a.GetID() != id))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Lỗi: ID không hợp lệ hoặc đã tồn tại.");
                        }
                        animal.EditID(id);
                        break;
                    case "x":
                        running = false;
                        Console.WriteLine("Thoát khỏi chức năng chỉnh sửa ");
                        break;
                }
                if (running)
                {
                    Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
                    Console.ReadKey();
                }
            }
        }

        private static void ChangeFather(Animal animal)
        {
            Console.WriteLine($"ID cha hiện tại: {animal.GetFatherID()}");
            while (true)
            {
                string newFatherID = Input.GetInput("Nhập ID cha mới (để trống nếu không có): ");

                if (string.IsNullOrWhiteSpace(newFatherID))
                {
                    animal.EditFatherID("Không có");
                    Console.WriteLine("Đã cập nhật thông tin cha: Không có");
                    break;
                }

                var newFather = SearchFunction.SearchAnimalByID(newFatherID, Zoo.GetAllCages());
                if (newFather == null)
                {
                    Console.WriteLine("Không tìm thấy động vật với ID này. Vui lòng thử lại.");
                }
                else if (newFather.GetID() == animal.GetID())
                {
                    Console.WriteLine("ID cha không thể trùng với ID động vật. Vui lòng thử lại.");
                }
                else
                {
                    animal.EditFatherID(newFatherID);
                    Console.WriteLine($"Đã cập nhật thông tin cha: {newFatherID}");
                    break;
                }
            }
        }

        private static void ChangeMother(Animal animal)
        {
            Console.WriteLine($"ID mẹ hiện tại: {animal.GetMotherID()}");
            while (true)
            {
                string newMotherID = Input.GetInput("Nhập ID mẹ mới (để trống nếu không có): ");

                if (string.IsNullOrWhiteSpace(newMotherID))
                {
                    animal.EditMotherID("Không có");
                    Console.WriteLine("Đã cập nhật thông tin mẹ: Không có");
                    break;
                }

                var newMother = SearchFunction.SearchAnimalByID(newMotherID, Zoo.GetAllCages());
                if (newMother == null)
                {
                    Console.WriteLine("Không tìm thấy động vật với ID này. Vui lòng thử lại.");
                }
                else if (newMother.GetID() == animal.GetID())
                {
                    Console.WriteLine("ID mẹ không thể trùng với ID động vật. Vui lòng thử lại.");
                }
                else
                {
                    animal.EditMotherID(newMotherID);
                    Console.WriteLine($"Đã cập nhật thông tin mẹ: {newMotherID}");
                    break;
                }
            }
        }
    }
}


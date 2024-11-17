using System;
namespace CK
{
	public class Zoo
{
    public List<Cage> Cages { get; set; } = new List<Cage>();
    public List<Animal> Animals { get; set; } = new List<Animal>();
    public List<Specie> Species { get; set; } = new List<Specie>();

    // Thêm động vật
    public void AddAnimal()
{
    Console.WriteLine("Nhập tên động vật:");
    string name = Console.ReadLine();

    Console.WriteLine("Nhập giới tính (1. Male, 2. Female):");
    string gender = Console.ReadLine() == "1" ? "Male" : "Female";

    // Hiển thị danh sách loài
    Console.WriteLine("Chọn loài:");
    for (int i = 0; i < Species.Count; i++)
    {
        Console.WriteLine($"{i + 2}. {Species[i].Name}");
    }
    Console.WriteLine("1. Thêm loài mới");
    int choice = int.Parse(Console.ReadLine());

    Specie species;
    if (choice == 1) // Người dùng chọn thêm loài mới
    {
        Console.WriteLine("Nhập tên loài:");
        string speciesName = Console.ReadLine();

        Console.WriteLine("Nhập môi trường sống (1. Trên cạn, 2. Dưới nước, 3. Trên cây):");
        string habitat = Console.ReadLine() switch
        {
            "1" => "Trên cạn",
            "2" => "Dưới nước",
            "3" => "Trên cây",
            _ => "Trên cạn"
        };

        Console.WriteLine("Nhập tuổi thọ trung bình của loài:");
        int avgAge = int.Parse(Console.ReadLine());

        species = new Specie(speciesName, habitat, avgAge);
        Species.Add(species);
    }
    else // Người dùng chọn loài có sẵn
    {
        species = Species[choice - 2];
    }

    Console.WriteLine("Con này được sinh ra trong sở thú? (y/n):");
    string parentInput = Console.ReadLine();
    string father = null, mother = null;

    if (parentInput.ToLower() == "y")
    {
        Console.WriteLine("Nhập tên cha:");
        father = Console.ReadLine();

        Console.WriteLine("Nhập tên mẹ:");
        mother = Console.ReadLine();
    }

    Console.WriteLine("Nhập cân nặng (kg):");
    double weight = double.Parse(Console.ReadLine());

    Console.WriteLine("Nhập trạng thái (1. Khỏe mạnh, 2. Mang thai):");
    string healthStatus = Console.ReadLine() == "1" ? "Khỏe mạnh" : "Mang thai";

    // Chọn chuồng
    var suitableCages = Cages.Where(c => c.Type == species.Name && c.HasSpace()).ToList();
    Cage selectedCage;

    if (suitableCages.Count > 0)
    {
        Console.WriteLine("Danh sách chuồng phù hợp:");
        for (int i = 0; i < suitableCages.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {suitableCages[i].ID} (Sức chứa còn: {suitableCages[i].RemainingCapacity()})");
        }

        Console.WriteLine("Chọn chuồng (nhập số):");
        int cageIndex = int.Parse(Console.ReadLine()) - 1;
        selectedCage = suitableCages[cageIndex];
    }
    else
    {
        Console.WriteLine("Không có chuồng nào phù hợp. Hãy thêm chuồng mới.");
        selectedCage = AddCage(species.Name);
    }

    // Tạo động vật
    Animal newAnimal = new Animal(name, species, gender, weight, healthStatus, selectedCage);
    Animals.Add(newAnimal);
    selectedCage.AddAnimal(newAnimal);

    Console.WriteLine($"Đã thêm động vật: {newAnimal.Name} (ID: {newAnimal.ID}) vào chuồng {selectedCage.ID}");
}


    // Thêm chuồng mới
    public Cage AddCage(string speciesType)
    {
        Console.WriteLine("Nhập diện tích (m^2):");
        double size = double.Parse(Console.ReadLine());

        Console.WriteLine("Nhập sức chứa tối đa:");
        int capacity = int.Parse(Console.ReadLine());

        Console.WriteLine("Nhập lịch vệ sinh chuồng (dd/MM/yyyy):");
        string cleaningSchedule = Console.ReadLine();

        Cage newCage = new Cage(size, capacity, speciesType, cleaningSchedule);
        Cages.Add(newCage);

        Console.WriteLine($"Đã thêm chuồng mới: {newCage.ID}");
        return newCage;
    }
}

	


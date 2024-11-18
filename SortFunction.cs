using System;
namespace CK
{
	public static class SortFunction
	{
        
            // Sắp xếp động vật theo tên (tăng dần hoặc giảm dần)
            public static void SortAnimalsByName(List<Animal> animals, bool ascending = true)
            {
                if (ascending)
                {
                    animals.Sort((a, b) => string.Compare(a.name, b.name, StringComparison.Ordinal));
                }
                else
                {
                    animals.Sort((a, b) => string.Compare(b.name, a.name, StringComparison.Ordinal));
                }
            }

            // Sắp xếp động vật theo cân nặng (tăng dần hoặc giảm dần)
            public static void SortAnimalsByWeight(List<Animal> animals, bool ascending = true)
            {
                if (ascending)
                {
                    animals.Sort((a, b) => a.weight.CompareTo(b.weight));
                }
                else
                {
                    animals.Sort((a, b) => b.weight.CompareTo(a.weight));
                }
            }

            // Sắp xếp động vật theo ID (tăng dần)
            public static void SortAnimalsByID(List<Animal> animals)
            {
                animals.Sort((a, b) => string.Compare(a.ID, b.ID, StringComparison.Ordinal));
            }
        

 
		

            // Sắp xếp chuồng theo loại (tăng dần hoặc giảm dần)
            public static void SortCagesByType(List<Cage> cages, bool ascending = true)
            {
                if (ascending)
                {
                    cages.Sort((c1, c2) => string.Compare(c1.Type, c2.Type, StringComparison.Ordinal));
                }
                else
                {
                    cages.Sort((c1, c2) => string.Compare(c2.Type, c1.Type, StringComparison.Ordinal));
                }
            }

            // Sắp xếp chuồng theo số lượng động vật bên trong (tăng dần hoặc giảm dần)
            public static void SortCagesByAnimalCount(List<Cage> cages, bool ascending = true)
            {
                if (ascending)
                {
                    cages.Sort((c1, c2) => c1.CurrentAnimals.Count.CompareTo(c2.CurrentAnimals.Count));
                }
                else
                {
                    cages.Sort((c1, c2) => c2.CurrentAnimals.Count.CompareTo(c1.CurrentAnimals.Count));
                }
            }

            // Sắp xếp chuồng theo diện tích (tăng dần hoặc giảm dần)
            public static void SortCagesBySize(List<Cage> cages, bool ascending = true)
            {
                if (ascending)
                {
                    cages.Sort((c1, c2) => c1.size.CompareTo(c2.size));
                }
                else
                {
                    cages.Sort((c1, c2) => c2.size.CompareTo(c1.size));
                }
            }
        

    }
}


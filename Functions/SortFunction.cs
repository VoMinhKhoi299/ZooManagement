using System;
using System.Collections.Generic;

namespace CK
{
    public static class SortFunction
    {
        // Sắp xếp động vật theo tên
        public static void SortAnimalsByName(List<Animal> animals, bool ascending = true)
        {
            if (animals.Count > 100) // Sử dụng Sort() cho danh sách lớn
            {
                animals.Sort((a, b) =>
                {
                    return ascending
                        ? string.Compare(a.GetName(), b.GetName(), StringComparison.Ordinal)
                        : string.Compare(b.GetName(), a.GetName(), StringComparison.Ordinal);
                });
            }
            else // Dùng Bubble Sort cho danh sách nhỏ
            {
                int n = animals.Count;
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        bool condition = ascending
                            ? string.Compare(animals[j].GetName(), animals[j + 1].GetName(), StringComparison.Ordinal) > 0
                            : string.Compare(animals[j].GetName(), animals[j + 1].GetName(), StringComparison.Ordinal) < 0;

                        if (condition)
                        {
                            var temp = animals[j];
                            animals[j] = animals[j + 1];
                            animals[j + 1] = temp;
                        }
                    }
                }
            }
        }

        // Sắp xếp động vật theo cân nặng
        public static void SortAnimalsByWeight(List<Animal> animals, bool ascending = true)
        {
            if (animals.Count > 100) // Sử dụng Sort() cho danh sách lớn
            {
                animals.Sort((a, b) =>
                {
                    return ascending
                        ? a.GetName().CompareTo(b.GetWeight())
                        : b.GetName().CompareTo(a.GetWeight());
                });
            }
            else // Dùng Selection Sort cho danh sách nhỏ
            {
                int n = animals.Count;
                for (int i = 0; i < n - 1; i++)
                {
                    int selected = i;
                    for (int j = i + 1; j < n; j++)
                    {
                        bool condition = ascending
                            ? animals[j].GetWeight() < animals[selected].GetWeight()
                            : animals[j].GetWeight() > animals[selected].GetWeight();

                        if (condition)
                        {
                            selected = j;
                        }
                    }

                    var temp = animals[i];
                    animals[i] = animals[selected];
                    animals[selected] = temp;
                }
            }
        }

        // Sắp xếp động vật theo ID
        public static void SortAnimalsByID(List<Animal> animals)
        {
            if (animals.Count > 100) // Sử dụng Sort() cho danh sách lớn
            {
                animals.Sort((a, b) => string.Compare(a.GetID(), b.GetID(), StringComparison.Ordinal));
            }
            else // Dùng Insertion Sort cho danh sách nhỏ
            {
                int n = animals.Count;
                for (int i = 1; i < n; i++)
                {
                    var key = animals[i];
                    int j = i - 1;

                    while (j >= 0 && string.Compare(animals[j].GetID(), key.GetID(), StringComparison.Ordinal) > 0)
                    {
                        animals[j + 1] = animals[j];
                        j--;
                    }

                    animals[j + 1] = key;
                }
            }
        }
    }
}

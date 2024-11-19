using System;
using System.Collections.Generic;

namespace CK
{
    public static class RemoveFunction
    {
        // Xóa tất cả động vật thuộc một loài
        public static void RemoveAnimalsBySpecie(List<Animal> animals, string specieName)
        {
            animals.RemoveAll(a => a.Specie.Name == specieName);
        }

        // Xóa động vật theo ID
        public static void RemoveAnimalByID(List<Animal> animals, string animalID)
        {
            var animalToRemove = animals.Find(a => a.ID == animalID);
            if (animalToRemove != null)
            {
                animals.Remove(animalToRemove);
            }
        }

        // Xóa chuồng theo ID
        public static void RemoveCageByID(List<Cage> cages, string cageID)
        {
            var cageToRemove = cages.Find(c => c.ID == cageID);
            if (cageToRemove != null && cageToRemove.CurrentAnimals.Count == 0)
            {
                cages.Remove(cageToRemove);
            }
        }
    }
}

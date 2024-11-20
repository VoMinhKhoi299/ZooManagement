using System;
using CK.Models;

namespace CK
{
    public static class Zoo
    {
        private static List<Cage> cages = new();

        public static void AddCage(Cage cage)
        {
            if (cage == null)
                throw new ArgumentNullException(nameof(cage), "Cage cannot be null.");
            if (!cages.Contains(cage)) {
                cages.Add(cage);
            }
        }

        public static int GetNumberOfCages()
        {
            return cages.Count;
        }

        public static string GetCageIDIndex(int index)
        {
            return cages.ElementAt(index).GetCageID();
        }

        public static Cage GetCage(string cageID)
        {
            return cages.FirstOrDefault(c => c.GetCageID() == cageID);
        }

        public static List<string> GetCageIDs()
        {
            return cages.Select(c => c.GetCageID()).ToList();
        }

        public static List<Cage> GetAllCages()
        {
            return cages;
        }

        public static class BreedingManager
        {
            private static List<Breeding> breedingEvents = new();

            public static void AddBreeding(Breeding breeding)
            {
                breedingEvents.Add(breeding);
            }

            public static List<Breeding> GetBreedingEvents()
            {
                return breedingEvents;
            }

            public static void DisplayAllBreedingEvents()
            {
                foreach (var breeding in breedingEvents)
                {
                    breeding.DisplayBreedingInfo();
                }
            }
        }
    }
}

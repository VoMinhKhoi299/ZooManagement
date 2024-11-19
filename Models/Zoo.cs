using System;

namespace CK
{
    public static class Zoo
    {
        private static List<Cage> cages = new();

        public static void AddCage(Cage cage)
        {
            if (cage == null)
                throw new ArgumentNullException(nameof(cage), "Cage cannot be null.");

            cages.Add(cage);
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
    }
}

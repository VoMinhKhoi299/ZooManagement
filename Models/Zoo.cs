using System;

namespace CK
{
    public static class Zoo
    {
        private static List<Cage> cages = new();

        public static void addCage(Cage cage)
        {
            if (cage == null)
                throw new ArgumentNullException(nameof(cage), "Cage cannot be null.");

            cages.Add(cage);
        }

        public static int getNumberOfCages()
        {
            return cages.Count;
        }

        public static string getCageIDIndex(int index)
        {
            return cages.ElementAt(index).getCageID();
        }

        public static Cage getCage(string cageID)
        {
            return cages.FirstOrDefault(c => c.getCageID() == cageID);
        }

        public static List<string> getCageIDs()
        {
            return cages.Select(c => c.getCageID()).ToList();
        }
    }
}

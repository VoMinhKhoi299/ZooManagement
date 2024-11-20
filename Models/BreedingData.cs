using System;
using System.Collections.Generic;
using System.Linq;
using CK.Models;

namespace CK.Managers
{
    public static class BreedingData
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

       
    }
}

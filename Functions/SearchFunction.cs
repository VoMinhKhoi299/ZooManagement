using System;
namespace CK
{
	public static class SearchFunction
	{
		public static List<Animal> searchByID(List<Animal> animals, string id)
		{
			List<Animal> results = new();
			foreach (var animal in animals)
			{
				if (animal.getID() == id)
				{
					results.Add(animal);
				}
			}
			return results;
		}

        public static List<Animal> searchByGender(List<Animal> animals, string gender)
        {
            List<Animal> results = new();
            foreach (var animal in animals)
            {
                if (animal.getGender() == gender)
                {
                    results.Add(animal);
                }
            }
            return results;
        }

        public static List<Animal> searchByName(List<Animal> animals, string name)
        {
            List<Animal> results = new();
            foreach (var animal in animals)
            {
                if (animal.getGender() == name)
                {
                    results.Add(animal);
                }
            }
            return results;
        }

        public static List<Cage> searchCage(List<Cage> cages, int choice, string text)
        {
            List<Cage> results = new();
            switch (choice)
            {
                case 1:     // 1. Tim kiem theo CageID
                    foreach (var cage in cages)
                    {
                        if (cage.getCageID() == text)
                        {
                            results.Add(cage);
                        }
                    }
                    break;
                case 2:		// 2. Tim kiem theo Loai chuong
                    foreach (var cage in cages)
                    {
                        if (cage.getSpecieName() == text)
                        {
                            results.Add(cage);
                        }
                    }
                    break;
                case 3:		// 3. Tim kiem theo Kich thuoc
                    foreach (var cage in cages)
                    {
                        if (int.TryParse(text, out int size))
                        {
                            if (int.Parse(text) == cage.getSize())
                            {
                                results.Add(cage);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid size input.");
                        }
                    }
                    break;
            }

            return results;
        }
    }
}


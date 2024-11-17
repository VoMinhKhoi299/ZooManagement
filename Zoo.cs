using System;
namespace CK
{
	public class Zoo
	{
		List<Cage>? cages;

		public Zoo()
		{
			this.cages = new();
		}
		public void addCage(Cage cage)
		{
            cages.Add(cage);
		}

		public void displayAllCages()
		{
			foreach (var cage in this.cages)
			{
				cage.displayCageInfo();
			}
		}

		public List<Cage> searchCage(int choice, string text)
		{
			List<Cage> results = new();
			switch (choice)
			{
                case 1:		// 1. Tim kiem theo CageID
					foreach (var cage in this.cages)
					{
						if (cage.getCageID() == text)
						{
							results.Add(cage);
						}
					}
					break;
				case 2:		// 2. Tim kiem theo Loai chuong
                    foreach (var cage in this.cages)
                    {
                        if (cage.getSpecieName() == text)
                        {
                            results.Add(cage);
                        }
                    }
					break;
                case 3:		// 3. Tim kiem theo Kich thuoc
                    foreach (var cage in this.cages)
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


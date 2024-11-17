using System;
namespace CK
{
	public class Zoo
	{
		public List<Cage>? cages;

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

		
	}
}


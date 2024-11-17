using System;
namespace CK
{
	public class Specie
	{
        public string Name { get; set; }
        public string Habitat { get; set; }
        public int AvgAge { get; set; }
        public int DefaultFeedingFreq { get; set; }
        public double DefaultFoodAmt { get; set; }
        public List<string> DefaultFavFood { get; set; }

        public Specie(string name, string habitat, int avgAge, int defaultFeedingFreq, double defaultFoodAmt, List<string> defaultFavFood)
        {
            Name = name;
            Habitat = habitat;
            AvgAge = avgAge;
            DefaultFeedingFreq = defaultFeedingFreq;
            DefaultFoodAmt = defaultFoodAmt;
            DefaultFavFood = defaultFavFood;
        }

        public virtual void DisplaySpecieInfo()
        {
            Console.WriteLine($"Loai: {Name}, Moi truong song: {Habitat}, Tuoi tho trung binh: {AvgAge} nam, Tan suat an: {DefaultFeedingFreq} lan/tuan, Luong thuc an: {DefaultFoodAmt}kg/ngay");
            Console.WriteLine($"Thuc an yeu thich: {string.Join(", ", DefaultFavFood)}");
        }
    }
}


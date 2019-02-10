using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein
{
    public class Animal
    {
        private string foodType;
        private string size;
        private int pointWorth;

        public Animal(string foodType, string size)
        {
            this.foodType = foodType;
            this.size = size;
            this.pointWorth = CalculatePoints(size);
        }

        public string FoodType { get => foodType; set => foodType = value; }
        public string Size { get => size; set => size = value; }
        public int PointWorth { get => pointWorth; set => pointWorth = value; }

        /// <summary>
        /// calculates the size into points
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private int CalculatePoints(string size)
        {
            int points = 0;
            if (size == "Small")
            {
                points = 1;
            }
            else if (size == "Medium")
            {
                points = 3;
            }
            else if (size == "Big")
            {
                points = 5;
            }
            return points;
        }

        public override string ToString()
        {
            return foodType + "   " + size + "   " + pointWorth.ToString();
        }
    }
}

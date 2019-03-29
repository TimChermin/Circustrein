using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Circustrein.Enums;

namespace Circustrein
{
    public class Animal
    {
        
        private string foodType;
        private AnimalSize animalSize;
        private int points;

        public Animal(string foodType, AnimalSize animalSize)
        {
            this.foodType = foodType;
            this.AnimalSize = animalSize;
            this.points = (int)animalSize;
        }

        public string FoodType { get => foodType; set => foodType = value; }
        public AnimalSize AnimalSize { get => animalSize; set => animalSize = value; }
        

        public override string ToString()
        {
            return foodType + "   " + animalSize.ToString() + "   " + points.ToString();
        }
    }
}

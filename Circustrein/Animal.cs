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
        
        private AnimalType foodType;
        private AnimalSize animalSize;
        private int points;

        public Animal(AnimalType foodType, AnimalSize animalSize)
        {
            this.foodType = foodType;
            this.AnimalSize = animalSize;
            this.points = (int)animalSize;
        }

        public AnimalType FoodType { get => foodType; set => foodType = value; }
        public AnimalSize AnimalSize { get => animalSize; set => animalSize = value; }
        

        public override string ToString()
        {
            return foodType.ToString() + "   " + animalSize.ToString() + "   " + points.ToString();
        }
    }
}

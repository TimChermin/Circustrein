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
        private int points;

        public Animal(AnimalType foodType, AnimalSize animalSize)
        {
            this.FoodType = foodType;
            this.AnimalSize = animalSize;
            this.points = (int)animalSize;
        }

        public AnimalType FoodType { get; set; }
        public AnimalSize AnimalSize { get; set; }

        public bool WillThisAnimalNotEatOrGetEatenByAnother(bool containsCarnivore, bool smallestAnimalIsCarnivore, AnimalSize smallestAnimal)
        {
            if (containsCarnivore == true)
            {
                if (FoodType == AnimalType.Carnivore)
                {
                    return false;
                }
                else
                {
                    return WillThisAnimalNotEatOrGetEatenByTheCarn(smallestAnimalIsCarnivore, smallestAnimal);
                }
            }
            else
            {
                return WillThisAnimalNotEatOrGetEaten(smallestAnimal);
            }
        }

        public bool WillThisAnimalNotEatOrGetEaten(AnimalSize smallestAnimal)
        {
            if (FoodType == AnimalType.Carnivore)
            {
                if (AnimalSize < smallestAnimal)
                {
                    return true;
                }
            }
            else if (FoodType != AnimalType.Carnivore)
            {
                return true;
            }
            return false;
        }

        public bool WillThisAnimalNotEatOrGetEatenByTheCarn(bool smallestAnimalIsCarnivore, AnimalSize smallestAnimal)
        {
            if (AnimalSize > smallestAnimal && smallestAnimalIsCarnivore == true)
            {
                return true;
            }
            else if (AnimalSize > smallestAnimal)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return FoodType.ToString() + "   " + AnimalSize.ToString() + "   " + points.ToString();
        }
    }
}

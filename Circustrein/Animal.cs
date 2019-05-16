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

        public bool ThisAnimalWontEatOrGetEatenWhenAdded(bool containsCarnivore, bool smallestAnimalIsCarnivore, AnimalSize smallestAnimal)
        {
            if (containsCarnivore == true)
            {
                if (FoodType == AnimalType.Carnivore)
                {
                    return false;
                }
                else
                {
                    return ThisAnimalWontEatOrGetEatenByTheCarnInTheWagon(smallestAnimalIsCarnivore, smallestAnimal);
                }
            }
            else
            {
                return ThisAnimalWontEatOrGetEaten(smallestAnimal);
            }
        }

        private bool ThisAnimalWontEatOrGetEaten(AnimalSize smallestAnimal)
        {
            if (FoodType == AnimalType.Carnivore)
            {
                if (AnimalSize < smallestAnimal || smallestAnimal == AnimalSize.Nothing)
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

        private bool ThisAnimalWontEatOrGetEatenByTheCarnInTheWagon(bool smallestAnimalIsCarnivore, AnimalSize smallestAnimal)
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

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

        public bool CanThisAnimalGoInTheWagon(bool containsCarnivore, bool smallestAnimalIsCarnivore, int wagonWeight, AnimalSize smallestAnimal)
        {
            if (containsCarnivore == true)
            {
                if (FoodType == AnimalType.Carnivore)
                {
                    return false;
                }
                else //(animal.FoodType == "Herbivore")
                {
                    return CheckSizeForCarnInWagon(smallestAnimalIsCarnivore, wagonWeight, smallestAnimal);
                }
            }
            else //doesn't have a carnivore 
            {
                if (FoodType == AnimalType.Carnivore)
                {
                    return CheckSizeForCarnNotInWagon(wagonWeight, smallestAnimal);
                }
                else // add herb
                {
                    return CheckSizeForCarnNotInWagon(wagonWeight, smallestAnimal);
                }
            }
        }

        public bool CheckSizeForCarnNotInWagon(int wagonWeight, AnimalSize smallestAnimal)
        {
            if (FoodType == AnimalType.Carnivore)
            {
                if (AnimalSize < smallestAnimal && wagonWeight + (int)AnimalSize <= 10)
                {
                    return true;
                }
            }
            else if (FoodType != AnimalType.Carnivore)
            {
                if (wagonWeight + (int)AnimalSize <= 10)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckSizeForCarnInWagon(bool smallestAnimalIsCarnivore, int wagonWeight, AnimalSize smallestAnimal)
        {
            //this was for the herb when haveing a carn in the wagon
            if (AnimalSize > smallestAnimal && smallestAnimalIsCarnivore == true && wagonWeight + (int)AnimalSize <= 10)
            {
                return true;
            }
            else if (AnimalSize > smallestAnimal && wagonWeight + (int)AnimalSize <= 10)
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

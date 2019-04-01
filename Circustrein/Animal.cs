﻿using System;
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

        public bool CanThisAnimalGoInTheWagon(Wagon wagon)
        {
            if (wagon.ContainsCarnivore == true)
            {
                if (FoodType == AnimalType.Carnivore)
                {
                    return false;
                }
                else //(animal.FoodType == "Herbivore")
                {
                    return CheckSizeForCarnInWagon(wagon);
                }
            }
            else //doesn't have a carnivore 
            {
                if (FoodType == AnimalType.Carnivore)
                {
                    return CheckSizeForCarnNotInWagon(wagon);
                }
                else // add herb
                {
                    return CheckSizeForCarnNotInWagon(wagon);
                }
            }
        }

        public bool CheckSizeForCarnNotInWagon(Wagon wagon)
        {
            if (FoodType == AnimalType.Carnivore)
            {
                if (AnimalSize < wagon.SmallestAnimal && wagon.Weight + (int)AnimalSize <= 10)
                {
                    return true;
                }
            }
            else if (FoodType != AnimalType.Carnivore)
            {
                if (wagon.Weight + (int)AnimalSize <= 10)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckSizeForCarnInWagon(Wagon wagon)
        {
            //this was for the herb when haveing a carn in the wagon
            if (AnimalSize > wagon.SmallestAnimal && wagon.SmallestAnimalIsCarnivore == true && wagon.Weight + (int)AnimalSize <= 10)
            {
                return true;
            }
            else if (AnimalSize > wagon.SmallestAnimal && wagon.Weight + (int)AnimalSize <= 10)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Circustrein.Enums;

namespace Circustrein
{
    class CheckWagon
    {

        private List<Animal> animalsInWagon = new List<Animal>();
        private AnimalSorter animalSorter;


        public CheckWagon(AnimalSorter animalSorter)
        {
            this.animalSorter = animalSorter;
        }

        public bool IsTheWagonEmpty(Wagon wagon)
        {
            if (wagon.Full == false && wagon.Weight == 0)
            {
                return true;
            }
            return false;
        }


        public bool CanTheAnimalBeAdded(Wagon wagon, Animal animal)
        {
            if (IsTheWagonEmpty(wagon) == false)
            {
                if (CanThisAnimalGoInTheWagon(wagon, animal) == true)
                {
                    return true;
                }

            }
            else if (IsTheWagonEmpty(wagon) == true)
            {
                return true;
            }
            return false;
        }


        
        public bool CanThisAnimalGoInTheWagon(Wagon wagon, Animal animal)
        {
            animalsInWagon = wagon.Animals;
            if (wagon.ContainsCarnivore == true)
            {
                if (animal.FoodType == AnimalType.Carnivore)
                {
                    return false;
                }
                else //(animal.FoodType == "Herbivore")
                {
                    return CheckSizeForCarnInWagon(wagon, animal);
                }
            }
            else //doesn't have a carnivore 
            {
                if (animal.FoodType == AnimalType.Carnivore)
                {
                    return CheckSizeForCarnNotInWagon(wagon, animal);
                }
                else // add herb
                {
                    return CheckSizeForCarnNotInWagon(wagon, animal);
                }
            }
        }
        

        public bool CheckSizeForCarnNotInWagon(Wagon wagon, Animal animal)
        {
            if (animal.FoodType == AnimalType.Carnivore)
            {
                if (animal.AnimalSize < wagon.SmallestAnimal && wagon.Weight + (int)animal.AnimalSize <= 10)
                {
                    return true;
                }
            }
            else if (animal.FoodType != AnimalType.Carnivore)
            {
                if (wagon.Weight + (int)animal.AnimalSize <= 10)
                {
                    return true;
                }
            }
            return false;
        }
        

        public bool CheckSizeForCarnInWagon(Wagon wagon, Animal animal)
        {
            //this was for the herb when haveing a carn in the wagon
            if (animal.AnimalSize > wagon.SmallestAnimal && wagon.SmallestAnimalIsCarnivore == true && wagon.Weight + (int)animal.AnimalSize <= 10)
            {
                return true;
            }
            else if (wagon.SmallestAnimalIsCarnivore == false && wagon.Weight + (int)animal.AnimalSize <= 10)
            {
                return true;
            }
            else if (animal.AnimalSize > wagon.SmallestAnimal && wagon.Weight + (int)animal.AnimalSize <= 10)
            {
                return true;
            }
            return false;
        }
    }
}

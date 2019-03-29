using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        /// <summary>
        /// Check if the animal can be added to the wagon
        /// </summary>
        /// <param name="wagon"></param>
        /// <param name="animal"></param>
        /// <returns></returns>
        public bool CanThisAnimalGoInTheWagon(Wagon wagon, Animal animal)
        {
            animalsInWagon = wagon.Animals;
            if (wagon.ContainsCarnivore == true)
            {
                if (animal.FoodType == "Carnivore")
                {
                    return false;
                }
                else //(animal.FoodType == "Herbivore")
                {
                    //added this first
                    return CarnInWagon(wagon, animal);
                }
            }
            else //doesn't have a carnivore 
            {
                if (animal.FoodType == "Carnivore")
                {
                    return CarnNotInWagon(wagon, animal);
                }
                else // add herb
                {
                    return CarnNotInWagon(wagon, animal);
                }
            }
        }

        /// <summary>
        /// Continue checken when there is no carn in the wagon yet
        /// </summary>
        /// <param name="wagon"></param>
        /// <param name="animal"></param>
        /// <returns></returns>
        public bool CarnNotInWagon(Wagon wagon, Animal animal)
        {
            if (animal.FoodType == "Carnivore")
            {
                if (animal.AnimalSize < wagon.SmallestAnimal && wagon.Weight + (int)animal.AnimalSize <= 10)
                {
                    wagon.AddAnimal(animal);
                    animalSorter.IsThisTheSmallestAnimal(animal, wagon);
                    return true;
                }
            }
            else if (animal.FoodType != "Carnivore")
            {
                if (wagon.Weight + (int)animal.AnimalSize <= 10)
                {
                    wagon.AddAnimal(animal);
                    animalSorter.IsThisTheSmallestAnimal(animal, wagon);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Continue checken when there is no carn in the wagon yet
        /// </summary>
        /// <param name="wagon"></param>
        /// <param name="animal"></param>
        /// <returns></returns>
        public bool CarnInWagon(Wagon wagon, Animal animal)
        {
            //this was for the herb when haveing a carn in the wagon
            if (animal.AnimalSize > wagon.SmallestAnimal && wagon.SmallestAnimalIsCarnivore == true && wagon.Weight + (int)animal.AnimalSize <= 10)
            {
                wagon.AddAnimal(animal);
                animalSorter.IsThisTheSmallestAnimal(animal, wagon);
                return true;
            }
            else if (wagon.SmallestAnimalIsCarnivore == false && wagon.Weight + (int)animal.AnimalSize <= 10)
            {
                wagon.AddAnimal(animal);
                animalSorter.IsThisTheSmallestAnimal(animal, wagon);
                return true;
            }
            else if (animal.AnimalSize > wagon.SmallestAnimal && wagon.Weight + (int)animal.AnimalSize <= 10)
            {
                wagon.AddAnimal(animal);
                return true;
            }
            else
            {
                return false;
                //can't add this animal
            }
        }
    }
}

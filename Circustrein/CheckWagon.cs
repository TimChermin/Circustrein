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
                    if (wagon.Weight > 0)
                    {
                        if (animal.PointWorth > wagon.SmallestAnimal && wagon.SmallestAnimalIsCarnivore == true && wagon.Weight + animal.PointWorth <= 10)
                        {
                            wagon.AddAnimal(animal);
                            animalSorter.IsThisTheSmallestAnimal(animal, wagon);
                            return true;
                        }
                        else if (wagon.SmallestAnimalIsCarnivore == false && wagon.Weight + animal.PointWorth <= 10)
                        {
                            wagon.AddAnimal(animal);
                            animalSorter.IsThisTheSmallestAnimal(animal, wagon);
                            return true;
                        }
                        else if (animal.PointWorth > wagon.SmallestAnimal && wagon.Weight + animal.PointWorth <= 10)
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
                    else
                    {
                        wagon.AddAnimal(animal);
                        animalSorter.IsThisTheSmallestAnimal(animal, wagon);
                        return true;
                    }
                }
            }
            else //doesn't have a carnivore 
            {
                if (animal.FoodType == "Carnivore")
                {
                    if (wagon.Weight > 0)
                    {
                        if (animal.PointWorth < wagon.SmallestAnimal && wagon.Weight + animal.PointWorth <= 10)
                        {
                            wagon.AddAnimal(animal);
                            animalSorter.IsThisTheSmallestAnimal(animal, wagon);
                            return true;
                        }
                        else
                        {
                            //can't add animal
                            return false;
                        }
                    }
                    else
                    {
                        wagon.AddAnimal(animal);
                        animalSorter.IsThisTheSmallestAnimal(animal, wagon);
                        return true;
                    }
                }
                else // add herb
                {
                    if (wagon.Weight > 0)
                    {
                        if (wagon.Weight + animal.PointWorth <= 10)
                        {
                            wagon.AddAnimal(animal);
                            animalSorter.IsThisTheSmallestAnimal(animal, wagon);
                            return true;
                        }
                        else
                        {
                            return false;
                            //can't add this animal
                        }
                    }
                    else
                    {
                        wagon.AddAnimal(animal);
                        animalSorter.IsThisTheSmallestAnimal(animal, wagon);
                        return true;
                    }
                }
            }
        }
    }
}

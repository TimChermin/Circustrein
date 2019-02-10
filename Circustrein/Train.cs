using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein
{
    public class Train
    {
        private List<Wagon> wagons = new List<Wagon>();
        private List<Animal> animals = new List<Animal>();
        private List<Animal> animalsInWagon = new List<Animal>();

        private List<Animal> carnivoreAnimals = new List<Animal>();
        private List<Animal> herbivoreAnimals = new List<Animal>();

        /// <summary>
        /// Adds the animal to the train (not to a wagon)
        /// </summary>
        /// <param name="foodType"></param>
        /// <param name="size"></param>
        public void AddAnimal(string foodType, string size)
        {
            Animal animal = new Animal(foodType, size);
            animals.Add(animal);
        }

        /// <summary>
        /// Sorts the Animals into Herbivores and Carnivores
        /// </summary>
        private void AnimalSorter()
        {
            foreach (Animal animal in animals)
            {
                if (animal.FoodType == "Herbivore")
                {
                    herbivoreAnimals.Add(animal);
                }
                else //FoodType == Carnivores
                {
                    carnivoreAnimals.Add(animal);
                }
            }
        }

        /// <summary>
        /// Adds the animal to the wagons
        /// </summary>
        public void AddAnimalToWagons()
        {
            AnimalSorter();

            if (wagons.Count == 0)
            {
                Wagon wagon = new Wagon();
                wagons.Add(wagon);
            }

            AddAnimalToWagon(carnivoreAnimals);
            AddAnimalToWagon(herbivoreAnimals);

            carnivoreAnimals.Clear();
            herbivoreAnimals.Clear();
            animals.Clear();
        }


        /// <summary>
        /// Adds the animal to the wagon
        /// </summary>
        /// <param name="animals"></param>
        private void AddAnimalToWagon(List<Animal> animals)
        {
            foreach (Animal animal in animals)
            {
                bool succes = false;
                foreach (Wagon wagon in wagons)
                {
                    if (wagon.Full != true)
                    {
                        if (wagon.Weight == 0)
                        {
                            wagon.AddAnimal(animal);
                            IsThisTheSmallestAnimal(animal, wagon);
                            succes = true;
                            //you can add anything
                        }
                        else
                        {
                            succes = CheckWagonTest(wagon, animal);
                        }
                    }
                    else //wagon is full
                    {
                        succes = false;
                    }
                    if (succes == true)
                    {
                        break;
                    }
                }
                if (succes == false)
                {
                    Wagon wag = new Wagon(animal);
                    wagons.Add(wag);
                }
            }
        }

        /// <summary>
        /// Check if the animal can be added to the wagon
        /// </summary>
        /// <param name="wagon"></param>
        /// <param name="animal"></param>
        /// <returns></returns>
        private bool CheckWagonTest(Wagon wagon, Animal animal)
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
                            IsThisTheSmallestAnimal(animal, wagon);
                            return true;
                        }
                        else if (wagon.SmallestAnimalIsCarnivore == false && wagon.Weight + animal.PointWorth <= 10)
                        {
                            wagon.AddAnimal(animal);
                            IsThisTheSmallestAnimal(animal, wagon);
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
                        IsThisTheSmallestAnimal(animal, wagon);
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
                            IsThisTheSmallestAnimal(animal, wagon);
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
                        IsThisTheSmallestAnimal(animal, wagon);
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
                            IsThisTheSmallestAnimal(animal, wagon);
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
                        IsThisTheSmallestAnimal(animal, wagon);
                        return true;
                    }
                }
            }
        }

        /// <summary>
        /// Checks if the to be added Animal is the smallest in the wagon
        /// </summary>
        /// <param name="animal"></param>
        /// <param name="wagon"></param>
        /// <returns></returns>
        private bool IsThisTheSmallestAnimal(Animal animal, Wagon wagon)
        {
            if (wagon.SmallestAnimal >= animal.PointWorth)
            {
                return false;
            }
            else if (wagon.SmallestAnimal < animal.PointWorth && wagon.SmallestAnimalIsCarnivore == true)
            {
                return true;
            }
            else
            {
                wagon.SmallestAnimal = animal.PointWorth;
                if (animal.FoodType == "Carnivore")
                {
                    wagon.SmallestAnimalIsCarnivore = true;
                }
                return true;
            }
        }
        
        /// <summary>
        /// Get all Animals (Not in wagons)
        /// </summary>
        /// <returns></returns>
        public List<Animal> LoadAnimals()
        {
            return animals;
        }

        /// <summary>
        /// Get all Wagons
        /// </summary>
        /// <returns></returns>
        public List<Wagon> LoadWagons()
        {
            return wagons;
        }
    }
}

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
        private AnimalSorter animalSorter;
        private CheckWagon checkWagon;
        private bool succes;

        public Train()
        {
            animalSorter = new AnimalSorter();
            checkWagon = new CheckWagon(animalSorter);
        }

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
        /// Adds the animal to the wagons
        /// </summary>
        public void AddAnimalToWagons()
        {
            animalSorter.SetAnimals(animals, wagons);
            wagons.Clear();
            if (wagons.Count == 0)
            {
                Wagon wagon = new Wagon();
                wagons.Add(wagon);
            }

            AddAnimalToWagon(animalSorter.CarnivoreAnimals);
            AddAnimalToWagon(animalSorter.HerbivoreAnimals);

            animalSorter.CarnivoreAnimals.Clear();
            animalSorter.HerbivoreAnimals.Clear();
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
                succes = false;
                foreach (Wagon wagon in wagons)
                {
                    succes = WhatIsTheWagonWeight(animal, wagon);
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

        private bool WhatIsTheWagonWeight(Animal animal, Wagon wagon)
        {
            if (wagon.Full != true)
            {
                if (wagon.Weight == 0)
                {
                    wagon.AddAnimal(animal);

                    animalSorter.IsThisTheSmallestAnimal(animal, wagon);

                    return succes = true;
                    //you can add anything
                }
                else
                {
                    return succes = checkWagon.CanThisAnimalGoInTheWagon(wagon, animal);
                }
            }
            
            return succes = false;
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

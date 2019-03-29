using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Circustrein.Enums;

namespace Circustrein
{
    class AnimalSorter
    {
        private List<Animal> carnivoreAnimals = new List<Animal>();
        private List<Animal> herbivoreAnimals = new List<Animal>();

        public List<Animal> CarnivoreAnimals { get => carnivoreAnimals; set => carnivoreAnimals = value; }
        public List<Animal> HerbivoreAnimals { get => herbivoreAnimals; set => herbivoreAnimals = value; }




        /// <summary>
        /// Sorts the Animals into Herbivores and Carnivores
        /// </summary>
        public void SortAnimals(List<Animal> animals, List<Wagon> wagons)
        {
            foreach (Wagon wagon in wagons)
            {
                foreach (Animal animal in wagon.Animals)
                {
                    if (animal.FoodType == AnimalType.Herbivore)
                    {
                        herbivoreAnimals.Add(animal);
                    }
                    else //FoodType == Carnivores
                    {
                        carnivoreAnimals.Add(animal);
                    }
                }
            }

            foreach (Animal animal in animals)
            {
                if (animal.FoodType == AnimalType.Herbivore)
                {
                    herbivoreAnimals.Add(animal);
                }
                else //FoodType == Carnivores
                {
                    carnivoreAnimals.Add(animal);
                }
            }
            OrderAnimalsBySize();
        }

        /// <summary>
        /// Orders all animals by size (big first and small last)
        /// </summary>
        public void OrderAnimalsBySize()
        {
            carnivoreAnimals = carnivoreAnimals.OrderByDescending(animal => animal.AnimalSize).ToList();
            herbivoreAnimals = herbivoreAnimals.OrderByDescending(animal => animal.AnimalSize).ToList();
        }



        /// <summary>
        /// Checks if the to be added Animal is the smallest in the wagon
        /// </summary>
        /// <param name="animal"></param>
        /// <param name="wagon"></param>
        /// <returns></returns>
        public bool IsThisTheSmallestAnimal(Animal animal, Wagon wagon)
        {
            //when the animal in the wagon is bigger than the to be added animal
            if (wagon.SmallestAnimal >= animal.AnimalSize)
            {
                return false;
            }
            //when the animal in the wagon is smaller than the to be added animal and the to wagon has a Carn
            else if (wagon.SmallestAnimal < animal.AnimalSize && wagon.SmallestAnimalIsCarnivore == true)
            {
                return true;
            }
            else
            {
                wagon.SmallestAnimal = animal.AnimalSize;
                if (animal.FoodType == AnimalType.Carnivore)
                {
                    wagon.SmallestAnimalIsCarnivore = true;
                }
                return true;
            }
        }


    }
}

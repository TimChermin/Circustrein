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
            CarnivoreAnimals.Clear();
            HerbivoreAnimals.Clear();

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


        


    }
}

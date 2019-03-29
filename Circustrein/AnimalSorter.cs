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

        public List<Animal> CarnivoreAnimals { get; set; }
        public List<Animal> HerbivoreAnimals { get; set; }

        
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
                        HerbivoreAnimals.Add(animal);
                    }
                    else //FoodType == Carnivores
                    {
                        CarnivoreAnimals.Add(animal);
                    }
                }
            }

            foreach (Animal animal in animals)
            {
                if (animal.FoodType == AnimalType.Herbivore)
                {
                    HerbivoreAnimals.Add(animal);
                }
                else //FoodType == Carnivores
                {
                    CarnivoreAnimals.Add(animal);
                }
            }
            CarnivoreAnimals = CarnivoreAnimals.OrderByDescending(animal => animal.AnimalSize).ToList();
            HerbivoreAnimals = HerbivoreAnimals.OrderByDescending(animal => animal.AnimalSize).ToList();
        }
    }
}

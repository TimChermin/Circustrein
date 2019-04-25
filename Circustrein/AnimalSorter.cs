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

        public void SortAnimals(List<Animal> animals, List<Wagon> wagons)
        {
            CarnivoreAnimals = new List<Animal>();
            HerbivoreAnimals = new List<Animal>();

            if (wagons == null || animals == null)
            {
                return;
            }

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

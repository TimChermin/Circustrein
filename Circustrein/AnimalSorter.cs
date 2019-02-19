using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void SortAnimals(List<Animal> animals)
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

    }
}

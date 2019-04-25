using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Circustrein.Enums;

namespace Circustrein
{
    public class AnimalSorter
    {
        public List<Animal> CarnivoreAnimals { get; set; }
        public List<Animal> HerbivoreAnimals { get; set; }
        public List<Animal> Animals { get; set; }

        public AnimalSorter()
        {
            Animals = new List<Animal>();
        }

        public void SortAnimals(List<Animal> animals, List<Wagon> wagons)
        {
            if (wagons == null || animals == null)
            {
                return;
            }

            foreach (Wagon wagon in wagons)
            {
                foreach (Animal animal in wagon.Animals)
                {
                    Animals.Add(animal);
                }
            }

            foreach (Animal animal in animals)
            {
                Animals.Add(animal);
            }
            Animals = Animals.OrderByDescending(animal => animal.AnimalSize).ToList();
            Animals = Animals.OrderByDescending(animal => animal.FoodType).ToList();
        }
    }
}

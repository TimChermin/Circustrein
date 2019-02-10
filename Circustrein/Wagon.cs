using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein
{
    public class Wagon
    {
        private int weight;
        private bool full;
        private int smallestAnimal;
        private bool smallestAnimalIsCarnivore;
        private bool containsCarnivore;

        private List<Animal> animals = new List<Animal>();

        public Wagon()
        {
            weight = 0;
            smallestAnimal = 0;
            containsCarnivore = false;
            smallestAnimalIsCarnivore = false;
            full = false;
        }

        public Wagon(Animal animal)
        {
            smallestAnimal = 0;
            //containsCarnivore = false;
            smallestAnimalIsCarnivore = false;
            full = false;
            AddAnimal(animal);
        }

        public int Weight { get => weight; set => weight = value; }
        public List<Animal> Animals { get => animals; set => animals = value; }
        public bool Full { get => full; set => full = value; }
        public int SmallestAnimal { get => smallestAnimal; set => smallestAnimal = value; }
        public bool ContainsCarnivore { get => containsCarnivore; set => containsCarnivore = value; }
        public bool SmallestAnimalIsCarnivore { get => smallestAnimalIsCarnivore; set => smallestAnimalIsCarnivore = value; }

        /// <summary>
        /// Adds the animal to this wagon
        /// </summary>
        /// <param name="animal"></param>
        public void AddAnimal(Animal animal)
        {
            animals.Add(animal);
            weight += animal.PointWorth;
            if (animal.FoodType == "Carnivore")
            {
                containsCarnivore = true;
                smallestAnimalIsCarnivore = true;
                smallestAnimal = animal.PointWorth;
            }
            else if (animal.FoodType == "Herbivore" && containsCarnivore != true)
            {
                containsCarnivore = false;
            }
            
            if ((animal.PointWorth == 5 && animal.FoodType == "Carnivore") || (weight == 10))
            {
                full = true;
            }
        }


        public override string ToString()
        {
            string wagons = "";
            foreach (Animal animal in animals)
            {
                wagons += animal.FoodType + ": " + animal.Size + System.Environment.NewLine;
            }
            return wagons;
        }
    }
}

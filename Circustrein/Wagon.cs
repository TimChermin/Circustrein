using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Circustrein.Enums;

namespace Circustrein
{
    public class Wagon
    {
        private List<Animal> animals = new List<Animal>();

        public Wagon()
        {
            Weight = 0;
            SmallestAnimal = AnimalSize.Nothing;
            ContainsCarnivore = false;
            SmallestAnimalIsCarnivore = false;
            Full = false;
        }

        public Wagon(Animal animal)
        {
            SmallestAnimal = AnimalSize.Nothing;
            ContainsCarnivore = false;
            SmallestAnimalIsCarnivore = false;
            Full = false;
            AddAnimal(animal);
        }

        public int Weight { get; set; }
        public List<Animal> Animals { get; set; }
        public bool Full { get; set; }
        public AnimalSize SmallestAnimal { get; set; }
        public bool ContainsCarnivore { get; set; }
        public bool SmallestAnimalIsCarnivore { get; set; }

        /// <summary>
        /// Adds the animal to this wagon
        /// </summary>
        /// <param name="animal"></param>
        public void AddAnimal(Animal animal)
        {
            if (animal.FoodType == AnimalType.Carnivore)
            {
                ContainsCarnivore = true;
                SmallestAnimalIsCarnivore = true;
                SmallestAnimal = animal.AnimalSize;
            }
            
            if ((animal.AnimalSize == AnimalSize.Big && animal.FoodType == AnimalType.Carnivore) || (Weight == 10))
            {
                Full = true;
            }
            animals.Add(animal);
            Weight += (int)animal.AnimalSize;
        }


        public override string ToString()
        {
            string wagons = "";
            foreach (Animal animal in animals)
            {
                wagons += animal.FoodType + ": " + animal.AnimalSize.ToString() + System.Environment.NewLine;
            }
            return wagons;
        }
    }
}

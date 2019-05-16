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
        public Wagon()
        {
            Weight = 0;
            SmallestAnimal = AnimalSize.Nothing;
            Animals = new List<Animal>();
        }
        public Wagon(Animal animal)
        {
            Animals = new List<Animal>();
            SmallestAnimal = animal.AnimalSize;
            AddAnimal(animal);
        }

        public int Weight { get; set; }
        public List<Animal> Animals { get; set; }
        public AnimalSize SmallestAnimal { get; set; }
        public bool ContainsCarnivore { get; set; }
        public bool SmallestAnimalIsCarnivore { get; set; }
        

        public bool TryToAddTheAnimal(Animal animal)
        {
            if (animal.ThisAnimalWontEatOrGetEatenWhenAdded(ContainsCarnivore, SmallestAnimalIsCarnivore, SmallestAnimal) && AddingTheAnimalWontGoOverMaxWeight(animal))
            {
                AddAnimal(animal);
                return true;
            }
            return false;
        }

        private void AddAnimal(Animal animal)
        {
            if (animal.FoodType == AnimalType.Carnivore)
            {
                ContainsCarnivore = true;
                SmallestAnimalIsCarnivore = true;
                SmallestAnimal = animal.AnimalSize;
            }
            IsTheAnimalTheSmallest(animal);
            Animals.Add(animal);
            Weight += (int)animal.AnimalSize;
        }

        private void IsTheAnimalTheSmallest(Animal animal)
        {
            if (SmallestAnimal >= animal.AnimalSize)
            {
                SmallestAnimal = animal.AnimalSize;
            }
        }

        private bool AddingTheAnimalWontGoOverMaxWeight(Animal animal)
        {
            if (Weight + (int)animal.AnimalSize <= 10)
            {
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            string wagons = "";
            foreach (Animal animal in Animals)
            {
                wagons += animal.FoodType + ": " + animal.AnimalSize.ToString() + System.Environment.NewLine;
            }
            return wagons;
        }
    }
}

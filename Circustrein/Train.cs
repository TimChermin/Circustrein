using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Circustrein.Enums;

namespace Circustrein
{
    public class Train
    {
        private List<Wagon> wagons = new List<Wagon>();
        private List<Animal> animals = new List<Animal>();
        private bool succes;

        public Train()
        {

        }

        public List<Animal> CarnivoreAnimals { get; set; }
        public List<Animal> HerbivoreAnimals { get; set; }


        public void AddAnimalToTrain(AnimalType foodType, AnimalSize size)
        {
            animals.Add(new Animal(foodType, size));
        }
        
        public void AddAnimalsToWagons()
        {
            SortAnimals(animals, wagons);
            
            wagons.Clear();
            Wagon wagon = new Wagon();
            wagons.Add(wagon);

            //first add the Carn to the wagon, after that you add the Herbs
            AddAnimalsToWagon(CarnivoreAnimals);
            AddAnimalsToWagon(HerbivoreAnimals);
            animals.Clear();
        }

        
        private void AddAnimalsToWagon(List<Animal> animals)
        {
            foreach (Animal animal in animals)
            {
                succes = false;
                foreach (Wagon wagon in wagons)
                {
                    if (wagon.CanTheAnimalBeAdded(animal) == true)
                    {
                        wagon.AddAnimal(animal);
                        succes = true;
                        break;
                    }
                }

                if (succes == false)
                {
                    Wagon wagon = new Wagon(animal);
                    wagons.Add(wagon);
                }
            }
        }
        

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

        public List<Animal> LoadAnimals()
        {
            return animals;
        }
        
        public List<Wagon> LoadWagons()
        {
            return wagons;
        }
    }
}

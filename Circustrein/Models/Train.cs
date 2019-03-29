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
        private AnimalSorter animalSorter;
        private CheckWagon checkWagon;
        private bool succes;

        public Train()
        {
            animalSorter = new AnimalSorter();
            checkWagon = new CheckWagon(animalSorter);
        }
        
        public void AddAnimalToTrain(AnimalType foodType, AnimalSize size)
        {
            animals.Add(new Animal(foodType, size));
        }
        
        public void AddAnimalsToWagons()
        {
            animalSorter.SortAnimals(animals, wagons);
            
            wagons.Clear();
            Wagon wagon = new Wagon();
            wagons.Add(wagon);

            //first add the Carn to the wagon, after that you add the Herbs
            AddAnimalsToWagon(animalSorter.CarnivoreAnimals);
            AddAnimalsToWagon(animalSorter.HerbivoreAnimals);
            animals.Clear();
        }

        
        private void AddAnimalsToWagon(List<Animal> animals)
        {
            foreach (Animal animal in animals)
            {
                succes = false;
                foreach (Wagon wagon in wagons)
                {
                    if (checkWagon.IsTheWagonEmpty(wagon) == false)
                    {
                        if (checkWagon.CanThisAnimalGoInTheWagon(wagon, animal) == true)
                        {
                            wagon.AddAnimal(animal);
                            succes = true;
                            break;
                        }
                        
                    }
                    else if (checkWagon.IsTheWagonEmpty(wagon) == true)
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

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
        public List<Wagon> wagons = new List<Wagon>();
        public List<Animal> animals = new List<Animal>();
        private bool succes;

        public Train()
        {

        }

        public void AddAnimalToTrain(AnimalType foodType, AnimalSize size)
        {
            animals.Add(new Animal(foodType, size));
        }
        
        public void AddAnimalsToWagon(List<Animal> animals)
        {
            foreach (Animal animal in animals)
            {
                succes = false;
                foreach (Wagon wagon in wagons)
                {
                    if (wagon.TryToAddTheAnimal(animal) == true)
                    {
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

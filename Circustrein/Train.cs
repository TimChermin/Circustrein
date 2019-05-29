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
        private bool succes;

        public Train()
        {
            Animals = new List<Animal>();
            Wagons = new List<Wagon>();
        }

        public List<Animal> Animals { get; set; }
        public List<Wagon> Wagons { get; set; }

        public void AddAnimalToTrain(AnimalType foodType, AnimalSize size)
        {
            Animals.Add(new Animal(foodType, size));
        }
        
        public void AddAnimalsToWagon(List<Animal> animals)
        {
            foreach (Animal animal in animals)
            {
                succes = false;
                foreach (Wagon wagon in Wagons)
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
                    Wagons.Add(wagon);
                }
            }
        }
    }
}

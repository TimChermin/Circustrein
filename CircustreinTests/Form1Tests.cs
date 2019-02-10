using Microsoft.VisualStudio.TestTools.UnitTesting;
using Circustrein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein.Tests
{
    [TestClass()]
    public class Form1Tests
    {

        Train train = new Train();

        //adds the first Animals for testing (before everything else)
        [TestInitialize]
        public void AddStartingAnimals()
        {
            for (int i = 0; i <= 15; i++)
            {
                if (i > 8 & i < 11)
                {
                    train.AddAnimal("Herbivore", "Big");
                }
                else if (i == 3)
                {
                    train.AddAnimal("Carnivore", "Medium");
                }
                else if (i >= 3 && i <= 8)
                {
                    train.AddAnimal("Carnivore", "Small");
                }
                else
                {
                    train.AddAnimal("Herbivore", "Medium");
                }
            }
            train.AddAnimalToWagons();
        }


        //check for multiple carnivores in the wagons (more than 1 == false)
        [TestMethod()]
        public void buttonAddAnimal_ClickTest()
        {
            foreach (Wagon wagon in train.LoadWagons())
            {
                int carnivoresInWagon = 0;

                
                foreach (Animal animal in wagon.Animals)
                {
                    if (animal.FoodType == "Carnivore")
                    {
                        carnivoresInWagon += 1;
                    }
                }

                Assert.IsFalse(carnivoresInWagon > 1);
            }
        }

        //check if the wagons weigh less than 10
        [TestMethod()]
        public void wagonWeight()
        {
            foreach (Wagon wagon in train.LoadWagons())
            {
                Assert.IsTrue(wagon.Weight <= 10);
            }
        }


    }
}
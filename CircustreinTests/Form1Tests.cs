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

        Train train;

        //adds the first Animals for testing (before everything else)
        [TestInitialize]
        public void CreateList()
        {
            train = new Train();

            /*for (int i = 0; i <= 15; i++)
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
            */
            train.AddAnimalToWagons();
        }

        //Should_ExpectedBehavior_When_StateUnderTest


        //Check for multiple carnivores in the wagons (more than 1 == false)
        [TestMethod()]
        public void Should_NotAddCarn_When_TheWagonAlreadyHasAnCarn()
        {
            //Arrange
            train.AddAnimal("Carnivore", "Small");
            train.AddAnimal("Carnivore", "Small");
            train.AddAnimal("Carnivore", "Small");
            train.AddAnimal("Carnivore", "Small");
            train.AddAnimal("Carnivore", "Small");
            train.AddAnimalToWagons();

            //Act
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

                //Assert
                Assert.IsFalse(carnivoresInWagon > 1);
            }
        }

        //Should_ExpectedBehavior_When_StateUnderTest

        //Check if the wagons weigh less than 10
        [TestMethod()]
        public void Should_NotGoOverTheMaxWagonWeight_When_AddingAnimals()
        {
            //Arrange
            train.AddAnimal("Herbivore", "Big");
            train.AddAnimal("Herbivore", "Big");
            train.AddAnimal("Herbivore", "Big");
            train.AddAnimal("Herbivore", "Big");
            train.AddAnimalToWagons();
            

            train.AddAnimal("Carnivore", "Medium");
            train.AddAnimal("Herbivore", "Big");
            train.AddAnimal("Carnivore", "Medium");
            train.AddAnimal("Carnivore", "Medium");
            train.AddAnimal("Carnivore", "Medium");
            train.AddAnimal("Carnivore", "Medium");
            train.AddAnimalToWagons();

            //Act
            foreach (Wagon wagon in train.LoadWagons())
            {
                //Assert
                Assert.IsTrue(wagon.Weight <= 10);
            }

            //Act
            int wagonCount = 0;
            foreach (Wagon wagon in train.LoadWagons())
            {
                wagonCount++;
            }
            //Assert
            Assert.IsTrue(wagonCount == 5);
        }

        [TestMethod()]
        public void Should_NotAddCarnToWagon_When_ItHasAnSmallerOrTheSameSizeHerb()
        {
            //Arrange
            train.AddAnimal("Herbivore", "Small");
            train.AddAnimal("Herbivore", "Small");
            train.AddAnimal("Herbivore", "Small");
            train.AddAnimal("Herbivore", "Small");
            train.AddAnimal("Herbivore", "Small");

            train.AddAnimal("Carnivore", "Small");
            train.AddAnimal("Carnivore", "Small");
            train.AddAnimal("Carnivore", "Small");
            train.AddAnimal("Carnivore", "Small");
            train.AddAnimal("Carnivore", "Small");
            train.AddAnimalToWagons();

            //Act
            int wagonCount = 0;
            foreach (Wagon wagon in train.LoadWagons())
            {
                wagonCount++;
            }

            //Assert
            Assert.IsTrue(wagonCount == 6);
        }


        [TestMethod()]
        public void Should_NotAddCarnToWagon_When_ItHasAnSmall()
        {
            //Arrange
            train.AddAnimal("Herbivore", "Small");
            train.AddAnimal("Herbivore", "Small");
            train.AddAnimal("Herbivore", "Small");
            train.AddAnimal("Herbivore", "Small");
            train.AddAnimal("Herbivore", "Small");

            train.AddAnimal("Carnivore", "Small");
            train.AddAnimal("Carnivore", "Small");
            train.AddAnimal("Carnivore", "Small");
            train.AddAnimal("Carnivore", "Small");
            train.AddAnimal("Carnivore", "Small");
            train.AddAnimalToWagons();
        }
    }
}
/*animals = new List<Animal>();
           animals.Add(animal = new Animal( "Carnivore", "Medium"));
           animals.Add(animal = new Animal("Herbivore", "Big"));
           animals.Add(animal = new Animal("Carnivore", "Medium"));
           animals.Add(animal = new Animal("Carnivore", "Medium"));
           animals.Add(animal = new Animal("Carnivore", "Medium"));
           animals.Add(animal = new Animal("Carnivore", "Medium"));*/

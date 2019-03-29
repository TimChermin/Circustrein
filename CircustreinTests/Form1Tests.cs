using Microsoft.VisualStudio.TestTools.UnitTesting;
using Circustrein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Circustrein.Enums;

namespace Circustrein.Tests
{
    [TestClass()]
    public class Form1Tests
    {

        Train train = new Train();

        //adds the first Animals for testing (before everything else)
        [TestInitialize]
        public void CreateList()
        {
            

           
        }

        //Should_ExpectedBehavior_When_StateUnderTest


        //Check for multiple carnivores in the wagons (more than 1 == false)
        [TestMethod()]
        public void Should_NotAddCarn_When_TheWagonAlreadyHasAnCarn()
        {
            //Arrange
            train.AddAnimalToTrain(AnimalType.Carnivore, AnimalSize.Small);
            train.AddAnimalToTrain(AnimalType.Carnivore, AnimalSize.Small);
            train.AddAnimalToTrain(AnimalType.Carnivore, AnimalSize.Small);
            train.AddAnimalToTrain(AnimalType.Carnivore, AnimalSize.Small);
            train.AddAnimalToTrain(AnimalType.Carnivore, AnimalSize.Small);
            train.AddAnimalToTrain(AnimalType.Carnivore, AnimalSize.Big);
            train.AddAnimalsToWagons();

            //Act
            foreach (Wagon wagon in train.LoadWagons())
            {
                int carnivoresInWagon = 0;
                
                foreach (Animal animal in wagon.Animals)
                {
                    if (animal.FoodType == AnimalType.Carnivore)
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
            train.AddAnimalToTrain(AnimalType.Herbivore, AnimalSize.Big);
            train.AddAnimalToTrain(AnimalType.Herbivore, AnimalSize.Big);
            train.AddAnimalToTrain(AnimalType.Herbivore, AnimalSize.Big);
            train.AddAnimalToTrain(AnimalType.Herbivore, AnimalSize.Big);
            train.AddAnimalsToWagons();


            train.AddAnimalToTrain(AnimalType.Herbivore, AnimalSize.Medium);
            train.AddAnimalToTrain(AnimalType.Herbivore, AnimalSize.Big);
            train.AddAnimalToTrain(AnimalType.Carnivore, AnimalSize.Medium);
            train.AddAnimalToTrain(AnimalType.Carnivore, AnimalSize.Medium);
            train.AddAnimalToTrain(AnimalType.Carnivore, AnimalSize.Medium);
            train.AddAnimalToTrain(AnimalType.Carnivore, AnimalSize.Medium);
            train.AddAnimalsToWagons();

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
            //7 when commenting the wagon.clear();
        }

        [TestMethod()]
        public void Should_NotAddCarnToWagon_When_ItHasAnSmallerOrTheSameSizeHerb()
        {
            //Arrange
            train.AddAnimalToTrain(AnimalType.Herbivore, AnimalSize.Small);
            train.AddAnimalToTrain(AnimalType.Herbivore, AnimalSize.Small);
            train.AddAnimalToTrain(AnimalType.Herbivore, AnimalSize.Small);
            train.AddAnimalToTrain(AnimalType.Herbivore, AnimalSize.Small);
            train.AddAnimalToTrain(AnimalType.Herbivore, AnimalSize.Small);

            train.AddAnimalToTrain(AnimalType.Carnivore, AnimalSize.Small);
            train.AddAnimalToTrain(AnimalType.Carnivore, AnimalSize.Small);
            train.AddAnimalToTrain(AnimalType.Carnivore, AnimalSize.Small);
            train.AddAnimalToTrain(AnimalType.Carnivore, AnimalSize.Small);
            train.AddAnimalToTrain(AnimalType.Carnivore, AnimalSize.Small);
            train.AddAnimalsToWagons();

            //Act
            int wagonCount = 0;
            foreach (Wagon wagon in train.LoadWagons())
            {
                wagonCount++;
            }

            //Assert
            Assert.IsTrue(wagonCount == 6);
        }
    }
}
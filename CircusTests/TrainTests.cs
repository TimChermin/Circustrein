using System;
using Circustrein;
using static Circustrein.Enums;
using Xunit;
using System.Collections.Generic;

namespace CircustreinTests
{
    public class TrainTests
    {
        [Fact]
        public void Should_AddAnimalToTheTrain_When_AddingAnimalsToTheTrain()
        {
            //Arrange
            Train train = new Train();
            Animal animal = new Animal(AnimalType.Herbivore, AnimalSize.Big);
            
            //Act
            train.AddAnimalToTrain(animal.FoodType, animal.AnimalSize);
            bool AnimalAddedToTrain = (train.Animals[0].FoodType == animal.FoodType && train.Animals[0].AnimalSize == animal.AnimalSize);

            //Assert
            Assert.True(AnimalAddedToTrain);
        }


        [Fact]
        public void Should_AddAnimalsToTheWagons_When_AddingAnimalsToTheWagons()
        {
            //Arrange
            Train train = new Train();
            train.Wagons.Add(new Wagon());
            List<Animal> animals = new List<Animal>();
            animals.Add(new Animal(AnimalType.Herbivore, AnimalSize.Big));

            //Act
            train.AddAnimalsToWagon(animals);
            bool animal1Added = (train.Wagons[0].Animals[0].AnimalSize == AnimalSize.Big);

            //Assert
            Assert.True(animal1Added);
        }

        [Fact]
        public void Should_AddAnimalsToTheNewWagon_When_AddingAnimalsToTheWagons()
        {
            //Arrange
            Train train = new Train();
            List<Animal> animals = new List<Animal>();
            animals.Add(new Animal(AnimalType.Herbivore, AnimalSize.Big));

            //Act
            train.AddAnimalsToWagon(animals);
            bool animal1Added = (train.Wagons[0].Animals[0].AnimalSize == AnimalSize.Big);

            //Assert
            Assert.True(animal1Added);
        }
    }
}
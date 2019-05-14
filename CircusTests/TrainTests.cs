using System;
using Circustrein;
using static Circustrein.Enums;
using Xunit;
using System.Collections.Generic;

namespace CircustreinTests
{
    public class TrainTests
    {
        Train train = new Train();
        Train train2 = new Train();
        Animal animal = new Animal(AnimalType.Herbivore, AnimalSize.Big);
        Animal animal2 = new Animal(AnimalType.Carnivore, AnimalSize.Big);

        [Fact]
        public void Should_AddAnimalToTheTrain_When_AddingAnimalsToTheTrain()
        {
            //Arrange
            train.AddAnimalToTrain(animal.FoodType, animal.AnimalSize);
            train.AddAnimalToTrain(animal2.FoodType, animal2.AnimalSize);

            //Act
            bool result1 = train.animals[0].FoodType == animal.FoodType && train.animals[0].AnimalSize == animal.AnimalSize;
            bool result2 = train.animals[1].FoodType == animal2.FoodType && train.animals[1].AnimalSize == animal2.AnimalSize;

            //Assert
            Assert.True(result1);
            Assert.True(result2);
        }

        [Fact]
        public void Should_AddAnimalsToTheWagons_When_AddingAnimalsToTheWagons()
        {
            //Arrange
            List<Animal> animals = new List<Animal>();
            animals.Add(new Animal(AnimalType.Herbivore, AnimalSize.Big));
            animals.Add(new Animal(AnimalType.Herbivore, AnimalSize.Big));
            animals.Add(new Animal(AnimalType.Herbivore, AnimalSize.Medium));
            animals.Add(new Animal(AnimalType.Herbivore, AnimalSize.Medium));
            animals.Add(new Animal(AnimalType.Herbivore, AnimalSize.Medium));
            animals.Add(new Animal(AnimalType.Herbivore, AnimalSize.Small));
            
            //Act
            train.AddAnimalsToWagon(animals);
            
            //Assert
            Assert.True(train.LoadWagons()[0].Animals[0].AnimalSize == AnimalSize.Big);
            Assert.True(train.LoadWagons()[0].Animals[1].AnimalSize == AnimalSize.Big);
            Assert.True(train.LoadWagons()[1].Animals[0].AnimalSize == AnimalSize.Medium);
            Assert.True(train.LoadWagons()[1].Animals[1].AnimalSize == AnimalSize.Medium);
            Assert.True(train.LoadWagons()[1].Animals[2].AnimalSize == AnimalSize.Medium);
            Assert.True(train.LoadWagons()[1].Animals[3].AnimalSize == AnimalSize.Small);

        }

    }
}

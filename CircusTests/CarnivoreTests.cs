using Circustrein;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static Circustrein.Enums;

namespace CircustreinTests
{
    public class CarnivoreTests
    {
        [Fact]
        public void Should_NotAddCarn_When_TheWagonAlreadyHasACarn()
        {
            //Arrange
            Wagon wagon = new Wagon(new Animal(AnimalType.Carnivore, AnimalSize.Medium));
            Animal animal = new Animal(AnimalType.Carnivore, AnimalSize.Small);

            //Act
            bool AnimalWontGetEaten = animal.WontEatOrGetEatenWhenAdded(wagon.ContainsCarnivore, wagon.SmallestAnimalIsCarnivore, wagon.SmallestAnimal);
       
            //Assert
            Assert.False(AnimalWontGetEaten);
        }
        

        [Fact]
        public void Should_AddCarn_When_TheWagonDoesntAlreadyHaveACarn()
        {
            //Arrange
            Wagon wagon = new Wagon();
            Animal animal = new Animal(AnimalType.Carnivore, AnimalSize.Small);

            //Act
            bool AnimalWontGetEaten = animal.WontEatOrGetEatenWhenAdded(wagon.ContainsCarnivore, wagon.SmallestAnimalIsCarnivore, wagon.SmallestAnimal);
            
            //Assert
            Assert.True(AnimalWontGetEaten);
        }

        [Fact]
        public void Should_AddCarn_When_TheWagonAlreadyHasABiggerHerb()
        {
            //Arrange
            Wagon wagon = new Wagon(new Animal(AnimalType.Herbivore, AnimalSize.Medium));
            Animal animal = new Animal(AnimalType.Carnivore, AnimalSize.Small);

            //Act
            bool AnimalWontGetEaten = animal.WontEatOrGetEatenWhenAdded(wagon.ContainsCarnivore, wagon.SmallestAnimalIsCarnivore, wagon.SmallestAnimal);

            //Assert
            Assert.True(AnimalWontGetEaten);
        }

        [Fact]
        public void Should_NotAddCarn_When_TheWagonAlreadyHasASmallerHerb()
        {
            //Arrange
            Wagon wagon = new Wagon(new Animal(AnimalType.Herbivore, AnimalSize.Medium));
            Animal animal = new Animal(AnimalType.Carnivore, AnimalSize.Big);

            //Act
            bool AnimalWontGetEaten = animal.WontEatOrGetEatenWhenAdded(wagon.ContainsCarnivore, wagon.SmallestAnimalIsCarnivore, wagon.SmallestAnimal);

            //Assert
            Assert.False(AnimalWontGetEaten);
        }

    }
}

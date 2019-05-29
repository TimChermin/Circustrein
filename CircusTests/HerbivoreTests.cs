using Circustrein;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static Circustrein.Enums;

namespace CircustreinTests
{
    public class HerbivoreTests
    {
        [Fact]
        public void Should_NotAddHerb_When_TheWagonAlreadyHasABiggerCarn()
        {
            //Arrange
            Wagon wagon = new Wagon(new Animal(AnimalType.Carnivore, AnimalSize.Medium));
            Animal animal = new Animal(AnimalType.Herbivore, AnimalSize.Small);

            //Act
            bool AnimalWontGetEaten = animal.WontEatOrGetEatenWhenAdded(wagon.ContainsCarnivore, wagon.SmallestAnimalIsCarnivore, wagon.SmallestAnimal);

            //Assert
            Assert.False(AnimalWontGetEaten);
        }

        [Fact]
        public void Should_AddHerb_When_TheWagonAlreadyHasASmallerCarn()
        {
            //Arrange
            Wagon wagon = new Wagon(new Animal(AnimalType.Carnivore, AnimalSize.Medium));
            Animal animal = new Animal(AnimalType.Herbivore, AnimalSize.Big);

            //Act
            bool AnimalWontGetEaten = animal.WontEatOrGetEatenWhenAdded(wagon.ContainsCarnivore, wagon.SmallestAnimalIsCarnivore, wagon.SmallestAnimal);

            //Assert
            Assert.True(AnimalWontGetEaten);
        }


        [Fact]
        public void Should_AddHerb_When_TheWagonDoesntAlreadyHaveACarn()
        {
            //Arrange
            Wagon wagon = new Wagon();
            Animal animal = new Animal(AnimalType.Herbivore, AnimalSize.Small);

            //Act
            bool AnimalWontGetEaten = animal.WontEatOrGetEatenWhenAdded(wagon.ContainsCarnivore, wagon.SmallestAnimalIsCarnivore, wagon.SmallestAnimal);

            //Assert
            Assert.True(AnimalWontGetEaten);
        }

        [Fact]
        public void Should_AddHerb_When_TheWagonAlreadyHasAHerb()
        {
            //Arrange
            Wagon wagon = new Wagon(new Animal(AnimalType.Herbivore, AnimalSize.Medium));
            Animal animal = new Animal(AnimalType.Herbivore, AnimalSize.Small);

            //Act
            bool AnimalWontGetEaten = animal.WontEatOrGetEatenWhenAdded(wagon.ContainsCarnivore, wagon.SmallestAnimalIsCarnivore, wagon.SmallestAnimal);

            //Assert
            Assert.True(AnimalWontGetEaten);
        }




    }
}

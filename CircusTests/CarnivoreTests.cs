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
            Wagon wagon2 = new Wagon(new Animal(AnimalType.Herbivore, AnimalSize.Medium));
            Animal animal = new Animal(AnimalType.Carnivore, AnimalSize.Small);
            Animal animal2 = new Animal(AnimalType.Herbivore, AnimalSize.Big);

            //Act
            bool AnimalWontGetEaten1 = animal.ThisAnimalWontEatOrGetEatenWhenAdded(wagon.ContainsCarnivore, wagon.SmallestAnimalIsCarnivore, wagon.SmallestAnimal);
            bool AnimalWontGetEaten2 = animal.ThisAnimalWontEatOrGetEatenWhenAdded(wagon2.ContainsCarnivore, wagon2.SmallestAnimalIsCarnivore, wagon2.SmallestAnimal);
            bool AnimalWontGetEaten3 = animal2.ThisAnimalWontEatOrGetEatenWhenAdded(wagon.ContainsCarnivore, wagon.SmallestAnimalIsCarnivore, wagon.SmallestAnimal);

            //Assert
            Assert.False(AnimalWontGetEaten1);
            Assert.True(AnimalWontGetEaten2);
            Assert.True(AnimalWontGetEaten3);
        }

        [Fact]
        public void Should_NotAddHerb_When_TheWagonAlreadyHasABiggerCarn()
        {
            //Arrange
            Wagon wagon = new Wagon(new Animal(AnimalType.Carnivore, AnimalSize.Medium));
            Animal animalHerbSmall = new Animal(AnimalType.Herbivore, AnimalSize.Small);
            Animal animalHerbMed = new Animal(AnimalType.Herbivore, AnimalSize.Medium);
            Animal animalHerbBig = new Animal(AnimalType.Herbivore, AnimalSize.Big);

            //Act
            bool AnimalWontGetEaten1 = animalHerbSmall.ThisAnimalWontEatOrGetEatenWhenAdded(wagon.ContainsCarnivore, wagon.SmallestAnimalIsCarnivore, wagon.SmallestAnimal);
            bool AnimalWontGetEaten2 = animalHerbMed.ThisAnimalWontEatOrGetEatenWhenAdded(wagon.ContainsCarnivore, wagon.SmallestAnimalIsCarnivore, wagon.SmallestAnimal);
            bool AnimalWontGetEaten3 = animalHerbBig.ThisAnimalWontEatOrGetEatenWhenAdded(wagon.ContainsCarnivore, wagon.SmallestAnimalIsCarnivore, wagon.SmallestAnimal);

            //Assert
            Assert.False(AnimalWontGetEaten1);
            Assert.False(AnimalWontGetEaten2);
            Assert.True(AnimalWontGetEaten3);
        }
    }
}

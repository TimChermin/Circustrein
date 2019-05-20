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
        public void Should_AddAnimal_When_AddingAnotherHerb()
        {
            //Arrange
            Wagon wagon = new Wagon(new Animal(AnimalType.Herbivore, AnimalSize.Big));
            Animal animalHerbSmall = new Animal(AnimalType.Herbivore, AnimalSize.Small);
            Animal animalHerbMed = new Animal(AnimalType.Herbivore, AnimalSize.Medium);
            Animal animalHerbBig = new Animal(AnimalType.Herbivore, AnimalSize.Big);

            //Act
            bool AnimalWontGetEaten1 = animalHerbSmall.ThisAnimalWontEatOrGetEatenWhenAdded(wagon.ContainsCarnivore, wagon.SmallestAnimalIsCarnivore, wagon.SmallestAnimal);
            bool AnimalWontGetEaten2 = animalHerbMed.ThisAnimalWontEatOrGetEatenWhenAdded(wagon.ContainsCarnivore, wagon.SmallestAnimalIsCarnivore, wagon.SmallestAnimal);
            bool AnimalWontGetEaten3 = animalHerbBig.ThisAnimalWontEatOrGetEatenWhenAdded(wagon.ContainsCarnivore, wagon.SmallestAnimalIsCarnivore, wagon.SmallestAnimal);

            //Assert
            Assert.True(AnimalWontGetEaten1);
            Assert.True(AnimalWontGetEaten2);
            Assert.True(AnimalWontGetEaten3);
        }
    }
}

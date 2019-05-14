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
            bool result1 = animalHerbSmall.WillThisAnimalNotEatOrGetEaten(wagon.SmallestAnimal);
            bool result2 = animalHerbMed.WillThisAnimalNotEatOrGetEaten(wagon.SmallestAnimal);
            bool result3 = animalHerbBig.WillThisAnimalNotEatOrGetEaten(wagon.SmallestAnimal);

            //Assert
            Assert.True(result1);
            Assert.True(result2);
            Assert.True(result3);
        }
    }
}

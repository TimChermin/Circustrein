using System;
using Circustrein;
using static Circustrein.Enums;
using Xunit;

namespace CircustreinTests
{
    public class WagonTests
    {

        [Fact]
        public void Should_ReturnTrue_When_TheAnimalIsAdded()
        {
            //Arrange
            Wagon wagon = new Wagon();

            //Act
            bool AnimalAdded = wagon.TryToAddTheAnimal(new Animal(AnimalType.Herbivore, AnimalSize.Big));

            //Assert
            Assert.True(AnimalAdded);
        }


        [Fact]
        public void Should_ReturnFalse_When_TheAnimalIsNotAdded()
        {
            //Arrange
            Wagon wagon = new Wagon();
            wagon.TryToAddTheAnimal(new Animal(AnimalType.Herbivore, AnimalSize.Big));
            wagon.TryToAddTheAnimal(new Animal(AnimalType.Herbivore, AnimalSize.Big));

            //Act
            bool AnimalAdded = wagon.TryToAddTheAnimal(new Animal(AnimalType.Herbivore, AnimalSize.Big));

            //Assert
            Assert.False(AnimalAdded);
        }
    }
}

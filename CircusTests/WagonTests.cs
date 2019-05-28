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
            Wagon wagon2 = new Wagon();
            wagon2.TryToAddTheAnimal(new Animal(AnimalType.Herbivore, AnimalSize.Big));
            wagon2.TryToAddTheAnimal(new Animal(AnimalType.Herbivore, AnimalSize.Big));

            //Act
            bool AnimalAdded = wagon.TryToAddTheAnimal(new Animal(AnimalType.Herbivore, AnimalSize.Big));
            bool AnimalAdded2 = wagon2.TryToAddTheAnimal(new Animal(AnimalType.Herbivore, AnimalSize.Big));

            //Assert
            Assert.True(AnimalAdded);
            Assert.False(AnimalAdded2);
        }
    }
}

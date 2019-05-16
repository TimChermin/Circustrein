using System;
using Circustrein;
using static Circustrein.Enums;
using Xunit;

namespace CircustreinTests
{
    public class WagonTests
    {
        Wagon wagon = new Wagon();
        Wagon wagon2 = new Wagon();

        [Fact]
        public void Should_ReturnTrue_When_TheWagonIsEmpty()
        {
            wagon2.TryToAddTheAnimal(new Animal(AnimalType.Herbivore, AnimalSize.Big));
            wagon2.TryToAddTheAnimal(new Animal(AnimalType.Herbivore, AnimalSize.Big));

            Assert.True(wagon.TryToAddTheAnimal(new Animal(AnimalType.Herbivore, AnimalSize.Big)));
            Assert.False(wagon2.TryToAddTheAnimal(new Animal(AnimalType.Herbivore, AnimalSize.Big)));
        }
    }
}

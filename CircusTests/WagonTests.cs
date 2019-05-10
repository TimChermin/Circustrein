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
            
            Assert.True(wagon.IsTheWagonEmpty());
            Assert.False(wagon2.IsTheWagonEmpty());
        }
    }
}

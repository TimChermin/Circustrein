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
            bool AnimalWontGetEaten1 = animalHerbSmall.WontEatOrGetEatenWhenAdded(wagon.ContainsCarnivore, wagon.SmallestAnimalIsCarnivore, wagon.SmallestAnimal);
            bool AnimalWontGetEaten2 = animalHerbMed.WontEatOrGetEatenWhenAdded(wagon.ContainsCarnivore, wagon.SmallestAnimalIsCarnivore, wagon.SmallestAnimal);
            bool AnimalWontGetEaten3 = animalHerbBig.WontEatOrGetEatenWhenAdded(wagon.ContainsCarnivore, wagon.SmallestAnimalIsCarnivore, wagon.SmallestAnimal);

            //Assert
            Assert.True(AnimalWontGetEaten1);
            Assert.True(AnimalWontGetEaten2);
            Assert.True(AnimalWontGetEaten3);
        }

        [Fact]
        public void Should_NotAddHerb_When_TheWagonAlreadyHasABiggerCadrn()
        {
            //Arrange
            Wagon wagon = new Wagon(new Animal(AnimalType.Carnivore, AnimalSize.Medium));
            Animal animalHerbSmall = new Animal(AnimalType.Herbivore, AnimalSize.Small);
            Animal animalHerbMed = new Animal(AnimalType.Herbivore, AnimalSize.Medium);
            Animal animalHerbBig = new Animal(AnimalType.Herbivore, AnimalSize.Big);

            //Act
            bool AnimalWontGetEaten1 = animalHerbSmall.WontEatOrGetEatenWhenAdded(wagon.ContainsCarnivore, wagon.SmallestAnimalIsCarnivore, wagon.SmallestAnimal);
            bool AnimalWontGetEaten2 = animalHerbMed.WontEatOrGetEatenWhenAdded(wagon.ContainsCarnivore, wagon.SmallestAnimalIsCarnivore, wagon.SmallestAnimal);
            bool AnimalWontGetEaten3 = animalHerbBig.WontEatOrGetEatenWhenAdded(wagon.ContainsCarnivore, wagon.SmallestAnimalIsCarnivore, wagon.SmallestAnimal);

            //Assert
            Assert.False(AnimalWontGetEaten1);
            Assert.False(AnimalWontGetEaten2);
            Assert.True(AnimalWontGetEaten3);
        }






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

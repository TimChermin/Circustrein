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
        Train train = new Train();

        [Fact]
        public void Should_NotAddCarn_When_TheWagonAlreadyHasACarn()
        {
            //Arrange
            train.wagons.Add(new Wagon(new Animal(AnimalType.Carnivore, AnimalSize.Medium)));
            train.wagons.Add(new Wagon(new Animal(AnimalType.Herbivore, AnimalSize.Medium)));
            Animal animal = new Animal(AnimalType.Carnivore, AnimalSize.Small);

            //Act
            Assert.False(animal.CanThisAnimalGoInTheWagon(train.wagons[0].ContainsCarnivore, train.wagons[0].SmallestAnimalIsCarnivore, train.wagons[0].Weight, train.wagons[0].SmallestAnimal));
            Assert.True(animal.CanThisAnimalGoInTheWagon(train.wagons[1].ContainsCarnivore, train.wagons[1].SmallestAnimalIsCarnivore, train.wagons[1].Weight, train.wagons[1].SmallestAnimal));
        }

        [Fact]
        public void Should_NotAddHerb_When_TheWagonAlreadyHasABiggerCarn()
        {
            train.wagons.Add(new Wagon(new Animal(AnimalType.Carnivore, AnimalSize.Medium)));
            
            Animal animalHerbSmall = new Animal(AnimalType.Herbivore, AnimalSize.Small);
            Animal animalHerbMed = new Animal(AnimalType.Herbivore, AnimalSize.Medium);
            Animal animalHerbBig = new Animal(AnimalType.Herbivore, AnimalSize.Big);

            Assert.False(animalHerbSmall.CheckSizeForCarnInWagon(train.wagons[0].SmallestAnimalIsCarnivore, train.wagons[0].Weight, train.wagons[0].SmallestAnimal));
            Assert.False(animalHerbMed.CheckSizeForCarnInWagon(train.wagons[0].SmallestAnimalIsCarnivore, train.wagons[0].Weight, train.wagons[0].SmallestAnimal));
            Assert.True(animalHerbBig.CheckSizeForCarnInWagon(train.wagons[0].SmallestAnimalIsCarnivore, train.wagons[0].Weight, train.wagons[0].SmallestAnimal));
        }
    }
}

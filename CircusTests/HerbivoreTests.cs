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
        Train train = new Train();

        [Fact]
        public void Should_NotAddAnimal_When_AddingAnotherAnimalWouldGoOverTheMaxWeight()
        {
            train.wagons.Add(new Wagon(new Animal(AnimalType.Herbivore, AnimalSize.Big)));
            train.wagons.Add(new Wagon(new Animal(AnimalType.Herbivore, AnimalSize.Big)));

            Animal animalHerbSmall = new Animal(AnimalType.Herbivore, AnimalSize.Small);
            Animal animalHerbMed = new Animal(AnimalType.Herbivore, AnimalSize.Medium);
            Animal animalHerbBig = new Animal(AnimalType.Herbivore, AnimalSize.Big);

            Assert.True(animalHerbSmall.CheckSizeForCarnNotInWagon(train.wagons[0].Weight, train.wagons[0].SmallestAnimal));
            Assert.True(animalHerbMed.CheckSizeForCarnNotInWagon(train.wagons[0].Weight, train.wagons[0].SmallestAnimal));
            Assert.True(animalHerbBig.CheckSizeForCarnNotInWagon(train.wagons[0].Weight, train.wagons[0].SmallestAnimal));
        }
    }
}

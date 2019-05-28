using Circustrein;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static Circustrein.Enums;

namespace CircustreinTests
{
    public class AnimalSorterTests
    {
        Train train = new Train();
        List<Wagon> wagons = new List<Wagon>();
        AnimalSorter animalSorter = new AnimalSorter();

        [Fact]
        public void Should_PutCarnFirstInList_When_SortingCarnAndHerb()
        {
            //Arrange
            train.Animals.Add(new Animal(AnimalType.Herbivore, AnimalSize.Small));
            train.Animals.Add(new Animal(AnimalType.Carnivore, AnimalSize.Small));

            //Act
            animalSorter.SortAnimals(train.Animals, wagons);

            //Assert
            Assert.True(animalSorter.Animals[0].FoodType == AnimalType.Carnivore);
            Assert.True(animalSorter.Animals[1].FoodType == AnimalType.Herbivore);
        }

        [Fact]
        public void Should_PutBiggerCarnFirstInList_When_SortingCarnSize()
        {
            //Arrange
            train.Animals.Add(new Animal(AnimalType.Carnivore, AnimalSize.Small));
            train.Animals.Add(new Animal(AnimalType.Carnivore, AnimalSize.Big));

            //Act
            animalSorter.SortAnimals(train.Animals, wagons);

            //Assert
            Assert.True(animalSorter.Animals[0].AnimalSize == AnimalSize.Big);
            Assert.True(animalSorter.Animals[1].AnimalSize == AnimalSize.Small);
        }

        [Fact]
        public void Should_PutBiggerHerbFirstInList_When_SortingHerbSize()
        {
            //Arrange
            train.Animals.Add(new Animal(AnimalType.Herbivore, AnimalSize.Small));
            train.Animals.Add(new Animal(AnimalType.Herbivore, AnimalSize.Big));

            //Act
            animalSorter.SortAnimals(train.Animals, wagons);

            //Assert
            Assert.True(animalSorter.Animals[0].AnimalSize == AnimalSize.Big);
            Assert.True(animalSorter.Animals[1].AnimalSize == AnimalSize.Small);
        }

        [Fact]
        public void Should_PutCarnFirstInList_When_SortingCarnAndHerbFromWagon()
        {
            //Arrange
            Wagon wagon = new Wagon(new Animal(AnimalType.Carnivore, AnimalSize.Small));
            wagon.Animals.Add(new Animal(AnimalType.Herbivore, AnimalSize.Medium));
            wagons.Add(wagon);

            //Act
            animalSorter.SortAnimals(train.Animals, wagons);

            //Assert
            Assert.True(animalSorter.Animals[0].FoodType == AnimalType.Carnivore);
            Assert.True(animalSorter.Animals[1].FoodType == AnimalType.Herbivore);
        }

        [Fact]
        public void Should_PutBiggerCarnFirstInList_When_SortingCarnSizeFromWagon()
        {
            //Arrange
            Wagon wagon = new Wagon(new Animal(AnimalType.Carnivore, AnimalSize.Small));
            wagons.Add(wagon);
            train.Animals.Add(new Animal(AnimalType.Carnivore, AnimalSize.Big));

            //Act
            animalSorter.SortAnimals(train.Animals, wagons);

            //Assert
            Assert.True(animalSorter.Animals[0].AnimalSize == AnimalSize.Big);
            Assert.True(animalSorter.Animals[1].AnimalSize == AnimalSize.Small);
        }

        [Fact]
        public void Should_PutBiggerHerbFirstInList_When_SortingHerbSizeFromWagon()
        {
            //Arrange
            Wagon wagon = new Wagon(new Animal(AnimalType.Herbivore, AnimalSize.Small));
            wagon.Animals.Add(new Animal(AnimalType.Herbivore, AnimalSize.Medium));
            wagons.Add(wagon);

            //Act
            animalSorter.SortAnimals(train.Animals, wagons);

            //Assert
            Assert.True(animalSorter.Animals[0].AnimalSize == AnimalSize.Medium);
            Assert.True(animalSorter.Animals[1].AnimalSize == AnimalSize.Small);
        }
        
    }
}

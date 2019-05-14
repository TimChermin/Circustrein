﻿using Circustrein;
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
        Wagon wagon = new Wagon(new Animal(AnimalType.Carnivore, AnimalSize.Small));
        AnimalSorter animalSorter = new AnimalSorter();

        [Fact]
        public void Should_SortAnimals_When_SortingTheAnimals()
        {
            //Arrange
            for (int i = 0; i < 10; i++)
            {
                train.animals.Add(new Animal(AnimalType.Carnivore, AnimalSize.Small));
                train.animals.Add(new Animal(AnimalType.Herbivore, AnimalSize.Small));
            }
            wagons.Add(wagon);

            //Act
            animalSorter.SortAnimals(train.animals, wagons);

            //Assert
            int animalCount = 0;
            foreach (Animal animal in animalSorter.Animals)
            {
                if (animalCount < 11)
                {
                    Assert.True(animal.FoodType == AnimalType.Carnivore);
                }
                else
                {
                    Assert.True(animal.FoodType == AnimalType.Herbivore);
                }
                animalCount++;
            }
        }
    }
}

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
        public void Should_SortAnimals_When_SortingTheAnimals()
        {
            for (int i = 0; i < 10; i++)
            {
                train.animals.Add(new Animal(AnimalType.Carnivore, AnimalSize.Small));
                train.animals.Add(new Animal(AnimalType.Herbivore, AnimalSize.Small));
            }
            animalSorter.SortAnimals(train.animals, wagons);

            int animalCount = 0;
            foreach (Animal animal in animalSorter.Animals)
            {
                if (animalCount < 10)
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

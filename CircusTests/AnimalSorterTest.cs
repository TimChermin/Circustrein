using Circustrein;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static Circustrein.Enums;

namespace CircustreinTests
{
    public class AnimalSorterTest
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


        }


        public void AddAnimalsToWagons()
        {
            animalSorter.SortAnimals(train.animals, wagons);

            train.wagons.Clear();
            Wagon wagon = new Wagon();
            train.wagons.Add(wagon);

            //first add the Carn to the wagon, after that you add the Herbs
            train.AddAnimalsToWagon(animalSorter.CarnivoreAnimals);
            train.AddAnimalsToWagon(animalSorter.HerbivoreAnimals);
            train.animals.Clear();
        }

    }
}

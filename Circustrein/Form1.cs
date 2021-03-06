﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Circustrein.Enums;

namespace Circustrein
{
    public partial class Form1 : Form
    {
        Train train;
        List<Wagon> wagons = new List<Wagon>();
        AnimalSorter animalSorter = new AnimalSorter();

        public Form1()
        {
            InitializeComponent();
            train = new Train();
            comboBoxSize.SelectedIndex = 0;
            comboBoxFoodType.SelectedIndex = 1;
            AddStartingAnimals();
        }

        public void buttonAddAnimal_Click(object sender, EventArgs e)
        {
            AnimalType foodType = (AnimalType)Enum.Parse(typeof(AnimalType), comboBoxFoodType.Text);
            AnimalSize size = (AnimalSize)Enum.Parse(typeof(AnimalSize),comboBoxSize.Text);
            train.AddAnimalToTrain(foodType, size);
            UpdateInterface();
        }

        private void buttonAddAnimalToWagons_Click(object sender, EventArgs e)
        {
            AddAnimalsToWagons();
            UpdateInterface();
        }


        private void UpdateInterface()
        {
            LoadAnimals();
            LoadWagons();
            LoadAnimalsInWagon();
        }

        private void LoadAnimals()
        {
            List<Animal> animals = new List<Animal>();
            animals = train.Animals;
            listBoxAnimals.Items.Clear();
            foreach (Animal animal in animals)
            {
                listBoxAnimals.Items.Add(animal);
            }
        }

        private void LoadWagons()
        {
            wagons = train.Wagons;
            listBoxWagons.Items.Clear();
            foreach (Wagon wagon in wagons)
            {
                listBoxWagons.Items.Add(wagon);
                listBoxWagons.DisplayMember = "Weight";
            }
        }

        private void LoadAnimalsInWagon()
        {
            listBoxAnimalInWagon.Items.Clear();
            Wagon selectedWagon = (Wagon)listBoxWagons.SelectedItem;
            foreach (Wagon wagon in wagons)
            {
                if (selectedWagon == wagon)
                {
                    listBoxAnimalInWagon.Items.Add(wagon);
                }
            }
        }

        public void AddAnimalsToWagons()
        {
            animalSorter.SortAnimals(train.Animals, wagons);

            train.Wagons.Clear();
            Wagon wagon = new Wagon();
            train.Wagons.Add(wagon);
            
            train.AddAnimalsToWagon(animalSorter.Animals);
            animalSorter.Animals.Clear();
            train.Animals.Clear();
        }

        /// <summary>
        /// adds animals for quick start
        /// </summary>
        private void AddStartingAnimals()
        {
            for (int i = 0; i <= 15; i++)
            {

                if (i > 8 & i < 11)
                {
                    train.AddAnimalToTrain(AnimalType.Herbivore, AnimalSize.Big);
                }
                else if (i < 3)
                {
                    train.AddAnimalToTrain(AnimalType.Carnivore, AnimalSize.Medium);
                }
                else if (i >= 3 && i <=8)
                {
                    train.AddAnimalToTrain(AnimalType.Carnivore, AnimalSize.Small);
                }
                else
                {
                    train.AddAnimalToTrain(AnimalType.Herbivore, AnimalSize.Medium);
                }
                
            }
            UpdateInterface();
        }

        private void listBoxWagons_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAnimalsInWagon();
        }
    }
}

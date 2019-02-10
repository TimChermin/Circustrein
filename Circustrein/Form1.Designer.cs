namespace Circustrein
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonAddAnimal = new System.Windows.Forms.Button();
            this.listBoxAnimals = new System.Windows.Forms.ListBox();
            this.listBoxWagons = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonAddAnimalToWagons = new System.Windows.Forms.Button();
            this.comboBoxSize = new System.Windows.Forms.ComboBox();
            this.comboBoxFoodType = new System.Windows.Forms.ComboBox();
            this.listBoxAnimalInWagon = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // buttonAddAnimal
            // 
            this.buttonAddAnimal.Location = new System.Drawing.Point(26, 438);
            this.buttonAddAnimal.Name = "buttonAddAnimal";
            this.buttonAddAnimal.Size = new System.Drawing.Size(194, 23);
            this.buttonAddAnimal.TabIndex = 0;
            this.buttonAddAnimal.Text = "Add Animal";
            this.buttonAddAnimal.UseVisualStyleBackColor = true;
            this.buttonAddAnimal.Click += new System.EventHandler(this.buttonAddAnimal_Click);
            // 
            // listBoxAnimals
            // 
            this.listBoxAnimals.FormattingEnabled = true;
            this.listBoxAnimals.ItemHeight = 16;
            this.listBoxAnimals.Location = new System.Drawing.Point(26, 116);
            this.listBoxAnimals.Name = "listBoxAnimals";
            this.listBoxAnimals.Size = new System.Drawing.Size(251, 292);
            this.listBoxAnimals.TabIndex = 1;
            // 
            // listBoxWagons
            // 
            this.listBoxWagons.FormattingEnabled = true;
            this.listBoxWagons.ItemHeight = 16;
            this.listBoxWagons.Location = new System.Drawing.Point(368, 116);
            this.listBoxWagons.Name = "listBoxWagons";
            this.listBoxWagons.Size = new System.Drawing.Size(339, 292);
            this.listBoxWagons.TabIndex = 2;
            this.listBoxWagons.SelectedIndexChanged += new System.EventHandler(this.listBoxWagons_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Animals";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(365, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Wagons";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(684, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Animals in Wagon";
            // 
            // buttonAddAnimalToWagons
            // 
            this.buttonAddAnimalToWagons.Location = new System.Drawing.Point(416, 438);
            this.buttonAddAnimalToWagons.Name = "buttonAddAnimalToWagons";
            this.buttonAddAnimalToWagons.Size = new System.Drawing.Size(200, 23);
            this.buttonAddAnimalToWagons.TabIndex = 7;
            this.buttonAddAnimalToWagons.Text = "Add Animal To Wagons";
            this.buttonAddAnimalToWagons.UseVisualStyleBackColor = true;
            this.buttonAddAnimalToWagons.Click += new System.EventHandler(this.buttonAddAnimalToWagons_Click);
            // 
            // comboBoxSize
            // 
            this.comboBoxSize.FormattingEnabled = true;
            this.comboBoxSize.Items.AddRange(new object[] {
            "Small",
            "Medium",
            "Big"});
            this.comboBoxSize.Location = new System.Drawing.Point(29, 57);
            this.comboBoxSize.Name = "comboBoxSize";
            this.comboBoxSize.Size = new System.Drawing.Size(121, 24);
            this.comboBoxSize.TabIndex = 8;
            // 
            // comboBoxFoodType
            // 
            this.comboBoxFoodType.FormattingEnabled = true;
            this.comboBoxFoodType.Items.AddRange(new object[] {
            "Carnivore",
            "Herbivore"});
            this.comboBoxFoodType.Location = new System.Drawing.Point(29, 26);
            this.comboBoxFoodType.Name = "comboBoxFoodType";
            this.comboBoxFoodType.Size = new System.Drawing.Size(121, 24);
            this.comboBoxFoodType.TabIndex = 9;
            // 
            // listBoxAnimalInWagon
            // 
            this.listBoxAnimalInWagon.FormattingEnabled = true;
            this.listBoxAnimalInWagon.HorizontalExtent = 600;
            this.listBoxAnimalInWagon.HorizontalScrollbar = true;
            this.listBoxAnimalInWagon.ItemHeight = 16;
            this.listBoxAnimalInWagon.Location = new System.Drawing.Point(859, 20);
            this.listBoxAnimalInWagon.Name = "listBoxAnimalInWagon";
            this.listBoxAnimalInWagon.Size = new System.Drawing.Size(278, 388);
            this.listBoxAnimalInWagon.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 582);
            this.Controls.Add(this.listBoxAnimalInWagon);
            this.Controls.Add(this.comboBoxFoodType);
            this.Controls.Add(this.comboBoxSize);
            this.Controls.Add(this.buttonAddAnimalToWagons);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxWagons);
            this.Controls.Add(this.listBoxAnimals);
            this.Controls.Add(this.buttonAddAnimal);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddAnimal;
        private System.Windows.Forms.ListBox listBoxAnimals;
        private System.Windows.Forms.ListBox listBoxWagons;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonAddAnimalToWagons;
        private System.Windows.Forms.ComboBox comboBoxSize;
        private System.Windows.Forms.ComboBox comboBoxFoodType;
        private System.Windows.Forms.ListBox listBoxAnimalInWagon;
    }
}


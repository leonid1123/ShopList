using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopList
{
    public partial class Form1 : Form
    {
        class Food
        {
            public string Name { set; get; }
            public decimal Price { set; get; }
            public decimal Quantity { set; get; }
            public string Mesurement { set; get; }

            public Food(string name, decimal price, decimal quantity, string mesurenemt)
            {
                Name = name;
                Price = price;
                Quantity = quantity;
                Mesurement = mesurenemt;
            }
        }
        List<Food> FoodList = new List<Food>();
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            decimal sum = 0;
            if (textBox1.Text.Trim().Length > 0 && numericUpDown1.Value > 0 && numericUpDown2.Value > 0)
            {
                bool gotDouble = false;
                foreach (Food food in FoodList)
                {
                    if (food.Name == textBox1.Text.Trim())
                    {
                        gotDouble = true;
                    }
                    Console.WriteLine(food.Name);
                    Console.WriteLine(gotDouble);
                }
                if (!gotDouble)
                {
                    Food newFood = new Food(textBox1.Text.Trim(), numericUpDown2.Value, numericUpDown1.Value, comboBox1.Text);
                    FoodList.Add(newFood);
                    checkedListBox1.Items.Add(newFood.Name + " " + newFood.Price.ToString() + "p." + newFood.Quantity.ToString() + " " + newFood.Mesurement);

                }
                else
                {
                    foreach (Food food in FoodList)
                    {
                        if (food.Name == textBox1.Text.Trim())
                        {
                            food.Quantity += numericUpDown1.Value;
                        }
                    }
                } //TODO написать метод для обновления списка и привязать его ко всем ситуациям
                foreach (Food food in FoodList)
                {
                    sum += food.Price * food.Quantity;
                }
                label4.Text = "Итоговая стоимость: " + sum.ToString() + "р.";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 2;

            Food milk = new Food("молоко", 100, 1, "л.");
            Food nuts = new Food("орешки", 123, 1, "г.");

            FoodList.Add(milk);
            FoodList.Add(nuts);
            FoodList.Add(nuts);

            decimal sum = 0;
            foreach (Food food in FoodList)
            {
                checkedListBox1.Items.Add(food.Name + " " + food.Price.ToString() + "p." + food.Quantity.ToString() + food.Mesurement);
                sum += food.Price;
            }
            label4.Text = "Итоговая стоимость: " + sum.ToString() + "р.";
        }
    }
}

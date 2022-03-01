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
            private string name;
            private decimal price;
            private decimal quantity;
            private string mesurement;

            public Food(string name, decimal price, decimal quantity, string mesurement)
            {
                this.name = name;
                this.price = price;
                this.quantity = quantity;
                this.mesurement = mesurement;
            }

            public string Name { get => name; set => name = value; }
            public decimal Price { get => price; set => price = value; }
            public decimal Quantity { get => quantity; set => quantity = value; }
            public string Mesurement { get => mesurement; set => mesurement = value; }
        }


        List<Food> FoodList = new List<Food>();
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            checkedListBox1.SelectedIndex = -1;
            if (textBox1.Text.Trim().Length > 0 && numericUpDown1.Value > 0 && numericUpDown2.Value > 0)
            {
                bool gotDouble = false;
                foreach (Food food in FoodList)
                {
                    if (food.Name == textBox1.Text.Trim())
                    {
                        gotDouble = true;
                    }
                }
                if (!gotDouble)
                {
                    Food newFood = new Food(textBox1.Text.Trim(), numericUpDown2.Value, numericUpDown1.Value, comboBox1.Text);
                    FoodList.Add(newFood);
                    PrintList(FoodList);

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
                }
                TotalPrice(FoodList);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 2;

            Food milk = new Food("молоко", 100, 1, "л.");
            Food nuts = new Food("орешки", 123, 1, "г.");

            FoodList.Add(milk);
            FoodList.Add(nuts);

            TotalPrice(FoodList);
            PrintList(FoodList);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedIndex > -1)
            {
                FoodList.RemoveAt(checkedListBox1.SelectedIndex);
                checkedListBox1.Items.RemoveAt(checkedListBox1.SelectedIndex);
            }
            TotalPrice(FoodList);
        }
        decimal TotalPrice(List<Food> listToCalculate)
        {
            decimal sum = 0;
            foreach (Food food in listToCalculate)
            {
                sum += food.Price * food.Quantity;
            }
            label4.Text = "Итоговая стоимость: " + sum.ToString();
            return sum;
        }
        int PrintList(List<Food> listToPrint)
        {
            checkedListBox1.Items.Clear();
            foreach (Food food in listToPrint)
            {
                checkedListBox1.Items.Add(food.Name + " " + food.Price.ToString() + "p." + food.Quantity.ToString() + " " + food.Mesurement);
            }
            return listToPrint.Count;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Form2 f = new Form2();
                f.SetDesktopLocation(MousePosition.X, MousePosition.Y);
                f.Show();
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedIndex != -1)
            {

                button3.Enabled = true;
                button3.Visible = true;
                textBox2.Enabled = true;
                textBox2.Visible = true;
                numericUpDown3.Enabled = true;
                numericUpDown3.Visible = true;
                numericUpDown4.Enabled = true;
                numericUpDown4.Visible = true;
                comboBox2.Enabled = true;
                comboBox2.Visible = true;
                label8.Enabled = true;
                label8.Visible = true;
                label9.Enabled = true;
                label9.Visible = true;
                label10.Enabled = true;
                label10.Visible = true;
                label11.Enabled = true;
                label11.Visible = true;

                textBox2.Text = FoodList[checkedListBox1.SelectedIndex].Name;
                numericUpDown4.Value = FoodList[checkedListBox1.SelectedIndex].Quantity;
                numericUpDown3.Value = FoodList[checkedListBox1.SelectedIndex].Price;
                comboBox2.Text = FoodList[checkedListBox1.SelectedIndex].Mesurement;
            }
            else
            {
                button3.Enabled = false;
                button3.Visible = false;
                textBox2.Enabled = false;
                textBox2.Visible = false;
                numericUpDown3.Enabled = false;
                numericUpDown3.Visible = false;
                numericUpDown4.Enabled = false;
                numericUpDown4.Visible = false;
                comboBox2.Enabled = false;
                comboBox2.Visible = false;
                label8.Enabled = false;
                label8.Visible = false;
                label9.Enabled = false;
                label9.Visible = false;
                label10.Enabled = false;
                label10.Visible = false;
                label11.Enabled = false;
                label11.Visible = false;

                textBox2.Text = "";
                numericUpDown4.Value = 0;
                numericUpDown3.Value = 0;
                comboBox2.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedIndex != -1)
            {
                if (textBox2.Text.Trim().Length > 0 && numericUpDown4.Value > 0 && numericUpDown3.Value > 0)
                {

                    FoodList[checkedListBox1.SelectedIndex].Name = textBox2.Text;
                    FoodList[checkedListBox1.SelectedIndex].Quantity = numericUpDown4.Value;
                    FoodList[checkedListBox1.SelectedIndex].Price = numericUpDown3.Value;
                    FoodList[checkedListBox1.SelectedIndex].Mesurement = comboBox2.Text;
                    PrintList(FoodList);
                    TotalPrice(FoodList);
                }

            }
        }
    }
}

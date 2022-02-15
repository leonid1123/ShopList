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
            public int Price { set; get; }
            public int Quantity { set; get; }
            public string Mesurement { set; get; }

            public Food(string name,int price,int quantity,string mesurenemt)
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
            Food newFood = new Food(textBox1.Text.Trim(), int.Parse(textBox3.Text), int.Parse(textBox2.Text), textBox5.Text);
            FoodList.Add(newFood);
            checkedListBox1.Items.Add(newFood.Name + " " + newFood.Price.ToString() + "p." + newFood.Quantity.ToString() +" "+ newFood.Mesurement);
            int sum=0;
            foreach (Food food in FoodList)
            {
                sum+=food.Price;
            }
            label4.Text = "Итоговая стоимость: " + sum.ToString() + "р.";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Food milk = new Food("молоко",100,1,"л.");
            Food nuts = new Food("орешки",123,1,"г.");

            FoodList.Add(milk);
            FoodList.Add(nuts);
            FoodList.Add(nuts);

            int sum = 0;
            foreach (Food food in FoodList)
            {
                checkedListBox1.Items.Add(food.Name+" "+food.Price.ToString()+"p."+food.Quantity.ToString()+food.Mesurement);
                sum+=food.Price;
            }
            label4.Text = "Итоговая стоимость: "+sum.ToString()+"р.";
        }
    }
}

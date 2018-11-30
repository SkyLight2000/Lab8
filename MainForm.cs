using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_8
{
    public partial class MainForm : Form
    {
        private BindingList<Animal> animals;

        public MainForm()
        {
            InitializeComponent();
            animals = new BindingList<Animal>();
            listBox1.DisplayMember = "Name";
            listBox1.DataSource = animals;
            listBox1.SelectedIndexChanged += new EventHandler(ListBox1_SelectedIndexChanged);
        }

        private void BtnAddAnimal_Click(object sender, EventArgs e)
        {
            Animal animal = new Animal();
            AnimalForm af = new AnimalForm(animal);
            if (af.ShowDialog() == DialogResult.OK)
            {
                animals.Add(animal);
            }
        }

        void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Animal animal = (Animal)listBox1.SelectedItem;
            MessageBox.Show("Имя: " + animal.Name + "\n" +
                "Вид: " + animal.Type + "\n" +
                "Порода: " + animal.Breed + "\n" +
                "Цвет: " + animal.Color + "\n" +
                "Возраст: " + animal.Age + "\n" +
                "Вес: " + animal.Weight + " кг", 
                "Информация про животное", MessageBoxButtons.OK);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Прекратить роботу?", "Завершение работы", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}

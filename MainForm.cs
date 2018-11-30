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
        public MainForm()
        {
            InitializeComponent();
            Animal animal = new Animal();
            List<Animal> animals = new List<Animal>();
            animals.Add(animal);
            listBox1.DisplayMember = "Name";
            listBox1.ValueMember = "Type";
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
        }

        private void btnAddAnimal_Click(object sender, EventArgs e)
        {
            Animal animal = new Animal();
            AnimalForm af = new AnimalForm(animal);
            if (af.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Add(animal);
            }
        }

        void listBox1_SelectedIndexChanged(object sender, EventArgs e)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Прекратить роботу?", "Завершение работы", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}

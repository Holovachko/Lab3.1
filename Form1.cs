using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3._1
{
    public partial class Form1 : Form
    {
        List<Table> men = new List<Table>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (Context andrii = new Context()) 
            {
                dataGridView1.DataSource = andrii.Table.ToList<Table>();
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            using (Context andrii = new Context())
            {
                men = andrii.Table.ToList<Table>()
                    .Where((men) => men.FlatAvailability == "yes")
                    .OrderBy(men => men.Name)
                    .ToList<Table>();
            }
            dataGridView1.DataSource = men;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            using (Context andrii = new Context())
            {
                men = andrii.Table.ToList<Table>()
                    .OrderByDescending(men => men.Salary)
                    .Take(1)
                    .ToList<Table>();
            }
            dataGridView1.DataSource = men;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            using (Context andrii = new Context())
            {
                men = andrii.Table.ToList<Table>()
                    .OrderBy(men => men.Salary)
                    .Skip(1)
                    .ToList<Table>();
            }
            dataGridView1.DataSource = men;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            using (Context andrii = new Context())
            {
                men = andrii.Table.ToList<Table>();
                men.ForEach(men => men.Salary += 1000);
            }
            dataGridView1.DataSource = men;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (Context andrii = new Context())
            {
                MessageBox.Show($"Кількість претиндентів зі зеленима очима: {andrii.Table.ToList<Table>().Count((men) => men.EyesColor == "green")}");

            }
        }


    }
}

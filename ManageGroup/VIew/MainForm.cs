using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManageGroup.Controller;
using ManageGroup.Domain;

namespace ManageGroup.VIew
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            //dataGridView1.DataSource = MainController.GetActivities();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            var ActList = (List<Activity>)dataGridView1.DataSource;
            var acvt = ActList[dataGridView1.SelectedRows[0].Index];
            MainController.DeleteActivities(acvt);
            dataGridView1.DataSource = MainController.GetActivities();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var addForm = new AddForm();
            addForm.ShowDialog();

            dataGridView1.DataSource = MainController.GetActivities();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            var ActivList = MainController.GetActivities();

            var serchList = ActivList.Where(x => x.DateStart == dateTimePicker1.Value.ToString("dd.MM.yyyy")).ToList<Activity>();

            dataGridView1.DataSource = serchList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = MainController.GetActivities();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            var ActList = (List<Activity>)dataGridView1.DataSource;

            var index = dataGridView1.SelectedRows[0].Index;
            var activity = ActList[index];

            var addForm = new AddForm(activity);

            addForm.ShowDialog();

            var ActivList = MainController.GetActivities();
            var serchList = ActivList.Where(x => x.DateStart == dateTimePicker1.Value.ToString("dd.MM.yyyy")).ToList<Activity>();
            dataGridView1.DataSource = serchList;
        }
    }
}

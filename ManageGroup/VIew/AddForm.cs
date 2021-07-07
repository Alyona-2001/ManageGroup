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
    public partial class AddForm : Form
    {
        bool isEdit;
        Activity activity;
        public AddForm()
        {
            isEdit = false;

            InitializeComponent();
            comboBox1.DataSource = MainController.GetTypeActivity();
            comboBox2.DataSource = MainController.GetStatus();
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
        }

        public AddForm(Activity act)
        {
            isEdit = true;

            activity = act;

            InitializeComponent();
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            comboBox1.DataSource = MainController.GetTypeActivity();
            comboBox2.DataSource = MainController.GetStatus();

            textBox1.Text = act.NameActivity;
            textBox2.Text = act.TimeStart;
            textBox3.Text = act.Duration.ToString();

            comboBox1.SelectedItem = act.TypeActivity;
            comboBox2.SelectedItem = act.status;

            var timeStart = DateTime.Parse(act.DateStart);
            timeStart = timeStart.AddHours((double)DateTime.Parse(act.TimeStart).Hour);
            timeStart = timeStart.AddMinutes((double)DateTime.Parse(act.TimeStart).Minute);

            dateTimePicker1.Value = timeStart;

            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            dateTimePicker1.Hide();
            button2.Text = "Сохранить";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
                var timeStart = dateTimePicker1.Value.Date;
                timeStart = timeStart.AddHours((double)DateTime.Parse(textBox2.Text).Hour);
                timeStart = timeStart.AddMinutes((double)DateTime.Parse(textBox2.Text).Minute);

                var dur = int.Parse(textBox3.Text);

                var timeEnd = timeStart.AddHours(dur).ToString("h:mm");
                var dateEnd = timeStart.AddHours(dur).ToString("dd.MM.yyyy");

                var activ = new Activity()
                {
                    NameActivity = textBox1.Text,
                    status = (Status)comboBox2.SelectedItem,
                    TypeActivity = (TypeComp)comboBox1.SelectedItem,
                    DateStart = dateTimePicker1.Value.ToString("dd.MM.yyyy"),
                    Duration = int.Parse(textBox3.Text),
                    TimeEnd = timeEnd,
                    DateEnd = dateEnd,
                    TimeStart = timeStart.ToString("hh:mm"),
                };

            if (isEdit)
            {
                activ.ID = activity.ID;
                MainController.UpdateAct(activ);
            }
            else
            {
                MainController.AddActivities(activ);
            }
                
            
            
            this.Close();

        }
    }
}

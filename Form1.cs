using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace La_croisiére_s_amuse
{
    public partial class Form1 : Form
    {
        DateTime debart;
        DateTime Arrive;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            numericUpDown1.Minimum = 0;
            button2.Enabled = false;
            dateTimePicker1.MinDate = DateTime.Now;  // i write  this line to get datetimePicker disable the pass time from current time 
            debart = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day);// i made a dateTime to allow me to calculate the difference in TimeSpin
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;



        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           debart = new DateTime(dateTimePicker1.Value.Year,dateTimePicker1.Value.Month,dateTimePicker1.Value.Day);
            dateTimePicker2.MinDate = debart;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
             Arrive = new DateTime(dateTimePicker2.Value.Year, dateTimePicker2.Value.Month, dateTimePicker2.Value.Day);
            TimeSpan diff = Arrive.Date - debart.Date ;
            
             label4.Text = diff.ToString("%d") + " day(s)";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                button2.Enabled = true;
                Form1.ActiveForm.Text = textBox1.Text; // to change the title of the form like what you're writing in text box
            }
            else
                button2.Enabled = false;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown2.Maximum = numericUpDown1.Value;
            label7.Text = Convert.ToString(numericUpDown1.Value) + " Free";
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            label7.Text = Convert.ToString(numericUpDown1.Value - numericUpDown2.Value)+" Free";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("From    :" + dateTimePicker1.Value.ToString("d") + "\nTo     :" + dateTimePicker2.Value.ToString("d")+ "\nDuration      :" + label4.Text+"\nPlaces      :"+numericUpDown1.Value.ToString()+"\nRegister    :"+numericUpDown2.Value.ToString()+"\nFree      :"+label7.Text, textBox1.Text, MessageBoxButtons.YesNo,MessageBoxIcon.Information);
        }
    }
}

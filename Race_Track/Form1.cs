using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Race_Track
{
    public partial class Form1 : Form
    {
        Greyhound[] greyhoundArray = new Greyhound[4];
        Guy[] guys = new Guy[3];
        Random r = new Random();
        public Form1()
        {
            InitializeComponent();
            SetGreyhounds();
            SetGuys();
        }
        internal void SetGreyhounds()
        {            
            greyhoundArray[0] = new Greyhound()
            {
                MyPictureBox = picBox1,
                StartingPosition = picBox1.Left,
                RaceTrackLength = picBoxTrack.Width - picBox1.Width,
                Randomizer = new Random()
            };
            greyhoundArray[1] = new Greyhound()
            {
                MyPictureBox = picBox2,
                StartingPosition = picBox2.Left,
                RaceTrackLength = picBoxTrack.Width - picBox2.Width,
                Randomizer = new Random()
            };
            greyhoundArray[2] = new Greyhound()
            {
                MyPictureBox = picBox3,
                StartingPosition = picBox3.Left,
                RaceTrackLength = picBoxTrack.Width - picBox3.Width,
                Randomizer = new Random()
            };
            greyhoundArray[3] = new Greyhound()
            {
                MyPictureBox = picBox4,
                StartingPosition = picBox4.Left,
                RaceTrackLength = picBoxTrack.Width - picBox4.Width,
                Randomizer = new Random()
            };
        }
        internal void SetGuys()
        {
            guys[0] = new Guy()
            {
                MyRadioButton = radioButton1,
                MyLabel = label3,
            };
            guys[1] = new Guy()
            {
                MyRadioButton = radioButton2,
                MyLabel = label4,
            };
            guys[2] = new Guy()
            {
                MyRadioButton = radioButton3,
                MyLabel = label5,
            };
            foreach (Guy guy in guys)
                guy.UpdateLabels();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                guys[0].PlaceBet(Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value));
                guys[0].UpdateLabels();
            }
            else if (radioButton2.Checked)
            {
                guys[1].PlaceBet(Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value));
                guys[1].UpdateLabels();
            }
            else if (radioButton3.Checked)
            {
                guys[2].PlaceBet(Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value));
                guys[2].UpdateLabels();
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                playerNamelabel.Text = guys[0].Name;
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
                playerNamelabel.Text = guys[1].Name;
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
                playerNamelabel.Text = guys[2].Name;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            GreyhoundStart();
            timer1.Enabled = true;
            foreach (Guy guy in guys)
                guy.UpdateLabels();
        }
        internal void GreyhoundStart()
        {
            foreach (Greyhound greyhound in greyhoundArray)
                greyhound.TakeStartingPosition();
        }
        internal void SetWinner(int n)
        {
            foreach (Guy guy in guys)
                guy.Collect(n);
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            bool a = false;
            int i = 0;
           
                i = r.Next(1, 5);
                switch (i)
                {
                    case 1:
                        a = greyhoundArray[0].Run();
                        if (a == true)
                        {
                            timer1.Enabled = false;
                            MessageBox.Show("dog #" + i + " wins!", "Winner");
                        }
                        break;
                    case 2:
                        a = greyhoundArray[1].Run();
                        if (a == true)
                        {
                            timer1.Enabled = false;
                            MessageBox.Show("dog #" + i + " wins!", "Winner");
                        }
                        break;
                    case 3:
                        a = greyhoundArray[2].Run();
                        if (a == true)
                        {
                            timer1.Enabled = false;
                            MessageBox.Show("dog #" + i + " wins!", "Winner");
                        }
                        break;
                    case 4:
                        a = greyhoundArray[3].Run();
                        if (a == true)
                        {
                            timer1.Enabled = false;
                            MessageBox.Show("dog #" + i + " wins!", "Winner");
                        }
                        break;
                    default:
                        MessageBox.Show("the dogs have gone MAD!!!");
                        break;
                }
            if (a == true)
                SetWinner(i);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(guyNo.Value) )
            {
                case 1:
                    guys[0].Name = guyName.Text;
                    guys[0].Cash = Convert.ToInt32(guyCash.Value);
                    break;
                case 2:
                    guys[1].Name = guyName.Text;
                    guys[1].Cash = Convert.ToInt32(guyCash.Value);
                    break;
                case 3:
                    guys[2].Name = guyName.Text;
                    guys[2].Cash = Convert.ToInt32(guyCash.Value);
                    break;
            }
            foreach (Guy guy in guys)
                guy.UpdateLabels();
        }
    }
}

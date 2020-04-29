using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorMixerStudio
{
    public partial class Form1 : Form
    {
        int red = 0;
        int green = 0;
        int blue = 0;
        int redStep = 1;
        int greenStep = 1;
        int blueStep = 1;

        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void RandomRed_Click(object sender, EventArgs e)
        {
            red = rand.Next(0, 256);
            RedSlider.Value = red;
            RedBox.BackColor = Color.FromArgb(red, 0, 0);
            this.BackColor = Color.FromArgb(red, green, blue);
        }

        private void RandomGreen_Click(object sender, EventArgs e)
        {
            green = rand.Next(0, 256);
            GreenSlider.Value = green;
            GreenBox.BackColor = Color.FromArgb(0, green, 0);
            this.BackColor = Color.FromArgb(red, green, blue);
        }

        private void RandomBlue_Click(object sender, EventArgs e)
        {
            blue = rand.Next(0, 256);
            BlueSlider.Value = blue;
            BlueBox.BackColor = Color.FromArgb(0, 0, blue);
            this.BackColor = Color.FromArgb(red, green, blue);
        }

        private void RandomMix_Click(object sender, EventArgs e)
        {
            red = rand.Next(0, 256);
            green = rand.Next(0, 256);
            blue = rand.Next(0, 256);

            RedSlider.Value = red;
            GreenSlider.Value = green;
            BlueSlider.Value = blue;


            RedBox.BackColor = Color.FromArgb(red, 0, 0);
            GreenBox.BackColor = Color.FromArgb(0, green, 0);
            BlueBox.BackColor = Color.FromArgb(0, 0, blue);
            this.BackColor = Color.FromArgb(red, green, blue);
        }

        private void RedSlider_Scroll(object sender, EventArgs e)
        {
            UpdateRed();
        }

        private void GreenSlider_Scroll(object sender, EventArgs e)
        {
            UpdateGreen();
        }

        private void BlueSlider_Scroll(object sender, EventArgs e)
        {
            UpdateBlue();
        }

        private void ResetColors_Click(object sender, EventArgs e)
        {
            red = 0;
            green = 0;
            blue = 0;

            RedSlider.Value = red;
            GreenSlider.Value = green;
            BlueSlider.Value = blue;


            RedBox.BackColor = Color.FromArgb(red, 0, 0);
            GreenBox.BackColor = Color.FromArgb(0, green, 0);
            BlueBox.BackColor = Color.FromArgb(0, 0, blue);
            this.BackColor = Color.FromArgb(red, green, blue);
        }

        private void RedTimer_Tick(object sender, EventArgs e)
        {
            if(RedSlider.Value < RedSlider.Maximum)
            {
                RedSlider.Value += 1;
                UpdateRed();
            }            
        }

        private void RedTimerStart_Click(object sender, EventArgs e)
        {
            RedTimer.Start();
        }

        private void UpdateRed()
        {
            red = RedSlider.Value;
            RedBox.BackColor = Color.FromArgb(red, 0, 0);
            this.BackColor = Color.FromArgb(red, green, blue);
        }

        private void UpdateGreen()
        {
            green = GreenSlider.Value;
            GreenBox.BackColor = Color.FromArgb(0, green, 0);
            this.BackColor = Color.FromArgb(red, green, blue);
        }

        private void UpdateBlue()
        {
            blue = BlueSlider.Value;
            BlueBox.BackColor = Color.FromArgb(0, 0, blue);
            this.BackColor = Color.FromArgb(red, green, blue);
        }

        private void GreenTimer_Tick(object sender, EventArgs e)
        {
            if (GreenSlider.Value == GreenSlider.Maximum)
            {
                greenStep = -1;
            }
            else if (GreenSlider.Value == GreenSlider.Minimum)
            {
                greenStep = 1;
            }
            GreenSlider.Value += greenStep;
            UpdateGreen();
        }

        private void GreenTimerStart_Click(object sender, EventArgs e)
        {
            GreenTimer.Start();
        }

        private void BlueTimerStart_Click(object sender, EventArgs e)
        {
            BlueTimer.Interval = 20;
            BlueTimer.Start();
        }

        private void BlueTimer_Tick(object sender, EventArgs e)
        {
            if (BlueSlider.Value == BlueSlider.Maximum)
            {
                blueStep = -1;
            }
            else if(BlueSlider.Value == BlueSlider.Minimum)
            {
                blueStep = 1;
            }
            BlueSlider.Value += blueStep;
            UpdateBlue();
        }
    }
}

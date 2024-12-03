using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoursCalcSimple
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Calculate();
        }

        private void Calculate()
        {
            // Arrays to store start and end times for each day
            double[] startTimes = new double[6];
            double[] endTimes = new double[6];

            // Arrays to store references to the TextBox controls for start and end times
            TextBox[] startTextBoxes = { textBoxMStart, textBoxTUEStart, textBoxWStart, textBoxTHUStart, textBoxFStart, textBoxSStart };
            TextBox[] endTextBoxes = { textBoxMFin, textBoxTueFin, textBoxWFin, textBoxThuFin, textBoxFFin, textBoxSFin };

            // Loop to parse input text and store values in arrays
            for (int i = 0; i < 6; i++)
            {
                double start, end;
                // Try to parse the text input into doubles
                if (double.TryParse(startTextBoxes[i].Text, out start) && double.TryParse(endTextBoxes[i].Text, out end))
                {
                    // Check if end time is less than start time
                    if (end < start)
                    {
                        // Show a message box if the end time is earlier than the start time
                        MessageBox.Show($"End time cannot be earlier than start time for day {i + 1}", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Exit the method if input is invalid
                    }

                    startTimes[i] = start; // Store parsed start time
                    endTimes[i] = end; // Store parsed end time
                }
                else
                {
                    startTimes[i] = 0; // Set start time to 0 if input is invalid
                    endTimes[i] = 0; // Set end time to 0 if input is invalid
                }
            }

            double totalMinutes = 0; // Variable to accumulate total minutes worked

            // Loop to calculate total minutes from start and end times
            for (int i = 0; i < 6; i++)
            {
                // Extract hours and minutes from start and end times
                double startHours = Math.Floor(startTimes[i] / 100);
                double startMinutes = startTimes[i] % 100;
                double endHours = Math.Floor(endTimes[i] / 100);
                double endMinutes = endTimes[i] % 100;

                // Convert start and end times to total minutes
                double startTotalMinutes = (startHours * 60) + startMinutes;
                double endTotalMinutes = (endHours * 60) + endMinutes;

                // Add difference between end and start times to total minutes
                totalMinutes += (endTotalMinutes - startTotalMinutes);
            }

            // Calculate total hours and remaining minutes
            double totalHours = Math.Floor(totalMinutes / 60);
            double remainingMinutes = totalMinutes % 60;
            double decimalHours = totalMinutes / 60; // Calculate total hours in decimal format

            // Set the result in TextBoxes
            textBoxTHours.Text = $"{totalHours:0}:{remainingMinutes:00}"; // Output in HH:MM format
            textBoxDecimalHours.Text = decimalHours.ToString("0.00"); // Output in decimal format
        }



        private void textBoxMStart_Click(object sender, EventArgs e)
        {
            textBoxMStart.Clear();
        }

        private void textBoxTUEStart_Click(object sender, EventArgs e)
        {
            textBoxTUEStart.Clear();
        }

        private void textBoxWStart_Click(object sender, EventArgs e)
        {
            textBoxWStart.Clear();
        }

        private void textBoxTHUStart_Click(object sender, EventArgs e)
        {
            textBoxTHUStart.Clear();
        }

        private void textBoxFStart_Click(object sender, EventArgs e)
        {
            textBoxFStart.Clear();
        }

        private void textBoxSStart_Click(object sender, EventArgs e)
        {
            textBoxSStart.Clear();
        }

        private void textBoxMFin_Click(object sender, EventArgs e)
        {
            textBoxMFin.Clear();
        }

        private void textBoxTueFin_Click(object sender, EventArgs e)
        {
            textBoxTueFin.Clear();
        }

        private void textBoxWFin_Click(object sender, EventArgs e)
        {
            textBoxWFin.Clear();
        }

        private void textBoxThuFin_Click(object sender, EventArgs e)
        {
            textBoxThuFin.Clear();
        }

        private void textBoxFFin_Click(object sender, EventArgs e)
        {
            textBoxFFin.Clear();
        }

        private void textBoxSFin_Click(object sender, EventArgs e)
        {
            textBoxSFin.Clear();
        }
    }
}

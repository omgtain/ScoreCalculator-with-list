using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScoreCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Tain Rose, Week 8, Team 6

        int total = 0;
        List<int> scoresList = new List<int>();

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValidData())
                {
                    int score = Convert.ToInt32(txtScore.Text);
                    scoresList.Add(score);
                    total += score;

                    int count = scoresList.Count;

                    int average = total / count;

                    txtScoreTotal.Text = total.ToString();
                    txtScoreCount.Text = count.ToString();
                    txtAverage.Text = average.ToString();
                    txtScore.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" +
                ex.GetType().ToString() + "\n" +
                ex.StackTrace, "Exception");
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            scoresList.Sort();
            string scoresString = "";
            foreach (int i in scoresList)
                if (i != 0)
                {
                    scoresString += i.ToString() + "\n";
                }
            MessageBox.Show(scoresString, "Sorted Scores");
            txtScore.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            total = 0;
            txtScore.Text = "";
            txtScoreTotal.Text = "";
            txtScoreCount.Text = "";
            txtAverage.Text = "";
            txtScore.Focus();
            scoresList.Clear();
        }

        public bool IsValidData()
        {
            return
                // Validate the Score text box
                IsPresent(txtScore, "Score") &&
                IsInt32(txtScore, "Score") &&
                IsWithinRange(txtScore, "Score", 01, 100);
        }

        public bool IsPresent(TextBox textBox, string name)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(name + " is a required field.", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }

        public bool IsInt32(TextBox textBox, string name)
        {
            int number = 0;
            if (Int32.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(name + " must be a valid integer.", "Entry Error");
                textBox.Focus();
                return false;
            }
        }

        public bool IsWithinRange(TextBox textBox, string name,
            decimal min, decimal max)
        {
            decimal number = Convert.ToDecimal(textBox.Text);
            if (number < min || number > max)
            {
                MessageBox.Show(name + " must be between " + min +
                    " and " + max + ".", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }

    }
}
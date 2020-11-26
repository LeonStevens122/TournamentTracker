using System;
using System.Windows.Forms;
using Tracker_Library;
using Tracker_Library.Models;

namespace TrackerUI
{
    public partial class CreatePrizeForm : Form
    {
        public CreatePrizeForm()
        {
            InitializeComponent();
        }

        private bool ValidateForm()
        {
            bool output = true;
            int placeNumber = 0;
            decimal prizeAmount = 0;
            double prizePercentage = 0;
            bool prizeAmountValid = decimal.TryParse(prizeAmountTextBox.Text, out prizeAmount);
            bool prizePercentageValid = double.TryParse(prizePercentageTextbox.Text, out prizePercentage);
            bool placeNumberValidNumber = int.TryParse(placeNumberTextBox.Text, out placeNumber);

            if (!placeNumberValidNumber)
            {
                output = false;
            }

            if (placeNumber < 1)
            {
                output = false;
            }

            if (prizeAmountValid == false || prizePercentageValid == false)
            {
                output = false;
            }

            if (prizeAmount <= 0 && prizePercentage <= 0)
            {
                output = false;
            }

            if (prizePercentage < 0 || prizePercentage > 100)
            {
                output = false;
            }

            return output;
        }

        private void teamNameLabel_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void orLabel_Click(object sender, EventArgs e)
        {
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PrizeModel model = new PrizeModel(
                    placeNameTextBox.Text,
                    placeNameTextBox.Text,
                    prizeAmountTextBox.Text,
                    prizePercentageTextbox.Text);

                GlobalConfig.Connection.CreatePrize(model);

                placeNameTextBox.Text = "";
                placeNameTextBox.Text = "";
                prizeAmountTextBox.Text = "0";
                prizePercentageTextbox.Text = "0";
            }
        }

        private void CreatePrizeForm_Load(object sender, EventArgs e)
        {
        }
    }
}
using System;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Linq;
using Tracker_Library.Models;
using Tracker_Library;

namespace TrackerUI
{
    public partial class CreateTeamForm : Form
    {
        public CreateTeamForm()
        {
            InitializeComponent();
        }

        private void createMemberButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PlayerModel p = new PlayerModel();

                p.FristName = firstNameTextBox.Text;
                p.LastName = lastNameTextBox.Text;
                p.CellphoneNumber = cellphoneTextBox.Text;
                p.EmailAddress = emailTextBox.Text;

                GlobalConfig.Connection.CreatePlayer(p);

                firstNameTextBox.Text = "";
                lastNameTextBox.Text = "";
                cellphoneTextBox.Text = "";
                emailTextBox.Text = "";


            } 
            else
            {
                MessageBox.Show("Please complete all New Member fields");
            }


        }


        private bool ValidateForm()
        {
            // TODO -- add Validation to form

            bool formIsValid = true;

            formIsValid = firstNameTextBox.Text.Length > 0;

            formIsValid = lastNameTextBox.Text.Length > 0;

            formIsValid = cellphoneTextBox.Text.Length > 0;

           
            bool IsValidEmail(string email)
            {
                try
                {
                    var mail = new System.Net.Mail.MailAddress(email);
                    return true;
                }
                catch
                {
                    MessageBox.Show("Email Address is not valid");
                    return false;
                }
            }

            formIsValid = IsValidEmail(emailTextBox.Text);

            return formIsValid;
        }
    }


}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Resources;

namespace BDenis3_UniversityManagementSystem
{
    public partial class Login : Form
    {
        private readonly ResourceManager rm = new ResourceManager(typeof(BDenis3_UniversityManagementSystem.strings));
        public Login()
        {
            InitializeComponent();
            populateStrings();
        }

        private void populateStrings()
        {
            this.Text = rm.GetString("LoginFormCaption", CultureInfo.CurrentCulture);
            labelMainInfo.Text = rm.GetString("WelcomeLabel", CultureInfo.CurrentCulture);
            labelUsername.Text = rm.GetString("LoginTextLabel", CultureInfo.CurrentCulture);
            labelPassword.Text = rm.GetString("PasswordTextLabel", CultureInfo.CurrentCulture);
            buttonLogin.Text = rm.GetString("LoginButtonLabel", CultureInfo.CurrentCulture);
            buttonCancel.Text = rm.GetString("CancelButtonLabel", CultureInfo.CurrentCulture);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            UserReader ureader = new UserReader();
            Collection<User> users = ureader.Execute();

            foreach (User user in users)
            {
                try
                {
                    MessageBox.Show(string.Format("User {0} found!", user.UserID));
                }
                catch
                {

                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}

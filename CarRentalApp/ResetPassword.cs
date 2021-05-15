using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class ResetPassword : Form
    {
        private readonly CarRentalEntities _db;
        private User _user;
        public ResetPassword(User user)
        {
            InitializeComponent();
            _db = new CarRentalEntities();
            _user = user;
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            try
            {
                var password = tbNewPassword.Text;
                var confirmedPassword = tbConfirmPassword.Text;
                var user = _db.Users.FirstOrDefault(q => q.id == _user.id);

                if (password != confirmedPassword)
                {
                    MessageBox.Show("Passwords dont match.Try again!");

                }
                user.password = Utils.HashPassword(password);
                _db.SaveChanges();
                MessageBox.Show("Password reset succesfully.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has ocurrer!");
            }
        }
    }
}

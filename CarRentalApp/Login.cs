using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class Login : Form
    {
        private readonly CarRentalEntities _db;
        public Login()
        {
            InitializeComponent();
            _db = new CarRentalEntities();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                SHA256 sha256 = SHA256.Create();

                var username = tbUsername.Text.Trim();
                var password = tbPassword.Text.Trim();
                
                var hashedPassword = Utils.HashPassword(password);
                var user = _db.Users.FirstOrDefault(q => q.username == username && q.password == hashedPassword && q.isActive==true);
                if (user == null)
                {
                    MessageBox.Show("Provide valid credentials.");
                }
                else
                {
                    
                    var mainWindow = new MainWindow(this, user);
                    mainWindow.Show();
                    Hide();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Something went wrong.");
            }
        }
    }
}

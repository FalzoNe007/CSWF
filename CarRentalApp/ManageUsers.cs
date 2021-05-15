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
    public partial class ManageUsers : Form
    {
        private readonly CarRentalEntities _db;
        public ManageUsers()
        {
            InitializeComponent();
            _db = new CarRentalEntities();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (!Utils.FormIsOpen("AddUser"))
            {
                var addUser = new AddUser(this);
                addUser.MdiParent = this.MdiParent;
                addUser.Show();
            }

        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (int)dgvUserList.SelectedRows[0].Cells["id"].Value;
                var user = _db.Users.FirstOrDefault(q => q.id == id);
               
                var hashedPassword = Utils.DefaultHashedPassword();
                user.password = hashedPassword;
                _db.SaveChanges();
                MessageBox.Show($"{user.username}'s password has been reset!");
                PopulateGrid();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Something went wrong.");
            }
            
        }

        private void btnDeactivateUser_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (int)dgvUserList.SelectedRows[0].Cells["id"].Value;
                var user = _db.Users.FirstOrDefault(q => q.id == id);

                user.isActive = user.isActive == true ? false : true;
                _db.SaveChanges();
                MessageBox.Show($"{user.username}'s active status has changed!");
                PopulateGrid();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Something went wrong.");
            }
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            PopulateGrid();     
        }

        public void PopulateGrid()
        {
            var users = _db.Users
                .Select(q => new
                {
                    q.id,
                    q.username,
                    q.UserRoles.FirstOrDefault().Role.name,
                    q.isActive
                }).ToList();
            dgvUserList.DataSource = users;
            dgvUserList.Columns["username"].HeaderText = "Username";
            dgvUserList.Columns["name"].HeaderText = "Role name";
            dgvUserList.Columns["isActive"].HeaderText = "Active";
            dgvUserList.Columns["id"].Visible = false;




        }
    }
}

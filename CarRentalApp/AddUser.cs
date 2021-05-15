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
    public partial class AddUser : Form
    {
        private readonly CarRentalEntities _db;
        private ManageUsers _manageUsers;
        public AddUser(ManageUsers manageUsers)
        {
            InitializeComponent();
            _db = new CarRentalEntities();
            _manageUsers = manageUsers;
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            var roles = _db.Roles.ToList();
            cmbRole.DataSource = roles;
            cmbRole.ValueMember = "id";
            cmbRole.DisplayMember = "name";

        }

        private void btnAddUserCancel_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btnAddUserSave_Click(object sender, EventArgs e)
        {
            try
            {
                var username = tbUsername.Text;
                var roleId = (int)cmbRole.SelectedValue;
                var password = Utils.DefaultHashedPassword();
                var user = new User
                {
                    username = username,
                    password = password,
                    isActive = true
                };
                _db.Users.Add(user);
                _db.SaveChanges();

                var userId = user.id;
                var userRole = new UserRole
                {
                    roleid = roleId,
                    userid = user.id
                };
                _db.UserRoles.Add(userRole);
                _db.SaveChanges();
                MessageBox.Show("New user added.");
                _manageUsers.PopulateGrid();
                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error has ocurred.");
            }



        }
    }
}

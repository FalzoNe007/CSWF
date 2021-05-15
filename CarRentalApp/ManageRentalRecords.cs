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
    public partial class ManageRentalRecords : Form
    {
        private readonly CarRentalEntities _db;
        public ManageRentalRecords()
        {
            InitializeComponent();
            _db = new CarRentalEntities();
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            var form = new AddEditRentalRecord(this);
            form.MdiParent = this.MdiParent;
            form.Show();
            
        }

        private void btnEditRecord_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (int)dgvRentalRecords.SelectedRows[0].Cells["id"].Value;
                var record = _db.CarRentalRecords.FirstOrDefault(q => q.id == id);
               var form = new AddEditRentalRecord(record, this);
               form.MdiParent = this.MdiParent;
               form.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            var id = (int)dgvRentalRecords.SelectedRows[0].Cells["id"].Value;
            var record = _db.CarRentalRecords.FirstOrDefault(q => q.id == id);
            _db.CarRentalRecords.Remove(record);
            _db.SaveChanges();
            PopulateGrid();
        }

        private void ManageRentalRecords_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateGrid();     
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void PopulateGrid()
        {
            var records = _db.CarRentalRecords.Select(q => new
            {
                Customer = q.CustomerName,
                DateOut = q.DateRented,
                DateIn = q.DateReturned,
                Id = q.id,
                q.Cost,
                Car = q.TypesOfCar.Make + " " + q.TypesOfCar.Model

            }).ToList();
            dgvRentalRecords.DataSource = records;
            dgvRentalRecords.Columns["DateIn"].HeaderText = "Date in";
            dgvRentalRecords.Columns["DateOut"].HeaderText = "Date out";
            dgvRentalRecords.Columns["Id"].Visible = false;

        }

        private void btnRefreshRecords_Click(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void dgvRentalRecords_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

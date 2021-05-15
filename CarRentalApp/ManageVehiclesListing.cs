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
    public partial class ManageVehicleListing : Form
    {
        private readonly CarRentalEntities _db;
        public ManageVehicleListing()
        {
            InitializeComponent();
            _db = new CarRentalEntities();
        }

        private void ManageVehicleListing_Load(object sender, EventArgs e)
        {
            // var cars = _db.TypesOfCars.ToList();
            //  var cars = _db.TypesOfCars.Select(q => new { CarID = q.id, CarName = q.name }).ToList();
            var cars = _db.TypesOfCars
                .Select(q => new
                {
                    Make = q.Make,
                    Model = q.Model,
                    VIN = q.VIN,
                    Year = q.Year,
                    LicensePlateNumber = q.LicensePlateNumber,
                    q.Id
                })
                .ToList();
            dgvVehicleList.DataSource = cars;
            dgvVehicleList.Columns[4].HeaderText = "License Plate Number";
            dgvVehicleList.Columns[5].Visible = false;
          //  dgvVehicleList.Columns[0].HeaderText = "ID";
          //  dgvVehicleList.Columns[1].HeaderText = "NAME";

        }

        private void btnAddNewCar_Click(object sender, EventArgs e)
        {
         
            AddEditVehicle form = new AddEditVehicle(this);
            form.MdiParent = this.MdiParent;
            form.Show();

        }

        private void btnEditCar_Click(object sender, EventArgs e)
        {
            var id = (int)dgvVehicleList.SelectedRows[0].Cells["id"].Value;
            var car = _db.TypesOfCars.FirstOrDefault(q => q.Id == id);
            var form = new AddEditVehicle(car, this);
            form.MdiParent = this.MdiParent;
            form.Show();
        }

        private void btnDeleteCar_Click(object sender, EventArgs e)
        {
            var id = (int)dgvVehicleList.SelectedRows[0].Cells["id"].Value;
            var car = _db.TypesOfCars.FirstOrDefault(q => q.Id == id);
            
            DialogResult dr = MessageBox.Show("Are you sure you want to delete this record?",
                "Delete", MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                _db.TypesOfCars.Remove(car);
                _db.SaveChanges();
            }
            PopulateGrid();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        public void PopulateGrid()
        {
            var cars = _db.TypesOfCars
                .Select(q => new
                {
                    Make = q.Make,
                    Model = q.Model,
                    VIN = q.VIN,
                    Year = q.Year,
                    LicensePlateNumber = q.LicensePlateNumber,
                    q.Id
                })
                .ToList();
            dgvVehicleList.DataSource = cars;
            dgvVehicleList.Columns[4].HeaderText = "License Plate Number";
            //Hide the column for ID. Changed from the hard coded column value to the name, 
            // to make it more dynamic. 
            dgvVehicleList.Columns["Id"].Visible = false;
        }
    }
}

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
    public partial class AddEditVehicle : Form
    {
        private bool isEditMode;
        private ManageVehicleListing _manageVehicleListing;

        private readonly CarRentalEntities _db;
        public AddEditVehicle(ManageVehicleListing manageVehicleListing = null)
        {
            InitializeComponent();
            lblTitle.Text = "Add New Vehicle";
            isEditMode = false;
            _manageVehicleListing = manageVehicleListing;
            _db = new CarRentalEntities();
        }
        public AddEditVehicle(TypesOfCar carToEdit, ManageVehicleListing manageVehicleListing = null)
        {
            InitializeComponent();
            lblTitle.Text = "Edit Vehicle";
            PopulateFields(carToEdit);
            _manageVehicleListing = manageVehicleListing;

            _db = new CarRentalEntities();
            isEditMode = true;
        }

        private void PopulateFields(TypesOfCar car)
        {
           lblId.Text = car.Id.ToString();
            tbMake.Text = car.Make;
            tbModel.Text = car.Model;
            tbVIN.Text = car.VIN;
            tbYear.Text = car.Year.ToString();
            tbLPN.Text = car.LicensePlateNumber;
        }

        private void AddEditVehicle_Load(object sender, EventArgs e)
        {

        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {

            try
            {
                if (isEditMode)
                {
                    var id = int.Parse(lblId.Text);
                    var car = _db.TypesOfCars.FirstOrDefault(q => q.Id == id);
                    car.Model = tbModel.Text;
                    car.Make = tbMake.Text;
                    car.Year = int.Parse(tbYear.Text);
                    car.VIN = tbVIN.Text;
                    car.LicensePlateNumber = tbLPN.Text;
                   
                }
                else
                {
                    var newCar = new TypesOfCar
                    {
                        LicensePlateNumber = tbLPN.Text,
                        Model = tbModel.Text,
                        Make = tbMake.Text,
                        Year = int.Parse(tbYear.Text),
                        VIN = tbVIN.Text
                    };
                    _db.TypesOfCars.Add(newCar);
                    
                }
                _db.SaveChanges();
                _manageVehicleListing.PopulateGrid();
                MessageBox.Show("Changes saved");
                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();

        }
    }
}

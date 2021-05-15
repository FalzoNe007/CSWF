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
    public partial class AddEditRentalRecord : Form
    {
        private bool isEditMode;
        private ManageRentalRecords _manageRentalRecords;
        private readonly CarRentalEntities _db;

        public AddEditRentalRecord(ManageRentalRecords manageRentalRecords=null)
        {
            InitializeComponent();
            lblTitle.Text = "Add New Rental";
            this.Text = "Add New Rental";
            isEditMode = false;
            _manageRentalRecords = manageRentalRecords;
            _db = new CarRentalEntities();
        }
        public AddEditRentalRecord(CarRentalRecord recordToEdit, ManageRentalRecords manageRentalRecords = null)
        {
            InitializeComponent();
            lblTitle.Text = "Edit Rental Record";
            PopulateFields(recordToEdit);
            _manageRentalRecords = manageRentalRecords;
            _db = new CarRentalEntities();
            isEditMode = true;

        }

        private void PopulateFields(CarRentalRecord recordToEdit)
        {
            tbCustomerName.Text = recordToEdit.CustomerName;
            dtpRented.Value = (DateTime)recordToEdit.DateRented;
            dtpReturned.Value = (DateTime)recordToEdit.DateReturned;

            tbCost.Text = recordToEdit.Cost.ToString();
            lblRecordId.Text = recordToEdit.id.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //  var cars = carRentalEntities.TypesOfCars.ToList();
            var cars = _db.TypesOfCars.Select(q => new
            {
                Id = q.Id,
                Name = q.Make + " " + q.Model
            }).ToList();
            cmbCarType.DisplayMember = "name";
            cmbCarType.ValueMember = "id";
            cmbCarType.DataSource = cars;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string customerName = tbCustomerName.Text;
                var dateRented = dtpRented.Value;
                var dateReturned = dtpReturned.Value;
                var carType = cmbCarType.Text;
                var isValid = true;
                var errorMessage = "";

                double cost = Convert.ToDouble(tbCost.Text);
                if (string.IsNullOrWhiteSpace(customerName) || string.IsNullOrWhiteSpace(carType))
                {
                    isValid = false;
                    errorMessage += "Enter missing data!\n";
                }
                if (dateRented > dateReturned)
                {
                    isValid = false;
                    errorMessage+="Ilegal date selection!\n";
                }
                if (isValid == true)
                {
                    if (isEditMode)
                    {
                        var id = int.Parse(lblRecordId.Text);
                        var carRentalRecord = _db.CarRentalRecords.FirstOrDefault(q => q.id == id);
                        carRentalRecord.CustomerName = customerName;
                        carRentalRecord.DateRented = dateRented;
                        carRentalRecord.DateReturned = dateReturned;
                        carRentalRecord.Cost = (decimal)cost;
                        carRentalRecord.TypeofCarId = (int)cmbCarType.SelectedValue;
                        _db.SaveChanges();
                        MessageBox.Show($"Thank you for submitting {tbCustomerName.Text} the car {cmbCarType.Text} on date {dtpRented.Value}"
                            + $" Cost is: {cost}");

                    }
                    else
                    {
                        var carRentalRecord = new CarRentalRecord();
                        carRentalRecord.CustomerName = customerName;
                        carRentalRecord.DateRented = dateRented;
                        carRentalRecord.DateReturned = dateReturned;
                        carRentalRecord.Cost = (decimal)cost;
                        carRentalRecord.TypeofCarId = (int)cmbCarType.SelectedValue;
                        _db.CarRentalRecords.Add(carRentalRecord);
                        _db.SaveChanges();
                        MessageBox.Show($"Thank you for submitting {tbCustomerName.Text} the car {cmbCarType.Text} on date {dtpRented.Value}"
                            + $" Cost is: {cost}");
                    }
                    _manageRentalRecords.PopulateGrid();
                    Close();
                    
                }
                else
                {
                    MessageBox.Show(errorMessage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
              //  throw;
            }
        }

       
    }
}

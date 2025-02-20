using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace CarRentalApp
{
    public partial class AddEditVehicleFrm: Form
    {
        private readonly CarRentalEntities _db;
        private ManageVehicleListingFrm _manageVehicleListingFrm;
        private bool isEditMode;
        public AddEditVehicleFrm(ManageVehicleListingFrm manageVehicleListingFrm  = null)
        {
            InitializeComponent();
            _db = new CarRentalEntities();
            lblTitle.Text = "Add New Vehicle";
            this.Text = "Add New Vehicle";
            isEditMode = false;
            PopulateComboBoxes();
            _manageVehicleListingFrm = manageVehicleListingFrm;
        }
        public AddEditVehicleFrm(CarType carToEdit, ManageVehicleListingFrm manageVehicleListingFrm = null)
        {
            InitializeComponent();
            lblTitle.Text = "Edit Existing Vehicle";
            this.Text = "Edit Existing Vehicle";
            _manageVehicleListingFrm = manageVehicleListingFrm;

            if (carToEdit == null)
            {
                MessageBox.Show("Please select a vehicle to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            } else
            {
                isEditMode = true;
                _db = new CarRentalEntities();
                PopulateFields(carToEdit);
            }

        }
        private void PopulateComboBoxes()
        {
            var makes = _db.CarTypes.Select(c => c.Make).Distinct().ToList();
            var models = _db.CarTypes.Select(c => c.Model).Distinct().ToList();
            cbMake.DataSource = makes;
            cbModel.DataSource = models;
        }
        private void PopulateFields(CarType car)
        {
            PopulateComboBoxes();
            lblId.Text = car.Id.ToString();
            cbMake.SelectedItem = car.Make;
            cbModel.SelectedItem = car.Model;
            tbVIN.Text = car.VIN;
            tbLicensePlateNumber.Text = car.LicensePlateNumber;
            tbYear.Text = car.Year.ToString();
        }

        private bool ValidateFields(out int year)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(cbMake.Text) ||
                string.IsNullOrWhiteSpace(cbModel.Text) ||
                string.IsNullOrWhiteSpace(tbVIN.Text) ||
                string.IsNullOrWhiteSpace(tbLicensePlateNumber.Text) ||
                !int.TryParse(tbYear.Text, out year))
            {
                MessageBox.Show("Please fill in all fields correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                year = 0;
                return false;
            }

            // Validate year range
            if (year < 1900 || year > DateTime.Now.Year)
            {
                MessageBox.Show("Please enter a valid year between 1900 and the current year.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                int year;

                // Validate fields and get the year
                if (!ValidateFields(out year)) return; // If validation fails, exit

                if (isEditMode)
                {
                    // Edit mode
                    var id = int.Parse(lblId.Text);

                    var car = _db.CarTypes.FirstOrDefault(q => q.Id == id);

                    // Check if car exists
                    if (car == null)
                    {
                        MessageBox.Show("Car not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    car.Make = cbMake.Text;
                    car.Model = cbModel.Text;
                    car.VIN = tbVIN.Text;
                    car.LicensePlateNumber = tbLicensePlateNumber.Text;
                    car.Year = int.Parse(tbYear.Text);
                }
                else
                {
                    // Add mode
                    var newCar = new CarType
                    {
                        Make = cbMake.Text,
                        Model = cbModel.Text,
                        VIN = tbVIN.Text,
                        LicensePlateNumber = tbLicensePlateNumber.Text,
                        Year = int.Parse(tbYear.Text)
                    };
                    _db.CarTypes.Add(newCar);
                }
                _db.SaveChanges();
                _manageVehicleListingFrm.PopulateGrid();
                MessageBox.Show("Vehicle saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

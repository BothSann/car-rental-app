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
    public partial class ManageVehicleListingFrm: Form
    {
        private readonly CarRentalEntities _db;

        public ManageVehicleListingFrm()
        {
            InitializeComponent();
            _db = new CarRentalEntities();
        }

        private void ManageVehicleListingFrm_Load(object sender, EventArgs e)
        {
            this.Select();
            this.ActiveControl = null;
            PopulateGrid();
        }

        private void btnAddNewCar_Click(object sender, EventArgs e)
        {
            var addEditVehicleFrm = new AddEditVehicleFrm(this);
            addEditVehicleFrm.MdiParent = this.MdiParent;
            addEditVehicleFrm.Show();
        }

        private void btnEditCar_Click(object sender, EventArgs e)
        {
            // Get the id of the selected car
            var id = (int)gvVehicleList.SelectedRows[0].Cells["Id"].Value;

            // Query the database for the record with the id
            var car = _db.CarTypes.FirstOrDefault(q => q.Id == id);

            // Open the AddEditVehicleFrm in edit mode
            var addEditVehicleFrm = new AddEditVehicleFrm(car, this);
            addEditVehicleFrm.MdiParent = this.MdiParent;
            addEditVehicleFrm.Show();
        }
        private void btnDeleteCar_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvVehicleList.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a car to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Get the id of the selected car
                var id = (int)gvVehicleList.SelectedRows[0].Cells["Id"].Value;

                // Query the database for the record with the id
                var car = _db.CarTypes.FirstOrDefault(q => q.Id == id);

                if (car == null)
                {
                    MessageBox.Show("Car not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var confirmResult = MessageBox.Show("Are you sure you want to delete this car?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    // Delete the record
                    _db.CarTypes.Remove(car);
                    _db.SaveChanges();
                    MessageBox.Show("Car deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnRefresh_Click(sender, e);
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the car: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateGrid();
            gvVehicleList.Refresh();
            gvVehicleList.Update();
        }

        public void PopulateGrid()
        {
            var cars = _db.CarTypes.Select(q => new
            {
                q.Id,
                Make = q.Make,
                Model = q.Model,
                VIN = q.VIN,
                LicensePlateNumber = q.LicensePlateNumber,
                Year = q.Year,

            }).ToList();

            gvVehicleList.DataSource = cars;
            gvVehicleList.Columns[0].Visible = false;
            gvVehicleList.Columns[4].HeaderText = "License Plate Number";
            //gvVehicleList.Columns[0].HeaderText = "Id";
            //gvVehicleList.Columns[1].HeaderText = "Car Model";
        }
    }
}

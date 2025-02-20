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

    public partial class ManageRentalRecordsFrm: Form
    {
        private readonly CarRentalEntities _db;
        public ManageRentalRecordsFrm()
        {
            InitializeComponent();
            _db = new CarRentalEntities();
        }

        private void btnAddNewRecord_Click(object sender, EventArgs e)
        {
            var addEditRentalRecordFrm = new AddEditRentalRecordFrm(this);
            addEditRentalRecordFrm.MdiParent = this.MdiParent;
            addEditRentalRecordFrm.Show();
        }

        private void btnEditRecord_Click(object sender, EventArgs e)
        {
            // Get the id of the selected car
            var id = (int)gvRecordList.SelectedRows[0].Cells["Id"].Value;

            // Query the database for the record with the id
            var record = _db.CarRentalRecords.FirstOrDefault(q => q.id == id);

            // Open the AddEditRentalRecordFrm form
            var addEditRentalRecordFrm = new AddEditRentalRecordFrm(record, this);
            addEditRentalRecordFrm.MdiParent = this.MdiParent;
            addEditRentalRecordFrm.Show();
        }

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvRecordList.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a car to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Get the id of the selected car
                var id = (int)gvRecordList.SelectedRows[0].Cells["Id"].Value;

                // Query the database for the record with the id
                var record = _db.CarRentalRecords.FirstOrDefault(q => q.id == id);

                if (record == null)
                {
                    MessageBox.Show("Record not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var confirmResult = MessageBox.Show("Are you sure you want to delete this record?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    // Delete the record
                    _db.CarRentalRecords.Remove(record);
                    _db.SaveChanges();
                    MessageBox.Show("Car deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PopulateGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void ManageRentalRecordsFrm_Load(object sender, EventArgs e)
        {
            this.Select();
            this.ActiveControl = null;
            try
            {
                PopulateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void PopulateGrid()
        {
            var records = _db.CarRentalRecords
            .Select(q => new
            {
                Id = q.id,
                CustomerName = q.CustomerName,
                DateRented = q.DateRented,
                DateReturned = q.DateReturned,
                Cost = q.Cost,
                TypeOfCarId = q.CarType.Make + " " + q.CarType.Model
            }).ToList();
            gvRecordList.DataSource = records;
            gvRecordList.Columns["DateRented"].HeaderText = "Rented Date";
            gvRecordList.Columns["DateReturned"].HeaderText = "Returned Date";
            gvRecordList.Columns["TypeOfCarId"].HeaderText = "Car Type";
            gvRecordList.Columns["Id"].Visible =  false;
        }
    }
}

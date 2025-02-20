using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CarRentalApp
{

    public partial class AddEditRentalRecordFrm: Form
    {
        private readonly CarRentalEntities _db;
        private ManageRentalRecordsFrm _manageRentalRecordsFrm;
        private bool isEditMode;
        public AddEditRentalRecordFrm(ManageRentalRecordsFrm manageRentalRecordsFrm = null)
        {
            InitializeComponent();
            _db = new CarRentalEntities();
            lblTitle.Text = "Add Rental Record";
            this.Text = "Add New Rental";
            isEditMode = false;
            _manageRentalRecordsFrm = manageRentalRecordsFrm;
        }
        public AddEditRentalRecordFrm(CarRentalRecord recordToEdit, ManageRentalRecordsFrm manageRentalRecordsFrm = null)
        {
            InitializeComponent();
            _db = new CarRentalEntities();
            lblTitle.Text = "Edit Rental Record";
            this.Text = "Edit Rental Record";
            _manageRentalRecordsFrm = manageRentalRecordsFrm;
            if (recordToEdit != null)
            {
                isEditMode = true;
                PopulateFields(recordToEdit);
            } 
            else
            {
                MessageBox.Show("Please select a record to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void PopulateFields(CarRentalRecord recordToEdit)
        {
            lblId.Text =  recordToEdit.id.ToString();
            tbCustomerName.Text = recordToEdit.CustomerName;
            dtRentedDate.Value = (DateTime)recordToEdit.DateRented;
            dtReturnedDate.Value = (DateTime)recordToEdit.DateReturned;
            tbCost.Text = recordToEdit.Cost.ToString();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string customerName = tbCustomerName.Text;
                DateTime rentedDate = dtRentedDate.Value;
                DateTime returnedDate = dtReturnedDate.Value;
                decimal cost;

                // Try parsing cost; handle format exception
                if (!decimal.TryParse(tbCost.Text, out cost))
                {
                    MessageBox.Show("Invalid cost format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var carType = cbCarTypes.Text;

                // Validation checks
                if (string.IsNullOrWhiteSpace(customerName) || string.IsNullOrWhiteSpace(carType))
                {
                    MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (rentedDate > returnedDate)
                {
                    MessageBox.Show("Rented date cannot be greater than returned date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Proceed to save the record
                var rentalRecord = new CarRentalRecord();
                if (isEditMode)
                {
                    var id = int.Parse(lblId.Text);
                    rentalRecord = _db.CarRentalRecords.FirstOrDefault(q => q.id == id);
                }

                rentalRecord.CustomerName = customerName;
                rentalRecord.DateRented = rentedDate;
                rentalRecord.DateReturned = returnedDate;
                rentalRecord.Cost = cost;
                rentalRecord.TypeOfCarId = (int)cbCarTypes.SelectedValue;

                if (!isEditMode)
                    _db.CarRentalRecords.Add(rentalRecord);

                _db.SaveChanges();
                _manageRentalRecordsFrm.PopulateGrid();
                MessageBox.Show("Record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.Select();
            this.ActiveControl = null;
            //var cars = _db.CarTypes.ToList();
            var cars = _db.CarTypes.Select(q => new
            {
                Id = q.Id,
                Name = q.Make + " " + q.Model
            }).ToList();
            cbCarTypes.DisplayMember = "Name";
            cbCarTypes.ValueMember = "Id";
            cbCarTypes.DataSource = cars;

        }
    }
}

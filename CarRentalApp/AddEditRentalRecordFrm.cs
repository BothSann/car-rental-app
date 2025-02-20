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
        private bool isEditMode;
        public AddEditRentalRecordFrm()
        {
            InitializeComponent();
            _db = new CarRentalEntities();
            lblTitle.Text = "Add Rental Record";
            this.Text = "Add New Rental";
            isEditMode = false;
        }
        public AddEditRentalRecordFrm(CarRentalRecord recordToEdit)
        {
            InitializeComponent();
            _db = new CarRentalEntities();
            lblTitle.Text = "Edit Rental Record";
            this.Text = "Edit Rental Record";
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
            lblId.Visible = true;
            lblId.Text = "Id: " + recordToEdit.id.ToString();
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
                decimal cost = Convert.ToDecimal(tbCost.Text);


                var carType = cbCarTypes.Text;
                var isValid = true;

                if (string.IsNullOrWhiteSpace(customerName) || string.IsNullOrWhiteSpace(carType))
                {
                    isValid = false;
                    throw new Exception("Please fill in all fields");
                }

                if (rentedDate > returnedDate)
                {
                    isValid = false;
                    throw new Exception("Rented date cannot be greater than returned date");    
                }
                if (isValid)
                {
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

                    if (!isEditMode) _db.CarRentalRecords.Add(rentalRecord);
                    _db.SaveChanges();
                    MessageBox.Show("Car rented successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    //_db.SaveChanges();
                    //MessageBox.Show("Record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                {
                    MessageBox.Show("An error occured. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);   
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

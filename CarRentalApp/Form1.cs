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
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string customerName = tbCustomerName.Text;
                DateTime rentedDate = dtRentedDate.Value;
                DateTime returnedDate = dtReturnedDate.Value;
                double cost = Convert.ToDouble(tbCost.Text);

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
                    MessageBox.Show($"{customerName}\n\r" +
                    $"{rentedDate}\n\r" +
                    $"{returnedDate}\n\r" +
                    $"{carType}\n\r" +
                    $"{cost}\n\r" +
                    $"Rented successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}");
            }
        }
    }
}

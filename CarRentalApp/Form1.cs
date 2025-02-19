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
            string customerName = tbCustomerName.Text;
            DateTime rentedDate = dtRentedDate.Value;
            DateTime returnedDate = dtReturnedDate.Value;
            double cost = Convert.ToDouble(tbCost.Text);

            var carType = cbCarTypes.SelectedItem.ToString();
            var isValid = true;

            if (string.IsNullOrWhiteSpace(customerName) || string.IsNullOrWhiteSpace(carType)) 
            {
                isValid = false;
                MessageBox.Show("Please fill in all fields");
            }   

            if (rentedDate > returnedDate)
            {
                isValid = false;
                MessageBox.Show("Rented date cannot be greater than returned date");
            }
            if (isValid)
            {
                MessageBox.Show($"{customerName}\n\r" +
                $"{rentedDate}\n\r" +
                $"{returnedDate}\n\r" +
                $"{carType}\n\r" +
                $"{cost}\n\r" +
                $"Thank you, {customerName}");
            }
        }
    }
}

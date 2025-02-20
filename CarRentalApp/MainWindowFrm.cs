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
    public partial class MainWindowFrm: Form
    {
        public MainWindowFrm()
        {
            InitializeComponent();
        }

        private void addRetalRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var OpenForms = Application.OpenForms;
            foreach (Form form in OpenForms)
            {
                if (form.GetType() == typeof(AddEditRentalRecordFrm))
                {
                    form.Activate();
                    return;
                }
            }
            var addRentalRecord = new AddEditRentalRecordFrm();
            addRentalRecord.MdiParent = this;
            addRentalRecord.Show();

        }

        private void manageVehicleListingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var OpenForms  = Application.OpenForms;
            foreach (Form form in OpenForms)
            {
                if (form.GetType() == typeof(ManageVehicleListingFrm))
                {
                    form.Activate();
                    return;
                }
            }
            var manageVehicleListing = new ManageVehicleListingFrm();  
            manageVehicleListing.MdiParent = this;
            manageVehicleListing.Show();
        }

        private void viewArchiveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var OpenForms = Application.OpenForms;
            foreach (Form form in OpenForms)
            {
                if (form.GetType() == typeof(ManageRentalRecordsFrm))
                {
                    form.Activate();
                    return;
                }
            }
            var manageRentalRecordsFrm = new ManageRentalRecordsFrm();
            manageRentalRecordsFrm.MdiParent = this;
            manageRentalRecordsFrm.Show();
        }

        private void editRentalRecordMenu_Click(object sender, EventArgs e)
        {
            var OpenForms = Application.OpenForms;
            foreach (Form form in OpenForms)
            {
                if (form.GetType() == typeof(ManageRentalRecordsFrm))
                {
                    form.Activate();
                    return;
                }
            }
            var manageRentalRecordsFrm = new ManageRentalRecordsFrm();
            manageRentalRecordsFrm.MdiParent = this;
            manageRentalRecordsFrm.Show();
        }
    }
}

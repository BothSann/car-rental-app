namespace CarRentalApp
{
    partial class MainWindowFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.manageVehicleListingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageRentalRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRetalRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewArchiveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Matura MT Script Capitals", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(217, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 85);
            this.label1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageVehicleListingToolStripMenuItem,
            this.manageRentalRecordToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1030, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // manageVehicleListingToolStripMenuItem
            // 
            this.manageVehicleListingToolStripMenuItem.Name = "manageVehicleListingToolStripMenuItem";
            this.manageVehicleListingToolStripMenuItem.Size = new System.Drawing.Size(140, 20);
            this.manageVehicleListingToolStripMenuItem.Text = "Manage Vehicle Listing";
            this.manageVehicleListingToolStripMenuItem.Click += new System.EventHandler(this.manageVehicleListingToolStripMenuItem_Click);
            // 
            // manageRentalRecordToolStripMenuItem
            // 
            this.manageRentalRecordToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRetalRecordToolStripMenuItem,
            this.viewArchiveToolStripMenuItem1});
            this.manageRentalRecordToolStripMenuItem.Name = "manageRentalRecordToolStripMenuItem";
            this.manageRentalRecordToolStripMenuItem.Size = new System.Drawing.Size(143, 20);
            this.manageRentalRecordToolStripMenuItem.Text = "Manage Rental Records";
            // 
            // addRetalRecordToolStripMenuItem
            // 
            this.addRetalRecordToolStripMenuItem.Name = "addRetalRecordToolStripMenuItem";
            this.addRetalRecordToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addRetalRecordToolStripMenuItem.Text = "Add Retal Record";
            this.addRetalRecordToolStripMenuItem.Click += new System.EventHandler(this.addRetalRecordToolStripMenuItem_Click);
            // 
            // viewArchiveToolStripMenuItem1
            // 
            this.viewArchiveToolStripMenuItem1.Name = "viewArchiveToolStripMenuItem1";
            this.viewArchiveToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.viewArchiveToolStripMenuItem1.Text = "View / Edit Archive";
            this.viewArchiveToolStripMenuItem1.Click += new System.EventHandler(this.viewArchiveToolStripMenuItem1_Click);
            // 
            // MainWindowFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1030, 703);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindowFrm";
            this.Text = "BS Auto Rentals System";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem manageVehicleListingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageRentalRecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRetalRecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewArchiveToolStripMenuItem1;
    }
}
namespace CarRentalApp
{
    partial class Form1
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
            this.tbCustomerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtRentedDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbCarTypes = new System.Windows.Forms.ComboBox();
            this.dtReturnedDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbCost = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Matura MT Script Capitals", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(136, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(553, 64);
            this.label1.TabIndex = 0;
            this.label1.Text = "Car Rental Application";
            // 
            // tbCustomerName
            // 
            this.tbCustomerName.Location = new System.Drawing.Point(96, 167);
            this.tbCustomerName.Multiline = true;
            this.tbCustomerName.Name = "tbCustomerName";
            this.tbCustomerName.Size = new System.Drawing.Size(265, 24);
            this.tbCustomerName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(92, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Customer Name";
            // 
            // dtRentedDate
            // 
            this.dtRentedDate.Location = new System.Drawing.Point(96, 231);
            this.dtRentedDate.Name = "dtRentedDate";
            this.dtRentedDate.Size = new System.Drawing.Size(265, 20);
            this.dtRentedDate.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(92, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Rented Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(460, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Returned Date";
            // 
            // cbCarTypes
            // 
            this.cbCarTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCarTypes.FormattingEnabled = true;
            this.cbCarTypes.Items.AddRange(new object[] {
            "Honda Civic",
            "Honda CR-V",
            "Toyota Corolla",
            "Toyota Camry",
            "BMW 3 Series",
            "Mercedes-Benz C-Class",
            "Audi A4",
            "Ford Mustang",
            "Chevrolet Camaro",
            "Ford Escape",
            "Jeep Grand Cherokee"});
            this.cbCarTypes.Location = new System.Drawing.Point(96, 288);
            this.cbCarTypes.Name = "cbCarTypes";
            this.cbCarTypes.Size = new System.Drawing.Size(265, 21);
            this.cbCarTypes.TabIndex = 7;
            // 
            // dtReturnedDate
            // 
            this.dtReturnedDate.Location = new System.Drawing.Point(464, 231);
            this.dtReturnedDate.Name = "dtReturnedDate";
            this.dtReturnedDate.Size = new System.Drawing.Size(265, 20);
            this.dtReturnedDate.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(92, 265);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Car Type";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Matura MT Script Capitals", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(551, 288);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(108, 40);
            this.btnSubmit.TabIndex = 10;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(460, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Cost";
            // 
            // tbCost
            // 
            this.tbCost.Location = new System.Drawing.Point(464, 167);
            this.tbCost.Multiline = true;
            this.tbCost.Name = "tbCost";
            this.tbCost.Size = new System.Drawing.Size(265, 24);
            this.tbCost.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 490);
            this.Controls.Add(this.tbCost);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtReturnedDate);
            this.Controls.Add(this.cbCarTypes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtRentedDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbCustomerName);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Car Rental App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCustomerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtRentedDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbCarTypes;
        private System.Windows.Forms.DateTimePicker dtReturnedDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbCost;
    }
}


namespace IslaBank2019
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dvgDatalist = new System.Windows.Forms.DataGridView();
            this.lblPcsperbook = new System.Windows.Forms.Label();
            this.txtOrQty = new System.Windows.Forms.TextBox();
            this.txtAccountName2 = new System.Windows.Forms.TextBox();
            this.txtAccountName1 = new System.Windows.Forms.TextBox();
            this.txtAccountNumber = new System.Windows.Forms.TextBox();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.cmbChkType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dvgDatalist)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcess.Location = new System.Drawing.Point(532, 453);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(150, 35);
            this.btnProcess.TabIndex = 29;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(434, 453);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 35);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dvgDatalist
            // 
            this.dvgDatalist.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dvgDatalist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgDatalist.Location = new System.Drawing.Point(20, 297);
            this.dvgDatalist.Name = "dvgDatalist";
            this.dvgDatalist.Size = new System.Drawing.Size(662, 150);
            this.dvgDatalist.TabIndex = 29;
            // 
            // lblPcsperbook
            // 
            this.lblPcsperbook.AutoSize = true;
            this.lblPcsperbook.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPcsperbook.Location = new System.Drawing.Point(337, 248);
            this.lblPcsperbook.Name = "lblPcsperbook";
            this.lblPcsperbook.Size = new System.Drawing.Size(133, 24);
            this.lblPcsperbook.TabIndex = 28;
            this.lblPcsperbook.Text = "Pcs per book";
            // 
            // txtOrQty
            // 
            this.txtOrQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrQty.Location = new System.Drawing.Point(217, 245);
            this.txtOrQty.Name = "txtOrQty";
            this.txtOrQty.Size = new System.Drawing.Size(92, 29);
            this.txtOrQty.TabIndex = 27;
            this.txtOrQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOrQty_KeyPress);
            // 
            // txtAccountName2
            // 
            this.txtAccountName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountName2.Location = new System.Drawing.Point(218, 210);
            this.txtAccountName2.Name = "txtAccountName2";
            this.txtAccountName2.Size = new System.Drawing.Size(444, 29);
            this.txtAccountName2.TabIndex = 26;
            this.txtAccountName2.TextChanged += new System.EventHandler(this.txtAccountName2_TextChanged);
            // 
            // txtAccountName1
            // 
            this.txtAccountName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountName1.Location = new System.Drawing.Point(217, 176);
            this.txtAccountName1.Name = "txtAccountName1";
            this.txtAccountName1.Size = new System.Drawing.Size(445, 29);
            this.txtAccountName1.TabIndex = 25;
            this.txtAccountName1.TextChanged += new System.EventHandler(this.txtAccountName1_TextChanged);
            this.txtAccountName1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAccountName1_KeyPress);
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountNumber.Location = new System.Drawing.Point(217, 105);
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.Size = new System.Drawing.Size(366, 29);
            this.txtAccountNumber.TabIndex = 23;
            this.txtAccountNumber.TextChanged += new System.EventHandler(this.txtAccountNumber_TextChanged);
            this.txtAccountNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAccountNumber_KeyPress);
            // 
            // cmbBranch
            // 
            this.cmbBranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(218, 138);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(444, 32);
            this.cmbBranch.TabIndex = 24;
            this.cmbBranch.SelectedIndexChanged += new System.EventHandler(this.cmbBranch_SelectedIndexChanged);
            this.cmbBranch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbBranch_KeyPress);
            // 
            // cmbChkType
            // 
            this.cmbChkType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbChkType.FormattingEnabled = true;
            this.cmbChkType.Location = new System.Drawing.Point(217, 68);
            this.cmbChkType.Name = "cmbChkType";
            this.cmbChkType.Size = new System.Drawing.Size(386, 32);
            this.cmbChkType.TabIndex = 22;
            this.cmbChkType.SelectedIndexChanged += new System.EventHandler(this.cmbChkType_SelectedIndexChanged);
            this.cmbChkType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbChkType_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 24);
            this.label6.TabIndex = 21;
            this.label6.Text = "Order Quantity : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(183, 24);
            this.label5.TabIndex = 20;
            this.label5.Text = "Account Name 2 : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(183, 24);
            this.label4.TabIndex = 19;
            this.label4.Text = "Account Name 1 : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 24);
            this.label3.TabIndex = 18;
            this.label3.Text = "Branch Name : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 24);
            this.label2.TabIndex = 17;
            this.label2.Text = "Account Number : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 24);
            this.label1.TabIndex = 16;
            this.label1.Text = "Cheque Name : ";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(182, 10);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(232, 22);
            this.dateTimePicker1.TabIndex = 33;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(20, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(662, 245);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(25, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 24);
            this.label7.TabIndex = 35;
            this.label7.Text = "Delivery Date : ";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(20, 453);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 35);
            this.button1.TabIndex = 36;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(538, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 16);
            this.label8.TabIndex = 37;
            this.label8.Text = "Welcome :";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(625, 11);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(0, 16);
            this.lblUsername.TabIndex = 38;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(694, 498);
            this.ControlBox = false;
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dvgDatalist);
            this.Controls.Add(this.lblPcsperbook);
            this.Controls.Add(this.txtOrQty);
            this.Controls.Add(this.txtAccountName2);
            this.Controls.Add(this.txtAccountName1);
            this.Controls.Add(this.txtAccountNumber);
            this.Controls.Add(this.cmbBranch);
            this.Controls.Add(this.cmbChkType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Isla Bank";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgDatalist)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dvgDatalist;
        private System.Windows.Forms.Label lblPcsperbook;
        private System.Windows.Forms.TextBox txtOrQty;
        private System.Windows.Forms.TextBox txtAccountName2;
        private System.Windows.Forms.TextBox txtAccountName1;
        private System.Windows.Forms.TextBox txtAccountNumber;
        private System.Windows.Forms.ComboBox cmbBranch;
        private System.Windows.Forms.ComboBox cmbChkType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblUsername;
    }
}


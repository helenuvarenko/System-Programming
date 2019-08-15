namespace MS_Sql
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonGET = new System.Windows.Forms.RadioButton();
            this.radioButtonDELETE = new System.Windows.Forms.RadioButton();
            this.radioButtonUPDATE = new System.Windows.Forms.RadioButton();
            this.radioButtonADD = new System.Windows.Forms.RadioButton();
            this.buttonQUERY = new System.Windows.Forms.Button();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxDURATION = new System.Windows.Forms.TextBox();
            this.textBoxPRICE = new System.Windows.Forms.TextBox();
            this.textBoxMASTER = new System.Windows.Forms.TextBox();
            this.textBoxNAME = new System.Windows.Forms.TextBox();
            this.comboBoxTYPE = new System.Windows.Forms.ComboBox();
            this.checkBoxID = new System.Windows.Forms.CheckBox();
            this.checkBoxTYPE = new System.Windows.Forms.CheckBox();
            this.buttonTYPE = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.textBoxResult = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(10, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(234, 227);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 45.8F);
            this.label1.Location = new System.Drawing.Point(251, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(494, 87);
            this.label1.TabIndex = 1;
            this.label1.Text = "Beauty Salon";
            // 
            // radioButtonGET
            // 
            this.radioButtonGET.AutoSize = true;
            this.radioButtonGET.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.8F);
            this.radioButtonGET.Location = new System.Drawing.Point(250, 94);
            this.radioButtonGET.Name = "radioButtonGET";
            this.radioButtonGET.Size = new System.Drawing.Size(220, 43);
            this.radioButtonGET.TabIndex = 2;
            this.radioButtonGET.TabStop = true;
            this.radioButtonGET.Text = "Get Service";
            this.radioButtonGET.UseVisualStyleBackColor = true;
            this.radioButtonGET.CheckedChanged += new System.EventHandler(this.radioButtonGET_CheckedChanged);
            // 
            // radioButtonDELETE
            // 
            this.radioButtonDELETE.AutoSize = true;
            this.radioButtonDELETE.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.8F);
            this.radioButtonDELETE.Location = new System.Drawing.Point(481, 143);
            this.radioButtonDELETE.Name = "radioButtonDELETE";
            this.radioButtonDELETE.Size = new System.Drawing.Size(264, 43);
            this.radioButtonDELETE.TabIndex = 3;
            this.radioButtonDELETE.TabStop = true;
            this.radioButtonDELETE.Text = "Delete Service";
            this.radioButtonDELETE.UseVisualStyleBackColor = true;
            this.radioButtonDELETE.CheckedChanged += new System.EventHandler(this.radioButtonDELETE_CheckedChanged);
            // 
            // radioButtonUPDATE
            // 
            this.radioButtonUPDATE.AutoSize = true;
            this.radioButtonUPDATE.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.8F);
            this.radioButtonUPDATE.Location = new System.Drawing.Point(481, 94);
            this.radioButtonUPDATE.Name = "radioButtonUPDATE";
            this.radioButtonUPDATE.Size = new System.Drawing.Size(275, 43);
            this.radioButtonUPDATE.TabIndex = 4;
            this.radioButtonUPDATE.TabStop = true;
            this.radioButtonUPDATE.Text = "Update Service";
            this.radioButtonUPDATE.UseVisualStyleBackColor = true;
            this.radioButtonUPDATE.CheckedChanged += new System.EventHandler(this.radioButtonUPDATE_CheckedChanged);
            // 
            // radioButtonADD
            // 
            this.radioButtonADD.AutoSize = true;
            this.radioButtonADD.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.8F);
            this.radioButtonADD.Location = new System.Drawing.Point(250, 143);
            this.radioButtonADD.Name = "radioButtonADD";
            this.radioButtonADD.Size = new System.Drawing.Size(225, 43);
            this.radioButtonADD.TabIndex = 5;
            this.radioButtonADD.TabStop = true;
            this.radioButtonADD.Text = "Add Service";
            this.radioButtonADD.UseVisualStyleBackColor = true;
            this.radioButtonADD.CheckedChanged += new System.EventHandler(this.radioButtonADD_CheckedChanged);
            // 
            // buttonQUERY
            // 
            this.buttonQUERY.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.8F);
            this.buttonQUERY.Location = new System.Drawing.Point(12, 295);
            this.buttonQUERY.Name = "buttonQUERY";
            this.buttonQUERY.Size = new System.Drawing.Size(279, 39);
            this.buttonQUERY.TabIndex = 6;
            this.buttonQUERY.Text = "Send Query";
            this.buttonQUERY.UseVisualStyleBackColor = true;
            this.buttonQUERY.Click += new System.EventHandler(this.buttonQUERY_Click);
            // 
            // textBoxID
            // 
            this.textBoxID.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.textBoxID.Location = new System.Drawing.Point(10, 243);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(128, 36);
            this.textBoxID.TabIndex = 7;
            this.textBoxID.Text = "Service ID";
            this.textBoxID.TextChanged += new System.EventHandler(this.textBoxID_TextChanged);
            this.textBoxID.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxID_Validating);
            // 
            // textBoxDURATION
            // 
            this.textBoxDURATION.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.textBoxDURATION.Location = new System.Drawing.Point(609, 243);
            this.textBoxDURATION.Name = "textBoxDURATION";
            this.textBoxDURATION.Size = new System.Drawing.Size(120, 36);
            this.textBoxDURATION.TabIndex = 8;
            this.textBoxDURATION.Text = "Duration";
            // 
            // textBoxPRICE
            // 
            this.textBoxPRICE.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.textBoxPRICE.Location = new System.Drawing.Point(331, 243);
            this.textBoxPRICE.Name = "textBoxPRICE";
            this.textBoxPRICE.Size = new System.Drawing.Size(77, 36);
            this.textBoxPRICE.TabIndex = 9;
            this.textBoxPRICE.Text = "Price";
            this.textBoxPRICE.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxPRICE_Validating);
            // 
            // textBoxMASTER
            // 
            this.textBoxMASTER.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.textBoxMASTER.Location = new System.Drawing.Point(427, 243);
            this.textBoxMASTER.Name = "textBoxMASTER";
            this.textBoxMASTER.Size = new System.Drawing.Size(156, 36);
            this.textBoxMASTER.TabIndex = 10;
            this.textBoxMASTER.Text = "Master name";
            this.textBoxMASTER.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxMASTER_Validating);
            // 
            // textBoxNAME
            // 
            this.textBoxNAME.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.textBoxNAME.Location = new System.Drawing.Point(144, 243);
            this.textBoxNAME.Name = "textBoxNAME";
            this.textBoxNAME.Size = new System.Drawing.Size(171, 36);
            this.textBoxNAME.TabIndex = 11;
            this.textBoxNAME.Text = "Service name";
            this.textBoxNAME.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxNAME_Validating);
            // 
            // comboBoxTYPE
            // 
            this.comboBoxTYPE.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.8F);
            this.comboBoxTYPE.FormattingEnabled = true;
            this.comboBoxTYPE.Location = new System.Drawing.Point(841, 243);
            this.comboBoxTYPE.Name = "comboBoxTYPE";
            this.comboBoxTYPE.Size = new System.Drawing.Size(308, 38);
            this.comboBoxTYPE.TabIndex = 12;
            this.comboBoxTYPE.Text = "Category Select";
            this.comboBoxTYPE.Click += new System.EventHandler(this.comboBoxTYPE_Click);
            this.comboBoxTYPE.Validating += new System.ComponentModel.CancelEventHandler(this.comboBoxTYPE_Validating);
            // 
            // checkBoxID
            // 
            this.checkBoxID.AutoSize = true;
            this.checkBoxID.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.8F);
            this.checkBoxID.Location = new System.Drawing.Point(861, 55);
            this.checkBoxID.Name = "checkBoxID";
            this.checkBoxID.Size = new System.Drawing.Size(109, 40);
            this.checkBoxID.TabIndex = 13;
            this.checkBoxID.Text = "By ID";
            this.checkBoxID.UseVisualStyleBackColor = true;
            this.checkBoxID.CheckedChanged += new System.EventHandler(this.checkBoxID_CheckedChanged);
            // 
            // checkBoxTYPE
            // 
            this.checkBoxTYPE.AutoSize = true;
            this.checkBoxTYPE.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.8F);
            this.checkBoxTYPE.Location = new System.Drawing.Point(861, 116);
            this.checkBoxTYPE.Name = "checkBoxTYPE";
            this.checkBoxTYPE.Size = new System.Drawing.Size(200, 40);
            this.checkBoxTYPE.TabIndex = 15;
            this.checkBoxTYPE.Text = "By Category";
            this.checkBoxTYPE.UseVisualStyleBackColor = true;
            this.checkBoxTYPE.CheckedChanged += new System.EventHandler(this.checkBoxTYPE_CheckedChanged);
            // 
            // buttonTYPE
            // 
            this.buttonTYPE.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.8F);
            this.buttonTYPE.Location = new System.Drawing.Point(340, 295);
            this.buttonTYPE.Name = "buttonTYPE";
            this.buttonTYPE.Size = new System.Drawing.Size(346, 39);
            this.buttonTYPE.TabIndex = 16;
            this.buttonTYPE.Text = "Go to Category Settings";
            this.buttonTYPE.UseVisualStyleBackColor = true;
            this.buttonTYPE.Click += new System.EventHandler(this.buttonTYPE_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 340);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1170, 269);
            this.dataGridView1.TabIndex = 17;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // textBoxResult
            // 
            this.textBoxResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.8F);
            this.textBoxResult.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxResult.Location = new System.Drawing.Point(841, 180);
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.ReadOnly = true;
            this.textBoxResult.Size = new System.Drawing.Size(308, 37);
            this.textBoxResult.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1194, 621);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonTYPE);
            this.Controls.Add(this.checkBoxTYPE);
            this.Controls.Add(this.checkBoxID);
            this.Controls.Add(this.comboBoxTYPE);
            this.Controls.Add(this.textBoxNAME);
            this.Controls.Add(this.textBoxMASTER);
            this.Controls.Add(this.textBoxPRICE);
            this.Controls.Add(this.textBoxDURATION);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.buttonQUERY);
            this.Controls.Add(this.radioButtonADD);
            this.Controls.Add(this.radioButtonUPDATE);
            this.Controls.Add(this.radioButtonDELETE);
            this.Controls.Add(this.radioButtonGET);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButtonGET;
        private System.Windows.Forms.RadioButton radioButtonDELETE;
        private System.Windows.Forms.RadioButton radioButtonUPDATE;
        private System.Windows.Forms.RadioButton radioButtonADD;
        private System.Windows.Forms.Button buttonQUERY;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textBoxDURATION;
        private System.Windows.Forms.TextBox textBoxPRICE;
        private System.Windows.Forms.TextBox textBoxMASTER;
        private System.Windows.Forms.TextBox textBoxNAME;
        private System.Windows.Forms.ComboBox comboBoxTYPE;
        private System.Windows.Forms.CheckBox checkBoxID;
        private System.Windows.Forms.CheckBox checkBoxTYPE;
        private System.Windows.Forms.Button buttonTYPE;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TextBox textBoxResult;
    }
}


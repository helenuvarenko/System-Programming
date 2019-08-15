namespace MS_SQL_1
{
    partial class Category
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Category));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.radioButtonGET = new System.Windows.Forms.RadioButton();
            this.radioButtonDELETE = new System.Windows.Forms.RadioButton();
            this.radioButtonUPDATE = new System.Windows.Forms.RadioButton();
            this.radioButtonADD = new System.Windows.Forms.RadioButton();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxDESCRIPTION = new System.Windows.Forms.TextBox();
            this.textBoxNAME = new System.Windows.Forms.TextBox();
            this.buttonQUERY = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.textBoxResult = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(194, 189);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 45.8F);
            this.label1.Location = new System.Drawing.Point(221, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(494, 87);
            this.label1.TabIndex = 1;
            this.label1.Text = "Beauty Salon";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 365);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1051, 227);
            this.dataGridView1.TabIndex = 2;
            // 
            // radioButtonGET
            // 
            this.radioButtonGET.AutoSize = true;
            this.radioButtonGET.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.8F);
            this.radioButtonGET.Location = new System.Drawing.Point(225, 115);
            this.radioButtonGET.Name = "radioButtonGET";
            this.radioButtonGET.Size = new System.Drawing.Size(177, 35);
            this.radioButtonGET.TabIndex = 0;
            this.radioButtonGET.TabStop = true;
            this.radioButtonGET.Text = "Get Service";
            this.radioButtonGET.UseVisualStyleBackColor = true;
            this.radioButtonGET.CheckedChanged += new System.EventHandler(this.radioButtonGET_CheckedChanged);
            // 
            // radioButtonDELETE
            // 
            this.radioButtonDELETE.AutoSize = true;
            this.radioButtonDELETE.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.8F);
            this.radioButtonDELETE.Location = new System.Drawing.Point(425, 166);
            this.radioButtonDELETE.Name = "radioButtonDELETE";
            this.radioButtonDELETE.Size = new System.Drawing.Size(212, 35);
            this.radioButtonDELETE.TabIndex = 4;
            this.radioButtonDELETE.TabStop = true;
            this.radioButtonDELETE.Text = "Delete Service";
            this.radioButtonDELETE.UseVisualStyleBackColor = true;
            this.radioButtonDELETE.CheckedChanged += new System.EventHandler(this.radioButtonDELETE_CheckedChanged);
            // 
            // radioButtonUPDATE
            // 
            this.radioButtonUPDATE.AutoSize = true;
            this.radioButtonUPDATE.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.8F);
            this.radioButtonUPDATE.Location = new System.Drawing.Point(425, 115);
            this.radioButtonUPDATE.Name = "radioButtonUPDATE";
            this.radioButtonUPDATE.Size = new System.Drawing.Size(221, 35);
            this.radioButtonUPDATE.TabIndex = 5;
            this.radioButtonUPDATE.TabStop = true;
            this.radioButtonUPDATE.Text = "Update Service";
            this.radioButtonUPDATE.UseVisualStyleBackColor = true;
            this.radioButtonUPDATE.CheckedChanged += new System.EventHandler(this.radioButtonUPDATE_CheckedChanged);
            // 
            // radioButtonADD
            // 
            this.radioButtonADD.AutoSize = true;
            this.radioButtonADD.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.8F);
            this.radioButtonADD.Location = new System.Drawing.Point(225, 166);
            this.radioButtonADD.Name = "radioButtonADD";
            this.radioButtonADD.Size = new System.Drawing.Size(181, 35);
            this.radioButtonADD.TabIndex = 6;
            this.radioButtonADD.TabStop = true;
            this.radioButtonADD.Text = "Add Service";
            this.radioButtonADD.UseVisualStyleBackColor = true;
            this.radioButtonADD.CheckedChanged += new System.EventHandler(this.radioButtonADD_CheckedChanged);
            // 
            // textBoxID
            // 
            this.textBoxID.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.textBoxID.Location = new System.Drawing.Point(12, 263);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(108, 34);
            this.textBoxID.TabIndex = 8;
            this.textBoxID.Text = "ID";
            this.textBoxID.TextChanged += new System.EventHandler(this.textBoxID_TextChanged);
            this.textBoxID.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxID_Validating);
            // 
            // textBoxDESCRIPTION
            // 
            this.textBoxDESCRIPTION.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.textBoxDESCRIPTION.Location = new System.Drawing.Point(504, 263);
            this.textBoxDESCRIPTION.Name = "textBoxDESCRIPTION";
            this.textBoxDESCRIPTION.Size = new System.Drawing.Size(348, 34);
            this.textBoxDESCRIPTION.TabIndex = 9;
            this.textBoxDESCRIPTION.Text = "Description";
            this.textBoxDESCRIPTION.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxDESCRIPTION_Validating);
            // 
            // textBoxNAME
            // 
            this.textBoxNAME.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.textBoxNAME.Location = new System.Drawing.Point(180, 263);
            this.textBoxNAME.Name = "textBoxNAME";
            this.textBoxNAME.Size = new System.Drawing.Size(239, 34);
            this.textBoxNAME.TabIndex = 10;
            this.textBoxNAME.Text = "Category name";
            this.textBoxNAME.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxNAME_Validating);
            // 
            // buttonQUERY
            // 
            this.buttonQUERY.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.buttonQUERY.Location = new System.Drawing.Point(778, 39);
            this.buttonQUERY.Name = "buttonQUERY";
            this.buttonQUERY.Size = new System.Drawing.Size(232, 60);
            this.buttonQUERY.TabIndex = 11;
            this.buttonQUERY.Text = "Send Query";
            this.buttonQUERY.UseVisualStyleBackColor = true;
            this.buttonQUERY.Click += new System.EventHandler(this.buttonQUERY_Click_1);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.button2.Location = new System.Drawing.Point(778, 115);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(232, 60);
            this.button2.TabIndex = 12;
            this.button2.Text = "Go Back";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // textBoxResult
            // 
            this.textBoxResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.textBoxResult.Location = new System.Drawing.Point(778, 208);
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(265, 32);
            this.textBoxResult.TabIndex = 13;
            // 
            // Category
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1075, 604);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonQUERY);
            this.Controls.Add(this.textBoxNAME);
            this.Controls.Add(this.textBoxDESCRIPTION);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.radioButtonADD);
            this.Controls.Add(this.radioButtonUPDATE);
            this.Controls.Add(this.radioButtonDELETE);
            this.Controls.Add(this.radioButtonGET);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Category";
            this.Text = "Category";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Category_FormClosing);
            this.Load += new System.EventHandler(this.Category_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RadioButton radioButtonGET;
        private System.Windows.Forms.RadioButton radioButtonDELETE;
        private System.Windows.Forms.RadioButton radioButtonUPDATE;
        private System.Windows.Forms.RadioButton radioButtonADD;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textBoxDESCRIPTION;
        private System.Windows.Forms.TextBox textBoxNAME;
        private System.Windows.Forms.Button buttonQUERY;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TextBox textBoxResult;
    }
}
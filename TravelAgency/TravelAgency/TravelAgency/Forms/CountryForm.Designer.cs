
namespace TravelAgency.Forms
{
    partial class CountryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CountryForm));
            this.buttonAddCountry = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelWarningCountry = new System.Windows.Forms.Label();
            this.labelCountry = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelWarningCity = new System.Windows.Forms.Label();
            this.labelCity = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxCity = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxCountry = new System.Windows.Forms.TextBox();
            this.buttonClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAddCountry
            // 
            this.buttonAddCountry.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonAddCountry.Image = global::TravelAgency.Properties.Resources.location;
            resources.ApplyResources(this.buttonAddCountry, "buttonAddCountry");
            this.buttonAddCountry.Name = "buttonAddCountry";
            this.buttonAddCountry.UseVisualStyleBackColor = false;
            this.buttonAddCountry.Click += new System.EventHandler(this.buttonAddCountry_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TravelAgency.Properties.Resources.location;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // labelWarningCountry
            // 
            resources.ApplyResources(this.labelWarningCountry, "labelWarningCountry");
            this.labelWarningCountry.ForeColor = System.Drawing.Color.DarkRed;
            this.labelWarningCountry.Name = "labelWarningCountry";
            // 
            // labelCountry
            // 
            resources.ApplyResources(this.labelCountry, "labelCountry");
            this.labelCountry.Name = "labelCountry";
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel3.Name = "panel3";
            // 
            // labelWarningCity
            // 
            resources.ApplyResources(this.labelWarningCity, "labelWarningCity");
            this.labelWarningCity.ForeColor = System.Drawing.Color.DarkRed;
            this.labelWarningCity.Name = "labelWarningCity";
            // 
            // labelCity
            // 
            resources.ApplyResources(this.labelCity, "labelCity");
            this.labelCity.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.labelCity.Name = "labelCity";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Name = "panel1";
            // 
            // textBoxCity
            // 
            resources.ApplyResources(this.textBoxCity, "textBoxCity");
            this.textBoxCity.BackColor = System.Drawing.Color.RoyalBlue;
            this.textBoxCity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCity.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBoxCity.Name = "textBoxCity";
            this.textBoxCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxCity_KeyDown);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.label9.Name = "label9";
            // 
            // textBoxCountry
            // 
            resources.ApplyResources(this.textBoxCountry, "textBoxCountry");
            this.textBoxCountry.BackColor = System.Drawing.Color.RoyalBlue;
            this.textBoxCountry.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCountry.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBoxCountry.Name = "textBoxCountry";
            // 
            // buttonClose
            // 
            resources.ApplyResources(this.buttonClose, "buttonClose");
            this.buttonClose.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonClose.Image = global::TravelAgency.Properties.Resources.error;
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // CountryForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.textBoxCountry);
            this.Controls.Add(this.buttonAddCountry);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelWarningCountry);
            this.Controls.Add(this.labelCountry);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.labelWarningCity);
            this.Controls.Add(this.labelCity);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBoxCity);
            this.Controls.Add(this.label9);
            this.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.Name = "CountryForm";
            this.Load += new System.EventHandler(this.CountryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddCountry;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelWarningCountry;
        private System.Windows.Forms.Label labelCountry;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelWarningCity;
        private System.Windows.Forms.Label labelCity;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxCity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxCountry;
        private System.Windows.Forms.Button buttonClose;
    }
}
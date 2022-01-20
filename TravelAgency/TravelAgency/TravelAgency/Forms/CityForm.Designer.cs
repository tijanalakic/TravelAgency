
namespace TravelAgency.Forms
{
    partial class CityForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CityForm));
            this.labelCityForm = new System.Windows.Forms.Label();
            this.labelWarningCity = new System.Windows.Forms.Label();
            this.labelCity = new System.Windows.Forms.Label();
            this.textBoxCity = new System.Windows.Forms.TextBox();
            this.labelWarningCountry = new System.Windows.Forms.Label();
            this.labelCountry = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonAddCity = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.comboBoxCountry2 = new System.Windows.Forms.ComboBox();
            this.panelLine = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCityForm
            // 
            resources.ApplyResources(this.labelCityForm, "labelCityForm");
            this.labelCityForm.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.labelCityForm.Name = "labelCityForm";
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
            // textBoxCity
            // 
            this.textBoxCity.BackColor = System.Drawing.Color.RoyalBlue;
            this.textBoxCity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.textBoxCity, "textBoxCity");
            this.textBoxCity.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBoxCity.Name = "textBoxCity";
            this.textBoxCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxCity_KeyDown);
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
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TravelAgency.Properties.Resources.location;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // buttonAddCity
            // 
            this.buttonAddCity.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonAddCity.Image = global::TravelAgency.Properties.Resources.location;
            resources.ApplyResources(this.buttonAddCity, "buttonAddCity");
            this.buttonAddCity.Name = "buttonAddCity";
            this.buttonAddCity.UseVisualStyleBackColor = false;
            this.buttonAddCity.Click += new System.EventHandler(this.buttonAddCity_Click);
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
            // comboBoxCountry2
            // 
            this.comboBoxCountry2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCountry2.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxCountry2, "comboBoxCountry2");
            this.comboBoxCountry2.Name = "comboBoxCountry2";
            // 
            // panelLine
            // 
            this.panelLine.BackColor = System.Drawing.SystemColors.InactiveCaption;
            resources.ApplyResources(this.panelLine, "panelLine");
            this.panelLine.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.panelLine.Name = "panelLine";
            // 
            // CityForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonAddCity);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelWarningCountry);
            this.Controls.Add(this.comboBoxCountry2);
            this.Controls.Add(this.labelCountry);
            this.Controls.Add(this.labelWarningCity);
            this.Controls.Add(this.labelCity);
            this.Controls.Add(this.panelLine);
            this.Controls.Add(this.textBoxCity);
            this.Controls.Add(this.labelCityForm);
            this.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.Name = "CityForm";
            this.Load += new System.EventHandler(this.CityForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCityForm;
        private System.Windows.Forms.Label labelWarningCity;
        private System.Windows.Forms.Label labelCity;
        private System.Windows.Forms.TextBox textBoxCity;
        private System.Windows.Forms.Label labelWarningCountry;
        private System.Windows.Forms.Label labelCountry;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonAddCity;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.ComboBox comboBoxCountry2;
        private System.Windows.Forms.Panel panelLine;
    }
}
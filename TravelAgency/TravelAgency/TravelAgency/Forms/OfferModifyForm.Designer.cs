
namespace TravelAgency.Forms
{
    partial class OfferModifyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OfferModifyForm));
            this.label4 = new System.Windows.Forms.Label();
            this.buttonModifyOffer = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.buttonAddCity = new System.Windows.Forms.Button();
            this.buttonAddCountry = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.labelWarningTransport = new System.Windows.Forms.Label();
            this.labelWarningTitle = new System.Windows.Forms.Label();
            this.labelWarningPrice = new System.Windows.Forms.Label();
            this.labelWarningMaxPassenger = new System.Windows.Forms.Label();
            this.labelWarningArrival = new System.Windows.Forms.Label();
            this.labelWarningCity = new System.Windows.Forms.Label();
            this.labelWarningCountry = new System.Windows.Forms.Label();
            this.comboBoxCity = new System.Windows.Forms.ComboBox();
            this.comboBoxCountry = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePickerArrival = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dateTimePickerDeparture = new System.Windows.Forms.DateTimePicker();
            this.groupBoxTransportation = new System.Windows.Forms.GroupBox();
            this.radioButtonAvion = new System.Windows.Forms.RadioButton();
            this.radioButtonBus = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.textBoxMaxPassangers = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxTransportation.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // buttonModifyOffer
            // 
            this.buttonModifyOffer.BackColor = System.Drawing.Color.MidnightBlue;
            resources.ApplyResources(this.buttonModifyOffer, "buttonModifyOffer");
            this.buttonModifyOffer.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.buttonModifyOffer.Image = global::TravelAgency.Properties.Resources.edit;
            this.buttonModifyOffer.Name = "buttonModifyOffer";
            this.buttonModifyOffer.UseVisualStyleBackColor = false;
            this.buttonModifyOffer.Click += new System.EventHandler(this.buttonModifyOffer_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // panel9
            // 
            resources.ApplyResources(this.panel9, "panel9");
            this.panel9.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel9.Name = "panel9";
            // 
            // buttonAddCity
            // 
            resources.ApplyResources(this.buttonAddCity, "buttonAddCity");
            this.buttonAddCity.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonAddCity.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.buttonAddCity.Name = "buttonAddCity";
            this.buttonAddCity.UseVisualStyleBackColor = false;
            this.buttonAddCity.Click += new System.EventHandler(this.buttonAddCity_Click);
            // 
            // buttonAddCountry
            // 
            resources.ApplyResources(this.buttonAddCountry, "buttonAddCountry");
            this.buttonAddCountry.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonAddCountry.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.buttonAddCountry.Name = "buttonAddCountry";
            this.toolTip1.SetToolTip(this.buttonAddCountry, resources.GetString("buttonAddCountry.ToolTip"));
            this.buttonAddCountry.UseVisualStyleBackColor = false;
            this.buttonAddCountry.Click += new System.EventHandler(this.buttonAddCountry_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TravelAgency.Properties.Resources.edit;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // labelWarningTransport
            // 
            resources.ApplyResources(this.labelWarningTransport, "labelWarningTransport");
            this.labelWarningTransport.ForeColor = System.Drawing.Color.DarkRed;
            this.labelWarningTransport.Name = "labelWarningTransport";
            // 
            // labelWarningTitle
            // 
            resources.ApplyResources(this.labelWarningTitle, "labelWarningTitle");
            this.labelWarningTitle.ForeColor = System.Drawing.Color.DarkRed;
            this.labelWarningTitle.Name = "labelWarningTitle";
            this.labelWarningTitle.Click += new System.EventHandler(this.labelWarningTitle_Click);
            // 
            // labelWarningPrice
            // 
            resources.ApplyResources(this.labelWarningPrice, "labelWarningPrice");
            this.labelWarningPrice.ForeColor = System.Drawing.Color.DarkRed;
            this.labelWarningPrice.Name = "labelWarningPrice";
            // 
            // labelWarningMaxPassenger
            // 
            resources.ApplyResources(this.labelWarningMaxPassenger, "labelWarningMaxPassenger");
            this.labelWarningMaxPassenger.ForeColor = System.Drawing.Color.DarkRed;
            this.labelWarningMaxPassenger.Name = "labelWarningMaxPassenger";
            // 
            // labelWarningArrival
            // 
            resources.ApplyResources(this.labelWarningArrival, "labelWarningArrival");
            this.labelWarningArrival.ForeColor = System.Drawing.Color.DarkRed;
            this.labelWarningArrival.Name = "labelWarningArrival";
            // 
            // labelWarningCity
            // 
            resources.ApplyResources(this.labelWarningCity, "labelWarningCity");
            this.labelWarningCity.ForeColor = System.Drawing.Color.DarkRed;
            this.labelWarningCity.Name = "labelWarningCity";
            // 
            // labelWarningCountry
            // 
            resources.ApplyResources(this.labelWarningCountry, "labelWarningCountry");
            this.labelWarningCountry.ForeColor = System.Drawing.Color.DarkRed;
            this.labelWarningCountry.Name = "labelWarningCountry";
            // 
            // comboBoxCity
            // 
            resources.ApplyResources(this.comboBoxCity, "comboBoxCity");
            this.comboBoxCity.FormattingEnabled = true;
            this.comboBoxCity.Name = "comboBoxCity";
            // 
            // comboBoxCountry
            // 
            resources.ApplyResources(this.comboBoxCountry, "comboBoxCountry");
            this.comboBoxCountry.FormattingEnabled = true;
            this.comboBoxCountry.Name = "comboBoxCountry";
            this.comboBoxCountry.SelectedIndexChanged += new System.EventHandler(this.comboBoxCountry_SelectedIndexChanged_1);
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // dateTimePickerArrival
            // 
            resources.ApplyResources(this.dateTimePickerArrival, "dateTimePickerArrival");
            this.dateTimePickerArrival.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerArrival.Name = "dateTimePickerArrival";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // dateTimePickerDeparture
            // 
            resources.ApplyResources(this.dateTimePickerDeparture, "dateTimePickerDeparture");
            this.dateTimePickerDeparture.CalendarForeColor = System.Drawing.Color.MidnightBlue;
            this.dateTimePickerDeparture.CalendarTitleForeColor = System.Drawing.Color.MidnightBlue;
            this.dateTimePickerDeparture.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerDeparture.Name = "dateTimePickerDeparture";
            // 
            // groupBoxTransportation
            // 
            resources.ApplyResources(this.groupBoxTransportation, "groupBoxTransportation");
            this.groupBoxTransportation.Controls.Add(this.radioButtonAvion);
            this.groupBoxTransportation.Controls.Add(this.radioButtonBus);
            this.groupBoxTransportation.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.groupBoxTransportation.Name = "groupBoxTransportation";
            this.groupBoxTransportation.TabStop = false;
            // 
            // radioButtonAvion
            // 
            resources.ApplyResources(this.radioButtonAvion, "radioButtonAvion");
            this.radioButtonAvion.Name = "radioButtonAvion";
            this.radioButtonAvion.TabStop = true;
            this.radioButtonAvion.UseVisualStyleBackColor = true;
            // 
            // radioButtonBus
            // 
            resources.ApplyResources(this.radioButtonBus, "radioButtonBus");
            this.radioButtonBus.Name = "radioButtonBus";
            this.radioButtonBus.TabStop = true;
            this.radioButtonBus.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Name = "panel1";
            // 
            // textBoxDescription
            // 
            resources.ApplyResources(this.textBoxDescription, "textBoxDescription");
            this.textBoxDescription.BackColor = System.Drawing.Color.White;
            this.textBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDescription.ForeColor = System.Drawing.Color.MidnightBlue;
            this.textBoxDescription.Name = "textBoxDescription";
            // 
            // panel5
            // 
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel5.Name = "panel5";
            // 
            // panel6
            // 
            resources.ApplyResources(this.panel6, "panel6");
            this.panel6.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel6.Name = "panel6";
            // 
            // panel7
            // 
            resources.ApplyResources(this.panel7, "panel7");
            this.panel7.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel7.Name = "panel7";
            // 
            // textBoxPrice
            // 
            resources.ApplyResources(this.textBoxPrice, "textBoxPrice");
            this.textBoxPrice.BackColor = System.Drawing.Color.RoyalBlue;
            this.textBoxPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPrice.ForeColor = System.Drawing.Color.MidnightBlue;
            this.textBoxPrice.Name = "textBoxPrice";
            // 
            // panel8
            // 
            resources.ApplyResources(this.panel8, "panel8");
            this.panel8.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel8.Name = "panel8";
            // 
            // textBoxMaxPassangers
            // 
            resources.ApplyResources(this.textBoxMaxPassangers, "textBoxMaxPassangers");
            this.textBoxMaxPassangers.BackColor = System.Drawing.Color.RoyalBlue;
            this.textBoxMaxPassangers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxMaxPassangers.ForeColor = System.Drawing.Color.MidnightBlue;
            this.textBoxMaxPassangers.Name = "textBoxMaxPassangers";
            // 
            // panel4
            // 
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel4.Name = "panel4";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.Name = "panel2";
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel3.Name = "panel3";
            // 
            // textBoxTitle
            // 
            resources.ApplyResources(this.textBoxTitle, "textBoxTitle");
            this.textBoxTitle.BackColor = System.Drawing.Color.RoyalBlue;
            this.textBoxTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTitle.ForeColor = System.Drawing.Color.MidnightBlue;
            this.textBoxTitle.Name = "textBoxTitle";
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
            // OfferModifyForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelWarningTransport);
            this.Controls.Add(this.labelWarningTitle);
            this.Controls.Add(this.labelWarningPrice);
            this.Controls.Add(this.labelWarningMaxPassenger);
            this.Controls.Add(this.labelWarningArrival);
            this.Controls.Add(this.labelWarningCity);
            this.Controls.Add(this.labelWarningCountry);
            this.Controls.Add(this.comboBoxCity);
            this.Controls.Add(this.comboBoxCountry);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePickerArrival);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dateTimePickerDeparture);
            this.Controls.Add(this.groupBoxTransportation);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.textBoxMaxPassangers);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonAddCity);
            this.Controls.Add(this.buttonAddCountry);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonModifyOffer);
            this.Controls.Add(this.label4);
            this.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.Name = "OfferModifyForm";
            this.Load += new System.EventHandler(this.OfferModifyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxTransportation.ResumeLayout(false);
            this.groupBoxTransportation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonModifyOffer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button buttonAddCity;
        private System.Windows.Forms.Button buttonAddCountry;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.Label labelWarningTransport;
        private System.Windows.Forms.Label labelWarningTitle;
        private System.Windows.Forms.Label labelWarningPrice;
        private System.Windows.Forms.Label labelWarningMaxPassenger;
        private System.Windows.Forms.Label labelWarningArrival;
        private System.Windows.Forms.Label labelWarningCity;
        private System.Windows.Forms.Label labelWarningCountry;
        private System.Windows.Forms.ComboBox comboBoxCity;
        private System.Windows.Forms.ComboBox comboBoxCountry;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickerArrival;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateTimePickerDeparture;
        private System.Windows.Forms.GroupBox groupBoxTransportation;
        private System.Windows.Forms.RadioButton radioButtonAvion;
        private System.Windows.Forms.RadioButton radioButtonBus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox textBoxMaxPassangers;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Button buttonClose;
    }
}
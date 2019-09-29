namespace SouthernBug.App.Window.Calculations
{
    partial class CalculationExtraArgsForm
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.KdComboBox = new System.Windows.Forms.ComboBox();
            this.groupBoxKD = new System.Windows.Forms.GroupBox();
            this.groupBoxKDD = new System.Windows.Forms.GroupBox();
            this.KddComboBox = new System.Windows.Forms.ComboBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.D2VariantComboBox = new System.Windows.Forms.ComboBox();
            this.groupBoxKD.SuspendLayout();
            this.groupBoxKDD.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTitle.Location = new System.Drawing.Point(12, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(467, 44);
            this.labelTitle.TabIndex = 22;
            this.labelTitle.Text = "labelTitle\r\nlabelTitle";
            // 
            // KdComboBox
            // 
            this.KdComboBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KdComboBox.FormattingEnabled = true;
            this.KdComboBox.Location = new System.Drawing.Point(16, 42);
            this.KdComboBox.Name = "KdComboBox";
            this.KdComboBox.Size = new System.Drawing.Size(483, 25);
            this.KdComboBox.TabIndex = 7;
            // 
            // groupBoxKD
            // 
            this.groupBoxKD.Controls.Add(this.KdComboBox);
            this.groupBoxKD.Location = new System.Drawing.Point(48, 134);
            this.groupBoxKD.Name = "groupBoxKD";
            this.groupBoxKD.Size = new System.Drawing.Size(526, 84);
            this.groupBoxKD.TabIndex = 17;
            this.groupBoxKD.TabStop = false;
            this.groupBoxKD.Text = "groupBoxKD";
            // 
            // groupBoxKDD
            // 
            this.groupBoxKDD.Controls.Add(this.KddComboBox);
            this.groupBoxKDD.Location = new System.Drawing.Point(48, 237);
            this.groupBoxKDD.Name = "groupBoxKDD";
            this.groupBoxKDD.Size = new System.Drawing.Size(526, 84);
            this.groupBoxKDD.TabIndex = 18;
            this.groupBoxKDD.TabStop = false;
            this.groupBoxKDD.Text = "groupBoxKDD";
            // 
            // KddComboBox
            // 
            this.KddComboBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KddComboBox.FormattingEnabled = true;
            this.KddComboBox.Location = new System.Drawing.Point(16, 42);
            this.KddComboBox.Name = "KddComboBox";
            this.KddComboBox.Size = new System.Drawing.Size(483, 25);
            this.KddComboBox.TabIndex = 7;
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(453, 3);
            this.OkButton.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(121, 33);
            this.OkButton.TabIndex = 23;
            this.OkButton.Text = "Підтвердити";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(327, 3);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(103, 33);
            this.CancelButton.TabIndex = 23;
            this.CancelButton.Text = "Скасувати";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.OkButton);
            this.flowLayoutPanel1.Controls.Add(this.CancelButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 343);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(594, 48);
            this.flowLayoutPanel1.TabIndex = 24;
            // 
            // D2VariantComboBox
            // 
            this.D2VariantComboBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.D2VariantComboBox.FormattingEnabled = true;
            this.D2VariantComboBox.Location = new System.Drawing.Point(64, 77);
            this.D2VariantComboBox.Name = "D2VariantComboBox";
            this.D2VariantComboBox.Size = new System.Drawing.Size(483, 25);
            this.D2VariantComboBox.TabIndex = 7;
            // 
            // CalculationExtraArgsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 391);
            this.Controls.Add(this.D2VariantComboBox);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.groupBoxKDD);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.groupBoxKD);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "CalculationExtraArgsForm";
            this.Text = "Дополнительные данные";
            this.groupBoxKD.ResumeLayout(false);
            this.groupBoxKDD.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.ComboBox KdComboBox;
        private System.Windows.Forms.GroupBox groupBoxKD;
        private System.Windows.Forms.GroupBox groupBoxKDD;
        private System.Windows.Forms.ComboBox KddComboBox;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ComboBox D2VariantComboBox;
    }
}
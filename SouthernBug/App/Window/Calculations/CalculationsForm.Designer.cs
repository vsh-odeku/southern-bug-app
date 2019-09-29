namespace SouthernBug.App.Window.Calculations
{
    partial class CalculationsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalculationsForm));
            this.YButton = new System.Windows.Forms.Button();
            this.QmButton = new System.Windows.Forms.Button();
            this.D1Button = new System.Windows.Forms.Button();
            this.D2Button = new System.Windows.Forms.Button();
            this.dayAndMonthComboBox = new System.Windows.Forms.ComboBox();
            this.yearComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.QPComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dSComboBox = new System.Windows.Forms.ComboBox();
            this.allowedRangeComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.X1ComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.X2ComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // YButton
            // 
            this.YButton.Location = new System.Drawing.Point(631, 55);
            this.YButton.Name = "YButton";
            this.YButton.Size = new System.Drawing.Size(137, 33);
            this.YButton.TabIndex = 3;
            this.YButton.Text = "Шарів стоку Y";
            this.YButton.UseVisualStyleBackColor = true;
            // 
            // QmButton
            // 
            this.QmButton.Location = new System.Drawing.Point(809, 55);
            this.QmButton.Name = "QmButton";
            this.QmButton.Size = new System.Drawing.Size(251, 33);
            this.QmButton.TabIndex = 4;
            this.QmButton.Text = "Максимальних витрат води Qm";
            this.QmButton.UseVisualStyleBackColor = true;
            // 
            // D1Button
            // 
            this.D1Button.Location = new System.Drawing.Point(631, 105);
            this.D1Button.Name = "D1Button";
            this.D1Button.Size = new System.Drawing.Size(429, 33);
            this.D1Button.TabIndex = 5;
            this.D1Button.Text = "Прогноз дат початку весняного водопілля D1";
            this.D1Button.UseVisualStyleBackColor = true;
            // 
            // D2Button
            // 
            this.D2Button.Location = new System.Drawing.Point(631, 154);
            this.D2Button.Name = "D2Button";
            this.D2Button.Size = new System.Drawing.Size(429, 33);
            this.D2Button.TabIndex = 6;
            this.D2Button.Text = "Прогноз дат максимальних витрат (рівнів) води D2";
            this.D2Button.UseVisualStyleBackColor = true;
            // 
            // dayAndMonthComboBox
            // 
            this.dayAndMonthComboBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dayAndMonthComboBox.FormattingEnabled = true;
            this.dayAndMonthComboBox.Location = new System.Drawing.Point(16, 25);
            this.dayAndMonthComboBox.Name = "dayAndMonthComboBox";
            this.dayAndMonthComboBox.Size = new System.Drawing.Size(407, 25);
            this.dayAndMonthComboBox.TabIndex = 7;
            // 
            // yearComboBox
            // 
            this.yearComboBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.yearComboBox.FormattingEnabled = true;
            this.yearComboBox.Location = new System.Drawing.Point(429, 25);
            this.yearComboBox.Name = "yearComboBox";
            this.yearComboBox.Size = new System.Drawing.Size(71, 25);
            this.yearComboBox.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dayAndMonthComboBox);
            this.groupBox1.Controls.Add(this.yearComboBox);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(35, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(523, 68);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Дата складання прогнозу";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.QPComboBox);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(35, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(523, 68);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Вибір показника вологості ґрунту";
            // 
            // QPComboBox
            // 
            this.QPComboBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.QPComboBox.FormattingEnabled = true;
            this.QPComboBox.Location = new System.Drawing.Point(16, 25);
            this.QPComboBox.Name = "QPComboBox";
            this.QPComboBox.Size = new System.Drawing.Size(483, 25);
            this.QPComboBox.TabIndex = 7;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dSComboBox);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(35, 239);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(523, 68);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Визначення середньої добавки снігу до максимальних снігозапасів dS";
            // 
            // dSComboBox
            // 
            this.dSComboBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dSComboBox.FormattingEnabled = true;
            this.dSComboBox.Location = new System.Drawing.Point(16, 25);
            this.dSComboBox.Name = "dSComboBox";
            this.dSComboBox.Size = new System.Drawing.Size(489, 25);
            this.dSComboBox.TabIndex = 7;
            // 
            // allowedRangeComboBox
            // 
            this.allowedRangeComboBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.allowedRangeComboBox.FormattingEnabled = true;
            this.allowedRangeComboBox.Location = new System.Drawing.Point(16, 25);
            this.allowedRangeComboBox.Name = "allowedRangeComboBox";
            this.allowedRangeComboBox.Size = new System.Drawing.Size(490, 25);
            this.allowedRangeComboBox.TabIndex = 7;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.allowedRangeComboBox);
            this.groupBox4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(35, 432);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(523, 68);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Коефіцієнт допустимого діапазону прогнозної величини";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.X1ComboBox);
            this.groupBox5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox5.Location = new System.Drawing.Point(35, 327);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(244, 87);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Дощові опади періоду танення снігу Х1";
            // 
            // X1ComboBox
            // 
            this.X1ComboBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.X1ComboBox.FormattingEnabled = true;
            this.X1ComboBox.Location = new System.Drawing.Point(16, 44);
            this.X1ComboBox.Name = "X1ComboBox";
            this.X1ComboBox.Size = new System.Drawing.Size(210, 25);
            this.X1ComboBox.TabIndex = 7;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.X2ComboBox);
            this.groupBox6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox6.Location = new System.Drawing.Point(307, 327);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(251, 87);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Дощові опади періоду спаду водопілля Х2";
            // 
            // X2ComboBox
            // 
            this.X2ComboBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.X2ComboBox.FormattingEnabled = true;
            this.X2ComboBox.Location = new System.Drawing.Point(15, 44);
            this.X2ComboBox.Name = "X2ComboBox";
            this.X2ComboBox.Size = new System.Drawing.Size(218, 25);
            this.X2ComboBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 22);
            this.label1.TabIndex = 15;
            this.label1.Text = "Вихідні дані";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(595, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 22);
            this.label2.TabIndex = 16;
            this.label2.Text = "Прогноз";
            // 
            // CalculationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 538);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.D2Button);
            this.Controls.Add(this.D1Button);
            this.Controls.Add(this.QmButton);
            this.Controls.Add(this.YButton);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "CalculationsForm";
            this.Text = "Прогноз";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button YButton;
        private System.Windows.Forms.Button QmButton;
        private System.Windows.Forms.Button D1Button;
        private System.Windows.Forms.Button D2Button;
        private System.Windows.Forms.ComboBox dayAndMonthComboBox;
        private System.Windows.Forms.ComboBox yearComboBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox QPComboBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox dSComboBox;
        private System.Windows.Forms.ComboBox allowedRangeComboBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox X1ComboBox;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox X2ComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
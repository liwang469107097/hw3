namespace Ksu.Cis300.ConnectFour
{
    partial class SetupDialog
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
            this.uxLevel = new System.Windows.Forms.NumericUpDown();
            this.uxLevelLabel = new System.Windows.Forms.Label();
            this.uxComputerFirst = new System.Windows.Forms.RadioButton();
            this.uxHumanFirst = new System.Windows.Forms.RadioButton();
            this.uxOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.uxLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // uxLevel
            // 
            this.uxLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxLevel.Location = new System.Drawing.Point(95, 12);
            this.uxLevel.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.uxLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uxLevel.Name = "uxLevel";
            this.uxLevel.Size = new System.Drawing.Size(175, 34);
            this.uxLevel.TabIndex = 0;
            this.uxLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uxLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // uxLevelLabel
            // 
            this.uxLevelLabel.AutoSize = true;
            this.uxLevelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxLevelLabel.Location = new System.Drawing.Point(12, 17);
            this.uxLevelLabel.Name = "uxLevelLabel";
            this.uxLevelLabel.Size = new System.Drawing.Size(77, 29);
            this.uxLevelLabel.TabIndex = 1;
            this.uxLevelLabel.Text = "Level:";
            // 
            // uxComputerFirst
            // 
            this.uxComputerFirst.AutoSize = true;
            this.uxComputerFirst.Checked = true;
            this.uxComputerFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxComputerFirst.Location = new System.Drawing.Point(17, 52);
            this.uxComputerFirst.Name = "uxComputerFirst";
            this.uxComputerFirst.Size = new System.Drawing.Size(246, 33);
            this.uxComputerFirst.TabIndex = 2;
            this.uxComputerFirst.TabStop = true;
            this.uxComputerFirst.Text = "Computer plays first";
            this.uxComputerFirst.UseVisualStyleBackColor = true;
            // 
            // uxHumanFirst
            // 
            this.uxHumanFirst.AutoSize = true;
            this.uxHumanFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxHumanFirst.Location = new System.Drawing.Point(17, 91);
            this.uxHumanFirst.Name = "uxHumanFirst";
            this.uxHumanFirst.Size = new System.Drawing.Size(216, 33);
            this.uxHumanFirst.TabIndex = 3;
            this.uxHumanFirst.Text = "Human plays first";
            this.uxHumanFirst.UseVisualStyleBackColor = true;
            // 
            // uxOk
            // 
            this.uxOk.AutoSize = true;
            this.uxOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.uxOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxOk.Location = new System.Drawing.Point(17, 130);
            this.uxOk.Name = "uxOk";
            this.uxOk.Size = new System.Drawing.Size(246, 49);
            this.uxOk.TabIndex = 4;
            this.uxOk.Text = "OK";
            this.uxOk.UseVisualStyleBackColor = true;
            // 
            // SetupDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 197);
            this.Controls.Add(this.uxOk);
            this.Controls.Add(this.uxHumanFirst);
            this.Controls.Add(this.uxComputerFirst);
            this.Controls.Add(this.uxLevelLabel);
            this.Controls.Add(this.uxLevel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SetupDialog";
            this.Text = "SetupDialog";
            this.Load += new System.EventHandler(this.SetupDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uxLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown uxLevel;
        private System.Windows.Forms.Label uxLevelLabel;
        private System.Windows.Forms.RadioButton uxComputerFirst;
        private System.Windows.Forms.RadioButton uxHumanFirst;
        private System.Windows.Forms.Button uxOk;
    }
}
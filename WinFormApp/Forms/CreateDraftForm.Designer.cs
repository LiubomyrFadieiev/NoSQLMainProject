
namespace WinFormApp.Forms
{
    partial class CreateDraftForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.draftTextBox = new System.Windows.Forms.RichTextBox();
            this.setTime = new System.Windows.Forms.RadioButton();
            this.submitButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.minuteNumeric = new System.Windows.Forms.NumericUpDown();
            this.secondsNumeric = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.minuteNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondsNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(302, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seconds";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Minutes";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(151, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Your Post";
            // 
            // draftTextBox
            // 
            this.draftTextBox.Location = new System.Drawing.Point(12, 36);
            this.draftTextBox.Name = "draftTextBox";
            this.draftTextBox.Size = new System.Drawing.Size(369, 200);
            this.draftTextBox.TabIndex = 3;
            this.draftTextBox.Text = "";
            this.draftTextBox.TextChanged += new System.EventHandler(this.draftTextBox_TextChanged);
            // 
            // setTime
            // 
            this.setTime.AutoSize = true;
            this.setTime.Location = new System.Drawing.Point(12, 280);
            this.setTime.Name = "setTime";
            this.setTime.Size = new System.Drawing.Size(188, 29);
            this.setTime.TabIndex = 4;
            this.setTime.TabStop = true;
            this.setTime.Text = "Set Expiration Time";
            this.setTime.UseVisualStyleBackColor = true;
            this.setTime.CheckedChanged += new System.EventHandler(this.setTime_CheckedChanged);
            // 
            // submitButton
            // 
            this.submitButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.submitButton.Location = new System.Drawing.Point(12, 404);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(112, 34);
            this.submitButton.TabIndex = 5;
            this.submitButton.Text = "Create";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(269, 404);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(112, 34);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // minuteNumeric
            // 
            this.minuteNumeric.Enabled = false;
            this.minuteNumeric.Location = new System.Drawing.Point(221, 280);
            this.minuteNumeric.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.minuteNumeric.Name = "minuteNumeric";
            this.minuteNumeric.Size = new System.Drawing.Size(75, 31);
            this.minuteNumeric.TabIndex = 7;
            this.minuteNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.minuteNumeric.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // secondsNumeric
            // 
            this.secondsNumeric.Enabled = false;
            this.secondsNumeric.Location = new System.Drawing.Point(302, 280);
            this.secondsNumeric.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.secondsNumeric.Name = "secondsNumeric";
            this.secondsNumeric.Size = new System.Drawing.Size(79, 31);
            this.secondsNumeric.TabIndex = 8;
            // 
            // CreateDraftForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 450);
            this.Controls.Add(this.secondsNumeric);
            this.Controls.Add(this.minuteNumeric);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.setTime);
            this.Controls.Add(this.draftTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CreateDraftForm";
            this.Text = "CreateDraftForm";
            ((System.ComponentModel.ISupportInitialize)(this.minuteNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondsNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox draftTextBox;
        private System.Windows.Forms.RadioButton setTime;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.NumericUpDown minuteNumeric;
        private System.Windows.Forms.NumericUpDown secondsNumeric;
    }
}

namespace WinFormApp.Forms
{
    partial class LogInForm
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
            this.logText = new System.Windows.Forms.TextBox();
            this.passText = new System.Windows.Forms.TextBox();
            this.loginLabel = new System.Windows.Forms.Label();
            this.passLabel = new System.Windows.Forms.Label();
            this.logButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // logText
            // 
            this.logText.Location = new System.Drawing.Point(94, 115);
            this.logText.Name = "logText";
            this.logText.Size = new System.Drawing.Size(152, 26);
            this.logText.TabIndex = 0;
            this.logText.Text = "jojo";
            // 
            // passText
            // 
            this.passText.Location = new System.Drawing.Point(94, 183);
            this.passText.Name = "passText";
            this.passText.Size = new System.Drawing.Size(152, 26);
            this.passText.TabIndex = 1;
            this.passText.Text = "j0j0_TheFirst";
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Location = new System.Drawing.Point(90, 92);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(143, 20);
            this.loginLabel.TabIndex = 2;
            this.loginLabel.Text = "Nickname or e-mail";
            // 
            // passLabel
            // 
            this.passLabel.AutoSize = true;
            this.passLabel.Location = new System.Drawing.Point(90, 160);
            this.passLabel.Name = "passLabel";
            this.passLabel.Size = new System.Drawing.Size(78, 20);
            this.passLabel.TabIndex = 3;
            this.passLabel.Text = "Password";
            // 
            // logButton
            // 
            this.logButton.Location = new System.Drawing.Point(94, 243);
            this.logButton.Name = "logButton";
            this.logButton.Size = new System.Drawing.Size(152, 74);
            this.logButton.TabIndex = 4;
            this.logButton.Text = "Sign In";
            this.logButton.UseVisualStyleBackColor = true;
            this.logButton.Click += new System.EventHandler(this.logButton_Click);
            // 
            // LogInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 450);
            this.Controls.Add(this.logButton);
            this.Controls.Add(this.passLabel);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.passText);
            this.Controls.Add(this.logText);
            this.Name = "LogInForm";
            this.Text = "LogInForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox logText;
        private System.Windows.Forms.TextBox passText;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Label passLabel;
        private System.Windows.Forms.Button logButton;
    }
}

namespace WinFormApp.Forms
{
    partial class DraftForm
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
            this.draft0Text = new System.Windows.Forms.RichTextBox();
            this.draft1Text = new System.Windows.Forms.RichTextBox();
            this.draft2Text = new System.Windows.Forms.RichTextBox();
            this.downButton = new System.Windows.Forms.Button();
            this.upButton = new System.Windows.Forms.Button();
            this.send0Button = new System.Windows.Forms.Button();
            this.delete0Button = new System.Windows.Forms.Button();
            this.delete1Button = new System.Windows.Forms.Button();
            this.send1Button = new System.Windows.Forms.Button();
            this.delete2Button = new System.Windows.Forms.Button();
            this.send2Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // draft0Text
            // 
            this.draft0Text.Location = new System.Drawing.Point(203, 12);
            this.draft0Text.Name = "draft0Text";
            this.draft0Text.Size = new System.Drawing.Size(315, 130);
            this.draft0Text.TabIndex = 0;
            this.draft0Text.Text = "";
            this.draft0Text.TextChanged += new System.EventHandler(this.draft0Text_TextChanged);
            // 
            // draft1Text
            // 
            this.draft1Text.Location = new System.Drawing.Point(203, 148);
            this.draft1Text.Name = "draft1Text";
            this.draft1Text.Size = new System.Drawing.Size(315, 144);
            this.draft1Text.TabIndex = 1;
            this.draft1Text.Text = "";
            this.draft1Text.TextChanged += new System.EventHandler(this.draft1Text_TextChanged);
            // 
            // draft2Text
            // 
            this.draft2Text.Location = new System.Drawing.Point(203, 289);
            this.draft2Text.Name = "draft2Text";
            this.draft2Text.Size = new System.Drawing.Size(315, 149);
            this.draft2Text.TabIndex = 2;
            this.draft2Text.Text = "";
            this.draft2Text.TextChanged += new System.EventHandler(this.draft2Text_TextChanged);
            // 
            // downButton
            // 
            this.downButton.Location = new System.Drawing.Point(676, 362);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(112, 34);
            this.downButton.TabIndex = 3;
            this.downButton.Text = "Down";
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // upButton
            // 
            this.upButton.Location = new System.Drawing.Point(676, 322);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(112, 34);
            this.upButton.TabIndex = 4;
            this.upButton.Text = "Up";
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // send0Button
            // 
            this.send0Button.Location = new System.Drawing.Point(85, 35);
            this.send0Button.Name = "send0Button";
            this.send0Button.Size = new System.Drawing.Size(112, 34);
            this.send0Button.TabIndex = 5;
            this.send0Button.Text = "Send";
            this.send0Button.UseVisualStyleBackColor = true;
            this.send0Button.Click += new System.EventHandler(this.send0Button_Click);
            // 
            // delete0Button
            // 
            this.delete0Button.Location = new System.Drawing.Point(85, 90);
            this.delete0Button.Name = "delete0Button";
            this.delete0Button.Size = new System.Drawing.Size(112, 34);
            this.delete0Button.TabIndex = 6;
            this.delete0Button.Text = "Delete";
            this.delete0Button.UseVisualStyleBackColor = true;
            this.delete0Button.Click += new System.EventHandler(this.delete0Button_Click);
            // 
            // delete1Button
            // 
            this.delete1Button.Location = new System.Drawing.Point(85, 225);
            this.delete1Button.Name = "delete1Button";
            this.delete1Button.Size = new System.Drawing.Size(112, 34);
            this.delete1Button.TabIndex = 8;
            this.delete1Button.Text = "Delete";
            this.delete1Button.UseVisualStyleBackColor = true;
            this.delete1Button.Click += new System.EventHandler(this.delete1Button_Click);
            // 
            // send1Button
            // 
            this.send1Button.Location = new System.Drawing.Point(85, 169);
            this.send1Button.Name = "send1Button";
            this.send1Button.Size = new System.Drawing.Size(112, 34);
            this.send1Button.TabIndex = 7;
            this.send1Button.Text = "Send";
            this.send1Button.UseVisualStyleBackColor = true;
            this.send1Button.Click += new System.EventHandler(this.button2_Click);
            // 
            // delete2Button
            // 
            this.delete2Button.Location = new System.Drawing.Point(85, 362);
            this.delete2Button.Name = "delete2Button";
            this.delete2Button.Size = new System.Drawing.Size(112, 34);
            this.delete2Button.TabIndex = 10;
            this.delete2Button.Text = "Delete";
            this.delete2Button.UseVisualStyleBackColor = true;
            this.delete2Button.Click += new System.EventHandler(this.delete2Button_Click);
            // 
            // send2Button
            // 
            this.send2Button.Location = new System.Drawing.Point(85, 307);
            this.send2Button.Name = "send2Button";
            this.send2Button.Size = new System.Drawing.Size(112, 34);
            this.send2Button.TabIndex = 9;
            this.send2Button.Text = "Send";
            this.send2Button.UseVisualStyleBackColor = true;
            this.send2Button.Click += new System.EventHandler(this.button4_Click);
            // 
            // DraftForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.delete2Button);
            this.Controls.Add(this.send2Button);
            this.Controls.Add(this.delete1Button);
            this.Controls.Add(this.send1Button);
            this.Controls.Add(this.delete0Button);
            this.Controls.Add(this.send0Button);
            this.Controls.Add(this.upButton);
            this.Controls.Add(this.downButton);
            this.Controls.Add(this.draft2Text);
            this.Controls.Add(this.draft1Text);
            this.Controls.Add(this.draft0Text);
            this.Name = "DraftForm";
            this.Text = "DraftForm";
            this.Load += new System.EventHandler(this.DraftForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox draft0Text;
        private System.Windows.Forms.RichTextBox draft1Text;
        private System.Windows.Forms.RichTextBox draft2Text;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button send0Button;
        private System.Windows.Forms.Button delete0Button;
        private System.Windows.Forms.Button delete1Button;
        private System.Windows.Forms.Button send1Button;
        private System.Windows.Forms.Button delete2Button;
        private System.Windows.Forms.Button send2Button;
    }
}
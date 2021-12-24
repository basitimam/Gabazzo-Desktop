
namespace gabazzoo
{
    partial class MainScreen
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
            this.View = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ContractorButton = new System.Windows.Forms.Button();
            this.UserButton = new System.Windows.Forms.Button();
            this.ViewServices = new System.Windows.Forms.Button();
            this.View.SuspendLayout();
            this.SuspendLayout();
            // 
            // View
            // 
            this.View.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.View.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(187)))), ((int)(((byte)(182)))));
            this.View.Controls.Add(this.label1);
            this.View.Location = new System.Drawing.Point(0, 0);
            this.View.Name = "View";
            this.View.Size = new System.Drawing.Size(833, 109);
            this.View.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MV Boli", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(324, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "View Insights";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ContractorButton
            // 
            this.ContractorButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ContractorButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(187)))), ((int)(((byte)(182)))));
            this.ContractorButton.Font = new System.Drawing.Font("Malgun Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContractorButton.ForeColor = System.Drawing.Color.White;
            this.ContractorButton.Location = new System.Drawing.Point(323, 278);
            this.ContractorButton.Name = "ContractorButton";
            this.ContractorButton.Size = new System.Drawing.Size(209, 45);
            this.ContractorButton.TabIndex = 4;
            this.ContractorButton.Text = "View Contractors";
            this.ContractorButton.UseVisualStyleBackColor = false;
            this.ContractorButton.Click += new System.EventHandler(this.ContractorButton_Click);
            // 
            // UserButton
            // 
            this.UserButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UserButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(187)))), ((int)(((byte)(182)))));
            this.UserButton.Font = new System.Drawing.Font("Malgun Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserButton.ForeColor = System.Drawing.Color.White;
            this.UserButton.Location = new System.Drawing.Point(23, 278);
            this.UserButton.Name = "UserButton";
            this.UserButton.Size = new System.Drawing.Size(209, 45);
            this.UserButton.TabIndex = 5;
            this.UserButton.Text = "View Users";
            this.UserButton.UseVisualStyleBackColor = false;
            this.UserButton.Click += new System.EventHandler(this.UserButton_Click);
            // 
            // ViewServices
            // 
            this.ViewServices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ViewServices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(187)))), ((int)(((byte)(182)))));
            this.ViewServices.Font = new System.Drawing.Font("Malgun Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewServices.ForeColor = System.Drawing.Color.White;
            this.ViewServices.Location = new System.Drawing.Point(601, 278);
            this.ViewServices.Name = "ViewServices";
            this.ViewServices.Size = new System.Drawing.Size(209, 45);
            this.ViewServices.TabIndex = 6;
            this.ViewServices.Text = "View Services";
            this.ViewServices.UseVisualStyleBackColor = false;
            this.ViewServices.Click += new System.EventHandler(this.ViewServices_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(832, 469);
            this.Controls.Add(this.ViewServices);
            this.Controls.Add(this.UserButton);
            this.Controls.Add(this.ContractorButton);
            this.Controls.Add(this.View);
            this.Name = "MainScreen";
            this.Text = "MainScreen";
            this.View.ResumeLayout(false);
            this.View.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel View;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ContractorButton;
        private System.Windows.Forms.Button UserButton;
        private System.Windows.Forms.Button ViewServices;
    }
}
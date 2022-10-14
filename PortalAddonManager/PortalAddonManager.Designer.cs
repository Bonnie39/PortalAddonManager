namespace PortalAddonManager
{
    partial class PortalAddonManager
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PortalAddonManager));
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.AddonListLabel = new System.Windows.Forms.Label();
            this.ExitButton = new Guna.UI2.WinForms.Guna2ImageButton();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.checkedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBox1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkedListBox1.ForeColor = System.Drawing.SystemColors.Info;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(12, 59);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(776, 324);
            this.checkedListBox1.TabIndex = 0;
            this.checkedListBox1.ThreeDCheckBoxes = true;
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.AnimateWindow = true;
            this.guna2BorderlessForm1.BorderRadius = 40;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockForm = false;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.DragStartTransparencyValue = 1D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // AddonListLabel
            // 
            this.AddonListLabel.AutoSize = true;
            this.AddonListLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddonListLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AddonListLabel.Location = new System.Drawing.Point(12, 26);
            this.AddonListLabel.Name = "AddonListLabel";
            this.AddonListLabel.Size = new System.Drawing.Size(92, 30);
            this.AddonListLabel.TabIndex = 1;
            this.AddonListLabel.Text = "Addons:";
            // 
            // ExitButton
            // 
            this.ExitButton.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.ExitButton.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.ExitButton.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.ExitButton.Image = ((System.Drawing.Image)(resources.GetObject("ExitButton.Image")));
            this.ExitButton.ImageOffset = new System.Drawing.Point(0, 0);
            this.ExitButton.ImageRotate = 0F;
            this.ExitButton.Location = new System.Drawing.Point(703, 389);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.PressedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.ExitButton.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.ExitButton.Size = new System.Drawing.Size(64, 54);
            this.ExitButton.TabIndex = 2;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // PortalAddonManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.AddonListLabel);
            this.Controls.Add(this.checkedListBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PortalAddonManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Portal Addon Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckedListBox checkedListBox1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Label AddonListLabel;
        private Guna.UI2.WinForms.Guna2ImageButton ExitButton;
    }
}
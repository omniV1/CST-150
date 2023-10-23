namespace Milestone_Fall2023
{
    partial class frmIntro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIntro));
            pbMrBones = new PictureBox();
            lblWelcomeToFrmIntro = new Label();
            btnContinueToCurrentInventory = new Button();
            btnImportFile = new Button();
            opdImportFile = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)pbMrBones).BeginInit();
            SuspendLayout();
            // 
            // pbMrBones
            // 
            pbMrBones.BackgroundImage = (Image)resources.GetObject("pbMrBones.BackgroundImage");
            pbMrBones.BackgroundImageLayout = ImageLayout.Zoom;
            pbMrBones.BorderStyle = BorderStyle.Fixed3D;
            pbMrBones.Location = new Point(225, 78);
            pbMrBones.Name = "pbMrBones";
            pbMrBones.Size = new Size(237, 258);
            pbMrBones.TabIndex = 0;
            pbMrBones.TabStop = false;
            // 
            // lblWelcomeToFrmIntro
            // 
            lblWelcomeToFrmIntro.AutoSize = true;
            lblWelcomeToFrmIntro.BackColor = Color.Transparent;
            lblWelcomeToFrmIntro.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblWelcomeToFrmIntro.Location = new Point(165, 29);
            lblWelcomeToFrmIntro.Name = "lblWelcomeToFrmIntro";
            lblWelcomeToFrmIntro.Size = new Size(393, 22);
            lblWelcomeToFrmIntro.TabIndex = 1;
            lblWelcomeToFrmIntro.Text = "Welcome to the Inventory management system.";
            // 
            // btnContinueToCurrentInventory
            // 
            btnContinueToCurrentInventory.BackgroundImage = (Image)resources.GetObject("btnContinueToCurrentInventory.BackgroundImage");
            btnContinueToCurrentInventory.BackgroundImageLayout = ImageLayout.Stretch;
            btnContinueToCurrentInventory.Cursor = Cursors.Hand;
            btnContinueToCurrentInventory.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnContinueToCurrentInventory.Location = new Point(515, 197);
            btnContinueToCurrentInventory.Name = "btnContinueToCurrentInventory";
            btnContinueToCurrentInventory.Size = new Size(127, 34);
            btnContinueToCurrentInventory.TabIndex = 2;
            btnContinueToCurrentInventory.Text = "  View inventory";
            btnContinueToCurrentInventory.TextAlign = ContentAlignment.MiddleLeft;
            btnContinueToCurrentInventory.UseVisualStyleBackColor = true;
            btnContinueToCurrentInventory.Click += BtnContinueToFrmCurrentInventory_Click;
            // 
            // btnImportFile
            // 
            btnImportFile.BackgroundImage = (Image)resources.GetObject("btnImportFile.BackgroundImage");
            btnImportFile.BackgroundImageLayout = ImageLayout.Stretch;
            btnImportFile.Cursor = Cursors.Hand;
            btnImportFile.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnImportFile.Location = new Point(515, 111);
            btnImportFile.Name = "btnImportFile";
            btnImportFile.Size = new Size(127, 34);
            btnImportFile.TabIndex = 3;
            btnImportFile.Text = "Import inventory.txt";
            btnImportFile.UseVisualStyleBackColor = true;
            btnImportFile.Click += BtnImportFile_Click;
            // 
            // opdImportFile
            // 
            opdImportFile.FileName = "openFileDialog1";
            // 
            // frmIntro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(726, 379);
            Controls.Add(btnImportFile);
            Controls.Add(btnContinueToCurrentInventory);
            Controls.Add(lblWelcomeToFrmIntro);
            Controls.Add(pbMrBones);
            DoubleBuffered = true;
            Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmIntro";
            Text = "Welcome";
            ((System.ComponentModel.ISupportInitialize)pbMrBones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbMrBones;
        private Label lblWelcomeToFrmIntro;
        private Button btnContinueToCurrentInventory;
        private Button btnImportFile;
        private OpenFileDialog opdImportFile;
    }
}
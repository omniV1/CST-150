namespace Milestone_Fall2023
{
    partial class frmCurrentInventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCurrentInventory));
            lblDisplayInventory = new Label();
            btnSortByIDHighestToLowest = new Button();
            btnSortByHighestCostToLowest = new Button();
            btnSaveInventory = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            pnlScrollInventory = new Panel();
            btnPrevious = new Button();
            btnNext = new Button();
            pbRaptor = new PictureBox();
            cmbSelectItemId = new ComboBox();
            lblSelectId = new Label();
            pnlScrollInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbRaptor).BeginInit();
            SuspendLayout();
            // 
            // lblDisplayInventory
            // 
            lblDisplayInventory.BackColor = Color.PaleGoldenrod;
            lblDisplayInventory.Font = new Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblDisplayInventory.Location = new Point(0, 0);
            lblDisplayInventory.Margin = new Padding(4, 0, 4, 0);
            lblDisplayInventory.Name = "lblDisplayInventory";
            lblDisplayInventory.Size = new Size(546, 294);
            lblDisplayInventory.TabIndex = 0;
            // 
            // btnSortByIDHighestToLowest
            // 
            btnSortByIDHighestToLowest.BackgroundImage = (Image)resources.GetObject("btnSortByIDHighestToLowest.BackgroundImage");
            btnSortByIDHighestToLowest.BackgroundImageLayout = ImageLayout.Stretch;
            btnSortByIDHighestToLowest.Cursor = Cursors.Hand;
            btnSortByIDHighestToLowest.Font = new Font("Calibri", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnSortByIDHighestToLowest.Location = new Point(759, 95);
            btnSortByIDHighestToLowest.Margin = new Padding(4);
            btnSortByIDHighestToLowest.Name = "btnSortByIDHighestToLowest";
            btnSortByIDHighestToLowest.Size = new Size(158, 34);
            btnSortByIDHighestToLowest.TabIndex = 2;
            btnSortByIDHighestToLowest.Text = "sort by ID ";
            btnSortByIDHighestToLowest.UseVisualStyleBackColor = true;
            btnSortByIDHighestToLowest.Click += BtnSortByIDHighestToLowest_OnClick;
            // 
            // btnSortByHighestCostToLowest
            // 
            btnSortByHighestCostToLowest.BackgroundImage = (Image)resources.GetObject("btnSortByHighestCostToLowest.BackgroundImage");
            btnSortByHighestCostToLowest.BackgroundImageLayout = ImageLayout.Stretch;
            btnSortByHighestCostToLowest.Cursor = Cursors.Hand;
            btnSortByHighestCostToLowest.Font = new Font("Calibri", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnSortByHighestCostToLowest.Location = new Point(759, 137);
            btnSortByHighestCostToLowest.Margin = new Padding(4);
            btnSortByHighestCostToLowest.Name = "btnSortByHighestCostToLowest";
            btnSortByHighestCostToLowest.Size = new Size(158, 34);
            btnSortByHighestCostToLowest.TabIndex = 3;
            btnSortByHighestCostToLowest.Text = "sort by cost ascending ";
            btnSortByHighestCostToLowest.UseVisualStyleBackColor = true;
            btnSortByHighestCostToLowest.Click += BtnSortByCostHighestToLowest_OnClick;
            // 
            // btnSaveInventory
            // 
            btnSaveInventory.BackgroundImage = (Image)resources.GetObject("btnSaveInventory.BackgroundImage");
            btnSaveInventory.BackgroundImageLayout = ImageLayout.Stretch;
            btnSaveInventory.Cursor = Cursors.Hand;
            btnSaveInventory.Font = new Font("Calibri", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnSaveInventory.Location = new Point(383, 424);
            btnSaveInventory.Margin = new Padding(4);
            btnSaveInventory.Name = "btnSaveInventory";
            btnSaveInventory.Size = new Size(139, 35);
            btnSaveInventory.TabIndex = 4;
            btnSaveInventory.Text = "Save inventory.txt";
            btnSaveInventory.UseVisualStyleBackColor = true;
            btnSaveInventory.Click += BtnSaveInventory_OnClick;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(251, 35);
            txtSearch.Margin = new Padding(4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(337, 26);
            txtSearch.TabIndex = 5;
            // 
            // btnSearch
            // 
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.Font = new Font("Calibri", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnSearch.Location = new Point(639, 35);
            btnSearch.Margin = new Padding(4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(112, 29);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += BtnSearch_Click;
            // 
            // pnlScrollInventory
            // 
            pnlScrollInventory.AutoScroll = true;
            pnlScrollInventory.Controls.Add(lblDisplayInventory);
            pnlScrollInventory.Location = new Point(194, 72);
            pnlScrollInventory.Margin = new Padding(4);
            pnlScrollInventory.Name = "pnlScrollInventory";
            pnlScrollInventory.Size = new Size(557, 281);
            pnlScrollInventory.TabIndex = 7;
            // 
            // btnPrevious
            // 
            btnPrevious.Cursor = Cursors.Hand;
            btnPrevious.Location = new Point(293, 383);
            btnPrevious.Margin = new Padding(4);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(132, 34);
            btnPrevious.TabIndex = 8;
            btnPrevious.Text = "Previous";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += BtnPrevious_Click;
            // 
            // btnNext
            // 
            btnNext.BackColor = Color.Transparent;
            btnNext.Cursor = Cursors.Hand;
            btnNext.Location = new Point(490, 383);
            btnNext.Margin = new Padding(4);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(132, 34);
            btnNext.TabIndex = 9;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += BtnNext_Click;
            // 
            // pbRaptor
            // 
            pbRaptor.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pbRaptor.BackgroundImage = (Image)resources.GetObject("pbRaptor.BackgroundImage");
            pbRaptor.BackgroundImageLayout = ImageLayout.Zoom;
            pbRaptor.Location = new Point(15, 15);
            pbRaptor.Margin = new Padding(4);
            pbRaptor.Name = "pbRaptor";
            pbRaptor.Size = new Size(157, 156);
            pbRaptor.TabIndex = 10;
            pbRaptor.TabStop = false;
            // 
            // cmbSelectItemId
            // 
            cmbSelectItemId.FormattingEnabled = true;
            cmbSelectItemId.Location = new Point(778, 220);
            cmbSelectItemId.Name = "cmbSelectItemId";
            cmbSelectItemId.Size = new Size(121, 27);
            cmbSelectItemId.TabIndex = 11;
            cmbSelectItemId.DropDownClosed += SelectedItemIdNumber;
            // 
            // lblSelectId
            // 
            lblSelectId.AutoSize = true;
            lblSelectId.BackColor = Color.Transparent;
            lblSelectId.Location = new Point(783, 198);
            lblSelectId.Name = "lblSelectId";
            lblSelectId.Size = new Size(116, 19);
            lblSelectId.TabIndex = 12;
            lblSelectId.Text = "Select Id number ";
            // 
            // frmCurrentInventory
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(926, 467);
            Controls.Add(lblSelectId);
            Controls.Add(cmbSelectItemId);
            Controls.Add(pbRaptor);
            Controls.Add(btnNext);
            Controls.Add(btnPrevious);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(btnSaveInventory);
            Controls.Add(btnSortByHighestCostToLowest);
            Controls.Add(btnSortByIDHighestToLowest);
            Controls.Add(pnlScrollInventory);
            DoubleBuffered = true;
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "frmCurrentInventory";
            Text = "Current inventory";
            pnlScrollInventory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbRaptor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDisplayInventory;
        private Button btnSortByIDHighestToLowest;
        private Button btnSortByHighestCostToLowest;
        private Button btnSaveInventory;
        private TextBox txtSearch;
        private Button btnSearch;
        private Panel pnlScrollInventory;
        private Button btnPrevious;
        private Button btnNext;
        private PictureBox pbRaptor;
        private ComboBox cmbSelectItemId;
        private Label lblSelectId;
    }
}
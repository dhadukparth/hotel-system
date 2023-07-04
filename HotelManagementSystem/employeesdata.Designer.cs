namespace HotelManagementSystem
{
    partial class employeesdata
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(employeesdata));
            this.displayEmployeeData = new System.Windows.Forms.DataGridView();
            this.bunifuGradientPanel1 = new Bunifu.UI.WinForms.BunifuGradientPanel();
            this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.btnClose = new Bunifu.UI.WinForms.BunifuImageButton();
            this.Edit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Delete = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.displayEmployeeData)).BeginInit();
            this.bunifuGradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // displayEmployeeData
            // 
            this.displayEmployeeData.AllowUserToAddRows = false;
            this.displayEmployeeData.AllowUserToDeleteRows = false;
            this.displayEmployeeData.AllowUserToResizeColumns = false;
            this.displayEmployeeData.AllowUserToResizeRows = false;
            this.displayEmployeeData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.displayEmployeeData.BackgroundColor = System.Drawing.Color.White;
            this.displayEmployeeData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.displayEmployeeData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Edit,
            this.Delete});
            this.displayEmployeeData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.displayEmployeeData.Location = new System.Drawing.Point(0, 56);
            this.displayEmployeeData.MultiSelect = false;
            this.displayEmployeeData.Name = "displayEmployeeData";
            this.displayEmployeeData.ReadOnly = true;
            this.displayEmployeeData.Size = new System.Drawing.Size(800, 394);
            this.displayEmployeeData.TabIndex = 2;
            this.displayEmployeeData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.displayEmployeeData_CellClick);
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.BorderRadius = 1;
            this.bunifuGradientPanel1.Controls.Add(this.bunifuLabel1);
            this.bunifuGradientPanel1.Controls.Add(this.btnClose);
            this.bunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(92)))), ((int)(((byte)(188)))));
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.DeepPink;
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.DodgerBlue;
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(60)))), ((int)(((byte)(212)))));
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(800, 50);
            this.bunifuGradientPanel1.TabIndex = 3;
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AllowParentOverrides = false;
            this.bunifuLabel1.AutoEllipsis = false;
            this.bunifuLabel1.CursorType = null;
            this.bunifuLabel1.Font = new System.Drawing.Font("Bell MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel1.ForeColor = System.Drawing.Color.White;
            this.bunifuLabel1.Location = new System.Drawing.Point(61, 13);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(154, 24);
            this.bunifuLabel1.TabIndex = 4;
            this.bunifuLabel1.Text = "Employee Records";
            this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // btnClose
            // 
            this.btnClose.ActiveImage = null;
            this.btnClose.AllowAnimations = true;
            this.btnClose.AllowBuffering = false;
            this.btnClose.AllowToggling = false;
            this.btnClose.AllowZooming = false;
            this.btnClose.AllowZoomingOnFocus = false;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.ErrorImage = ((System.Drawing.Image)(resources.GetObject("btnClose.ErrorImage")));
            this.btnClose.FadeWhenInactive = false;
            this.btnClose.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.btnClose.Image = global::HotelManagementSystem.Properties.Resources.button;
            this.btnClose.ImageActive = null;
            this.btnClose.ImageLocation = null;
            this.btnClose.ImageMargin = 20;
            this.btnClose.ImageSize = new System.Drawing.Size(27, 30);
            this.btnClose.ImageZoomSize = new System.Drawing.Size(47, 50);
            this.btnClose.InitialImage = ((System.Drawing.Image)(resources.GetObject("btnClose.InitialImage")));
            this.btnClose.Location = new System.Drawing.Point(753, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Rotation = 0;
            this.btnClose.ShowActiveImage = true;
            this.btnClose.ShowCursorChanges = true;
            this.btnClose.ShowImageBorders = false;
            this.btnClose.ShowSizeMarkers = false;
            this.btnClose.Size = new System.Drawing.Size(47, 50);
            this.btnClose.TabIndex = 3;
            this.btnClose.ToolTipText = "";
            this.btnClose.WaitOnLoad = false;
            this.btnClose.Zoom = 20;
            this.btnClose.ZoomSpeed = 10;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Edit
            // 
            this.Edit.HeaderText = "Edit";
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Text = "Edit";
            this.Edit.UseColumnTextForLinkValue = true;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Text = "Delete";
            this.Delete.UseColumnTextForLinkValue = true;
            // 
            // employeesdata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.displayEmployeeData);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "employeesdata";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "employeesdata";
            this.Load += new System.EventHandler(this.employeesdata_Load);
            ((System.ComponentModel.ISupportInitialize)(this.displayEmployeeData)).EndInit();
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.bunifuGradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView displayEmployeeData;
        private Bunifu.UI.WinForms.BunifuImageButton btnClose;
        private Bunifu.UI.WinForms.BunifuGradientPanel bunifuGradientPanel1;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
        private System.Windows.Forms.DataGridViewLinkColumn Edit;
        private System.Windows.Forms.DataGridViewLinkColumn Delete;
    }
}
namespace FlowMeter_Monitor
{
    partial class FrmDebug
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
            this.gcDebug = new DevExpress.XtraGrid.GridControl();
            this.gvDebug = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcDataName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDataValue = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcDebug)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDebug)).BeginInit();
            this.SuspendLayout();
            // 
            // gcDebug
            // 
            this.gcDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDebug.Font = new System.Drawing.Font("华文中宋", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gcDebug.Location = new System.Drawing.Point(0, 0);
            this.gcDebug.MainView = this.gvDebug;
            this.gcDebug.Name = "gcDebug";
            this.gcDebug.Size = new System.Drawing.Size(482, 335);
            this.gcDebug.TabIndex = 0;
            this.gcDebug.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDebug});
            // 
            // gvDebug
            // 
            this.gvDebug.Appearance.HeaderPanel.Font = new System.Drawing.Font("华文中宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gvDebug.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvDebug.Appearance.Row.Font = new System.Drawing.Font("华文中宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gvDebug.Appearance.Row.Options.UseFont = true;
            this.gvDebug.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcDataName,
            this.gcDataValue});
            this.gvDebug.GridControl = this.gcDebug;
            this.gvDebug.IndicatorWidth = 40;
            this.gvDebug.Name = "gvDebug";
            this.gvDebug.OptionsView.ShowGroupPanel = false;
            this.gvDebug.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvDebug_CustomDrawRowIndicator);
            // 
            // gcDataName
            // 
            this.gcDataName.Caption = "数据名称";
            this.gcDataName.FieldName = "Name";
            this.gcDataName.Name = "gcDataName";
            this.gcDataName.Visible = true;
            this.gcDataName.VisibleIndex = 0;
            // 
            // gcDataValue
            // 
            this.gcDataValue.Caption = "数值";
            this.gcDataValue.FieldName = "Value";
            this.gcDataValue.Name = "gcDataValue";
            this.gcDataValue.Visible = true;
            this.gcDataValue.VisibleIndex = 1;
            // 
            // FrmDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 335);
            this.Controls.Add(this.gcDebug);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmDebug";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "数据";
            this.Load += new System.EventHandler(this.FrmDebug_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcDebug)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDebug)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcDebug;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDebug;
        private DevExpress.XtraGrid.Columns.GridColumn gcDataName;
        private DevExpress.XtraGrid.Columns.GridColumn gcDataValue;
    }
}
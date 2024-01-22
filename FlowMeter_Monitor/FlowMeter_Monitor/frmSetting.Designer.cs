namespace FlowMeter_Monitor
{
    partial class frmSetting
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
            this.btnSet = new System.Windows.Forms.Button();
            this.cmbFlowUnit = new System.Windows.Forms.ComboBox();
            this.tbFlowRange = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCtrlSource = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbFlowOutMode = new System.Windows.Forms.ComboBox();
            this.输出模式 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbFlowInMode = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnSet
            // 
            this.btnSet.Font = new System.Drawing.Font("华文中宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSet.ForeColor = System.Drawing.Color.Black;
            this.btnSet.Location = new System.Drawing.Point(173, 269);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(99, 36);
            this.btnSet.TabIndex = 8;
            this.btnSet.Text = "设置";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // cmbFlowUnit
            // 
            this.cmbFlowUnit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbFlowUnit.Font = new System.Drawing.Font("华文中宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbFlowUnit.FormattingEnabled = true;
            this.cmbFlowUnit.Items.AddRange(new object[] {
            "%",
            "SCCM",
            "SLM"});
            this.cmbFlowUnit.Location = new System.Drawing.Point(173, 18);
            this.cmbFlowUnit.Name = "cmbFlowUnit";
            this.cmbFlowUnit.Size = new System.Drawing.Size(99, 27);
            this.cmbFlowUnit.TabIndex = 7;
            // 
            // tbFlowRange
            // 
            this.tbFlowRange.Font = new System.Drawing.Font("华文中宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbFlowRange.Location = new System.Drawing.Point(173, 67);
            this.tbFlowRange.Name = "tbFlowRange";
            this.tbFlowRange.Size = new System.Drawing.Size(100, 29);
            this.tbFlowRange.TabIndex = 6;
            this.tbFlowRange.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("华文中宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(96, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "流量单位";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("华文中宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(97, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "流量量程";
            // 
            // cmbCtrlSource
            // 
            this.cmbCtrlSource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbCtrlSource.Font = new System.Drawing.Font("华文中宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbCtrlSource.FormattingEnabled = true;
            this.cmbCtrlSource.Items.AddRange(new object[] {
            "内设",
            "外设"});
            this.cmbCtrlSource.Location = new System.Drawing.Point(173, 118);
            this.cmbCtrlSource.Name = "cmbCtrlSource";
            this.cmbCtrlSource.Size = new System.Drawing.Size(99, 27);
            this.cmbCtrlSource.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("华文中宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(96, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "控制方式";
            // 
            // cmbFlowOutMode
            // 
            this.cmbFlowOutMode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbFlowOutMode.Font = new System.Drawing.Font("华文中宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbFlowOutMode.FormattingEnabled = true;
            this.cmbFlowOutMode.Items.AddRange(new object[] {
            "0-5V",
            "0-10mA",
            "4-20mA"});
            this.cmbFlowOutMode.Location = new System.Drawing.Point(173, 167);
            this.cmbFlowOutMode.Name = "cmbFlowOutMode";
            this.cmbFlowOutMode.Size = new System.Drawing.Size(99, 27);
            this.cmbFlowOutMode.TabIndex = 12;
            // 
            // 输出模式
            // 
            this.输出模式.AutoSize = true;
            this.输出模式.Font = new System.Drawing.Font("华文中宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.输出模式.Location = new System.Drawing.Point(32, 167);
            this.输出模式.Name = "输出模式";
            this.输出模式.Size = new System.Drawing.Size(137, 19);
            this.输出模式.TabIndex = 11;
            this.输出模式.Text = "输入输出信号类型";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("华文中宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(-1, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 19);
            this.label4.TabIndex = 11;
            this.label4.Text = "            MFC信号类型";
            // 
            // cmbFlowInMode
            // 
            this.cmbFlowInMode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbFlowInMode.Font = new System.Drawing.Font("华文中宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbFlowInMode.FormattingEnabled = true;
            this.cmbFlowInMode.Items.AddRange(new object[] {
            "0-5V",
            "0-10mA",
            "4-20mA"});
            this.cmbFlowInMode.Location = new System.Drawing.Point(173, 218);
            this.cmbFlowInMode.Name = "cmbFlowInMode";
            this.cmbFlowInMode.Size = new System.Drawing.Size(99, 27);
            this.cmbFlowInMode.TabIndex = 12;
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 322);
            this.Controls.Add(this.cmbFlowInMode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbFlowOutMode);
            this.Controls.Add(this.输出模式);
            this.Controls.Add(this.cmbCtrlSource);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.cmbFlowUnit);
            this.Controls.Add(this.tbFlowRange);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "参数";
            this.Load += new System.EventHandler(this.frmSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.ComboBox cmbFlowUnit;
        private System.Windows.Forms.TextBox tbFlowRange;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCtrlSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbFlowOutMode;
        private System.Windows.Forms.Label 输出模式;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbFlowInMode;
    }
}
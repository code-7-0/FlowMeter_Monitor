using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Common;

namespace FlowMeter_Monitor
{
    public partial class frmComCfg : DevExpress.XtraEditors.XtraForm
    {
        public frmComCfg()
        {
            InitializeComponent();
            InitView();
        }

        private void InitView()
        {
            this.MaximizeBox = false;
            Com.comPort = SystemConfig.GetConfigData("Port", Com.comPort);
            Com.comBaud = SystemConfig.GetConfigData("Baud", Com.comBaud);
            Com.comParity = SystemConfig.GetConfigData("Parity", Com.comParity);

            cmbPort.SelectedIndex = Com.comPort;
            cmbBaud.SelectedIndex = Com.comBaud;
            cmbParity.SelectedIndex = Com.comParity;

            if (Com.bIsOpen)
            {
                cmbPort.Enabled = false;
                cmbBaud.Enabled = false;
                cmbParity.Enabled = false;
                btnComSet.Enabled = false;
            }
        }

        private void btnComSet_Click(object sender, EventArgs e)
        {
            Com.comPort = cmbPort.SelectedIndex;
            Com.comBaud = cmbBaud.SelectedIndex;
            Com.comParity = cmbParity.SelectedIndex;

            SystemConfig.WriteConfigData("Port", Com.comPort.ToString());
            SystemConfig.WriteConfigData("Baud", Com.comBaud.ToString());
            SystemConfig.WriteConfigData("Parity", Com.comParity.ToString());

            this.Close();

        }
    }
}
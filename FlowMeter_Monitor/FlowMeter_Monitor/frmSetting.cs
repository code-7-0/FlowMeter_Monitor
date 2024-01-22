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
using System.Threading;

namespace FlowMeter_Monitor
{
    public partial class frmSetting : DevExpress.XtraEditors.XtraForm
    {
        private bool bSetBusy = false;
        UInt16[] cfgBuf = new UInt16[10];
        public void Set_Thread()
        {
            System.Diagnostics.Debug.WriteLine("进入参数设置线程");
            Set_SysCfg();
            bSetBusy = false;
            System.Diagnostics.Debug.WriteLine("退出参数设置线程");
        }

        public frmSetting()
        {
            InitializeComponent();
            InitView();
        }

        private void InitView()
        {
            UInt16 usTmp;
            float fTmp;
            // 窗口最大化按钮
            this.MaximizeBox = false;

            // 流量单位
            usTmp = Util.WordSwap(Com.tBaseInfo.FlowUnit);
            if (usTmp < 3)
            {
                cmbFlowUnit.SelectedIndex = usTmp;
            }
            else
            {
                cmbFlowUnit.SelectedIndex = 0;
            }

            // 流量范围
            fTmp = Util.IntToFloat(Com.tBaseInfo.FlowRange);
            tbFlowRange.Text = fTmp.ToString();

            // 控制方式
            usTmp = Util.WordSwap(Com.tBaseInfo.CtrlSource);
            if (usTmp < 2)
            {
                cmbCtrlSource.SelectedIndex = usTmp;
            }
            else
            {
                cmbCtrlSource.SelectedIndex = 0;
            }

            usTmp = Util.WordSwap(Com.tBaseInfo.FlowOutMode);
            if (usTmp <= 2)
            {
                cmbFlowOutMode.SelectedIndex = usTmp;
            }
            else
            {
                cmbFlowOutMode.SelectedIndex = 0;
            }

            usTmp = Util.WordSwap(Com.tBaseInfo.FlowInMode);
            if (usTmp <= 2)
            {
                cmbFlowInMode.SelectedIndex = usTmp;
            }
            else
            {
                cmbFlowInMode.SelectedIndex = 0;
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            if (Com.bIsOpen)
            {
                if (!bSetBusy)
                {
                    try
                    {
                        float fTmp;
                        byte[] buf;

                        fTmp = Convert.ToSingle(tbFlowRange.Text);
                        if( fTmp<1.0f||fTmp>9999.0f)
                        {
                            MessageBox.Show("流量量程范围(1~9999)", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        cfgBuf[0] = (UInt16)cmbFlowUnit.SelectedIndex;

                        fTmp = float.Parse(tbFlowRange.Text);
                        buf = BitConverter.GetBytes(fTmp);
                        cfgBuf[1] = (UInt16)(buf[0] + (UInt16)(buf[1] << 8));
                        cfgBuf[2] = (UInt16)(buf[2] + (UInt16)(buf[3] << 8));

                        cfgBuf[3] = (UInt16)cmbCtrlSource.SelectedIndex;

                        cfgBuf[4] = (UInt16)cmbFlowOutMode.SelectedIndex;

                        cfgBuf[5]= (UInt16)cmbFlowInMode.SelectedIndex;

                        bSetBusy = true;
                        new Thread(Set_Thread).Start();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "告警", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            else
            {
                MessageBox.Show("通讯端口未打开！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Set_SysCfg()
        {
            if (Com.COMERR_NONE == Com.Set_SysCfg(cfgBuf))
            {

            }
        }

        private void tBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键
            if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0)) return;   //处理负数
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;   //处理非法字符
                }
            }
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {

        }
    }

}
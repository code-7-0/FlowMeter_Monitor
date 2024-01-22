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
    public partial class frmSysCalib : DevExpress.XtraEditors.XtraForm
    {
        public bool bQuery = false;
        public delegate void UpdateControl();
        UpdateControl updateControl;

        private bool bCmdBusy = false;

        private void Query_Thread()
        {
            System.Diagnostics.Debug.WriteLine("进入查询系统参数线程");
            bQuery = true;
            while (bQuery)
            {
                Query_SysCalib();
                Thread.Sleep(100); 
            }
            System.Diagnostics.Debug.WriteLine("退出查询系统参数线程");
        }

        private void Set_Thread(UInt16 addr,UInt16 val)
        {
            Set_CalibValue(addr,val);
            bCmdBusy = false;
        }

        public frmSysCalib()
        {
            InitializeComponent();
            // 窗口最大化按钮
            this.MaximizeBox = false;
        }

        private void frmCalibration_Load(object sender, EventArgs e)
        {
            byte[] buf = new byte[200];
            for (int i = 0; i < 200; i++)
            {
                buf[i] = 0;
            }
            Com.tSysCalib = (Com.T_SysCalib)Util.ByteToStruct(buf, typeof(Com.T_SysCalib));

            updateControl = new UpdateControl(Update_UI);

            Thread t = new Thread(Query_Thread);
           // t.IsBackground = true;
            t.Start();
        }

        private void Update_UI()
        {
            UInt16 usTmp;
            float fTmp;
            Image img;
            // DAC通道1
            {
                // Vset1准备好标志
                usTmp = Util.WordSwap(Com.tSysCalib.usDac1Vset1Rdy);
                if (1 == usTmp)
                {
                    img = Properties.Resources.LedRed;
                }
                else
                {
                    img = Properties.Resources.LedNone;
                }
                picDac1_Vset1_Rdy.Image = img;

                // Vout1准备好标志
                usTmp = Util.WordSwap(Com.tSysCalib.usDac1Vout1Rdy);
                if (1 == usTmp)
                {
                    img = Properties.Resources.LedRed;
                }
                else
                {
                    img = Properties.Resources.LedNone;
                }
                picDac1_Vout1_Rdy.Image = img;

                // Vset2准备好标志
                usTmp = Util.WordSwap(Com.tSysCalib.usDac1Vset2Rdy);
                if (1 == usTmp)
                {
                    img = Properties.Resources.LedRed;
                }
                else
                {
                    img = Properties.Resources.LedNone;
                }
                picDac1_Vset2_Rdy.Image = img;

                // Vout2准备好标志
                usTmp = Util.WordSwap(Com.tSysCalib.usDac1Vout2Rdy);
                if (1 == usTmp)
                {
                    img = Properties.Resources.LedRed;
                }
                else
                {
                    img = Properties.Resources.LedNone;
                }
                picDac1_Vout2_Rdy.Image = img;

                // K系数
                fTmp = Util.IntToFloat(Com.tBaseInfo.fDac1K);
                tbDac1_K.Text = String.Format("{0:F4}", fTmp);

                // B系数
                fTmp = Util.IntToFloat(Com.tBaseInfo.fDac1B);
                tbDac1_B.Text = String.Format("{0:F4}", fTmp);
            }

            // DAC通道2
            {
                // Vset1准备好标志
                usTmp = Util.WordSwap(Com.tSysCalib.usDac2Vset1Rdy);
                if (1 == usTmp)
                {
                    img = Properties.Resources.LedRed;
                }
                else
                {
                    img = Properties.Resources.LedNone;
                }
                picDac2_Vset1_Rdy.Image = img;

                // Vout1准备好标志
                usTmp = Util.WordSwap(Com.tSysCalib.usDac2Vout1Rdy);
                if (1 == usTmp)
                {
                    img = Properties.Resources.LedRed;
                }
                else
                {
                    img = Properties.Resources.LedNone;
                }
                picDac2_Vout1_Rdy.Image = img;

                // Vset2准备好标志
                usTmp = Util.WordSwap(Com.tSysCalib.usDac2Vset2Rdy);
                if (1 == usTmp)
                {
                    img = Properties.Resources.LedRed;
                }
                else
                {
                    img = Properties.Resources.LedNone;
                }
                picDac2_Vset2_Rdy.Image = img;

                // Vout2准备好标志
                usTmp = Util.WordSwap(Com.tSysCalib.usDac2Vout2Rdy);
                if (1 == usTmp)
                {
                    img = Properties.Resources.LedRed;
                }
                else
                {
                    img = Properties.Resources.LedNone;
                }
                picDac2_Vout2_Rdy.Image = img;

                // K系数
                fTmp = Util.IntToFloat(Com.tBaseInfo.fDac2K);
                tbDac2_K.Text = String.Format("{0:F4}", fTmp);

                // B系数
                fTmp = Util.IntToFloat(Com.tBaseInfo.fDac2B);
                tbDac2_B.Text = String.Format("{0:F4}", fTmp);
            }

            // ADC通道1
            {
                // Vref1
                usTmp = Util.WordSwap(Com.tSysCalib.usAdc1Vmea1);
                fTmp = usTmp * 0.001f;
                tbAdc1_Vmea1.Text = string.Format("{0:f3}", fTmp);
                // Vref2
                usTmp = Util.WordSwap(Com.tSysCalib.usAdc1Vmea2);
                fTmp = usTmp * 0.001f;
                tbAdc1_Vmea2.Text = string.Format("{0:f3}", fTmp);
                // Vref1准备好标志
                usTmp = Util.WordSwap(Com.tSysCalib.usAdc1Value1Rdy);
                if (1 == usTmp)
                {
                    img = Properties.Resources.LedRed;
                }
                else
                {
                    img = Properties.Resources.LedNone;
                }
                picAdc1_Vref1_Rdy.Image = img;
                // Vout2准备好标志
                usTmp = Util.WordSwap(Com.tSysCalib.usAdc1Value2Rdy);
                if (1 == usTmp)
                {
                    img = Properties.Resources.LedRed;
                }
                else
                {
                    img = Properties.Resources.LedNone;
                }
                picAdc1_Vref2_Rdy.Image = img;

                // K系数
                fTmp = Util.IntToFloat(Com.tBaseInfo.fAdc1K);
                tbAdc1_K.Text = String.Format("{0:F4}", fTmp);

                // B系数
                fTmp = Util.IntToFloat(Com.tBaseInfo.fAdc1B);
                tbAdc1_B.Text = String.Format("{0:F4}", fTmp);
            }

            // ADC通道2
            {
                // Vref1
                usTmp = Util.WordSwap(Com.tSysCalib.usAdc2Vmea1);
                fTmp = usTmp * 0.001f;
                tbAdc2_Vmea1.Text = string.Format("{0:f3}", fTmp);
                // Vref2
                usTmp = Util.WordSwap(Com.tSysCalib.usAdc2Vmea2);
                fTmp = usTmp * 0.001f;
                tbAdc2_Vmea2.Text = string.Format("{0:f3}", fTmp);
                // Vref1准备好标志
                usTmp = Util.WordSwap(Com.tSysCalib.usAdc2Value1Rdy);
                if (1 == usTmp)
                {
                    img = Properties.Resources.LedRed;
                }
                else
                {
                    img = Properties.Resources.LedNone;
                }
                picAdc2_Vref1_Rdy.Image = img;
                // Vout2准备好标志
                usTmp = Util.WordSwap(Com.tSysCalib.usAdc2Value2Rdy);
                if (1 == usTmp)
                {
                    img = Properties.Resources.LedRed;
                }
                else
                {
                    img = Properties.Resources.LedNone;
                }
                picAdc2_Vref2_Rdy.Image = img;

                // K系数
                fTmp = Util.IntToFloat(Com.tBaseInfo.fAdc2K);
                tbAdc2_K.Text = String.Format("{0:F4}", fTmp);

                // B系数
                fTmp = Util.IntToFloat(Com.tBaseInfo.fAdc2B);
                tbAdc2_B.Text = String.Format("{0:F4}", fTmp);
            }
        }

        private void Query_SysCalib()
        {
            byte[] buf = new byte[200];
            if (Com.COMERR_NONE == Com.Query_SysCalib(buf))
            {
                Com.tSysCalib = (Com.T_SysCalib)Util.ByteToStruct(buf, typeof(Com.T_SysCalib));
                try
                {
                    this.Invoke(updateControl);
                }
                catch { }
            }
           
        }

        private void Set_CalibValue(UInt16 addr,UInt16 val)
        {
            byte[] buf = new byte[200];
            if (Com.COMERR_NONE == Com.Set_CalibValue(addr,val))
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

       

        private void btnDac1_Vset1_Write_Click(object sender, EventArgs e)
        {
            double fTmp;
            UInt16 usTmp;
            String str;

            if (!Com.bIsOpen)
            {
                MessageBox.Show("通讯端口未打开！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            usTmp = Util.WordSwap(Com.tSysCalib.usDac1Step);
            if(0 != usTmp)
            {
                str = string.Format("请进行第{0:d}步", usTmp + 1);
                MessageBox.Show(str, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (tbDac1_Vset1.Text.Equals(""))
            {
                MessageBox.Show("数值不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (bCmdBusy)
            {
                MessageBox.Show("命令处理中！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                
                fTmp = Convert.ToDouble(tbDac1_Vset1.Text);
                if(fTmp>5.0f)
                {
                    MessageBox.Show("数值不能大于5！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                usTmp = (UInt16)(fTmp * 1000);
                bCmdBusy = true;
                Thread t = new Thread(() => Set_Thread(Com.MB_W_DAC1_VSET1_BASEADDR, usTmp));
                t.Start();
            }
        }

        private void btnDac1_Vout1_Write_Click(object sender, EventArgs e)
        {
            double fTmp;
            UInt16 usTmp;
            String str;

            if (!Com.bIsOpen)
            {
                MessageBox.Show("通讯端口未打开！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            usTmp = Util.WordSwap(Com.tSysCalib.usDac1Step);
            if (1 != usTmp)
            {
                str = string.Format("请进行第{0:d}步", usTmp + 1);
                MessageBox.Show(str, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbDac1_Vout1.Text.Equals(""))
            {
                MessageBox.Show("数值不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (bCmdBusy)
            {
                MessageBox.Show("命令处理中！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                fTmp = Convert.ToDouble(tbDac1_Vout1.Text);
                usTmp = (UInt16)(fTmp * 1000);
                bCmdBusy = true;
                Thread t = new Thread(() => Set_Thread(Com.MB_W_DAC1_VOUT1_BASEADDR, usTmp));
                t.Start();
            }
        }

       
        private void btnDac1_Vset2_Write_Click(object sender, EventArgs e)
        {
            double fTmp;
            UInt16 usTmp;
            String str;

            if (!Com.bIsOpen)
            {
                MessageBox.Show("通讯端口未打开！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            usTmp = Util.WordSwap(Com.tSysCalib.usDac1Step);
            if(2 != usTmp)
            {
                str = string.Format("请进行第{0:d}步", usTmp + 1);
                MessageBox.Show(str, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbDac1_Vset2.Text.Equals(""))
            {
                MessageBox.Show("数值不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (bCmdBusy)
            {
                MessageBox.Show("命令处理中！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                fTmp = Convert.ToDouble(tbDac1_Vset2.Text);
                if (fTmp > 5.0f)
                {
                    MessageBox.Show("数值不能大于5！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                usTmp = (UInt16)(fTmp * 1000);
                bCmdBusy = true;
                Thread t = new Thread(() => Set_Thread(Com.MB_W_DAC1_VSET2_BASEADDR, usTmp));
                t.Start();
            }
        }

        private void btnDac1_Vout2_Write_Click(object sender, EventArgs e)
        {
            double fTmp;
            UInt16 usTmp;
            String str;

            if (!Com.bIsOpen)
            {
                MessageBox.Show("通讯端口未打开！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            usTmp = Util.WordSwap(Com.tSysCalib.usDac1Step);
            if (3 != usTmp)
            {
                str = string.Format("请进行第{0:d}步", usTmp + 1);
                MessageBox.Show(str, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbDac1_Vout2.Text.Equals(""))
            {
                MessageBox.Show("数值不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (bCmdBusy)
            {
                MessageBox.Show("命令处理中！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                fTmp = Convert.ToDouble(tbDac1_Vout2.Text);
                usTmp = (UInt16)(fTmp * 1000);
                bCmdBusy = true;
                Thread t = new Thread(() => Set_Thread(Com.MB_W_DAC1_VOUT2_BASEADDR, usTmp));
                t.Start();
            }
        }

        private void btnDac2_Vset1_Write_Click(object sender, EventArgs e)
        {
            double fTmp;
            UInt16 usTmp;
            String str;

            if (!Com.bIsOpen)
            {
                MessageBox.Show("通讯端口未打开！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            usTmp = Util.WordSwap(Com.tSysCalib.usDac2Step);
            if (0 != usTmp)
            {
                str = string.Format("请进行第{0:d}步", usTmp + 1);
                MessageBox.Show(str, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbDac2_Vset1.Text.Equals(""))
            {
                MessageBox.Show("数值不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (bCmdBusy)
            {
                MessageBox.Show("命令处理中！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                fTmp = Convert.ToDouble(tbDac2_Vset1.Text);
                if (fTmp > 5.0f)
                {
                    MessageBox.Show("数值不能大于5！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                usTmp = (UInt16)(fTmp * 1000);
                bCmdBusy = true;
                Thread t = new Thread(() => Set_Thread(Com.MB_W_DAC2_VSET1_BASEADDR, usTmp));
                t.Start();
            }
        }

        private void btnDac2_Vout1_Write_Click(object sender, EventArgs e)
        {
            double fTmp;
            UInt16 usTmp;
            String str;

            if (!Com.bIsOpen)
            {
                MessageBox.Show("通讯端口未打开！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            usTmp = Util.WordSwap(Com.tSysCalib.usDac2Step);
            if (1 != usTmp)
            {
                str = string.Format("请进行第{0:d}步", usTmp + 1);
                MessageBox.Show(str, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbDac2_Vout1.Text.Equals(""))
            {
                MessageBox.Show("数值不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (bCmdBusy)
            {
                MessageBox.Show("命令处理中！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                fTmp = Convert.ToDouble(tbDac2_Vout1.Text);
                usTmp = (UInt16)(fTmp * 1000);
                bCmdBusy = true;
                Thread t = new Thread(() => Set_Thread(Com.MB_W_DAC2_VOUT1_BASEADDR, usTmp));
                t.Start();
            }
        }

        
        private void btnDac2_Vset2_Write_Click(object sender, EventArgs e)
        {
            double fTmp;
            UInt16 usTmp;
            String str;

            if (!Com.bIsOpen)
            {
                MessageBox.Show("通讯端口未打开！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            usTmp = Util.WordSwap(Com.tSysCalib.usDac2Step);
            if (2 != usTmp)
            {
                str = string.Format("请进行第{0:d}步", usTmp + 1);
                MessageBox.Show(str, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbDac2_Vset2.Text.Equals(""))
            {
                MessageBox.Show("数值不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (bCmdBusy)
            {
                MessageBox.Show("命令处理中！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                fTmp = Convert.ToDouble(tbDac2_Vset2.Text);
                if (fTmp > 5.0f)
                {
                    MessageBox.Show("数值不能大于5！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                usTmp = (UInt16)(fTmp * 1000);
                bCmdBusy = true;
                Thread t = new Thread(() => Set_Thread(Com.MB_W_DAC2_VSET2_BASEADDR, usTmp));
                t.Start();
            }
        }

        private void btnDac2_Vout2_Write_Click(object sender, EventArgs e)
        {
            double fTmp;
            UInt16 usTmp;
            String str;

            if (!Com.bIsOpen)
            {
                MessageBox.Show("通讯端口未打开！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            usTmp = Util.WordSwap(Com.tSysCalib.usDac2Step);
            if (3 != usTmp)
            {
                str = string.Format("请进行第{0:d}步", usTmp + 1);
                MessageBox.Show(str, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbDac2_Vout2.Text.Equals(""))
            {
                MessageBox.Show("数值不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (bCmdBusy)
            {
                MessageBox.Show("命令处理中！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                fTmp = Convert.ToDouble(tbDac2_Vout2.Text);
                usTmp = (UInt16)(fTmp * 1000);
                bCmdBusy = true;
                Thread t = new Thread(() => Set_Thread(Com.MB_W_DAC2_VOUT2_BASEADDR, usTmp));
                t.Start();
            }
        }

        private void btnAdc1_Vref1_Write_Click(object sender, EventArgs e)
        {
            if (!Com.bIsOpen)
            {
                MessageBox.Show("通讯端口未打开！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbAdc1_Vref1.Text.Equals(""))
            {
                MessageBox.Show("数值不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (bCmdBusy)
            {
                MessageBox.Show("命令处理中！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                double fTmp;
                UInt16 usTmp;
                fTmp = Convert.ToDouble(tbAdc1_Vref1.Text);
                usTmp = (UInt16)(fTmp * 1000);
                bCmdBusy = true;
                Thread t = new Thread(() => Set_Thread(Com.MB_W_ADC1_V1_BASEADDR, usTmp));
                t.Start();
            }
        }

        private void btnAdc1_Vref2_Write_Click(object sender, EventArgs e)
        {
            if (!Com.bIsOpen)
            {
                MessageBox.Show("通讯端口未打开！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbAdc1_Vref2.Text.Equals(""))
            {
                MessageBox.Show("数值不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (bCmdBusy)
            {
                MessageBox.Show("命令处理中！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                double fTmp;
                UInt16 usTmp;
                fTmp = Convert.ToDouble(tbAdc1_Vref2.Text);
                usTmp = (UInt16)(fTmp * 1000);
                bCmdBusy = true;
                Thread t = new Thread(() => Set_Thread(Com.MB_W_ADC1_V2_BASEADDR, usTmp));
                t.Start();
            }
        }

        private void btnAdc2_Vref1_Write_Click(object sender, EventArgs e)
        {
            if (!Com.bIsOpen)
            {
                MessageBox.Show("通讯端口未打开！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbAdc2_Vref1.Text.Equals(""))
            {
                MessageBox.Show("数值不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (bCmdBusy)
            {
                MessageBox.Show("命令处理中！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                double fTmp;
                UInt16 usTmp;
                fTmp = Convert.ToDouble(tbAdc2_Vref1.Text);
                usTmp = (UInt16)(fTmp * 1000);
                bCmdBusy = true;
                Thread t = new Thread(() => Set_Thread(Com.MB_W_ADC2_V1_BASEADDR, usTmp));
                t.Start();
            }
        }

        private void btnAdc2_Vref2_Write_Click(object sender, EventArgs e)
        {
            if (!Com.bIsOpen)
            {
                MessageBox.Show("通讯端口未打开！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbAdc2_Vref2.Text.Equals(""))
            {
                MessageBox.Show("数值不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (bCmdBusy)
            {
                MessageBox.Show("命令处理中！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                double fTmp;
                UInt16 usTmp;
                fTmp = Convert.ToDouble(tbAdc2_Vref2.Text);
                usTmp = (UInt16)(fTmp * 1000);
                bCmdBusy = true;
                Thread t = new Thread(() => Set_Thread(Com.MB_W_ADC2_V2_BASEADDR, usTmp));
                t.Start();
            }
        }

        private void frmSysCalib_FormClosing(object sender, FormClosingEventArgs e)
        {
            bQuery = false;
        }
    }
}
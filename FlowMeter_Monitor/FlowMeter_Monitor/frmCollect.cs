using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Common;

namespace FlowMeter_Monitor
{
    
    public partial class frmCollect : DevExpress.XtraEditors.XtraForm
    {
        //private bool bStartBusy = false;
        public frmCollect()
        {
            InitializeComponent();
            InitView();
        }

        private void InitView()
        {
            //UInt16 usTmp;
            //float fTmp;
            // 窗口最大化按钮
            this.MaximizeBox = false;
        }
        // 开始存储按钮点击事件
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (Com.bIsOpen)
            {
                if (!Com.isRecording)
                {
                    try
                    {
                        // 尝试将文本框的内容转换为整数
                        if (int.TryParse(Collect_interval.Text, out int inputValue))
                        {
                            // 验证输入是否在指定范围内
                            if (inputValue >= 1 && inputValue <= 600)
                            {
                                // 转换为uint16类型并存储在变量中
                                Com.CollectInterval = Convert.ToUInt16(inputValue);
                                Com.isRecording = true;//正在采集标志置位
                                Com.timercnt = 0;//清零定时器计时
                                 // 显示成功消息
                                MessageBox.Show("开启成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("输入不在指定范围内，请输入0-666的整数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            // 显示错误消息，输入不是整数
                            MessageBox.Show("输入不在指定范围内，请输入0-666的整数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "告警", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                 MessageBox.Show("采集还未停止！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("通讯端口未打开！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void frmCollect_Load(object sender, EventArgs e)
        {

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

        //private void btnStop_Click(object sender, EventArgs e)
        //{
        //    if (Com.bIsOpen)
        //    {
        //        if (Com.isRecording)
        //        {
        //            Com.isRecording = false;//正在采集标志置位
        //            MessageBox.Show("数据采集关闭！", "提示");
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("通讯端口未打开！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}
    }
}

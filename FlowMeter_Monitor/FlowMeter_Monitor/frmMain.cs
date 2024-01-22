using Common;
using DevExpress.LookAndFeel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;

namespace FlowMeter_Monitor
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        // 在类中添加一个全局的List来存储多个记录，每个记录包含时间、流量值和流量单位
        List<Tuple<string, float, string>> flowDataList = new List<Tuple<string, float, string>>();
        int maxRecordsThreshold = 1000;// 设置阈值，当存储的记录数量达到在记录数据该值时触发清理
        //UInt16 timercnt = 0;

        private static System.Timers.Timer Timer1;

        UInt16 WorkModeSet = 0;
        bool bCtrlWkModeBusy = false;

        float FlowPctSet = 0;
        bool bCtrlFlowBusy = false;

        bool bSetDevAddrBusy = false;

        bool bOnLine = false;

        // 定义一个委托
        public delegate void UpdateControl();
        UpdateControl updateControl;

        private delegate void Message(int type);
        Message message;

        private static bool bLed = false;

        public void Monitor_Thread()
        {
            System.Diagnostics.Debug.WriteLine("进入监控线程");
            while (true)
            {
                if (Com.bIsOpen)
                {
                    Query_BaseInfo();
                    Thread.Sleep(100);
                    Query_DebugInfo();
                    Thread.Sleep(100);
                }
                else
                {
                    Thread.Sleep(10);
                }

            }
        }

        public void Ctrl_WkMode_Thread()
        {
            System.Diagnostics.Debug.WriteLine("进入工作模式控制线程");
            Set_WorkMode();
            bCtrlWkModeBusy = false;
            System.Diagnostics.Debug.WriteLine("退出工作模式控制线程");
        }

        public void Ctrl_Flow_Thread()
        {
            System.Diagnostics.Debug.WriteLine("进入流量控制线程");
            Set_Flow();
            bCtrlFlowBusy = false;
            System.Diagnostics.Debug.WriteLine("退出流量控制线程");
        }

        public void Set_DevAddr_Thread()
        {
            System.Diagnostics.Debug.WriteLine("进入通讯地址线程");
            Set_DevAddr();
            bSetDevAddrBusy = false;
            System.Diagnostics.Debug.WriteLine("退出通讯地址设置线程");
        }


        public frmMain()
        {
            InitializeComponent();
        }

        private void InitView()
        {
            // 窗口最大化按钮
            this.MaximizeBox = false;
            // 串口标题
            this.Text = Com.WindowName;

            this.btnFlowSet.Focus();

            // 设置皮肤主题
            UserLookAndFeel.Default.SetSkinStyle("Money Twins");//皮肤主题

            // 读取串口配置
            Com.comPort = SystemConfig.GetConfigData("Port", Com.comPort);
            Com.comBaud = SystemConfig.GetConfigData("Baud", Com.comBaud);
            Com.comParity = SystemConfig.GetConfigData("Parity", Com.comParity);

            byte[] buf = new byte[200];
            for (int i = 0; i < 200; i++)
            {
                buf[i] = 0;
            }
            Com.tBaseInfo = (Com.T_BaseInfo)Util.ByteToStruct(buf, typeof(Com.T_BaseInfo));
            Com.tDebugInfo = (Com.T_DebugInfo)Util.ByteToStruct(buf, typeof(Com.T_DebugInfo));

            tbDevAddr.Text = Com.devAddr.ToString();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            InitView();

            Timer1 = new System.Timers.Timer(200);
            Timer1.Elapsed += new ElapsedEventHandler(OnTimerElapsed);
            Timer1.Interval = 200;
            Timer1.Enabled = true;

            // 绑定一个方法
            updateControl = new UpdateControl(Update_UI);
            message = new Message(MessageShow);

            // 启动监控线程
            Thread t = new Thread(Monitor_Thread);
            t.IsBackground = true;
            t.Start();

        }

        private void Update_UI()
        {
            UInt16 usTmp;
            Int16 sTmp;
            UInt16 flowUnit,flowRange;
            

            float fTmp;
            string str = "";
            Image img;

            // 流量量程
            fTmp = Util.IntToFloat(Com.tBaseInfo.FlowRange);
            lblFlowRange.Text = Util.FloatTo4DigitString(fTmp);

            // 流量单位
            usTmp = Util.WordSwap(Com.tBaseInfo.FlowUnit);
            if (0 == usTmp)
            {
                str = "%";
            }
            else if (1 == usTmp)
            {
                str = "SCCM";
            }
            else if (2 == usTmp)
            {
                str = "SLM";
            }
            lblFlowUnit.Text = str;
            flowUnit = usTmp;

            // 控制源
            usTmp = Util.WordSwap(Com.tBaseInfo.CtrlSource);
            if(0 == usTmp)
            {
                str = "内设";
            }
            else
            {
                str = "外设";
            }
            lblCtrlSource.Text = str;

            // 输入输出信号类型
            usTmp = Util.WordSwap(Com.tBaseInfo.FlowOutMode);
            if (0 == usTmp)
            {
                str = "0-5V";
                
            }
            else if(1 == usTmp)
            {
                str = "0-10mA";
            }
            else if(2 == usTmp)
            {
                str = "4-20mA";
            }
            else
            {
                str = "0-5V";
            }
            lblOutPutType.Text = str;


            // MFC信号类型
            usTmp = Util.WordSwap(Com.tBaseInfo.FlowInMode);
            if (0 == usTmp)
            {
                str = "0-5V";

            }
            else if (1 == usTmp)
            {
                str = "0-10mA";
            }
            else if (2 == usTmp)
            {
                str = "4-20mA";
            }
            else
            {
                str = "0-5V";
            }
            lblMfcType.Text = str;
            // 工作模式
            usTmp = Util.WordSwap(Com.tBaseInfo.WorkMode);
            if (0 == usTmp)
            {
                // 关闭
                img = Properties.Resources.LedRed;
                picWMClose.Image = img;
                img = Properties.Resources.LedNone;
                picWMAuto.Image = img;
                picWMClean.Image = img;
                
            }
            else if (1 == usTmp)
            {
                // 阀控
                img = Properties.Resources.LedRed;
                picWMAuto.Image = img;
                img = Properties.Resources.LedNone;
                picWMClean.Image = img;
                picWMClose.Image = img;
            }
            else if (2 == usTmp)
            {
                // 清洗
                img = Properties.Resources.LedRed;
                picWMClean.Image = img;
                img = Properties.Resources.LedNone;
                picWMAuto.Image = img;
                picWMClose.Image = img;
            }
   
            // 实测流量
            fTmp = Util.IntToFloat(Com.tBaseInfo.FlowFb);
            lblFlowFb.Text = Util.FloatTo4DigitString(fTmp);

            // 设定流量
            fTmp = Util.IntToFloat(Com.tBaseInfo.FlowSet);
            lblFlowSet.Text = Util.FloatTo4DigitString(fTmp);

            // 固件版本
            str = "固件版本：V";
            usTmp = Util.WordSwap(Com.tBaseInfo.Version[0]);
            str += usTmp.ToString() + ".";
            usTmp = Util.WordSwap(Com.tBaseInfo.Version[1]);
            str += usTmp.ToString() + ".";
            usTmp = Util.WordSwap(Com.tBaseInfo.Version[2]);
            str += usTmp.ToString();

            statusFWVersion.Text = str;

            // 设备温度
            str = "温度：";
            sTmp = (Int16)Util.WordSwap((UInt16)Com.tBaseInfo.Temp);
            str += sTmp.ToString() + "℃";
            statusDevTemp.Text = str;

            //流量值采集条数
            str = "流量采集条数：";
            str += flowDataList.Count.ToString();
            if (flowDataList.Count >= maxRecordsThreshold)
                str += "(存储已满)";
            statusCollectnum.Text = str;


            // 串口状态
            if (Com.IsOpen())
            {
                Com.bIsOpen = true;
            }
            else
            {
                Com.bIsOpen = false;
            }

            if (Com.bIsOpen)
            {
                barRun.Enabled = false;
                barStop.Enabled = true;
            }
            else
            {
                barRun.Enabled = true;
                barStop.Enabled = false;
            }

            if (Com.bIsOpen)
            { 
                if (bLed)
                {
                    bLed = false;
                    img = Properties.Resources.LedNone;
                }
                else
                {
                    bLed = true;
                    img = Properties.Resources.LedGreen;
                }
                statusCom.Image = img;
                statusCom.Text = "监控中" +string.Format("    通讯失败次数：{0}",Com.comErrCnt);
            }
            else
            {

                img = Properties.Resources.LedNone;
                statusCom.Image = img;
                statusCom.Text = "监控关闭" + string.Format("    通讯失败次数：{0}", Com.comErrCnt);

            }
        }

        private void MessageShow(int type)
        {
            switch (type)
            {
                case 0:
                    MessageBox.Show("工作模式设置成功！");
                    break;

                case 1:
                    MessageBox.Show("工作模式设置失败！");
                    break;
                default:
                    break;
            }
        }
        private void OnTimerElapsed(object source, ElapsedEventArgs e)
        {
            /*if(bOnLine)
            {
                UInt16 usTmp;
                usTmp = Util.WordSwap(Com.tBaseInfo.FlowSet);

                if(!bCtrlFlowBusy)
                {
                    if(usTmp != FlowPctSet)
                    {
                        bCtrlFlowBusy = true;
                        new Thread(Ctrl_Flow_Thread).Start();
                    } 
                }
            }*/

            try
            {
                //采集流量数据
                if(Com.isRecording == true)
                {
                    Com.timercnt++;
                    if (Com.timercnt >= Com.CollectInterval * 5)
                    {
                        RecordFlowValueAndUnit();
                        Com.timercnt = 0;
                    }
                }

                this.Invoke(updateControl);//UI更新
            }
            catch (System.Exception ex)
            {

            }

        }

        private void Query_BaseInfo()
        {
            byte[] buf = new byte[200];
            if (Com.COMERR_NONE == Com.Query_StdInfo(buf))
            {
                Com.tBaseInfo = (Com.T_BaseInfo)Util.ByteToStruct(buf, typeof(Com.T_BaseInfo));
                bOnLine = true;
            }
            else
            {
                bOnLine = false;
            }
        }

        private void Query_DebugInfo()
        {
            byte[] buf = new byte[200];
            if (Com.COMERR_NONE == Com.Query_DebugInfo(buf))
            {
                Com.tDebugInfo = (Com.T_DebugInfo)Util.ByteToStruct(buf, typeof(Com.T_DebugInfo));
            }
        }

        private void Set_WorkMode()
        {
            byte[] buf = new byte[200];
            if (Com.COMERR_NONE == Com.Set_WorkMode(WorkModeSet))
            {
            }
        }

        private void Set_Flow()
        {
            byte[] buf ;
            UInt16[] flow = new UInt16[2];
            buf = BitConverter.GetBytes(FlowPctSet);
            flow[0] = (UInt16)(buf[0] + (UInt16)(buf[1] << 8));
            flow[1] = (UInt16)(buf[2] + (UInt16)(buf[3] << 8));
            if (Com.COMERR_NONE == Com.Set_Flow(flow))
            {
            }
        }

        private void Set_DevAddr()
        {
            if (Com.COMERR_NONE == Com.Set_DevAddr((UInt16)Com.devAddr))
            {
            }
        }


        private void btnWkmodeAuto_Click(object sender, EventArgs e)
        {
            if(Com.bIsOpen)
            {
                if (!bCtrlWkModeBusy)
                {
                    bCtrlWkModeBusy = true;
                    WorkModeSet = 1;
                    new Thread(Ctrl_WkMode_Thread).Start();
                }
            }
            else
            {
                MessageBox.Show("通讯端口未打开！", "提示",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnWkmodeClose_Click(object sender, EventArgs e)
        {
            if(Com.bIsOpen)
            {
                if (!bCtrlWkModeBusy)
                {
                    bCtrlWkModeBusy = true;
                    WorkModeSet = 0;
                    new Thread(Ctrl_WkMode_Thread).Start();
                }
            }
            else
            {
                MessageBox.Show("通讯端口未打开！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnWkmodeClean_Click(object sender, EventArgs e)
        {
            if (Com.bIsOpen)
            {
                if (!bCtrlWkModeBusy)
                {
                    bCtrlWkModeBusy = true;
                    WorkModeSet = 2;
                    new Thread(Ctrl_WkMode_Thread).Start();
                }
            }
            else
            {
                MessageBox.Show("通讯端口未打开！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void barRun_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Com.IsOpen())
            {
                if (!Com.Open(Com.comPort, Com.comBaud))
                {
                    MessageBox.Show("端口被占用或无效端口", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            
        }

        private void barStop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Com.IsOpen())           
            {
                Com.Close();
            }
        }

        private void barComCfg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmComCfg frm = new frmComCfg();
            frm.ShowDialog(this);
        }

        private void barSetting_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSetting frm = new frmSetting();
            frm.ShowDialog(this);
        }

        private void barCalibration_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSysCalib frm = new frmSysCalib();
            frm.ShowDialog(this);
        }

        private void barDebug_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmDebug frm = new FrmDebug();
            frm.ShowDialog(this);
        }


        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Timer1.Stop();
        }

        private void btnFlowSet_Click(object sender, EventArgs e)
        {
            double fTmp,ftmp2;
            UInt16 usTmp;
            if (tbFlowSetPC.Text.Equals(""))
            {
                MessageBox.Show("数值不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            fTmp = Convert.ToDouble(tbFlowSetPC.Text);
            ftmp2 = Util.IntToFloat(Com.tBaseInfo.FlowRange);
            if (fTmp < 0.0f || fTmp > ftmp2)
            {

                string str = string.Format("非法数值，取值范围（0~{0}）！", Util.FloatTo4DigitString((float)ftmp2));
                MessageBox.Show(str, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (bOnLine && !bCtrlFlowBusy)
            {
                FlowPctSet = (float)fTmp;
                bCtrlFlowBusy = true;
                new Thread(Ctrl_Flow_Thread).Start();
                
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

        private void btnDevAddrSet_Click(object sender, EventArgs e)
        {
            if (Com.bIsOpen)
            {
                if (!bSetDevAddrBusy)
                {
                    bSetDevAddrBusy = true;
                    new Thread(Set_DevAddr_Thread).Start();
                }
            }
            else
            {
                MessageBox.Show("通讯端口未打开！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbDevAddr_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    int num = int.Parse(tbDevAddr.Text);
            //    if(num<1 || num>247)
            //    {
            //        MessageBox.Show("地址设置范围为1~247!");
            //        return;
            //    }

            //    Com.devAddr = num;
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            int num;

            if (tbDevAddr.Text == "" || tbDevAddr.Text == "0")
            {
                tbDevAddr.Text = "1";
            }

            try
            {
                num = int.Parse(tbDevAddr.Text);         
                if (num <= 247)
                {
                    Com.devAddr = num;
                    return;
                }
                else
                {
                    tbDevAddr.Text = 247.ToString();
                }
                tbDevAddr.SelectionStart = tbDevAddr.Text.Length;
                Com.devAddr = int.Parse(tbDevAddr.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void statusCom_DoubleClick(object sender, EventArgs e)
        {
            Com.comErrCnt = 0;
        }

        private void barCollect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmCollect frm = new frmCollect();
            frm.ShowDialog(this);
        }

        // 记录流量值和单位
        private void RecordFlowValueAndUnit()
        {
            float globalFlowValue=0.0f;
            string flowUnit="";
            UInt16 usTmp;
            if (Com.bIsOpen)
            {
                if (flowDataList.Count < maxRecordsThreshold)// 检查是否达到阈值，如果是，则停止记录
                {
                    // 获取当前时间
                    string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    // 实测流量
                    globalFlowValue = Util.IntToFloat(Com.tBaseInfo.FlowFb);
                    //lblFlowFb.Text = Util.FloatTo4DigitString(globalFlowValue);
                    // 流量单位
                    usTmp = Util.WordSwap(Com.tBaseInfo.FlowUnit);
                    if (0 == usTmp)
                    {
                        flowUnit = "%";
                    }
                    else if (1 == usTmp)
                    {
                        flowUnit = "SCCM";
                    }
                    else if (2 == usTmp)
                    {
                        flowUnit = "SLM";
                    }

                    // 添加当前记录到列表
                    flowDataList.Add(new Tuple<string, float, string>(currentTime, globalFlowValue, flowUnit));

                    // 检查是否达到阈值，如果是，则进行清理
                    //if (flowDataList.Count >= maxRecordsThreshold)
                    //{
                    //    ClearData();
                    //}
                }
                if (flowDataList.Count == maxRecordsThreshold)
                {
                    //// 弹出询问对话框
                    //DialogResult result = MessageBox.Show("存储数据达1000条，是否要将存储的数据导出为Excel表格？", "导出数据", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    //if (result == DialogResult.OK)
                    //{
                    //    // 用户点击了确认按钮，执行导出操作
                    //    ExportDataToExcel();
                    //}
                    //Com.isRecording = false;
                    //// 如果用户点击取消按钮，什么都不做，对话框会自动关闭
                }
            }
            else
            {
                Com.isRecording = false;
                flowDataList.Clear();
                MessageBox.Show("串口已关闭，数据采集终止！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 清理数据
        //private void ClearData()
        //{
        //    // 清空已存储的数据
        //    flowDataList.Clear();
        //    // 可以在此处添加其他清理操作，例如释放资源等
        //}

        private void ExportDataToExcel()
        {
            if (flowDataList.Count > 0)
            {
                // 创建Excel工作簿
                IWorkbook workbook = new XSSFWorkbook();
                ISheet sheet = workbook.CreateSheet("FlowData");

                // 创建表头
                IRow headerRow = sheet.CreateRow(0);
                headerRow.CreateCell(0).SetCellValue("Time");
                headerRow.CreateCell(1).SetCellValue("Flow Value");
                headerRow.CreateCell(2).SetCellValue("Flow Unit");

                // 遍历列表并创建数据行
                for (int i = 0; i < flowDataList.Count; i++)
                {
                    IRow dataRow = sheet.CreateRow(i + 1);
                    dataRow.CreateCell(0).SetCellValue(flowDataList[i].Item1);
                    dataRow.CreateCell(1).SetCellValue(flowDataList[i].Item2);
                    dataRow.CreateCell(2).SetCellValue(flowDataList[i].Item3);
                }

                // 使用 SaveFileDialog 获取用户选择的文件路径
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveFileDialog.Title = "导出流量数据";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 保存Excel文件
                    using (FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write))
                    {
                        workbook.Write(fileStream);
                    }

                    // 清空已导出的数据
                    //flowDataList.Clear();//数据全部导出后才会清除
                    //Com.isRecording = false;//采集数据结束
                }
            }
            else
            {
                // 提示用户没有数据可导出
                MessageBox.Show("没有数据可导出", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 导出为Excel按钮点击事件
        private void barExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Com.bIsOpen)
            {
                //if (Com.isRecording)
                //{
                    try
                    { 
                        Com.isRecording = false;//正在采集标志置位
                                            //MessageBox.Show("数据采集已关闭！", "提示");
                        if (flowDataList.Count > 0)
                        {
                            // 弹出询问对话框
                            DialogResult result = MessageBox.Show("数据采集已关闭，是否要将存储的数据导出为Excel表格？", "导出数据", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                            if (result == DialogResult.OK)
                            {
                                // 用户点击了确认按钮，执行导出操作
                                ExportDataToExcel();
                            }
                            // 如果用户点击取消按钮，什么都不做，对话框会自动关闭
                            flowDataList.Clear();
                        }
                        else
                        {
                            // 提示用户没有数据可导出
                            MessageBox.Show("没有数据可以导出", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "告警", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                //}
                //else
                //{
                //    MessageBox.Show("数据采集未开始！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
            }
            else
                MessageBox.Show("通讯端口未打开！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


    }
}

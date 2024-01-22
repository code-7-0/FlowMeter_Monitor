using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows;
using System.Threading;

using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Common
{
    public class Com
    {
        // 主窗口名称
        public static String WindowName = "D08-1F  1.2.2";
        // 端口参数
        public static int comPort = 2;
        public static int comBaud = 5;
        public static int comParity = 0;

        //流量采集参数
        public static bool isRecording = false; // 用于标识是否正在记录数据
        public static UInt16 CollectInterval = 0;//采样周期
        public static  UInt16 timercnt = 0;
        // 通讯故障计数
        public static int comErrCnt = 0;

        // 串口是否打开标志
        public static bool bIsOpen = false;

        public static int devAddr = 1;


        // 通讯同步锁
        private static Object comLock = new Object();

        // 声明 API 函数
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern IntPtr SendMessage(int hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern int FindWindow(string lpClassName, string lpWindowName);

        // 定义消息常数
        public const int CUSTOM_MESSAGE = 0X400 + 2;//自定义消息

        // 读寄存器基地址
        public const int MB_R_STDINFO_BASEADDR     = 10000;
        public const int MB_R_DEBUGINFO_BASEADDR   = 10100;
        public const int MB_R_SYSCALIB_BASEADDR = 10200;
        // 写寄存器及地址
        public const int MB_W_WORKMODE_BASEADDR = 10000;
        public const int MB_W_FLOW_BASEADDR = 10001;
        public const int MB_W_SYSCFG_BASEADDR = 10020;
        public const int MB_W_DEVADDR_BASEADDR = 10043;

        public const int MB_W_DAC1_VSET1_BASEADDR = 10200;
        public const int MB_W_DAC1_VOUT1_BASEADDR = 10201;
        public const int MB_W_DAC1_VSET2_BASEADDR = 10202;
        public const int MB_W_DAC1_VOUT2_BASEADDR = 10203;

        public const int MB_W_DAC2_VSET1_BASEADDR = 10210;
        public const int MB_W_DAC2_VOUT1_BASEADDR = 10211;
        public const int MB_W_DAC2_VSET2_BASEADDR = 10212;
        public const int MB_W_DAC2_VOUT2_BASEADDR = 10213;

        public const int MB_W_ADC1_V1_BASEADDR = 10220;
        public const int MB_W_ADC1_V2_BASEADDR = 10222;

        public const int MB_W_ADC2_V1_BASEADDR = 10230;
        public const int MB_W_ADC2_V2_BASEADDR = 10232;


        // 通讯故障码
        public const int  COMERR_NONE  = 0;
	    public const int  COMERR_CRC   = 1;
	    public const int  COMERR_NOANS = 2;
	    public const int  COMERR_FRAME = 3;
        public const int  COMERR_PORT  = 4;
        public const int  COM_DIR_RCV = 10;


        private static byte[] m_cWriteBuff = new byte[500];
        public static byte[] m_cDispData = new byte[500];

        public static T_BaseInfo tBaseInfo;
        public static T_DebugInfo tDebugInfo;
        public static T_SysCalib tSysCalib;

        public static bool bComErr = false;


        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct T_BaseInfo
        {
         // 基础数据
            public byte Addr;
            public byte Func;
            public byte Len;

            public UInt16 WorkMode; // 工作模式
            public UInt32 FlowSet;  // 流量设定
            public UInt32 FlowFb;   // 流量反馈
            public Int16  Temp;     // 温度

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 11)]
            public UInt16[] Rsvd1;  // 保留

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public UInt16[] Version;// 固件版本

        // 配置参数
            public UInt16 FlowUnit;   // 流量单位
            public UInt32 FlowRange;  // 流量范围
            public UInt16 CtrlSource;
            public UInt16 FlowOutMode;
            public UInt16 FlowInMode;
            public UInt32 fDac1K;
            public UInt32 fDac1B;

            public UInt32 fDac2K;
            public UInt32 fDac2B;

            public UInt32 fAdc1K;
            public UInt32 fAdc1B;

            public UInt32 fAdc2K;
            public UInt32 fAdc2B;           

            public Int16 crc;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct T_DebugInfo
        {
            // 基础数据
            public byte Addr;
            public byte Func;
            public byte Len;

            public UInt32 FlowSetInt; 
            public UInt32 FlowSetExt;
            public UInt16 usDacCal;         // DAC校准标志
            public Int16  Uadc1;            // ADC通道1采集的电压--校准值(单位V 放大1000倍 如2500表示2.5V)
            public Int16 Uadc1Org;         // ADC通道1采集的电压--未校准值(单位V 放大1000倍 如2500表示2.5V)
            public Int16  Uadc2;            // ADC通道2采集的电压--校准值(单位V 放大1000倍 如2500表示2.5V)
            public Int16  Uadc2Org;         // ADC通道2采集的电压--未校准值(单位V 放大1000倍 如2500表示2.5V)
            public UInt16 Adc1Ad;
            public UInt16 Adc2Ad;

            public Int16 crc;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct T_SysCalib
        {
            // 基础数据
            public byte Addr;
            public byte Func;
            public byte Len;

            // DAC通道1
            public UInt16 usDac1Vset1;        // 01--
            public UInt16 usDac1Vout1;        // 02
            public UInt16 usDac1Vset2;        // 03--
            public UInt16 usDac1Vout2;        // 04
            public UInt16 usDac1Vset1Rdy;     // 05
            public UInt16 usDac1Vout1Rdy;     // 06
            public UInt16 usDac1Vset2Rdy;     // 07
            public UInt16 usDac1Vout2Rdy;     // 08
            public UInt16 usDac1Step;         // 09
            public UInt16 Rsvd1;

            // DACÍ通道2
            public UInt16 usDac2Vset1;        // 01--
            public UInt16 usDac2Vout1;        // 02
            public UInt16 usDac2Vset2;        // 03--
            public UInt16 usDac2Vout2;        // 04
            public UInt16 usDac2Vset1Rdy;     // 05
            public UInt16 usDac2Vout1Rdy;     // 06
            public UInt16 usDac2Vset2Rdy;     // 07
            public UInt16 usDac2Vout2Rdy;     // 08
            public UInt16 usDac2Step;         // 09
            public UInt16 Rsvd2;

            // ADC通道1
            public UInt16 usAdc1Vref1;
            public UInt16 usAdc1Vmea1;
            public UInt16 usAdc1Vref2;
            public UInt16 usAdc1Vmea2;
            public UInt16 usAdc1Value1Rdy;
            public UInt16 usAdc1Value2Rdy;
            public UInt32 f5;
            public UInt32 f6;

            // ADC通道2
            public UInt16 usAdc2Vref1;
            public UInt16 usAdc2Vmea1;
            public UInt16 usAdc2Vref2;
            public UInt16 usAdc2Vmea2;
            public UInt16 usAdc2Value1Rdy;
            public UInt16 usAdc2Value2Rdy;
            public UInt32 f7;
            public UInt32 f8;

            public Int16 crc;
        }

        public static readonly String[] portTable ={
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9"};

        public static readonly int[] baudTable ={
            300,
            600,
            1200,
            2400,
            4800,
            9600,
            19200,
            38400,
            43000,
            56000,
            57600,
            115200};

        static SerialPort sp;// = new SerialPort();
        public static bool recOK  = false;
        public static int recLen = 0;

        public Com()
        {
        }

        public static bool Open(int portInx,int baudInx)
        {
            sp = new SerialPort();
            // 端口号
            sp.PortName = portTable[portInx];

            // 波特率
            sp.BaudRate = baudTable[baudInx];

            // 数据位
            sp.DataBits = 8;

            // 停止位
            sp.StopBits = StopBits.One;

            // 校验位
            sp.Parity = Parity.None;

            try
            {
                sp.Open();
                return true;
            }
            catch(Exception)
            {
                //MessageBox.Show("串口无效或已被占用！", "提示");
                return false;
            }
        }

        public static void Close()
        {
            if (null != sp)
            {
                sp.Close();
            }
            
        }

        public static bool IsOpen()
        {
            if (null != sp)
            {
                return sp.IsOpen;
            }
            else
            {
                return false;
            }
            
        }

        //向窗体发送消息的函数
        public static void SendMsgToMainForm(int MSG, int msgLen, int msgFlag)
        {
            try
            {
                int WINDOW_HANDLER = FindWindow(null, WindowName);
                if (WINDOW_HANDLER == 0)
                {
                    throw new Exception("Could not find Main window!");
                }

                SendMessage(WINDOW_HANDLER, CUSTOM_MESSAGE, new IntPtr(msgLen), new IntPtr(msgFlag));
            }
            catch { }

        }

        public static void Com_SendFrame(Byte[] sndBuf, Int32 sndLen)
        {
            try
            {
                sp.DiscardInBuffer();
                sp.Write(sndBuf, 0, sndLen);
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
           

            // 消息发送至主窗口
            Array.Copy(sndBuf, m_cDispData, sndLen);
            SendMsgToMainForm(CUSTOM_MESSAGE, sndLen, COM_DIR_RCV);
        }

        private static int Com_ReceiveFrame(byte[] rcvBuf, int expLen)
        {
            int timeStart;
            int ptr = 0;

            //sp.DiscardInBuffer();
            timeStart = System.Environment.TickCount;
            while ((System.Environment.TickCount - timeStart) < 2000)
            {
                try
                {
                    if (sp.BytesToRead > 0)
                    {
                        int num;
                        num = sp.BytesToRead;
                        if ((ptr + num) > rcvBuf.Length)
                        {
                            sp.DiscardInBuffer();
                            Com.bComErr = true;
                            return COMERR_FRAME;
                        }

                        sp.Read(rcvBuf, ptr, num);
                        ptr += num;
                        if (ptr >= expLen)
                        {
                            if (0 == Util.Crc16(rcvBuf, expLen))
                            {
                                Array.Copy(rcvBuf, m_cDispData, ptr);
                                SendMsgToMainForm(CUSTOM_MESSAGE, ptr, COMERR_NONE);
                                Com.bComErr = false;
                                return COMERR_NONE;
                            }
                            else
                            {
                                Array.Copy(rcvBuf, m_cDispData, ptr);
                                SendMsgToMainForm(CUSTOM_MESSAGE, ptr, COMERR_CRC);
                                Com.bComErr = true;
                                return COMERR_CRC;
                            }

                        }
                        else
                        {
                            Thread.Sleep(10);
                        }

                    }
                }
                catch (System.Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
                
            }
            if (0 == ptr)
            {
                SendMsgToMainForm(CUSTOM_MESSAGE, ptr, COMERR_NOANS);
                Com.bComErr = true;
                return COMERR_NOANS;
            }
            else
            {
                Array.Copy(rcvBuf, m_cDispData, ptr);
                SendMsgToMainForm(CUSTOM_MESSAGE, ptr, COMERR_FRAME);
                Com.bComErr = true;
                return COMERR_FRAME;
            }
        }

        private static int Com_SendCmd(byte[] sndBuf, int sndLen, byte[] rcvBuf, int expLen)
        {
            int res;
            lock (comLock)
            {
                if (true == bIsOpen)
                {
                    // 发送数据
                    Com_SendFrame(sndBuf, sndLen);

                    // 接受应答数据
                    res = Com_ReceiveFrame(rcvBuf, expLen);

                    if(COMERR_NONE != res)
                    {
                        comErrCnt++;
                    }
                    Thread.Sleep(100);
                    return res;
                }
                else
                {
                    Thread.Sleep(1000);
                    SendMsgToMainForm(CUSTOM_MESSAGE, 0, COMERR_PORT);
                    return COMERR_PORT;
                }
            }
        }

        public static int Query_StdInfo(byte[] rcvBuf)
        {
            int ptr = 0;
            UInt16 crc;
            int nLenTmp,nRegNum;
            
            byte[] wBuf = new byte[200];

            T_BaseInfo info = new T_BaseInfo();
            nLenTmp = Marshal.SizeOf(info);
            nRegNum = (nLenTmp - 5) / 2;

            // 地址
            wBuf[ptr++] = (byte)devAddr;
            // 功能码
            wBuf[ptr++] = 0x03;
            // 寄存器起始地址
            wBuf[ptr++] = (MB_R_STDINFO_BASEADDR >> 8) & 0x00FF;
            wBuf[ptr++] = MB_R_STDINFO_BASEADDR & 0x00FF;
            // 寄存器数量
            wBuf[ptr++] = (byte)((nRegNum >> 8) & 0x00FF);
            wBuf[ptr++] = (byte)(nRegNum & 0x00FF);
            // CRC
            crc = Util.Crc16(wBuf, ptr);
            wBuf[ptr++] = (byte)(crc & 0x00FF);
            wBuf[ptr++] = (byte)((crc >> 8) & 0x00FF);

            return Com_SendCmd(wBuf, ptr, rcvBuf, nLenTmp);
        }

        public static int Query_DebugInfo(byte[] rcvBuf)
        {
            int ptr = 0;
            UInt16 crc;
            int nLenTmp, nRegNum;

            byte[] wBuf = new byte[200];

            T_DebugInfo info = new T_DebugInfo();
            nLenTmp = Marshal.SizeOf(info);
            nRegNum = (nLenTmp - 5) / 2;

            // 地址
            wBuf[ptr++] = (byte)devAddr;
            // 功能码
            wBuf[ptr++] = 0x03;
            // 寄存器起始地址
            wBuf[ptr++] = (MB_R_DEBUGINFO_BASEADDR >> 8) & 0x00FF;
            wBuf[ptr++] = MB_R_DEBUGINFO_BASEADDR & 0x00FF;
            // 寄存器数量
            wBuf[ptr++] = (byte)((nRegNum >> 8) & 0x00FF);
            wBuf[ptr++] = (byte)(nRegNum & 0x00FF);
            // CRC
            crc = Util.Crc16(wBuf, ptr);
            wBuf[ptr++] = (byte)(crc & 0x00FF);
            wBuf[ptr++] = (byte)((crc >> 8) & 0x00FF);

            return Com_SendCmd(wBuf, ptr, rcvBuf, nLenTmp);
        }

        public static int Query_SysCalib(byte[] rcvBuf)
        {
            int ptr = 0;
            UInt16 crc;
            int nLenTmp, nRegNum;

            byte[] wBuf = new byte[200];

            T_SysCalib info = new T_SysCalib();
            nLenTmp = Marshal.SizeOf(info);
            nRegNum = (nLenTmp - 5) / 2;

            // 地址
            wBuf[ptr++] = (byte)devAddr;
            // 功能码
            wBuf[ptr++] = 0x03;
            // 寄存器起始地址
            wBuf[ptr++] = (MB_R_SYSCALIB_BASEADDR >> 8) & 0x00FF;
            wBuf[ptr++] = MB_R_SYSCALIB_BASEADDR & 0x00FF;
            // 寄存器数量
            wBuf[ptr++] = (byte)((nRegNum >> 8) & 0x00FF);
            wBuf[ptr++] = (byte)(nRegNum & 0x00FF);
            // CRC
            crc = Util.Crc16(wBuf, ptr);
            wBuf[ptr++] = (byte)(crc & 0x00FF);
            wBuf[ptr++] = (byte)((crc >> 8) & 0x00FF);

            return Com_SendCmd(wBuf, ptr, rcvBuf, nLenTmp);
        }

        public static int Set_Flow(UInt16[] flow)
        {
            int ptr = 0;
            UInt16 crc;
            int nLenTmp, nRegNum;


            byte[] wBuf = new byte[200];
            byte[] rBuf = new byte[100];
            nLenTmp = 8;
            nRegNum = 2;

            // 地址
            wBuf[ptr++] = (byte)devAddr;
            // 功能码
            wBuf[ptr++] = 0x10;
            // 寄存器起始地址
            wBuf[ptr++] = (byte)(((MB_W_FLOW_BASEADDR) >> 8) & 0x00FF);
            wBuf[ptr++] = (byte)((MB_W_FLOW_BASEADDR) & 0x00FF);
            // 寄存器数量
            wBuf[ptr++] = (byte)((nRegNum >> 8) & 0x00FF);
            wBuf[ptr++] = (byte)(nRegNum & 0x00FF);
            // 字节数
            wBuf[ptr++] = (byte)(nRegNum * 2);
            // 数据
            for (int i = 0; i < nRegNum; i++)
            {
                wBuf[ptr++] = (byte)((flow[i] >> 8) & 0x00FF);
                wBuf[ptr++] = (byte)(flow[i] & 0x00FF);
            }

            // CRC
            crc = Util.Crc16(wBuf, ptr);
            wBuf[ptr++] = (byte)(crc & 0x00FF);
            wBuf[ptr++] = (byte)((crc >> 8) & 0x00FF);

            return Com_SendCmd(wBuf, ptr, rBuf, nLenTmp);
        }

        public static int Set_WorkMode(UInt16 mode)
        {
            int ptr = 0;
            UInt16 crc;
            int nLenTmp, nRegNum;


            byte[] wBuf = new byte[200];
            byte[] rBuf = new byte[100];
            nLenTmp = 8;
            nRegNum = 1;

            // 地址
            wBuf[ptr++] = (byte)devAddr;
            // 功能码
            wBuf[ptr++] = 0x10;
            // 寄存器起始地址
            wBuf[ptr++] = (byte)(((MB_W_WORKMODE_BASEADDR) >> 8) & 0x00FF);
            wBuf[ptr++] = (byte)((MB_W_WORKMODE_BASEADDR) & 0x00FF);
            // 寄存器数量
            wBuf[ptr++] = (byte)((nRegNum >> 8) & 0x00FF);
            wBuf[ptr++] = (byte)(nRegNum & 0x00FF);
            // 字节数
            wBuf[ptr++] = (byte)(nRegNum * 2);
            // 数据
            wBuf[ptr++] = (byte)((mode >> 8) & 0x00FF);
            wBuf[ptr++] = (byte)(mode & 0x00FF);
           
            // CRC
            crc = Util.Crc16(wBuf, ptr);
            wBuf[ptr++] = (byte)(crc & 0x00FF);
            wBuf[ptr++] = (byte)((crc >> 8) & 0x00FF);

            return Com_SendCmd(wBuf, ptr, rBuf, nLenTmp);
        }

        public static int Set_SysCfg(UInt16[] cfgBuf)
        {
            int ptr = 0;
            UInt16 crc;
            int nLenTmp,nRegNum;

            byte[] wBuf = new byte[200];
            byte[] rBuf = new byte[100];
            nLenTmp = 8;
            nRegNum = 6;

            // 地址
            wBuf[ptr++] = (byte)devAddr;
            // 功能码
            wBuf[ptr++] = 0x10;
            // 寄存器起始地址
            wBuf[ptr++] = (byte)(((MB_W_SYSCFG_BASEADDR) >> 8) & 0x00FF);
            wBuf[ptr++] = (byte)((MB_W_SYSCFG_BASEADDR) & 0x00FF);
            // 寄存器数量
            wBuf[ptr++] = (byte)((nRegNum >> 8) & 0x00FF);
            wBuf[ptr++] = (byte)(nRegNum & 0x00FF);
            // 字节数
            wBuf[ptr++] = (byte)(nRegNum * 2);
            // 数据
            for (int i = 0; i < nRegNum; i++)
            {
                wBuf[ptr++] = (byte)((cfgBuf[i] >> 8) & 0x00FF);
                wBuf[ptr++] = (byte)(cfgBuf[i] & 0x00FF);
            }
            // CRC
            crc = Util.Crc16(wBuf, ptr);
            wBuf[ptr++] = (byte)(crc & 0x00FF);
            wBuf[ptr++] = (byte)((crc >> 8) & 0x00FF);

            return Com_SendCmd(wBuf, ptr, rBuf, nLenTmp);
        }


        public static int Set_CalibValue(UInt16 addr,UInt16 val)
        {
            int ptr = 0;
            UInt16 crc;
            int nLenTmp, nRegNum;


            byte[] wBuf = new byte[200];
            byte[] rBuf = new byte[100];
            nLenTmp = 8;
            nRegNum = 1;

            // 地址
            wBuf[ptr++] = (byte)devAddr;
            // 功能码
            wBuf[ptr++] = 0x10;
            // 寄存器起始地址
            wBuf[ptr++] = (byte)(((addr) >> 8) & 0x00FF);
            wBuf[ptr++] = (byte)((addr) & 0x00FF);
            // 寄存器数量
            wBuf[ptr++] = (byte)((nRegNum >> 8) & 0x00FF);
            wBuf[ptr++] = (byte)(nRegNum & 0x00FF);
            // 字节数
            wBuf[ptr++] = (byte)(nRegNum * 2);
            // 数据
            wBuf[ptr++] = (byte)((val >> 8) & 0x00FF);
            wBuf[ptr++] = (byte)(val & 0x00FF);

            // CRC
            crc = Util.Crc16(wBuf, ptr);
            wBuf[ptr++] = (byte)(crc & 0x00FF);
            wBuf[ptr++] = (byte)((crc >> 8) & 0x00FF);

            return Com_SendCmd(wBuf, ptr, rBuf, nLenTmp);
        }

        public static int Set_DevAddr(UInt16 addr)
        {
            int ptr = 0;
            UInt16 crc;
            int nLenTmp, nRegNum;


            byte[] wBuf = new byte[200];
            byte[] rBuf = new byte[100];
            nLenTmp = 8;
            nRegNum = 1;

            // 地址
            wBuf[ptr++] = 0;
            // 功能码
            wBuf[ptr++] = 0x10;
            // 寄存器起始地址
            wBuf[ptr++] = (byte)(((MB_W_DEVADDR_BASEADDR) >> 8) & 0x00FF);
            wBuf[ptr++] = (byte)((MB_W_DEVADDR_BASEADDR) & 0x00FF);
            // 寄存器数量
            wBuf[ptr++] = (byte)((nRegNum >> 8) & 0x00FF);
            wBuf[ptr++] = (byte)(nRegNum & 0x00FF);
            // 字节数
            wBuf[ptr++] = (byte)(nRegNum * 2);
            // 数据
            wBuf[ptr++] = (byte)((addr >> 8) & 0x00FF);
            wBuf[ptr++] = (byte)(addr & 0x00FF);
            

            // CRC
            crc = Util.Crc16(wBuf, ptr);
            wBuf[ptr++] = (byte)(crc & 0x00FF);
            wBuf[ptr++] = (byte)((crc >> 8) & 0x00FF);

            return Com_SendCmd(wBuf, ptr, rBuf, nLenTmp);
        }
    }


}

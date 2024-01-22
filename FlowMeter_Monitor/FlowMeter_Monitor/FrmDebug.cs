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
using System.Threading;
using Common;

namespace FlowMeter_Monitor
{
    public partial class FrmDebug : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dtDebugInfo;

        private delegate void UpdateControl();
        UpdateControl updateControl;

        private void Update_Thread()
        {
            while(true)
            {
                try
                {
                    this.Invoke(updateControl);
                }
                catch
                { }
                
                Thread.Sleep(100);
                
            }
        }
        public FrmDebug()
        {
            InitializeComponent();
        }

        private void FrmDebug_Load(object sender, EventArgs e)
        {
            // 窗口最大化按钮
            this.MaximizeBox = false;

            dtDebugInfo = new DataTable();
            dtDebugInfo.Columns.Add("Name",typeof(string));
            dtDebugInfo.Columns.Add("Value", typeof(string));
            for(int i=0;i<9;i++)
            {
                dtDebugInfo.Rows.Add();
            }

            gcDebug.DataSource = dtDebugInfo;

            updateControl = new UpdateControl(Update_UI);

            Thread t = new Thread(Update_Thread);
            t.IsBackground = true;
            t.Start();
        }

        private void Update_UI()
        {
            float fTmp;
            UInt16 usTmp;
            Int16 sTmp;

            // 更新数据表
            for (int i = 0; i < 9; i++)
            {
                DataRow dr = dtDebugInfo.Rows[i];
                dr.BeginEdit();

                switch(i)
                {
                    case 0:
                        dr["Name"] = "Uadc1";
                        sTmp = (Int16)Util.WordSwap((UInt16)Com.tDebugInfo.Uadc1);
                        fTmp = sTmp * 0.001f;
                        dr["Value"] = string.Format("{0:f3}", fTmp);
                        break;

                    case 1:
                        dr["Name"] = "Uadc2";
                        sTmp = (Int16)Util.WordSwap((UInt16)Com.tDebugInfo.Uadc2);
                        fTmp = sTmp * 0.001f;
                        dr["Value"] = string.Format("{0:f3}", fTmp); ;
                        break;

                    case 2:
                        dr["Name"] = "Uadc1Org";
                        sTmp = (Int16)Util.WordSwap((UInt16)Com.tDebugInfo.Uadc1Org);
                        fTmp = sTmp * 0.001f;
                        dr["Value"] = string.Format("{0:f3}", fTmp); ;
                        break;

                    case 3:
                        dr["Name"] = "Uadc2Org";
                        sTmp = (Int16)Util.WordSwap((UInt16)Com.tDebugInfo.Uadc2Org);
                        fTmp = sTmp * 0.001f;
                        dr["Value"] = string.Format("{0:f3}", fTmp); ;
                        break;

                    case 4:
                        dr["Name"] = "DacCal";
                        usTmp = Util.WordSwap((UInt16)Com.tDebugInfo.usDacCal);
                        dr["Value"] = usTmp.ToString(); ;
                        break;

                    case 5:
                        dr["Name"] = "FlowSetInt";
                        fTmp = (Int16)Util.IntToFloat(Com.tDebugInfo.FlowSetInt);
                        dr["Value"] = string.Format("{0:f2}", fTmp); ;
                        break;

                    case 6:
                        dr["Name"] = "FlowSetExt";
                        fTmp = Util.IntToFloat(Com.tDebugInfo.FlowSetExt);
                        dr["Value"] = string.Format("{0:f2}", fTmp); ;
                        break;

                    case 7:
                        dr["Name"] = "Adc1Ad";
                        usTmp = Util.WordSwap((UInt16)Com.tDebugInfo.Adc1Ad);
                        dr["Value"] = usTmp.ToString();
                        break;
                    case 8:
                        dr["Name"] = "Adc2Ad";
                        usTmp = Util.WordSwap((UInt16)Com.tDebugInfo.Adc2Ad);
                        dr["Value"] = usTmp.ToString();
                        break;
            

                    default:
                        break;

                }
                dr.EndEdit();
                dr.AcceptChanges();
            }

        }

        private void gvDebug_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
    
    }
}
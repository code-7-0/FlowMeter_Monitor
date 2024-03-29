﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Common
{
    public class Util
    {
        private static readonly byte[] CRCHi = {
	        0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 
	        0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 
	        0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 
	        0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 
	        0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 
	        0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 
	        0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 
	        0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 
	        0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 
	        0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 
	        0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 
	        0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 
	        0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 
	        0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 
	        0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
	        0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 
	        0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 
	        0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 
	        0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 
	        0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 
	        0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 
	        0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 
	        0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 
	        0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 
	        0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 
	        0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 
	        0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 
	        0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 
	        0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 
	        0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
	        0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 
	        0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40
        };

        private static readonly byte[] CRCLo = {
	        0x00, 0xC0, 0xC1, 0x01, 0xC3, 0x03, 0x02, 0xC2, 
	        0xC6, 0x06, 0x07, 0xC7, 0x05, 0xC5, 0xC4, 0x04, 
	        0xCC, 0x0C, 0x0D, 0xCD, 0x0F, 0xCF, 0xCE, 0x0E, 
	        0x0A, 0xCA, 0xCB, 0x0B, 0xC9, 0x09, 0x08, 0xC8, 
	        0xD8, 0x18, 0x19, 0xD9, 0x1B, 0xDB, 0xDA, 0x1A, 
	        0x1E, 0xDE, 0xDF, 0x1F, 0xDD, 0x1D, 0x1C, 0xDC, 
	        0x14, 0xD4, 0xD5, 0x15, 0xD7, 0x17, 0x16, 0xD6, 
	        0xD2, 0x12, 0x13, 0xD3, 0x11, 0xD1, 0xD0, 0x10, 
	        0xF0, 0x30, 0x31, 0xF1, 0x33, 0xF3, 0xF2, 0x32, 
	        0x36, 0xF6, 0xF7, 0x37, 0xF5, 0x35, 0x34, 0xF4, 
	        0x3C, 0xFC, 0xFD, 0x3D, 0xFF, 0x3F, 0x3E, 0xFE, 
	        0xFA, 0x3A, 0x3B, 0xFB, 0x39, 0xF9, 0xF8, 0x38, 
	        0x28, 0xE8, 0xE9, 0x29, 0xEB, 0x2B, 0x2A, 0xEA, 
	        0xEE, 0x2E, 0x2F, 0xEF, 0x2D, 0xED, 0xEC, 0x2C, 
	        0xE4, 0x24, 0x25, 0xE5, 0x27, 0xE7, 0xE6, 0x26,
	        0x22, 0xE2, 0xE3, 0x23, 0xE1, 0x21, 0x20, 0xE0, 
	        0xA0, 0x60, 0x61, 0xA1, 0x63, 0xA3, 0xA2, 0x62, 
	        0x66, 0xA6, 0xA7, 0x67, 0xA5, 0x65, 0x64, 0xA4, 
	        0x6C, 0xAC, 0xAD, 0x6D, 0xAF, 0x6F, 0x6E, 0xAE, 
	        0xAA, 0x6A, 0x6B, 0xAB, 0x69, 0xA9, 0xA8, 0x68, 
	        0x78, 0xB8, 0xB9, 0x79, 0xBB, 0x7B, 0x7A, 0xBA, 
	        0xBE, 0x7E, 0x7F, 0xBF, 0x7D, 0xBD, 0xBC, 0x7C, 
	        0xB4, 0x74, 0x75, 0xB5, 0x77, 0xB7, 0xB6, 0x76, 
	        0x72, 0xB2, 0xB3, 0x73, 0xB1, 0x71, 0x70, 0xB0, 
	        0x50, 0x90, 0x91, 0x51, 0x93, 0x53, 0x52, 0x92, 
	        0x96, 0x56, 0x57, 0x97, 0x55, 0x95, 0x94, 0x54, 
	        0x9C, 0x5C, 0x5D, 0x9D, 0x5F, 0x9F, 0x9E, 0x5E, 
	        0x5A, 0x9A, 0x9B, 0x5B, 0x99, 0x59, 0x58, 0x98, 
	        0x88, 0x48, 0x49, 0x89, 0x4B, 0x8B, 0x8A, 0x4A, 
	        0x4E, 0x8E, 0x8F, 0x4F, 0x8D, 0x4D, 0x4C, 0x8C,
	        0x44, 0x84, 0x85, 0x45, 0x87, 0x47, 0x46, 0x86, 
	        0x82, 0x42, 0x43, 0x83, 0x41, 0x81, 0x80, 0x40
        };

        public static ushort Crc16(byte[] buffer, int dataLen)
        {
            byte crcHi = 0xff; // 高位初始化
            byte crcLo = 0xff; // 低位初始化
            int i;

            for (i = 0; i < dataLen; i++)
            {
                int crcIndex = crcHi ^ buffer[i]; //查找crc表值
                crcHi = (byte)(crcLo ^ CRCHi[crcIndex]);
                crcLo = CRCLo[crcIndex];
            }
            return (ushort)(crcHi | crcLo << 8);
        }

        public static byte LRC(byte[] buf, int length)
        {
            uint iCount = 0;
            byte lrcValue = 0x00;

            for (iCount = 0; iCount < length; iCount++)
            {
                lrcValue = (byte)(lrcValue + buf[iCount]);
            }
            return ((byte)((~lrcValue) + 1));
        }

        public static void Delay(int milliSecond)
        {
            int start = Environment.TickCount;
            while (Math.Abs(Environment.TickCount - start) < milliSecond)//毫秒
            {
                Application.DoEvents();//可执行某无聊的操作
            }
        }

        //将结构体类型转换为byte
        public static byte[] StructToBytes(object structObj, int size)
        {
            byte[] bytes = new byte[size];
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            //将结构体拷到分配好的内存空间
            Marshal.StructureToPtr(structObj, structPtr, false);
            //从内存空间拷贝到byte 数组
            Marshal.Copy(structPtr, bytes, 0, size);
            //释放内存空间
            Marshal.FreeHGlobal(structPtr);
            return bytes;

        }

        //将Byte转换为结构体类型
        public static object ByteToStruct(byte[] bytes, Type type)
        {
            int size = Marshal.SizeOf(type);
            if (size > bytes.Length)
            {
                return null;
            }
            //分配结构体内存空间
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            //将byte数组拷贝到分配好的内存空间
            Marshal.Copy(bytes, 0, structPtr, size);
            //将内存空间转换为目标结构体
            object obj = Marshal.PtrToStructure(structPtr, type);
            //释放内存空间
            Marshal.FreeHGlobal(structPtr);
            return obj;
        }

        public static float IntToFloat(UInt32 val)
        {
            UInt16 sTmp;
            UInt32 uiTmp;
            byte[] buf = new byte[4];

            uiTmp = 0;
            sTmp = (UInt16)(val >> 0);
            sTmp = (UInt16)(((sTmp >> 8) & 0x00FF) + ((sTmp << 8) & 0xFF00));
            uiTmp += (UInt32)sTmp;
            sTmp = (UInt16)(val >> 16);
            sTmp = (UInt16)(((sTmp >> 8) & 0x00FF) + ((sTmp << 8) & 0xFF00));
            uiTmp += ((UInt32)sTmp << 16);
            buf[0] = (byte)uiTmp;
            buf[1] = (byte)(uiTmp >> 8);
            buf[2] = (byte)(uiTmp >> 16);
            buf[3] = (byte)(uiTmp >> 24);
            return BitConverter.ToSingle(buf, 0);
            
        }

        public static UInt16 WordSwap(UInt16 val)
        {
            return (UInt16)(((val >> 8) & 0x00FF) + ((val << 8) & 0xFF00));
        }

        public static string FloatTo4DigitString(float f)
        {
            string str;
            if (f >= 1000.0f)
            {
                str = string.Format("{0:f0}", f);
            }
            else if (f >= 100.0f)
            {
                str = string.Format("{0:f1}", f);
            }
            else if (f >= 10.0f)
            {
                str = string.Format("{0:f2}", f);
            }
            else
            {
                str = string.Format("{0:f3}", f);
            }

            return str;
        }
    }
}

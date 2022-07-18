using System;
using System.Collections.Generic;
using System.Text;

namespace Tools.DataConvert {

    public class StringLib
    {

        #region 将字节数组转换成字符串

        public static string GetStringFromByteArrayByBitConvert(byte[] source, int start, int count)
        {
            return BitConverter.ToString(source, start, count);
        }

        #endregion 将字节数组转换成字符串

        #region 将字节数组转换成带编码格式字符串

        public static string GetStringFromByteArray(byte[] source, int start, int count, Encoding encoding)
        {
            return encoding.GetString(ByteArrayLib.GetByteArray(source, start, count));
        }

        public static string GetStringFromByteArray(byte[] source, int start, int count)
        {
            return Encoding.ASCII.GetString(ByteArrayLib.GetByteArray(source, start, count));
        }

        #endregion 将字节数组转换成带编码格式字符串

        #region 将字节数组转换成带16进制字符串

        public static string GetHexStringFromByteArray(byte[] source, int start, int count, char segment = ' ')
        {
            byte[] b = ByteArrayLib.GetByteArray(source, start, count);

            StringBuilder sb = new StringBuilder();

            if (b.Length > 0)
            {
                foreach (var item in b)
                {
                    if (segment == 0) sb.Append(string.Format("{0:X2}", item));
                    else sb.Append(string.Format("{0:X2}{1}", item, segment));
                }
            }
            if (segment != 0 && sb.Length > 1 && sb[sb.Length - 1] == segment)
            {
                sb.Remove(sb.Length - 1, 1);
            }
            return sb.ToString();
        }

        public static string GetHexStringFromByteArray(byte[] source, char segment = ' ')
        {
            return GetHexStringFromByteArray(source, 0, source.Length, segment);
        }

        #endregion 将字节数组转换成带16进制字符串

        #region 将字节数组转换成西门子字符串

        public static string GetSiemensStringFromByteArray(byte[] source, int start, int length)
        {
            byte[] b = ByteArrayLib.GetByteArray(source, start, length + 2);

            int valid = b[1];
            if (valid > 0)
            {
                return Encoding.GetEncoding("GBK").GetString(ByteArrayLib.GetByteArray(b, 2, valid));
            }
            else
            {
                return "empty";
            }
        }

        #endregion 将字节数组转换成西门子字符串

        //=============================================

        #region 分割字符串

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="str1">被分割的字符串</param>
        /// <param name="char1">分割用字符</param>
        /// <returns></returns>
        public static string[] SplitString(string str1, char[] char1)
        {
            return str1.Split(char1, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="str1">被分割的字符串</param>
        /// <param name="str2">分割用字符串 空格分隔</param>
        /// <returns></returns>
        public static string[] SplitString(string str1, string str2)
        {
            List<string> slist = new List<string>();
            List<char> clist = new List<char>();
            slist.AddRange(str2.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            foreach (var item in slist)
            {
                clist.Add(Convert.ToChar(item));
            }
            return str1.Split(clist.ToArray(), StringSplitOptions.RemoveEmptyEntries);
        }

        #endregion 分割字符串

        #region StringToDateTime

        public static DateTime StringToDateTime(string str1)
        {
            return Convert.ToDateTime(str1);
        }

        #endregion StringToDateTime
    }
}
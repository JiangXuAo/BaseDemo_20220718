using System;
using System.Collections.Generic;
using System.Text;

namespace Tools.DataConvert {

    public class StringLib
    {

        #region ���ֽ�����ת�����ַ���

        public static string GetStringFromByteArrayByBitConvert(byte[] source, int start, int count)
        {
            return BitConverter.ToString(source, start, count);
        }

        #endregion ���ֽ�����ת�����ַ���

        #region ���ֽ�����ת���ɴ������ʽ�ַ���

        public static string GetStringFromByteArray(byte[] source, int start, int count, Encoding encoding)
        {
            return encoding.GetString(ByteArrayLib.GetByteArray(source, start, count));
        }

        public static string GetStringFromByteArray(byte[] source, int start, int count)
        {
            return Encoding.ASCII.GetString(ByteArrayLib.GetByteArray(source, start, count));
        }

        #endregion ���ֽ�����ת���ɴ������ʽ�ַ���

        #region ���ֽ�����ת���ɴ�16�����ַ���

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

        #endregion ���ֽ�����ת���ɴ�16�����ַ���

        #region ���ֽ�����ת�����������ַ���

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

        #endregion ���ֽ�����ת�����������ַ���

        //=============================================

        #region �ָ��ַ���

        /// <summary>
        /// �ָ��ַ���
        /// </summary>
        /// <param name="str1">���ָ���ַ���</param>
        /// <param name="char1">�ָ����ַ�</param>
        /// <returns></returns>
        public static string[] SplitString(string str1, char[] char1)
        {
            return str1.Split(char1, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// �ָ��ַ���
        /// </summary>
        /// <param name="str1">���ָ���ַ���</param>
        /// <param name="str2">�ָ����ַ��� �ո�ָ�</param>
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

        #endregion �ָ��ַ���

        #region StringToDateTime

        public static DateTime StringToDateTime(string str1)
        {
            return Convert.ToDateTime(str1);
        }

        #endregion StringToDateTime
    }
}
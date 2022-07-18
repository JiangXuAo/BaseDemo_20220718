using System;
using System.Collections.Generic;

namespace Tools.DataConvert
{

    /// <summary>
    /// λת����
    /// </summary>
    public class BitLib
    {

        #region �����ֽڼ������ȡָ��λ

        /// <summary>
        /// ����ָ���ֽڵ�ָ��λ
        /// </summary>
        /// <param name="b">�ֽ�</param>
        /// <param name="offset">ָ��λ��0-7��</param>
        /// <returns>�������</returns>
        public static bool GetBitFromByte(byte b, int offset)
        {
            if (offset >= 0 && offset <= 7)
            {
                return (b & (int)Math.Pow(2, offset)) != 0;
            }
            return false;
        }

        /// <summary>
        /// �����ֽ������е�ĳ���ֽ�ĳ��λ
        /// </summary>
        /// <param name="b">�ֽ�����</param>
        /// <param name="index">�ֽ�����</param>
        /// <param name="offset">ָ��λ��0-7��</param>
        /// <returns>�������</returns>
        public static bool GetBitFromByteArray(byte[] b, int index, int offset)
        {
            byte[] res = ByteArrayLib.GetByteArray(b, index, 1);

            return GetBitFromByte(res[0], offset);
        }

        #endregion �����ֽڼ������ȡָ��λ

        #region ���������ֽڼ������ȡָ��λ

        /// <summary>
        /// ���������ֽڵ�ָ��λ
        /// </summary>
        /// <param name="b">�����ֽ�</param>
        /// <param name="offset">ָ��λ��0-15��</param>
        /// <param name="reverse">�ֽ�˳��</param>
        /// <returns>�������</returns>
        public static bool GetBitFrom2Byte(byte[] b, int offset, bool reverse = false)
        {
            byte low = reverse ? b[0] : b[1];
            byte high = reverse ? b[1] : b[0];

            if (offset >= 0 && offset <= 7)
            {
                return GetBitFromByte(low, offset);
            }
            else if (offset >= 8 && offset <= 15)
            {
                return GetBitFromByte(high, offset - 8);
            }
            else
            {
                throw new Exception("��������Ϊ0-15֮��");
            }
        }

        /// <summary>
        /// �����ֽ�������ĳ2���ֽڵ�ָ��λ
        /// </summary>
        /// <param name="b">�ֽ�����</param>
        /// <param name="index">�ֽ�����</param>
        /// <param name="offset">ָ��λ��0-15��</param>
        /// <param name="reverse">�ֽ�˳��</param>
        /// <returns>�������</returns>
        public static bool GetBitFrom2ByteArray(byte[] b, int index, int offset, bool reverse = false)
        {
            byte[] res = ByteArrayLib.GetByteArray(b, index, 2);

            return GetBitFrom2Byte(res, offset, reverse);
        }

        #endregion ���������ֽڼ������ȡָ��λ

        #region ����һ��Short��UShort����ָ��λ

        /// <summary>
        /// ����һ��Short����ָ��λ
        /// </summary>
        /// <param name="val">short��ֵ</param>
        /// <param name="offset">ָ��λ��0-15��</param>
        /// <param name="reverse">�ֽ�˳��</param>
        /// <returns>�������</returns>
        public static bool GetBitFromShort(short val, int offset, bool reverse = false)
        {
            return GetBitFrom2Byte(BitConverter.GetBytes(val), offset, reverse);
        }

        /// <summary>
        /// ����һ��UShort����ָ��λ
        /// </summary>
        /// <param name="val">ushort��ֵ</param>
        /// <param name="offset">ָ��λ��0-15��</param>
        /// <param name="reverse">�ֽ�˳��</param>
        /// <returns>�������</returns>
        public static bool GetBitFromUShort(ushort val, int offset, bool reverse = false)
        {
            return GetBitFrom2Byte(BitConverter.GetBytes(val), offset, reverse);
        }

        #endregion ����һ��Short��UShort����ָ��λ

        #region �����ֽڼ����鷵�ز�������

        /// <summary>
        /// ��һ���ֽ�ת���ɲ�������
        /// </summary>
        /// <param name="b">�ֽ�</param>
        /// <param name="reverse">λ˳��</param>
        /// <returns>��������</returns>
        public static bool[] GetBitArrayFromByte(byte b, bool reverse = false)
        {
            bool[] array = new bool[8];

            if (reverse)
            {
                for (int i = 7; i >= 0; i--)
                { //����byte��ÿbit�����ж�
                    array[i] = (b & 1) == 1;   //�ж�byte�����һλ�Ƿ�Ϊ1����Ϊ1������true��������false
                    b = (byte)(b >> 1);       //��byte����һλ
                }
            }
            else
            {
                for (int i = 0; i <= 7; i++)
                { //����byte��ÿbit�����ж�
                    array[i] = (b & 1) == 1;   //�ж�byte�����һλ�Ƿ�Ϊ1����Ϊ1������true��������false
                    b = (byte)(b >> 1);       //��byte����һλ
                }
            }
            return array;
        }

        /// <summary>
        /// ��һ���ֽ�����ת���ɲ�������
        /// </summary>
        /// <param name="b">�ֽ�����</param>
        /// <param name="reverse">λ˳��</param>
        /// <returns>��������</returns>
        public static bool[] GetBitArrayFromByteArray(byte[] b, bool reverse = false)
        {
            List<bool> res = new List<bool>();

            foreach (var item in b)
            {
                res.AddRange(GetBitArrayFromByte(item, reverse));
            }
            return res.ToArray();
        }

        #endregion �����ֽڼ����鷵�ز�������

        //=============================================
    }
}
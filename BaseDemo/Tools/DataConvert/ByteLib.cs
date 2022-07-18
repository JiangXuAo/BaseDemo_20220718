using System;

namespace Tools.DataConvert {

    /// <summary>
    /// �����ֽ�ת����
    /// </summary>
    public class ByteLib
    {

        #region ��ȡĳ���ֽ�

        /// <summary>
        /// ���ֽ������н�ȡĳ���ֽ�
        /// </summary>
        /// <param name="source"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public static byte GetByteFromByteArray(byte[] source, int start)
        {
            return ByteArrayLib.GetByteArray(source, start, 1)[0];
        }

        #endregion ��ȡĳ���ֽ�

        #region ���ֽ���ĳ��λ��ֵ

        /// <summary>
        /// ���ֽ��е�ĳ��λ��ֵ
        /// </summary>
        /// <param name="value">ԭʼ�ֽ�</param>
        /// <param name="bit">λ</param>
        /// <param name="val">д����ֵ</param>
        /// <returns>�����ֽ�</returns>
        public static byte SetbitValue(byte value, int bit, bool val)
        {
            return val ? (byte)(value | (byte)Math.Pow(2, bit)) : (byte)(value & (byte)~(byte)Math.Pow(2, bit));
        }

        #endregion ���ֽ���ĳ��λ��ֵ

        //=============================================
    }
}
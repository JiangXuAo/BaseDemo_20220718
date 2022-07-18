using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Tools.DataConvert {

    public enum DataFormat {
        ABCD,
        BADC,
        CDAB,
        DCBA
    }

    public enum DataType {
        Bool,
        Byte,
        Short,
        UShort,
        Int,
        UInt,
        Float,
        Double,
        Long,
        ULong,
        String
    }

    /// <summary>
    /// �ֽ�����ת����
    /// </summary>
    public class ByteArrayLib {

        #region �Զ����ȡ�ֽ�����

        /// <summary>
        /// �Զ����ȡ�ֽ�����
        /// </summary>
        /// <param name="source">�ֽ�����</param>
        /// <param name="start">��ʼ�ֽ�</param>
        /// <param name="length">��ȡ����</param>
        /// <returns>�ֽ�����</returns>
        public static byte[] GetByteArray(byte[] source, int start, int length) {
            byte[] Res = new byte[length];
            if (source != null && start >= 0 && length > 0 && source.Length >= (start + length)) {
                Array.Copy(source, start, Res, 0, length);
                return Res;
            } else {
                return null;
            }
        }

        #endregion �Զ����ȡ�ֽ�����

        public static byte[] ReplaceByteArray(byte[] source, int start, byte[] value) {
            for (int i = 0; i < value.Length; i++) {
                source[start + i] = value[i];
            }
            return source;
        }

        #region �Զ����ȡ2���ֽ�

        /// <summary>
        /// ���ֽ������н�ȡ2���ֽ�
        /// </summary>
        /// <param name="source">�ֽ�����</param>
        /// <param name="start">��ʼ����</param>
        /// <param name="type">�ֽ�˳��Ĭ��ΪABCD</param>
        /// <returns>�ֽ�����</returns>
        public static byte[] Get2ByteArray(byte[] source, int start, DataFormat type = DataFormat.ABCD) {
            byte[] Res = new byte[2];

            byte[] ResTemp = GetByteArray(source, start, 2);

            if (ResTemp == null) return null;

            switch (type) {
                case DataFormat.ABCD:
                case DataFormat.CDAB:
                    Res[0] = ResTemp[1];
                    Res[1] = ResTemp[0];
                    break;

                case DataFormat.BADC:
                case DataFormat.DCBA:
                    Res = ResTemp;
                    break;
            }
            return Res;
        }

        #endregion �Զ����ȡ2���ֽ�

        #region �Զ����ȡ4���ֽ�

        /// <summary>
        /// ���ֽ������н�ȡ4���ֽ�
        /// </summary>
        /// <param name="source">�ֽ�����</param>
        /// <param name="start">��ʼ����</param>
        /// <param name="type">�ֽ�˳��Ĭ��ΪABCD</param>
        /// <returns>�ֽ�����</returns>
        public static byte[] Get4ByteArray(byte[] source, int start, DataFormat type = DataFormat.ABCD) {
            byte[] Res = new byte[4];

            byte[] ResTemp = GetByteArray(source, start, 4);

            if (ResTemp == null) return null;

            switch (type) {
                case DataFormat.ABCD:
                    Res[0] = ResTemp[3];
                    Res[1] = ResTemp[2];
                    Res[2] = ResTemp[1];
                    Res[3] = ResTemp[0];
                    break;

                case DataFormat.CDAB:
                    Res[0] = ResTemp[1];
                    Res[1] = ResTemp[0];
                    Res[2] = ResTemp[3];
                    Res[3] = ResTemp[2];
                    break;

                case DataFormat.BADC:
                    Res[0] = ResTemp[2];
                    Res[1] = ResTemp[3];
                    Res[2] = ResTemp[0];
                    Res[3] = ResTemp[1];
                    break;

                case DataFormat.DCBA:
                    Res = ResTemp;
                    break;
            }
            return Res;
        }

        #endregion �Զ����ȡ4���ֽ�

        #region �Զ����ȡ8���ֽ�

        /// <summary>
        /// ���ֽ������н�ȡ8���ֽ�
        /// </summary>
        /// <param name="source">�ֽ�����</param>
        /// <param name="start">��ʼ����</param>
        /// <param name="type">�ֽ�˳��Ĭ��ΪABCD</param>
        /// <returns>�ֽ�����</returns>
        public static byte[] Get8ByteArray(byte[] source, int start, DataFormat type = DataFormat.ABCD) {
            byte[] Res = new byte[8];

            byte[] ResTemp = GetByteArray(source, start, 8);

            if (ResTemp == null) return null;

            switch (type) {
                case DataFormat.ABCD:
                    Res[0] = ResTemp[7];
                    Res[1] = ResTemp[6];
                    Res[2] = ResTemp[5];
                    Res[3] = ResTemp[4];
                    Res[4] = ResTemp[3];
                    Res[5] = ResTemp[2];
                    Res[6] = ResTemp[1];
                    Res[7] = ResTemp[0];
                    break;

                case DataFormat.CDAB:
                    Res[0] = ResTemp[1];
                    Res[1] = ResTemp[0];
                    Res[2] = ResTemp[3];
                    Res[3] = ResTemp[2];
                    Res[4] = ResTemp[5];
                    Res[5] = ResTemp[4];
                    Res[6] = ResTemp[7];
                    Res[7] = ResTemp[6];
                    break;

                case DataFormat.BADC:
                    Res[0] = ResTemp[6];
                    Res[1] = ResTemp[7];
                    Res[2] = ResTemp[4];
                    Res[3] = ResTemp[5];
                    Res[4] = ResTemp[2];
                    Res[5] = ResTemp[3];
                    Res[6] = ResTemp[0];
                    Res[7] = ResTemp[1];
                    break;

                case DataFormat.DCBA:
                    Res = ResTemp;
                    break;
            }
            return Res;
        }

        #endregion �Զ����ȡ8���ֽ�

        #region �Ƚ������ֽ������Ƿ����

        /// <summary>
        /// �Ƚ������ֽ������Ƿ���ȫ��ͬ
        /// </summary>
        /// <param name="b1">�ֽ�����1</param>
        /// <param name="b2">�ֽ�����2</param>
        /// <returns>�Ƿ���ͬ</returns>
        public static bool ByteArrayEquals(byte[] b1, byte[] b2) {
            if (b1 == null || b2 == null) return false;
            if (b1.Length != b2.Length) return false;
            for (int i = 0; i < b1.Length; i++) {
                if (b1[i] != b2[i]) {
                    return false;
                }
            }
            return true;
        }

        #endregion �Ƚ������ֽ������Ƿ����

        #region �������ֽ�ת�����ֽ�����

        /// <summary>
        /// �������ֽ�ת�����ֽ�����
        /// </summary>
        /// <param name="value">�����ֽ�</param>
        /// <returns>�ֽ�����</returns>
        public static byte[] GetByteArrayFromByte(byte value) {
            return new byte[] { value };
        }

        #endregion �������ֽ�ת�����ֽ�����

        #region ��Short��UShort����ת�����ֽ�����

        /// <summary>
        /// ��Short������ֵת�����ֽ�����
        /// </summary>
        /// <param name="SetValue">Short������ֵ</param>
        /// <param name="dataFormat">�ֽ�˳��</param>
        /// <returns>�ֽ�����</returns>
        public static byte[] GetByteArrayFromShort(short SetValue, DataFormat dataFormat = DataFormat.ABCD) {
            byte[] ResTemp = BitConverter.GetBytes(SetValue);
            byte[] Res = new byte[2];

            switch (dataFormat) {
                case DataFormat.ABCD:
                case DataFormat.CDAB:
                    Res[0] = ResTemp[1];
                    Res[1] = ResTemp[0];
                    break;

                case DataFormat.BADC:
                case DataFormat.DCBA:
                    Res = ResTemp;
                    break;

                default:
                    break;
            }
            return Res;
        }

        /// <summary>
        /// ��UShort������ֵת�����ֽ�����
        /// </summary>
        /// <param name="SetValue">UShort������ֵ</param>
        /// <param name="dataFormat">�ֽ�˳��</param>
        /// <returns>�ֽ�����</returns>
        public static byte[] GetByteArrayFromUShort(ushort SetValue, DataFormat dataFormat = DataFormat.ABCD) {
            byte[] ResTemp = BitConverter.GetBytes(SetValue);
            byte[] Res = new byte[2];

            switch (dataFormat) {
                case DataFormat.ABCD:
                case DataFormat.CDAB:
                    Res[0] = ResTemp[1];
                    Res[1] = ResTemp[0];
                    break;

                case DataFormat.BADC:
                case DataFormat.DCBA:
                    Res = ResTemp;
                    break;

                default:
                    break;
            }
            return Res;
        }

        #endregion ��Short��UShort����ת�����ֽ�����

        #region ��Short��UShort����ת�����ֽ�����

        /// <summary>
        /// ��Short����ת�����ֽ�����
        /// </summary>
        /// <param name="SetValue">Short����</param>
        /// <param name="dataFormat">�ֽ�˳��</param>
        /// <returns>�ֽ�����</returns>
        public static byte[] GetByteArrayFromShortArray(short[] SetValue, DataFormat dataFormat = DataFormat.ABCD) {
            ByteArray array = new ByteArray();

            foreach (var item in SetValue) {
                array.Add(GetByteArrayFromShort(item, dataFormat));
            }
            return array.array;
        }

        /// <summary>
        /// ��UShort����ת�����ֽ�����
        /// </summary>
        /// <param name="SetValue">UShort����</param>
        /// <param name="dataFormat">�ֽ�˳��</param>
        /// <returns>�ֽ�����</returns>
        public static byte[] GetByteArrayFromUShortArray(ushort[] SetValue, DataFormat dataFormat = DataFormat.ABCD) {
            ByteArray array = new ByteArray();

            foreach (var item in SetValue) {
                array.Add(GetByteArrayFromUShort(item, dataFormat));
            }
            return array.array;
        }

        #endregion ��Short��UShort����ת�����ֽ�����

        #region ��Int��UInt��Float��Double����ת�����ֽ�����

        /// <summary>
        /// ��Int������ֵת�����ֽ�����
        /// </summary>
        /// <param name="SetValue">Int������ֵ</param>
        /// <param name="dataFormat">�ֽ�˳��</param>
        /// <returns>�ֽ�����</returns>
        public static byte[] GetByteArrayFromInt(int SetValue, DataFormat dataFormat = DataFormat.ABCD) {
            byte[] ResTemp = BitConverter.GetBytes(SetValue);

            byte[] Res = new byte[4];

            switch (dataFormat) {
                case DataFormat.ABCD:
                    Res[0] = ResTemp[3];
                    Res[1] = ResTemp[2];
                    Res[2] = ResTemp[1];
                    Res[3] = ResTemp[0];
                    break;

                case DataFormat.CDAB:
                    Res[0] = ResTemp[1];
                    Res[1] = ResTemp[0];
                    Res[2] = ResTemp[3];
                    Res[3] = ResTemp[2];
                    break;

                case DataFormat.BADC:
                    Res[0] = ResTemp[2];
                    Res[1] = ResTemp[3];
                    Res[2] = ResTemp[0];
                    Res[3] = ResTemp[1];
                    break;

                case DataFormat.DCBA:
                    Res = ResTemp;
                    break;
            }
            return Res;
        }

        /// <summary>
        /// ��UInt������ֵת�����ֽ�����
        /// </summary>
        /// <param name="SetValue">UInt������ֵ</param>
        /// <param name="dataFormat">�ֽ�˳��</param>
        /// <returns>�ֽ�����</returns>
        public static byte[] GetByteArrayFromUInt(uint SetValue, DataFormat dataFormat = DataFormat.ABCD) {
            byte[] ResTemp = BitConverter.GetBytes(SetValue);

            byte[] Res = new byte[4];

            switch (dataFormat) {
                case DataFormat.ABCD:
                    Res[0] = ResTemp[3];
                    Res[1] = ResTemp[2];
                    Res[2] = ResTemp[1];
                    Res[3] = ResTemp[0];
                    break;

                case DataFormat.CDAB:
                    Res[0] = ResTemp[1];
                    Res[1] = ResTemp[0];
                    Res[2] = ResTemp[3];
                    Res[3] = ResTemp[2];
                    break;

                case DataFormat.BADC:
                    Res[0] = ResTemp[2];
                    Res[1] = ResTemp[3];
                    Res[2] = ResTemp[0];
                    Res[3] = ResTemp[1];
                    break;

                case DataFormat.DCBA:
                    Res = ResTemp;
                    break;
            }
            return Res;
        }

        /// <summary>
        /// ��Float��ֵת�����ֽ�����
        /// </summary>
        /// <param name="SetValue">Float������ֵ</param>
        /// <param name="dataFormat">�ֽ�˳��</param>
        /// <returns>�ֽ�����</returns>
        public static byte[] GetByteArrayFromFloat(float SetValue, DataFormat dataFormat = DataFormat.ABCD) {
            byte[] ResTemp = BitConverter.GetBytes(SetValue);

            byte[] Res = new byte[4];

            switch (dataFormat) {
                case DataFormat.ABCD:
                    Res[0] = ResTemp[3];
                    Res[1] = ResTemp[2];
                    Res[2] = ResTemp[1];
                    Res[3] = ResTemp[0];
                    break;

                case DataFormat.CDAB:
                    Res[0] = ResTemp[1];
                    Res[1] = ResTemp[0];
                    Res[2] = ResTemp[3];
                    Res[3] = ResTemp[2];
                    break;

                case DataFormat.BADC:
                    Res[0] = ResTemp[2];
                    Res[1] = ResTemp[3];
                    Res[2] = ResTemp[0];
                    Res[3] = ResTemp[1];
                    break;

                case DataFormat.DCBA:
                    Res = ResTemp;
                    break;
            }
            return Res;
        }

        /// <summary>
        /// ��Double������ֵת�����ֽ�����
        /// </summary>
        /// <param name="SetValue">Double������ֵ</param>
        /// <param name="dataFormat">�ֽ�˳��</param>
        /// <returns>�ֽ�����</returns>
        public static byte[] GetByteArrayFromDouble(double SetValue, DataFormat dataFormat = DataFormat.ABCD) {
            byte[] ResTemp = BitConverter.GetBytes(SetValue);

            byte[] Res = new byte[8];

            switch (dataFormat) {
                case DataFormat.ABCD:
                    Res[0] = ResTemp[7];
                    Res[1] = ResTemp[6];
                    Res[2] = ResTemp[5];
                    Res[3] = ResTemp[4];
                    Res[4] = ResTemp[3];
                    Res[5] = ResTemp[2];
                    Res[6] = ResTemp[1];
                    Res[7] = ResTemp[0];
                    break;

                case DataFormat.CDAB:
                    Res[0] = ResTemp[1];
                    Res[1] = ResTemp[0];
                    Res[2] = ResTemp[3];
                    Res[3] = ResTemp[2];
                    Res[4] = ResTemp[5];
                    Res[5] = ResTemp[4];
                    Res[6] = ResTemp[7];
                    Res[7] = ResTemp[6];
                    break;

                case DataFormat.BADC:
                    Res[0] = ResTemp[6];
                    Res[1] = ResTemp[7];
                    Res[2] = ResTemp[4];
                    Res[3] = ResTemp[5];
                    Res[4] = ResTemp[2];
                    Res[5] = ResTemp[3];
                    Res[6] = ResTemp[0];
                    Res[7] = ResTemp[1];
                    break;

                case DataFormat.DCBA:
                    Res = ResTemp;
                    break;
            }
            return Res;
        }

        #endregion ��Int��UInt��Float��Double����ת�����ֽ�����

        #region ��Int��UInt��Float��Double����ת�����ֽ�����

        /// <summary>
        /// ��Int��������ת�����ֽ�����
        /// </summary>
        /// <param name="SetValue">Int��������</param>
        /// <param name="dataFormat">�ֽ�˳��</param>
        /// <returns>�ֽ�����</returns>
        public static byte[] GetByteArrayFromIntArray(int[] SetValue, DataFormat dataFormat = DataFormat.ABCD) {
            ByteArray array = new ByteArray();

            foreach (var item in SetValue) {
                array.Add(GetByteArrayFromInt(item, dataFormat));
            }
            return array.array;
        }

        /// <summary>
        /// ��UInt��������ת�����ֽ�����
        /// </summary>
        /// <param name="SetValue">UInt��������</param>
        /// <param name="dataFormat">�ֽ�˳��</param>
        /// <returns>�ֽ�����</returns>
        public static byte[] GetByteArrayFromUIntArray(uint[] SetValue, DataFormat dataFormat = DataFormat.ABCD) {
            ByteArray array = new ByteArray();

            foreach (var item in SetValue) {
                array.Add(GetByteArrayFromUInt(item, dataFormat));
            }
            return array.array;
        }

        /// <summary>
        /// ��Float��������ת���ֽ�����
        /// </summary>
        /// <param name="SetValue">Float��������</param>
        /// <param name="dataFormat">�ֽ�˳��</param>
        /// <returns>�ֽ�����</returns>
        public static byte[] GetByteArrayFromFloatArray(float[] SetValue, DataFormat dataFormat = DataFormat.ABCD) {
            ByteArray array = new ByteArray();

            foreach (var item in SetValue) {
                array.Add(GetByteArrayFromFloat(item, dataFormat));
            }
            return array.array;
        }

        /// <summary>
        /// ��Double��������ת���ֽ�����
        /// </summary>
        /// <param name="SetValue">Double��������</param>
        /// <param name="dataFormat">�ֽ�˳��</param>
        /// <returns>�ֽ�����</returns>
        public static byte[] GetByteArrayFromDoubleArray(double[] SetValue, DataFormat dataFormat = DataFormat.ABCD) {
            ByteArray array = new ByteArray();

            foreach (var item in SetValue) {
                array.Add(GetByteArrayFromDouble(item, dataFormat));
            }
            return array.array;
        }

        #endregion ��Int��UInt��Float��Double����ת�����ֽ�����

        #region ��Long��ULong����ת�����ֽ�����

        /// <summary>
        /// ��Long������ֵת�����ֽ�����
        /// </summary>
        /// <param name="SetValue">Long������ֵ</param>
        /// <param name="dataFormat">�ֽ�˳��</param>
        /// <returns>�ֽ�����</returns>
        public static byte[] GetByteArrayFromLong(long SetValue, DataFormat dataFormat = DataFormat.ABCD) {
            byte[] ResTemp = BitConverter.GetBytes(SetValue);

            byte[] Res = new byte[8];

            switch (dataFormat) {
                case DataFormat.ABCD:
                    Res[0] = ResTemp[7];
                    Res[1] = ResTemp[6];
                    Res[2] = ResTemp[5];
                    Res[3] = ResTemp[4];
                    Res[4] = ResTemp[3];
                    Res[5] = ResTemp[2];
                    Res[6] = ResTemp[1];
                    Res[7] = ResTemp[0];
                    break;

                case DataFormat.CDAB:
                    Res[0] = ResTemp[1];
                    Res[1] = ResTemp[0];
                    Res[2] = ResTemp[3];
                    Res[3] = ResTemp[2];
                    Res[4] = ResTemp[5];
                    Res[5] = ResTemp[4];
                    Res[6] = ResTemp[7];
                    Res[7] = ResTemp[6];
                    break;

                case DataFormat.BADC:
                    Res[0] = ResTemp[6];
                    Res[1] = ResTemp[7];
                    Res[2] = ResTemp[4];
                    Res[3] = ResTemp[5];
                    Res[4] = ResTemp[2];
                    Res[5] = ResTemp[3];
                    Res[6] = ResTemp[0];
                    Res[7] = ResTemp[1];
                    break;

                case DataFormat.DCBA:
                    Res = ResTemp;
                    break;
            }
            return Res;
        }

        /// <summary>
        /// ��ULong������ֵת�����ֽ�����
        /// </summary>
        /// <param name="SetValue">ULong������ֵ</param>
        /// <param name="dataFormat">�ֽ�˳��</param>
        /// <returns>�ֽ�����</returns>
        public static byte[] GetByteArrayFromULong(ulong SetValue, DataFormat dataFormat = DataFormat.ABCD) {
            byte[] ResTemp = BitConverter.GetBytes(SetValue);

            byte[] Res = new byte[8];

            switch (dataFormat) {
                case DataFormat.ABCD:
                    Res[0] = ResTemp[7];
                    Res[1] = ResTemp[6];
                    Res[2] = ResTemp[5];
                    Res[3] = ResTemp[4];
                    Res[4] = ResTemp[3];
                    Res[5] = ResTemp[2];
                    Res[6] = ResTemp[1];
                    Res[7] = ResTemp[0];
                    break;

                case DataFormat.CDAB:
                    Res[0] = ResTemp[1];
                    Res[1] = ResTemp[0];
                    Res[2] = ResTemp[3];
                    Res[3] = ResTemp[2];
                    Res[4] = ResTemp[5];
                    Res[5] = ResTemp[4];
                    Res[6] = ResTemp[7];
                    Res[7] = ResTemp[6];
                    break;

                case DataFormat.BADC:
                    Res[0] = ResTemp[6];
                    Res[1] = ResTemp[7];
                    Res[2] = ResTemp[4];
                    Res[3] = ResTemp[5];
                    Res[4] = ResTemp[2];
                    Res[5] = ResTemp[3];
                    Res[6] = ResTemp[0];
                    Res[7] = ResTemp[1];
                    break;

                case DataFormat.DCBA:
                    Res = ResTemp;
                    break;
            }
            return Res;
        }

        #endregion ��Long��ULong����ת�����ֽ�����

        #region ��Long��ULong����ת�����ֽ�����

        /// <summary>
        /// ��Long��������ת�����ֽ�����
        /// </summary>
        /// <param name="SetValue">Long��������</param>
        /// <param name="dataFormat">�ֽ�˳��</param>
        /// <returns>�ֽ�����</returns>
        public static byte[] GetByteArrayFromLongArray(long[] SetValue, DataFormat dataFormat = DataFormat.ABCD) {
            ByteArray array = new ByteArray();

            foreach (var item in SetValue) {
                array.Add(GetByteArrayFromDouble(item, dataFormat));
            }
            return array.array;
        }

        /// <summary>
        /// ��ULong��������ת�����ֽ�����
        /// </summary>
        /// <param name="SetValue">ULong��������</param>
        /// <param name="dataFormat">�ֽ�˳��</param>
        /// <returns>�ֽ�����</returns>
        public static byte[] GetByteArrayFromULongArray(ulong[] SetValue, DataFormat dataFormat = DataFormat.ABCD) {
            ByteArray array = new ByteArray();

            foreach (var item in SetValue) {
                array.Add(GetByteArrayFromDouble(item, dataFormat));
            }
            return array.array;
        }

        #endregion ��Long��ULong����ת�����ֽ�����

        #region ���ַ���ת�����ֽ�����

        /// <summary>
        /// ��ָ�������ʽ���ַ���ת�����ֽ�����
        /// </summary>
        /// <param name="SetValue">�ַ���</param>
        /// <param name="encoding">�����ʽ</param>
        /// <returns>�ֽ�����</returns>
        public static byte[] GetByteArrayFromString(string SetValue, Encoding encoding) {
            return encoding.GetBytes(SetValue);
        }

        #endregion ���ַ���ת�����ֽ�����

        #region ��16�����ַ���ת�����ֽ�����

        /// <summary>
        /// ��16�����ַ������տո�ָ����ֽ�����
        /// </summary>
        /// <param name="val">16�����ַ���</param>
        /// <returns>�ֽ�����</returns>
        public static byte[] GetByteArrayFromHexString(string val) {
            List<byte> Result = new List<byte>();
            if (val.Contains(' ')) {
                string[] str = Regex.Split(val, "\\s+", RegexOptions.IgnoreCase);

                foreach (var item in str) {
                    Result.Add(Convert.ToByte(item, 16));
                }
            } else {
                Result.Add(Convert.ToByte(val));
            }

            return Result.ToArray();
        }

        private static List<char> hexCharList = new List<char>()
            {
                '0','1','2','3','4','5','6','7','8','9','A','B','C','D','E','F'
            };

        /// <summary>
        /// ��16�����ַ������÷ָ���ת�����ֽ����飨ÿ2���ַ�Ϊ1���ֽڣ�
        /// </summary>
        /// <param name="val">16�����ַ���</param>
        /// <returns>�ֽ�����</returns>
        public static byte[] GetByteArrayFromHexStringWithoutSpilt(string val) {
            val = val.ToUpper();

            MemoryStream ms = new MemoryStream();

            for (int i = 0; i < val.Length; i++) {
                if ((i + 1) < val.Length) {
                    if (hexCharList.Contains(val[i]) && hexCharList.Contains(val[i + 1])) {
                        // ����һ���ϸ���ֽ�����
                        ms.WriteByte((byte)(hexCharList.IndexOf(val[i]) * 16 + hexCharList.IndexOf(val[i + 1])));
                        i++;
                    }
                }
            }

            byte[] result = ms.ToArray();
            ms.Dispose();
            return result;
        }

        /// <summary>
        /// ��16�����ַ������÷ָ���ת�����ֽ����� ָ���ָ��ַ�
        /// </summary>
        /// <param name="val"></param>
        /// <param name="spilt"></param>
        /// <returns></returns>
        public static byte[] GetByteArrayFromHexString(string val, char spilt = ' ') {
            val = val.Trim();//ȥ���ո�

            List<byte> Result = new List<byte>();

            try {
                if (val.Contains(spilt)) {
                    string[] str = val.Split(new char[] { spilt }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var item in str) {
                        Result.Add(Convert.ToByte(item.Trim(), 16));
                    }
                } else {
                    Result.Add(Convert.ToByte(val.Trim(), 16));
                }
                return Result.ToArray();
            } catch (Exception) {
                return null;
            }
        }

        #endregion ��16�����ַ���ת�����ֽ�����

        #region ����������ת�����ֽ�����

        /// <summary>
        /// ����������ת�����ֽ�����
        /// </summary>
        /// <param name="val">��������</param>
        /// <returns>�ֽ�����</returns>
        public static byte[] GetByteArrayFromBoolArray(bool[] val) {
            if (val == null && val.Length == 0) return null;

            int iByteArrLen = 0;

            if (val.Length % 8 == 0) {
                iByteArrLen = val.Length / 8;
            } else {
                iByteArrLen = val.Length / 8 + 1;
            }

            byte[] result = new byte[iByteArrLen];

            //����ÿ���ֽ�
            for (int i = 0; i < iByteArrLen; i++) {
                int total = val.Length < 8 * (i + 1) ? val.Length - 8 * i : 8;

                //������ǰ�ֽڵ�ÿ��λ��ֵ
                for (int j = 0; j < total; j++) {
                    result[i] = ByteLib.SetbitValue(result[i], j, val[8 * i + j]);
                }
            }
            return result;
        }

        #endregion ����������ת�����ֽ�����

        #region ���������ַ���ת�����ֽ�����

        /// <summary>
        /// ���������ַ���ת�����ֽ�����
        /// </summary>
        /// <param name="SetValue">�������ַ���</param>
        /// <returns>�ֽ�����</returns>
        public static byte[] GetByteArrayFromSiemensString(string SetValue) {
            byte[] b = GetByteArrayFromString(SetValue, Encoding.GetEncoding("GBK"));
            byte[] array = new byte[b.Length + 2];
            array[1] = (byte)(b.Length);
            Array.Copy(b, 0, array, 2, b.Length);

            return array;
        }

        #endregion ���������ַ���ת�����ֽ�����

        #region �ֽ�����ת����ASCII�ֽ�����

        /// <summary>
        /// ���ֽ�����ת����ASCII�ֽ�����
        /// </summary>
        /// <param name="inBytes">�ֽ�����</param>
        /// <returns>ASCII�ֽ�����</returns>
        public static byte[] GetAsciiBytesFromByteArray(byte[] inBytes) {
            return Encoding.ASCII.GetBytes(StringLib.GetHexStringFromByteArray(inBytes, (char)0));
        }

        #endregion �ֽ�����ת����ASCII�ֽ�����

        #region �ϲ��ֽ�����

        /// <summary>
        /// ��2���ֽ�������кϲ�
        /// </summary>
        /// <param name="bytes1">�ֽ�����1</param>
        /// <param name="bytes2">�ֽ�����2</param>
        /// <returns>�ֽ�����</returns>
        public static byte[] CombineTwoByteArray(byte[] bytes1, byte[] bytes2) {
            if (bytes1 == null && bytes2 == null) return null;
            if (bytes1 == null) return bytes2;
            if (bytes2 == null) return bytes1;

            byte[] buffer = new byte[bytes1.Length + bytes2.Length];
            bytes1.CopyTo(buffer, 0);
            bytes2.CopyTo(buffer, bytes1.Length);
            return buffer;
        }

        /// <summary>
        /// ��3���ֽ�������кϲ�
        /// </summary>
        /// <param name="bytes1">�ֽ�����1</param>
        /// <param name="bytes2">�ֽ�����2</param>
        /// <param name="bytes3">�ֽ�����3</param>
        /// <returns></returns>
        public static byte[] CombineThreeByteArray(byte[] bytes1, byte[] bytes2, byte[] bytes3) {
            return CombineTwoByteArray(CombineTwoByteArray(bytes1, bytes2), bytes3);
        }

        #endregion �ϲ��ֽ�����

        #region ASCII�ֽ�����ת�����ֽ�����

        /// <summary>
        /// ��ASCII�ֽ�����ת�����ֽ�����
        /// </summary>
        /// <param name="inBytes">ASCII�ֽ�����</param>
        /// <returns>�ֽ�����</returns>
        public static byte[] GetBytesArrayFromASCIIByteArray(byte[] inBytes) {
            return GetByteArrayFromHexStringWithoutSpilt(Encoding.ASCII.GetString(inBytes));
        }

        #endregion ASCII�ֽ�����ת�����ֽ�����

        //=============================================
    }
}
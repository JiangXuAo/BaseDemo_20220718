using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Tools.DataConvert {

    public class UShortLib {

        #region �ֽ������н�ȡת��16λ�޷�������

        public static ushort GetUShortFromByteArray(byte[] source, int start = 0, DataFormat type = DataFormat.ABCD) {
            return BitConverter.ToUInt16(ByteArrayLib.Get2ByteArray(source, start, type), 0);
        }

        #endregion �ֽ������н�ȡת��16λ�޷�������

        #region ���ֽ������н�ȡת��16λ�޷�����������

        public static ushort[] GetUShortArrayFromByteArray(byte[] source, DataFormat type = DataFormat.ABCD) {
            ushort[] result = new ushort[source.Length / 2];

            for (int i = 0; i < result.Length; i++) {
                result[i] = GetUShortFromByteArray(source, i * 2, type);
            }
            return result;
        }

        #endregion ���ֽ������н�ȡת��16λ�޷�����������

        #region ���ַ���תת��16λ�޷�����������

        public static ushort[] GetUShortArrayFromString(string val) {
            List<ushort> Result = new List<ushort>();
            if (val.Contains(' ')) {
                string[] str = Regex.Split(val, "\\s+", RegexOptions.IgnoreCase);

                foreach (var item in str) {
                    Result.Add(Convert.ToUInt16(item));
                }
            } else {
                Result.Add(Convert.ToUInt16(val));
            }

            return Result.ToArray();
        }

        #endregion ���ַ���תת��16λ�޷�����������

        #region ���޷�������ĳ��λ��ֵ

        /// <summary>
        /// ���޷�������ĳ��λ��ֵ
        /// </summary>
        /// <param name="_Mask">����λ</param>
        /// <param name="a">����������</param>
        /// <param name="flag">������</param>
        /// <returns>��������</returns>
        public static ushort SetIntegerSomeBit(int _Mask, ushort a, bool flag) {
            if (flag) {
                a = Convert.ToUInt16(a | (0x1 << _Mask));
            } else {
                a = Convert.ToUInt16(a & ~(0x1 << _Mask));
            }
            return a;
        }

        #endregion ���޷�������ĳ��λ��ֵ

        //=============================================
    }
}
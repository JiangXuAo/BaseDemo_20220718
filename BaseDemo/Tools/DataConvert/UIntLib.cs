using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Tools.DataConvert {

    public class UIntLib
    {

        #region �ֽ������н�ȡת��32λ�޷�������

        public static uint GetUIntFromByteArray(byte[] source, int start = 0, DataFormat type = DataFormat.ABCD)
        {
            return BitConverter.ToUInt32(ByteArrayLib.Get4ByteArray(source, start, type), 0);
        }

        #endregion �ֽ������н�ȡת��32λ�޷�������

        #region ���ֽ������н�ȡת��32λ�޷�����������

        public static uint[] GetUIntArrayFromByteArray(byte[] source, DataFormat type = DataFormat.ABCD)
        {
            uint[] values = new uint[source.Length / 4];

            for (int i = 0; i < source.Length / 4; i++)
            {
                values[i] = GetUIntFromByteArray(source, 4 * i, type);
            }

            return values;
        }

        #endregion ���ֽ������н�ȡת��32λ�޷�����������

        #region ���ַ���תת��32λ�޷�����������

        public static uint[] GetUIntArrayFromString(string val)
        {
            List<uint> Result = new List<uint>();
            if (val.Contains(' '))
            {
                string[] str = Regex.Split(val, "\\s+", RegexOptions.IgnoreCase);

                foreach (var item in str)
                {
                    Result.Add(Convert.ToUInt32(item));
                }
            }
            else
            {
                Result.Add(Convert.ToUInt32(val));
            }

            return Result.ToArray();
        }

        #endregion ���ַ���תת��32λ�޷�����������

        //=============================================
    }
}
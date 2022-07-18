using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Tools.DataConvert {

    public class ULongLib {

        #region �ֽ������н�ȡת��32λ����

        public static ulong GetULongFromByteArray(byte[] source, int start, DataFormat type = DataFormat.ABCD) {
            return BitConverter.ToUInt64(ByteArrayLib.Get8ByteArray(source, start, type), 0);
        }

        #endregion �ֽ������н�ȡת��32λ����

        #region ���ֽ������н�ȡת��64λ��������

        public static ulong[] GetULongArrayFromByteArray(byte[] source, DataFormat type = DataFormat.ABCD) {
            ulong[] values = new ulong[source.Length / 8];

            for (int i = 0; i < source.Length / 8; i++) {
                values[i] = GetULongFromByteArray(source, 8 * i, type);
            }

            return values;
        }

        #endregion ���ֽ������н�ȡת��64λ��������

        #region ���ַ���תת��64λ��������

        public static ulong[] GetULongArrayFromString(string val) {
            List<ulong> Result = new List<ulong>();

            if (val.Contains(' ')) {
                string[] str = Regex.Split(val, "\\s+", RegexOptions.IgnoreCase);

                foreach (var item in str) {
                    Result.Add(Convert.ToUInt64(item));
                }
            } else {
                Result.Add(Convert.ToUInt64(val));
            }

            return Result.ToArray();
        }

        #endregion ���ַ���תת��64λ��������

        //=============================================
    }
}
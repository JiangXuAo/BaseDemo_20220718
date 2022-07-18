using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Tools.DataConvert {

    public class LongLib {

        #region �ֽ������н�ȡת��64λ����

        public static long GetLongFromByteArray(byte[] source, int start, DataFormat type = DataFormat.ABCD) {
            return BitConverter.ToInt64(ByteArrayLib.Get8ByteArray(source, start, type), 0);
        }

        #endregion �ֽ������н�ȡת��64λ����

        #region ���ֽ������н�ȡת��64λ��������

        public static long[] GetLongArrayFromByteArray(byte[] source, DataFormat type = DataFormat.ABCD) {
            long[] values = new long[source.Length / 8];

            for (int i = 0; i < source.Length / 8; i++) {
                values[i] = GetLongFromByteArray(source, 8 * i, type);
            }

            return values;
        }

        #endregion ���ֽ������н�ȡת��64λ��������

        #region ���ַ���תת��64λ��������

        public static long[] GetLongArrayFromString(string val) {
            List<long> Result = new List<long>();

            if (val.Contains(' ')) {
                string[] str = Regex.Split(val, "\\s+", RegexOptions.IgnoreCase);

                foreach (var item in str) {
                    Result.Add(Convert.ToInt64(item));
                }
            } else {
                Result.Add(Convert.ToInt64(val));
            }

            return Result.ToArray();
        }

        #endregion ���ַ���תת��64λ��������

        //=============================================
    }
}
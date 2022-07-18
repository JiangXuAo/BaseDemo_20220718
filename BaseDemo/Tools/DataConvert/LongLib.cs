using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Tools.DataConvert {

    public class LongLib {

        #region 字节数组中截取转成64位整型

        public static long GetLongFromByteArray(byte[] source, int start, DataFormat type = DataFormat.ABCD) {
            return BitConverter.ToInt64(ByteArrayLib.Get8ByteArray(source, start, type), 0);
        }

        #endregion 字节数组中截取转成64位整型

        #region 将字节数组中截取转成64位整型数组

        public static long[] GetLongArrayFromByteArray(byte[] source, DataFormat type = DataFormat.ABCD) {
            long[] values = new long[source.Length / 8];

            for (int i = 0; i < source.Length / 8; i++) {
                values[i] = GetLongFromByteArray(source, 8 * i, type);
            }

            return values;
        }

        #endregion 将字节数组中截取转成64位整型数组

        #region 将字符串转转成64位整型数组

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

        #endregion 将字符串转转成64位整型数组

        //=============================================
    }
}
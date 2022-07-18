using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Tools.DataConvert {

    public class ULongLib {

        #region 字节数组中截取转成32位整型

        public static ulong GetULongFromByteArray(byte[] source, int start, DataFormat type = DataFormat.ABCD) {
            return BitConverter.ToUInt64(ByteArrayLib.Get8ByteArray(source, start, type), 0);
        }

        #endregion 字节数组中截取转成32位整型

        #region 将字节数组中截取转成64位整型数组

        public static ulong[] GetULongArrayFromByteArray(byte[] source, DataFormat type = DataFormat.ABCD) {
            ulong[] values = new ulong[source.Length / 8];

            for (int i = 0; i < source.Length / 8; i++) {
                values[i] = GetULongFromByteArray(source, 8 * i, type);
            }

            return values;
        }

        #endregion 将字节数组中截取转成64位整型数组

        #region 将字符串转转成64位整型数组

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

        #endregion 将字符串转转成64位整型数组

        //=============================================
    }
}
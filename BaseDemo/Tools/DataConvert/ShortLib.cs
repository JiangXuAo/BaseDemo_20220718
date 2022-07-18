using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Tools.DataConvert {

    public class ShortLib {

        #region 字节数组中截取转成16位整型

        public static short GetShortFromByteArray(byte[] source, int start = 0, DataFormat dataFormat = DataFormat.ABCD) {
            return BitConverter.ToInt16(ByteArrayLib.Get2ByteArray(source, start, dataFormat), 0);
        }

        #endregion 字节数组中截取转成16位整型

        #region 将字节数组中截取转成16位整型数组

        public static short[] GetShortArrayFromByteArray(byte[] source, DataFormat type = DataFormat.ABCD) {
            short[] result = new short[source.Length / 2];

            for (int i = 0; i < result.Length; i++) {
                result[i] = GetShortFromByteArray(source, i * 2, type);
            }
            return result;
        }

        #endregion 将字节数组中截取转成16位整型数组

        #region 将字符串转转成16位整型数组

        public static short[] GetShortArrayFromString(string val) {
            List<short> Result = new List<short>();

            if (val.Contains(' ')) {
                string[] str = Regex.Split(val, "\\s+", RegexOptions.IgnoreCase);

                foreach (var item in str) {
                    Result.Add(Convert.ToInt16(item));
                }
            } else {
                Result.Add(Convert.ToInt16(val));
            }

            return Result.ToArray();
        }

        #endregion 将字符串转转成16位整型数组

        #region 设置16位整型或字节数组某个位

        public static short SetbitValueFromShort(short value, int bit, bool val, DataFormat dataFormat = DataFormat.ABCD) {
            byte[] bt = ByteArrayLib.GetByteArrayFromShort(value, dataFormat);

            if (bit >= 0 && bit <= 7) {
                bt[1] = ByteLib.SetbitValue(bt[1], bit, val);
            } else {
                bt[0] = ByteLib.SetbitValue(bt[0], bit - 8, val);
            }
            return ShortLib.GetShortFromByteArray(bt, 0, dataFormat);
        }

        public static short SetbitValueFrom2ByteArray(byte[] bt, int bit, bool val, DataFormat dataFormat = DataFormat.ABCD) {
            if (bit >= 0 && bit <= 7) {
                bt[1] = ByteLib.SetbitValue(bt[1], bit, val);
            } else {
                bt[0] = ByteLib.SetbitValue(bt[0], bit - 8, val);
            }
            return GetShortFromByteArray(bt, 0, dataFormat);
        }

        #endregion 设置16位整型或字节数组某个位

        //=============================================
    }
}
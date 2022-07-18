using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Tools.DataConvert {

    /// <summary>
    /// Int类型转换库
    /// </summary>
    public class IntLib {

        #region 字节数组中截取转成32位整型

        /// <summary>
        /// 字节数组中截取转成32位整型
        /// </summary>
        /// <param name="source"></param>
        /// <param name="start"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int GetIntFromByteArray(byte[] source, int start = 0, DataFormat type = DataFormat.ABCD) {
            return BitConverter.ToInt32(ByteArrayLib.Get4ByteArray(source, start, type), 0);
        }

        #endregion 字节数组中截取转成32位整型

        #region 将字节数组中截取转成32位整型数组

        /// <summary>
        /// 将字节数组中截取转成32位整型数组
        /// </summary>
        /// <param name="source"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int[] GetIntArrayFromByteArray(byte[] source, DataFormat type = DataFormat.ABCD) {
            int[] values = new int[source.Length / 4];

            for (int i = 0; i < source.Length / 4; i++) {
                values[i] = GetIntFromByteArray(source, 4 * i, type);
            }

            return values;
        }

        #endregion 将字节数组中截取转成32位整型数组

        #region 将字符串转转成32位整型数组

        /// <summary>
        /// 将字符串转转成32位整型数组
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static int[] GetIntArrayFromString(string val) {
            List<int> Result = new List<int>();
            if (val.Contains(' ')) {
                string[] str = Regex.Split(val, "\\s+", RegexOptions.IgnoreCase);

                foreach (var item in str) {
                    Result.Add(Convert.ToInt32(item));
                }
            } else {
                Result.Add(Convert.ToInt32(val));
            }

            return Result.ToArray();
        }

        #endregion 将字符串转转成32位整型数组

        //=============================================
    }
}
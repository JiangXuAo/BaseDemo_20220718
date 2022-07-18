using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Tools.DataConvert {

    /// <summary>
    /// Double类型转换库
    /// </summary>
    public class DoubleLib {

        #region 字节数组中截取转成双精度浮点型

        /// <summary>
        /// 将字节数组中某8个字节转换成Double类型
        /// </summary>
        /// <param name="source">字节数组</param>
        /// <param name="start">开始位置</param>
        /// <param name="type">字节顺序</param>
        /// <returns>Double类型数值</returns>
        public static double GetDoubleFromByteArray(byte[] source, int start, DataFormat type = DataFormat.ABCD) {
            byte[] result = ByteArrayLib.Get8ByteArray(source, start, type);
            if (result != null) {
                return BitConverter.ToDouble(result, 0);
            } else {
                return 0.0;
            }
        }

        #endregion 字节数组中截取转成双精度浮点型

        #region 将字节数组中截取转成双精度浮点型数组

        /// <summary>
        /// 将字节数组转换成Double数组
        /// </summary>
        /// <param name="source">字节数组</param>
        /// <param name="type">字节顺序</param>
        /// <returns>Double数组</returns>
        public static double[] GetDoubleArrayFromByteArray(byte[] source, DataFormat type = DataFormat.ABCD) {
            double[] values = new double[source.Length / 8];

            for (int i = 0; i < source.Length / 4; i++) {
                values[i] = GetDoubleFromByteArray(source, 8 * i, type);
            }

            return values;
        }

        #endregion 将字节数组中截取转成双精度浮点型数组

        #region 将字符串转转成双精度浮点型数组

        /// <summary>
        /// 将Double字符串转换成双精度浮点型数组
        /// </summary>
        /// <param name="val">Double字符串</param>
        /// <returns>双精度浮点型数组</returns>
        public static double[] GetDoubleArrayFromString(string val) {
            List<double> Result = new List<double>();
            if (val.Contains(' ')) {
                string[] str = Regex.Split(val, "\\s+", RegexOptions.IgnoreCase);

                foreach (var item in str) {
                    Result.Add(Convert.ToDouble(item));
                }
            } else {
                Result.Add(Convert.ToDouble(val));
            }

            return Result.ToArray();
        }

        #endregion 将字符串转转成双精度浮点型数组

        //=============================================
    }
}
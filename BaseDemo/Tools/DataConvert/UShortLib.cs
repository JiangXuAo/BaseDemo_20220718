using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Tools.DataConvert {

    public class UShortLib {

        #region 字节数组中截取转成16位无符号整型

        public static ushort GetUShortFromByteArray(byte[] source, int start = 0, DataFormat type = DataFormat.ABCD) {
            return BitConverter.ToUInt16(ByteArrayLib.Get2ByteArray(source, start, type), 0);
        }

        #endregion 字节数组中截取转成16位无符号整型

        #region 将字节数组中截取转成16位无符号整型数组

        public static ushort[] GetUShortArrayFromByteArray(byte[] source, DataFormat type = DataFormat.ABCD) {
            ushort[] result = new ushort[source.Length / 2];

            for (int i = 0; i < result.Length; i++) {
                result[i] = GetUShortFromByteArray(source, i * 2, type);
            }
            return result;
        }

        #endregion 将字节数组中截取转成16位无符号整型数组

        #region 将字符串转转成16位无符号整型数组

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

        #endregion 将字符串转转成16位无符号整型数组

        #region 将无符号整型某个位赋值

        /// <summary>
        /// 将无符号整型某个位赋值
        /// </summary>
        /// <param name="_Mask">操作位</param>
        /// <param name="a">操作的整数</param>
        /// <param name="flag">操作数</param>
        /// <returns>返回整数</returns>
        public static ushort SetIntegerSomeBit(int _Mask, ushort a, bool flag) {
            if (flag) {
                a = Convert.ToUInt16(a | (0x1 << _Mask));
            } else {
                a = Convert.ToUInt16(a & ~(0x1 << _Mask));
            }
            return a;
        }

        #endregion 将无符号整型某个位赋值

        //=============================================
    }
}
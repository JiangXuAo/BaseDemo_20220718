using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Tools.DataConvert {

    public class UIntLib
    {

        #region 字节数组中截取转成32位无符号整型

        public static uint GetUIntFromByteArray(byte[] source, int start = 0, DataFormat type = DataFormat.ABCD)
        {
            return BitConverter.ToUInt32(ByteArrayLib.Get4ByteArray(source, start, type), 0);
        }

        #endregion 字节数组中截取转成32位无符号整型

        #region 将字节数组中截取转成32位无符号整型数组

        public static uint[] GetUIntArrayFromByteArray(byte[] source, DataFormat type = DataFormat.ABCD)
        {
            uint[] values = new uint[source.Length / 4];

            for (int i = 0; i < source.Length / 4; i++)
            {
                values[i] = GetUIntFromByteArray(source, 4 * i, type);
            }

            return values;
        }

        #endregion 将字节数组中截取转成32位无符号整型数组

        #region 将字符串转转成32位无符号整型数组

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

        #endregion 将字符串转转成32位无符号整型数组

        //=============================================
    }
}
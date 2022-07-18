using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Tools.DataConvert {

    /// <summary>
    /// Int����ת����
    /// </summary>
    public class IntLib {

        #region �ֽ������н�ȡת��32λ����

        /// <summary>
        /// �ֽ������н�ȡת��32λ����
        /// </summary>
        /// <param name="source"></param>
        /// <param name="start"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int GetIntFromByteArray(byte[] source, int start = 0, DataFormat type = DataFormat.ABCD) {
            return BitConverter.ToInt32(ByteArrayLib.Get4ByteArray(source, start, type), 0);
        }

        #endregion �ֽ������н�ȡת��32λ����

        #region ���ֽ������н�ȡת��32λ��������

        /// <summary>
        /// ���ֽ������н�ȡת��32λ��������
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

        #endregion ���ֽ������н�ȡת��32λ��������

        #region ���ַ���תת��32λ��������

        /// <summary>
        /// ���ַ���תת��32λ��������
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

        #endregion ���ַ���תת��32λ��������

        //=============================================
    }
}
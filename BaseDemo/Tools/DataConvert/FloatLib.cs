using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Tools.DataConvert {

    /// <summary>
    /// Float����ת����
    /// </summary>
    public class FloatLib {

        #region �ֽ������н�ȡת�ɸ�����

        /// <summary>
        /// ���ֽ�������ĳ4���ֽ�ת����Float����
        /// </summary>
        /// <param name="source"></param>
        /// <param name="start"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static float GetFloatFromByteArray(byte[] source, int start = 0, DataFormat type = DataFormat.ABCD) {
            byte[] result = ByteArrayLib.Get4ByteArray(source, start, type);
            if (result != null) {
                return BitConverter.ToSingle(result, 0);
            } else {
                return 0.0f;
            }
        }

        #endregion �ֽ������н�ȡת�ɸ�����

        #region ���ֽ������н�ȡת�ɸ���������

        /// <summary>
        /// ���ֽ�����ת����Float����
        /// </summary>
        /// <param name="source"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static float[] GetFloatArrayFromByteArray(byte[] source, DataFormat type = DataFormat.ABCD) {
            float[] values = new float[source.Length / 4];

            for (int i = 0; i < source.Length / 4; i++) {
                values[i] = GetFloatFromByteArray(source, 4 * i, type);
            }

            return values;
        }

        #endregion ���ֽ������н�ȡת�ɸ���������

        #region ���ַ���ת���ɸ���������

        /// <summary>
        /// ��Float�ַ���ת���ɵ����ȸ���������
        /// </summary>
        /// <param name="val">Float�ַ���</param>
        /// <returns>�����ȸ���������</returns>
        public static float[] GetFloatArrayFromString(string val) {
            List<float> Result = new List<float>();
            if (val.Contains(' ')) {
                string[] str = Regex.Split(val, "\\s+", RegexOptions.IgnoreCase);

                foreach (var item in str) {
                    Result.Add(Convert.ToSingle(item));
                }
            } else {
                Result.Add(Convert.ToSingle(val));
            }

            return Result.ToArray();
        }

        #endregion ���ַ���ת���ɸ���������

        //=============================================
    }
}
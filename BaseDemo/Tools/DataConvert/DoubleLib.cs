using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Tools.DataConvert {

    /// <summary>
    /// Double����ת����
    /// </summary>
    public class DoubleLib {

        #region �ֽ������н�ȡת��˫���ȸ�����

        /// <summary>
        /// ���ֽ�������ĳ8���ֽ�ת����Double����
        /// </summary>
        /// <param name="source">�ֽ�����</param>
        /// <param name="start">��ʼλ��</param>
        /// <param name="type">�ֽ�˳��</param>
        /// <returns>Double������ֵ</returns>
        public static double GetDoubleFromByteArray(byte[] source, int start, DataFormat type = DataFormat.ABCD) {
            byte[] result = ByteArrayLib.Get8ByteArray(source, start, type);
            if (result != null) {
                return BitConverter.ToDouble(result, 0);
            } else {
                return 0.0;
            }
        }

        #endregion �ֽ������н�ȡת��˫���ȸ�����

        #region ���ֽ������н�ȡת��˫���ȸ���������

        /// <summary>
        /// ���ֽ�����ת����Double����
        /// </summary>
        /// <param name="source">�ֽ�����</param>
        /// <param name="type">�ֽ�˳��</param>
        /// <returns>Double����</returns>
        public static double[] GetDoubleArrayFromByteArray(byte[] source, DataFormat type = DataFormat.ABCD) {
            double[] values = new double[source.Length / 8];

            for (int i = 0; i < source.Length / 4; i++) {
                values[i] = GetDoubleFromByteArray(source, 8 * i, type);
            }

            return values;
        }

        #endregion ���ֽ������н�ȡת��˫���ȸ���������

        #region ���ַ���תת��˫���ȸ���������

        /// <summary>
        /// ��Double�ַ���ת����˫���ȸ���������
        /// </summary>
        /// <param name="val">Double�ַ���</param>
        /// <returns>˫���ȸ���������</returns>
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

        #endregion ���ַ���תת��˫���ȸ���������

        //=============================================
    }
}
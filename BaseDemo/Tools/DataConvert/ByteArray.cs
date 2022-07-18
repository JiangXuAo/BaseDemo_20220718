using System.Collections.Generic;

namespace Tools.DataConvert {

    /// <summary>
    /// �ֽ����������
    /// </summary>
    public class ByteArray
    {

        #region ��ʼ��

        private List<byte> list = new List<byte>();

        /// <summary>
        /// ��ʼ��byte����
        /// </summary>
        public ByteArray()
        {
            list = new List<byte>();
        }

        #endregion ��ʼ��

        #region ��ȡ�ֽ�����

        /// <summary>
        /// ���ԣ������ֽ�����
        /// </summary>
        public byte[] array
        {
            get { return list.ToArray(); }
        }

        #endregion ��ȡ�ֽ�����

        #region ��ط���

        /// <summary>
        /// ����ֽ�����
        /// </summary>
        public void Clear()
        {
            list = new List<byte>();
        }

        /// <summary>
        /// ���һ���ֽ�
        /// </summary>
        /// <param name="item">�ֽ�</param>
        public void Add(byte item)
        {
            list.Add(item);
        }

        /// <summary>
        /// ���һ���ֽ�����
        /// </summary>
        /// <param name="items">�ֽ�����</param>
        public void Add(byte[] items)
        {
            list.AddRange(items);
        }

        /// <summary>
        /// ���һ��ByteArray����
        /// </summary>
        /// <param name="byteArray">ByteArray����</param>
        public void Add(ByteArray byteArray)
        {
            list.AddRange(byteArray.array);
        }

        #endregion ��ط���

        //=============================================
    }
}
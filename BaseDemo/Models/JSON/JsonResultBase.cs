using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Models.JSON {

    /// <summary>
    /// JSON对象基础类
    /// </summary>
    public class JsonResultBase {

        /// <summary>
        /// 最小值
        /// </summary>
        public float Min { get; set; }

        /// <summary>
        /// 最大值
        /// </summary>
        public float Max { get; set; }

        /// <summary>
        /// 当前值
        /// </summary>
        public float Value { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 返回结果
        /// </summary>
        public float Result { get; set; }
    }
}
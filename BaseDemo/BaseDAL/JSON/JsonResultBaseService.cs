using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.JSON;

namespace BaseDAL {

    /// <summary>
    /// JSON对象基础类的服务类
    /// </summary>
    public class JsonResultBaseService {
        public JsonResultBase JsonResultBase { get; set; }

        public JsonResultBaseService() {
        }

        public JsonResultBaseService(string title, float min, float max) : this() {
            JsonResultBase.Title = title;
            JsonResultBase.Min = min;
            JsonResultBase.Max = max;
        }

        public JsonResultBaseService(string title, float min, float max, float value) : this(title, min, max) {
            JsonResultBase.Value = value;
        }
    }
}
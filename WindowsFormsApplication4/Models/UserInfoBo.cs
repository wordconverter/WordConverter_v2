using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordConverter_v2.Models
{
    public class UserInfoBo
    {
        public int kengen { get; set; }
        public long userId { get; set; }
        public Boolean pascal { get; set; }
        public Boolean camel { get; set; }
        public Boolean snake { get; set; }
        public int dispNumber { get; set; }
        public string hotKey { get; set; }
        public int startUpMode { get; set; }
        public int empId { get; set; }
        public string dbType { get; set; }
    }
}


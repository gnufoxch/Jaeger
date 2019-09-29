using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Model
{
    public class OrderInfo
    {
        public int Id { get; set; }
        public DateTime InsertDate { get; set; }
        public bool Status { get; set; }
        public string FileName { get; set; }
        public string XmlContent { get; set; }
    }
}

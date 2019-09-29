using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Order.Model;
using Order = Order.Model.Order;

namespace OrderConsumer
{
    public static class DataOrganizer
    {
        public static global::Order.Model.OrderInfo LoadFromXmlString(string xmlFilePath)
        {
            XmlDocument doc  = new XmlDocument();
            doc.Load($@"{xmlFilePath}");
            string xmlContents = doc.InnerXml;
            var order = FileOrganizer.LoadFromXMLString(xmlContents);
            OrderInfo orderInfo = new OrderInfo()
            {
                FileName = Path.GetFileName(xmlFilePath),
                InsertDate = DateTime.Now,
                Status = order.Status,
                XmlContent = xmlContents
            };
            return orderInfo;
        }
    }
}

using Order.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace OrderGenerator
{
    public class OrderManager
    {
        public void CreateOrder(object o)
        {
            var order = new Order.Model.Order();
            order.Status = Status.GetBoolValue();

            Console.WriteLine($"Order created in  {DateTime.Now}");

            using (var stringWriter = new System.IO.StringWriter())
            {
                var serializer = new XmlSerializer(order.GetType());
                serializer.Serialize(stringWriter, order);
                Console.WriteLine(stringWriter);

                //create filename
                string fileName = $"Order_{order.Id}.xml";

                //save xml
                XmlDocument docSave = new XmlDocument();
                docSave.LoadXml(stringWriter.ToString());
                if (!Directory.Exists(Utility.Path.NewXml))
                {
                    Directory.CreateDirectory(Utility.Path.NewXml);
                }
                docSave.Save($@"{Utility.Path.NewXml}{fileName}");
            }
        }
    }
}

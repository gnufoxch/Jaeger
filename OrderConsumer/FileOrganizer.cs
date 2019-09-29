using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Business;
using Order = Order.Model.Order;

/// <summary>
/// Lok Fung CHOI
/// </summary>
namespace OrderConsumer
{
    public static class FileOrganizer
    {
        private static readonly OrderInfoLogic orderLogic = new OrderInfoLogic();

        public static void MoveFileToTempFolder(object state)
        {
            //Check if folder exists
            if (!Directory.Exists(Utility.Path.XmlTemp))
            {
                Directory.CreateDirectory(Utility.Path.XmlTemp);
            }

            //Get the files from folders
            string[] sourceFiles = Directory.GetFiles(Utility.Path.NewXml);


            //Move the files in another folder
            foreach (string sourceFile in sourceFiles)
            {
                string fileName = Path.GetFileName(sourceFile);
                string destinationFile = Path.Combine(Utility.Path.XmlTemp, fileName);

                File.Move(sourceFile, destinationFile);
            }
        }
        
        public static void MoveFilesToAnotherFolder(string source, string target)
        {
            //Check if folder exists
            if (!Directory.Exists(target))
            {
                Directory.CreateDirectory(target);
            }

            //Get the files from folders
            string[] sourceFiles = Directory.GetFiles(source);


            //Move the files in another folder
            foreach (string sourceFile in sourceFiles)
            {
                string fileName = Path.GetFileName(sourceFile);
                string destinationFile = Path.Combine(target, fileName);

                File.Move(sourceFile, destinationFile);
            }
        }

        public static void MoveOnFileAnotherFolder(string fileName, string source, string target)
        {
            //Check if folder exists
            if (!Directory.Exists(target))
            {
                Directory.CreateDirectory(target);
            }

            //Get the files from folders
            string sourceFile = Path.Combine(source,fileName);
            string destinationFile = Path.Combine(target, fileName);

            File.Move(sourceFile, destinationFile);
        }

        public static void InsertFileToDatabase(object o)
        {
            List<string> xmlList = ReadAllXmlFromFolder();

            foreach (var xmlFile in xmlList)
            {
                var order = DataOrganizer.LoadFromXmlString(xmlFile);
                orderLogic.Insert(order);
                FileOrganizer.MoveOnFileAnotherFolder(order.FileName, Utility.Path.XmlTemp, Utility.Path.XmlInsertedIntoDatabase);
            }

        }

        public static List<string> ReadAllXmlFromFolder()
        {
            List<string> xmlList = new List<string>();

            foreach (var xmlFile in Directory.EnumerateFiles(Utility.Path.XmlTemp, "*.xml"))
            {
                string contents = File.ReadAllText(xmlFile);
                xmlList.Add(xmlFile);
            }

            return xmlList;
        }


        public static global::Order.Model.Order LoadFromXMLString(string xmlText)
        {
            using (var stringReader = new System.IO.StringReader(xmlText))
            {
                var serializer = new XmlSerializer(typeof(global::Order.Model.Order));
                return serializer.Deserialize(stringReader) as global::Order.Model.Order;
            }
        }
    }
}

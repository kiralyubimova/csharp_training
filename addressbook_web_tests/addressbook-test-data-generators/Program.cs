using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTests;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            string format = args[2];
            List<GroupData> groups = new List<GroupData>();
            for(int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header = TestBase.GenerateRandomString(100),
                    Footer = TestBase.GenerateRandomString(100)
                });
            }
            if (format == "csv")
            {
                WriteGroupsToCSVFile(groups, writer);
            }
            else if (format == "xml")
            {
                WriteGroupsToXMLFile(groups, writer);
            }
            else if (format == "json")
            {
                WriteGroupsToJSONFile(groups, writer);
            }
            else
            {
                System.Console.Out.WriteLine("Unrecognised format " + format);
            }
            writer.Close();
        }

        static void WriteGroupsToCSVFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("{0};{1};{2}",
                    group.Name, group.Header, group.Footer));
            }
        }

        static void WriteGroupsToXMLFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void WriteGroupsToJSONFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }
    }
}

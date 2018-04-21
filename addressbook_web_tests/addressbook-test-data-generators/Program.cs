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
            string dataType = args[0];
            int count = Convert.ToInt32(args[1]);
            StreamWriter writer = new StreamWriter(args[2]);
            string format = args[3];
            if (dataType == "groups")
            {
                List<GroupData> groups = new List<GroupData>();
                for (int i = 0; i < count; i++)
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
            }
            else if (dataType == "contacts")
            {
                List<ContactData> contacts = new List<ContactData>();
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData(TestBase.GenerateRandomString(15), TestBase.GenerateRandomString(15))
                    {
                        Nickname = TestBase.GenerateRandomString(100),
                        Middlename = TestBase.GenerateRandomString(100),
                        Email = TestBase.GenerateRandomString(100),
                        Company = TestBase.GenerateRandomString(100),
                        Title = TestBase.GenerateRandomString(100),
                        Address = TestBase.GenerateRandomString(100)
                    });
                }

                if (format == "xml")
                {
                    WriteContactsToXMLFile(contacts, writer);
                }
                else if (format == "json")
                {
                    WriteContactsToJSONFile(contacts, writer);
                }
                else
                {
                    System.Console.Out.WriteLine("Unrecognised format " + format);
                }
            }
            else
            {
                System.Console.Out.WriteLine("Unrecognised data type " + dataType);
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

        static void WriteContactsToXMLFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        static void WriteContactsToJSONFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }
    }
}

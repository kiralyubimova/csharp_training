using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : ContactTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }

        [Test]
        public void TestContactInformationEditDetails()
        {
            string fromDetails = app.Contacts.GetContactInformationFromDetails(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            string personalBlock = strWithNewLine((strWithSpace(fromForm.Name) + strWithSpace(fromForm.Middlename) + fromForm.Surname).Trim()) +
                strWithNewLine(fromForm.Nickname) +
                strWithNewLine(fromForm.Title) +
                strWithNewLine(fromForm.Company) +
                strWithNewLine(fromForm.Address);
            string phoneBlock = "";
            if (fromForm.HomePhone != "")
            {
                phoneBlock = phoneBlock + "H: " + strWithNewLine(fromForm.HomePhone);
            }
            if (fromForm.MobilePhone != "")
            {
                phoneBlock = phoneBlock + "M: " + strWithNewLine(fromForm.MobilePhone);
            }
            if (fromForm.WorkPhone != "")
            {
                phoneBlock = phoneBlock + "W: " + strWithNewLine(fromForm.WorkPhone);
            }

            if (fromForm.Fax != "")
            {
                phoneBlock = phoneBlock + "F: " + strWithNewLine(fromForm.Fax);
            }

            string emailBlock = strWithNewLine(fromForm.Email) +
                strWithNewLine(fromForm.Email2) +
                strWithNewLine(fromForm.Email3);
            if (fromForm.Homepage != "")
            {
                emailBlock = emailBlock + "Homepage:\r\n" + fromForm.Homepage;
            }


            string stringFromForm = (strWithNewLine(personalBlock) +
                strWithNewLine(phoneBlock) + 
                strWithNewLine(emailBlock)).Trim();

            fromDetails = fromDetails.Substring(0, stringFromForm.Length);
            Assert.AreEqual(fromDetails, stringFromForm);
        }
        private string strWithSpace(string str)
        {
            if(str == "" || str == null)
            {
                return "";
            }
            return str.Trim() + " ";
        }
        private string strWithNewLine(string str)
        {
            if (str == "" || str == null)
            {
                return "";
            }
            return str + "\r\n";
        }
    }
}

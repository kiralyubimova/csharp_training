using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
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
            string stringFromForm = (strWithSpace(fromForm.Name) + strWithSpace(fromForm.Middlename) + fromForm.Surname).Trim() + "\r\n"
                +(fromForm.Nickname).Trim()+"\r\n";
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
    }
}

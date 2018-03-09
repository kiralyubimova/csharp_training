using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
       [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Mike", "Smith");
            contact.Nickname = "Mickie";
            
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Create(contact);
            oldContacts.Add(contact);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            app.Auth.LogOut();
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("", "");

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Create(contact);
            oldContacts.Add(contact);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            app.Auth.LogOut();
        }
    }
}

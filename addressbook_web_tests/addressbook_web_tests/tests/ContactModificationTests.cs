using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
 
    class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newContactData = new ContactData("Modified", "Modifiedsurname");
            app.Contacts.CheckContactExistance();
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Modify(0, newContactData);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Name = newContactData.Name;
            oldContacts[0].Surname = newContactData.Surname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            app.Auth.LogOut();
        }

        [Test]
        public void RandomContactModificationTest()
        {
            ContactData newContactData = new ContactData("RandomModified", "RandomModifiedsurname");
            app.Contacts.CheckContactExistance();
            app.Contacts.ModifyRandom(newContactData);
            app.Auth.LogOut();
        }

    }
}

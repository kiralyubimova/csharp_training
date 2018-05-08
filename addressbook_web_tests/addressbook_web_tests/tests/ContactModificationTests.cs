using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
 
    class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newContactData = new ContactData("Modified", "Modifiedsurname");
            app.Contacts.CheckContactExistance();
            List<ContactData> oldContacts = ContactData.GetAll();
            oldContacts.Sort();
            app.Contacts.Modify(0, newContactData);
            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts[0].Name = newContactData.Name;
            oldContacts[0].Surname = newContactData.Surname;
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void RandomContactModificationTest()
        {
            ContactData newContactData = new ContactData("RandomModified", "RandomModifiedsurname");
            app.Contacts.CheckContactExistance();
            app.Contacts.ModifyRandom(newContactData);
        }

    }
}

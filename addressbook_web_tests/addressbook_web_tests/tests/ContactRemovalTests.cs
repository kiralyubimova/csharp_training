using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Contacts.CheckContactExistance();
            List<ContactData> oldContacts = ContactData.GetAll();
            oldContacts.Sort();

            app.Contacts.Remove(0);
            oldContacts.RemoveAt(0);
            
            List<ContactData> newContacts = ContactData.GetAll();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void RandomContactRemovalTest()
        {
            app.Contacts.CheckContactExistance();
            app.Contacts.RemoveRandom();
        }
    }
}

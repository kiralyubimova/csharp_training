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

            app.Contacts.Modify(14, newContactData);
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

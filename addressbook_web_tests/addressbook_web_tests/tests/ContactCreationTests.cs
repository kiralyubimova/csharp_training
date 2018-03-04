using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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

            app.Contacts.Create(contact);
            app.Auth.LogOut();
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("", "");

            app.Contacts.Create(contact);
            app.Auth.LogOut();
        }
    }
}

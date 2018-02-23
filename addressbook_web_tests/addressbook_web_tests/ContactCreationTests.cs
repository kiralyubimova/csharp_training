using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
       [Test]
        public void ContactCreationTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            AddNewContact();

            // Initializing object contact
            ContactData contact = new ContactData("Mike", "Smith");
            contact.Nickname = "Mickie";

            // Calling method with initialised object as parameter
            FillContactForm(contact);

            SubmitForm();
            LogOut();
        }
    }
}

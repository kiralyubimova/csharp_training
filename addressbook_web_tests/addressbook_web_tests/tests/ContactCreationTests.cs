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
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Contacts.AddNewContact();

            // Initializing object contact
            ContactData contact = new ContactData("Mike", "Smith");
            contact.Nickname = "Mickie";

            // Calling method with initialised object as parameter
            app.Contacts.FillContactForm(contact);

            app.Contacts.SubmitForm();
            app.Auth.LogOut();
        }
    }
}

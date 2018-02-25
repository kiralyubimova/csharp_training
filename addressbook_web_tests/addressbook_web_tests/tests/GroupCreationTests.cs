using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupsPage();
            app.Groups.InitGroupCreation();

            // Initializing object group
            GroupData group = new GroupData("Group Name");
            group.Header = "Group Header";
            group.Footer = "Group Footer";

            // Calling method with initialised object as parameter
            app.Groups.FillGroupForm(group);

            app.Groups.SubmitGroupCreation();
            app.Groups.ReturnToGroupsPage();
        }        
    }
}

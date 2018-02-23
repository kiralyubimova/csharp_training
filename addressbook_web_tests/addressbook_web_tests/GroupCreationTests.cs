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
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitGroupCreation();

            // Initializing object group
            GroupData group = new GroupData("Group Name");
            group.Header = "Group Header";
            group.Footer = "Group Footer";

            // Calling method with initialised object as parameter
            FillGroupForm(group);

            SubmitGroupCreation();
            ReturnToGroupsPage();
        }        
    }
}

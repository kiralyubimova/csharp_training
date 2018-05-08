using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("New Group Name");
            newData.Header = null;
            newData.Footer = null;
            app.Groups.CheckGroupExistance();
            List<GroupData> oldGroups = GroupData.GetAll();
            oldGroups.Sort();
            GroupData oldData = oldGroups[0];

            app.Groups.Modify(0, newData);

            List<GroupData> newGroups = GroupData.GetAll();

            Assert.AreEqual(oldGroups.Count, newGroups.Count);

            oldGroups[0].Name = newData.Name;
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            foreach(GroupData group in newGroups)
            {
                if(group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }

    }
}

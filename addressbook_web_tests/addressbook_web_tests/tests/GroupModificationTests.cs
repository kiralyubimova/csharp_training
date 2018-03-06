﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("New Group Name");
            newData.Header = null;
            newData.Footer = null;

            app.Groups.Modify(1, newData);
        }

        [Test]
        public void RandomGroupModificationTest()
        {
            GroupData newData = new GroupData("New Group Name Random");
            newData.Header = null;
            newData.Footer = null;

            app.Groups.CheckGroupExistance();
            app.Groups.ModifyRandom(newData);
        }
    }
}
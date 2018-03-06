﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Contacts.Remove("14");
        }

        [Test]
        public void RandomContactRemovalTest()
        {
            app.Contacts.CheckContactExistance();
            app.Contacts.RemoveRandom();
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                List<ContactData> contacts = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    ICollection<IWebElement> columns = element.FindElements(By.CssSelector("td"));
                    string surname = columns.ElementAt(1).Text;
                    string name = columns.ElementAt(2).Text;
                    string id = columns.ElementAt(0).FindElement(By.Name("selected[]")).GetAttribute("id");

                    ContactData contactData = new ContactData(name, surname);
                    contactData.Id = id;

                    contacts.Add(contactData);
                }
            }
            return new List<ContactData>(contactCache);
        }

        public ContactHelper Create(ContactData contact)
        {
            AddNewContact();
            FillContactForm(contact);
            SubmitForm();
            return this;
        }

        public ContactHelper Modify(int index, ContactData newContactData)
        {
            EditContact(index);
            FillContactForm(newContactData);
            SubmitForm();
            return this;
        }

        public ContactHelper CheckContactExistance()
        {
            if (!IsElementPresent(By.Name("selected[]")))
            {
                Create(new ContactData("Dave", "Black"));
                manager.Navigator.GoToHomePage();
            }
            return this;
        }

        public ContactHelper ModifyRandom(ContactData newContactData)
        {
            EditRandomContact();
            FillContactForm(newContactData);
            SubmitForm();
            return this;
        }


        public ContactHelper Remove(int index)
        {
            SelectContact(index);
            RemoveContact();
            return this;
        }


        public ContactHelper RemoveRandom()
        {
            if (!IsElementPresent(By.Name("selected[]")))
            {
                Create(new ContactData("Dave", "Black"));
                manager.Navigator.GoToHomePage();
            }
            SelectRandomContact();
            RemoveContact();
            return this;
        }

        public ContactHelper AddNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Name);
            Type(By.Name("lastname"), contact.Surname);
            Type(By.Name("nickname"), contact.Nickname);
            return this;
        }

        public ContactHelper SubmitForm()
        {
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            contactCache = null;
            return this;
        }



        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }


        public ContactHelper SelectRandomContact()
        {
            ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.Name("selected[]"));

            Random rnd = new Random();
            int int_index = rnd.Next(0, elements.Count);
            IWebElement random_element = elements[int_index];
            random_element.Click();
            return this;
        }

        public ContactHelper EditContact(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + index + "]")).Click();
            return this;
        }

        public ContactHelper EditRandomContact()
        {
            ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.Name("selected[]"));

            Random rnd = new Random();
            int int_index = rnd.Next(1, elements.Count+1);

            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + int_index + "]")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
            return this;
        }
    }
}

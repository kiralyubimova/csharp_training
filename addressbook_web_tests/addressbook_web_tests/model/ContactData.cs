using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string middlename = "";
        private string nickname = "";
        private string title = "";
        private string company = "";
        private string fax = "";
        private string email = "";
        private string email2 = "";
        private string email3 = "";
        private string homepage = "";
        private string group = "";
        private string secondaryaddress = "";
        private string secondaryhome = "";
        private string notes = "";
        private string allPhones;
        // service field
        private string id = "";
        private string allEmails;

        public ContactData(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if(Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name && Surname == other.Surname;
        }

        public override int GetHashCode()
        {
            return (Name+Surname).GetHashCode();
        }

        public override string ToString()
        {
            return "name = " + Name + "\nsurname = " + Surname + "\nnickname = " + Nickname;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Surname.CompareTo(other.Surname) != 0)
            {
                return Surname.CompareTo(other.Surname);
            }
            return Name.CompareTo(other.Name);
        }

        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string Notes
        {
            get
            {
                return notes;
            }
            set
            {
                notes = value;
            }
        }

        public string Secondaryhome
        {
            get
            {
                return secondaryhome;
            }
            set
            {
                secondaryhome = value;
            }
        }

        public string Secondaryaddress
        {
            get
            {
                return secondaryaddress;
            }
            set
            {
                secondaryaddress = value;
            }
        }

        public string Group
        {
            get
            {
                return group;
            }
            set
            {
                group = value;
            }
        }

        public string Homepage
        {
            get
            {
                return homepage;
            }
            set
            {
                homepage = value;
            }
        }

        public string Email3
        {
            get
            {
                return email3;
            }
            set
            {
                email3 = value;
            }
        }

        public string Email2
        {
            get
            {
                return email2;
            }
            set
            {
                email2 = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public string Fax
        {
            get
            {
                return fax;
            }
            set
            {
                fax = value;
            }
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUpEMail(Email) + CleanUpEMail(Email2) + CleanUpEMail(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, @"[ \-()]", "") + "\r\n";
        }
        private string CleanUpEMail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email.Trim() + "\r\n";
        }

        public string WorkPhone { get; set; }

        public string MobilePhone { get; set; }

        public string HomePhone { get; set; }

        public string Address { get; set; }

        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Middlename
        {
            get
            {
                return middlename;
            }
            set
            {
                middlename = value;
            }
        }

        public string Nickname
        {
            get
            {
                return nickname;
            }
            set
            {
                nickname = value;
            }
        }
    }
}

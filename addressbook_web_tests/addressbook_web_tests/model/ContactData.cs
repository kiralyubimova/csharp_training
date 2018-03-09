using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string name;
        private string surname;
        private string middlename = "";
        private string nickname = "";
        private string title = "";
        private string company = "";
        private string address = "";
        private string homephone = "";
        private string mobilephone = "";
        private string workphone = "";
        private string fax = "";
        private string email = "";
        private string email2 = "";
        private string email3 = "";
        private string homepage = "";
        private string group = "";
        private string secondaryaddress = "";
        private string secondaryhome = "";
        private string notes = "";
        // service field
        private string id = "";

        public ContactData(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
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
            return Name + " " + Surname;
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

        public string Workphone
        {
            get
            {
                return workphone;
            }
            set
            {
                workphone = value;
            }
        }

        public string Mobilephone
        {
            get
            {
                return mobilephone;
            }
            set
            {
                mobilephone = value;
            }
        }

        public string Homephone
        {
            get
            {
                return homephone;
            }
            set
            {
                homephone = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

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

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }

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

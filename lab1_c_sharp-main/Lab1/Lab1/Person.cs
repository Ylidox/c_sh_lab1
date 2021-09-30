using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class Person : IDateAndCopy
    {
        protected string name;
        protected string surname;
        protected DateTime birthday;

        public Person()
        {
            name = "Борис";
            surname = "Ельцин";
            birthday = new DateTime(1931, 2, 1);
        }

        public Person(string name, string surname, DateTime bd)
        {
            this.name = name;
            this.surname = surname;
            this.birthday = bd;
        }

        public string Name {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Surname {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }
        public int Year 
        {
            get
            {
                return birthday.Year;
            }
            set
            {
                birthday = new DateTime(value, birthday.Month, birthday.Day);
            }
        }

        public DateTime Date
        {
            get
            {
                return birthday;
            }
            set
            {
                birthday = value;
            }
        }
        public override string ToString()
        {
            return Surname + " " + Name + " " + birthday.ToShortDateString();
        }

        public virtual string ToShortString()
        {
            return Surname + " " + Name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Person m = obj as Person;
            if (m as Person == null)
                return false;

            return m.Name == this.Name &&
                m.Surname  == this.Surname &&
                m.birthday.ToShortDateString() == this.birthday.ToShortDateString();
        }

        public static bool operator== (Person obj1, Person obj2)
        {
            return obj1.Equals(obj2);
        }
        public static bool operator!=(Person obj1, Person obj2)
        {
            return !obj1.Equals(obj2);
        }

        public override int GetHashCode()
        {
            char[] name = this.Name.ToCharArray();
            char[] surname = this.Surname.ToCharArray();
            int result = 0;
            for (int i = 0; i < surname.Length; i++)
            {
                result = result * 11 + surname[i];
            }
            for (int i = 0; i < name.Length; i++)
            {
                result += name[i] * 31;
            }
            return result;
        }

        public virtual object DeepCopy()
        {
            Person p = new Person(this.Name, this.Surname, this.birthday);
            object obj = p;
            return obj;
        }
    }
}

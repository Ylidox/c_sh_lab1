using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class Test
    {
        private string subject;
        private bool isPassed;

        public string Subject
        {
            get
            {
                return subject;
            }
            set
            {
                subject = value;
            }
        }
        public bool IsPassed
        {
            get
            {
                return isPassed;
            }
            set
            {
                isPassed = value;
            }
        }

        public Test()
        {
            subject = "Math";
            isPassed = true;
        }
        public Test(string subject, bool isPassed)
        {
            this.subject = subject;
            this.isPassed = isPassed;
        }
        public virtual object DeepCopy()
        {
            Test t = new Test(Subject, IsPassed);
            object obj = t;
            return obj;
        }

        public override string ToString()
        {
            string output = subject;
            output += (isPassed) ? " зачет" : " незачет";
            return output;
        }
    }
}

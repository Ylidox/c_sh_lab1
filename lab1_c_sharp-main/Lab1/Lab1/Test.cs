using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class Test
    {
        private string subject;
        private bool isPassed;

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
        public override string ToString()
        {
            return this.subject + " " + this.isPassed;
        }
    }
}

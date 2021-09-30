using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class Exam : IDateAndCopy
    {
        private string lesson;
        private int note;
        private DateTime date;

        public string Lesson
        {
            get
            {
                return lesson;
            }
            set
            {
                lesson = value;
            }
        }
        public int Note
        {
            get
            {
                return note;
            }
            set
            {
                note = value;
            }
        }
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }
        public Exam()
        {
            lesson = "mathematics";
            note = 5;
            date = new DateTime(2020, 7, 1);
        }
        public Exam(string lesson, int note, DateTime date)
        {
            this.lesson = lesson;
            this.note = note;
            this.date = date;
        }

        public override string ToString()
        {
            return Lesson + " " + Note + " " + Date.ToShortDateString();
        }

        public virtual object DeepCopy()
        {
            Exam e = new Exam(this.Lesson, this.note, this.date);
            object obj = e;
            return e;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class Student : Person
    {
        private Person personalData;
        private Education education;
        private int group;
        private Exam[] exams;

        public Student(Person personalDateValue, Education educationValue, int groupValue, Exam[] examsValue)
        {
            personalData = personalDateValue;
            education = educationValue;
            group = groupValue;
            exams = new Exam[0];
            this.AddExams(examsValue);
        }
        public Student()
        {
            personalData = new Person();
            education = Education.Вachelor;
            group = 13;
            exams = new Exam[0];
        }
        public Person Person
        {
            get
            {
                return personalData;
            }
            set
            {
                personalData = value;
            }
        }
        public Education Education
        {
            get
            {
                return education;
            }
            set
            {
                education = value;
            }
        }
        public int Group
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
        public Exam[] Exams
        {
            get
            {
                return exams;
            }
            set
            {
                exams = value;
            }
        }
        public double averageRating
        {
            get
            {
                double output = 0;
                for (var i = 0; i < this.exams.Length; i++)
                {
                    output += exams[i].Note;
                }
                output /= this.exams.Length;
                return output;
            }
        }

        public bool this[Education index]
        {
            get
            {
                if (this.education == index)
                {
                    return true;                
                }
                return false;
            }
        }
        public void AddExams(Exam[] exams)
        {
            int len = this.exams.Length;
            Array.Resize(ref this.exams, this.exams.Length + exams.Length);
            
            for (int i = 0; i < exams.Length; i++)
            {
                this.exams[len + i] = exams[i].DeepCopy() as Exam;
            }
        }
        public override string ToString()
        {
            string outExams = "";
            for (int i = 0; i < this.exams.Length; i++)
            {
                outExams += exams[i].ToString() + "\n";
            }
            return personalData.ToString() + "\n" +
                    education + "\n" +
                    group + "\n" +
                    outExams;
        }
        public virtual string ToShortString()
        {
            return personalData.ToString() + "\n" +
                    education + "\n" +
                    group + "\n" +
                    this.averageRating;
        }
        public virtual Student DeepCopy()
        {
            Student s = new Student();
            s.personalData = this.personalData.DeepCopy() as Person;
            s.education = this.education;
            s.group = this.group;
            s.AddExams(this.exams);    
            return s;
        }
    }
}

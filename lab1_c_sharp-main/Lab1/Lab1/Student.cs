using System;
using System.Collections;
using System.Text;


namespace Lab1
{
    class Student : Person, IDateAndCopy
    {
        private Education education;
        private int group;
        private ArrayList tests;
        private ArrayList exams;

        public Student(Person personalDateValue, Education educationValue, int groupValue, ArrayList examsValue, ArrayList testsValue)
            : base(personalDateValue)
        {
            education = educationValue;
            Group = groupValue;
            exams = new ArrayList();
            this.AddExams(examsValue);
            tests = new ArrayList();
            this.AddTests(testsValue);
        }
        public Student() : base()
        {
            education = Education.Вachelor;
            Group = 113;
            exams = new ArrayList();
            tests = new ArrayList();
        }
        public Student(Person personValue, Education educationValue, int groupValue)
            : base(personValue)
        {
            education = educationValue;
            group = groupValue;
            exams = new ArrayList();
            tests = new ArrayList();
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
                if (value < 100 || value > 599){
                    throw new Exception("\nПередано некорректное значение группы!\n");
                }
                group = value;   
            }
        }
        public int Size
        {
            get
            {
                return this.exams.Count + this.tests.Count;
            }
        }
        public ArrayList Exams
        {
            get
            {
                return exams;
            }
            set
            {
                exams.Clear();
                exams.AddRange(value);
            }
        }
        public double averageRating
        {
            get
            {
                double output = 0;
                foreach (Exam exam in exams)
                    output += exam.Note;
                output /= exams.Count;
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

        public object this[int index]
        {
            get
            {
                try 
                {
                    object obj = new object();
                    if (index < this.exams.Count)
                    {
                        obj = this.exams[index];
                    }
                    else if (index >= this.exams.Count &&
                        this.exams.Count - index < this.tests.Count)
                    {
                        int i = index - this.exams.Count;
                        obj = this.tests[i];
                    }
                    else
                    {
                        throw new Exception("\nПереданный индекс выходит за пределы массивов exams и tests!\n");
                    }
                    return obj;
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                    return null;
                }
            }
        }

        public object this[int index, int note]
        {
            get
            {
                try
                {
                    if (index < this.exams.Count)
                    {
                        Exam e = this.exams[index] as Exam;
                        if(e.Note >= note)
                        {
                            return this.exams[index];
                        }
                            
                    }
                    else
                    {
                        throw new Exception("\nПереданный индекс выходит за пределы массивов exams!\n");
                    }
                    return null;
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                    return null;
                }
            }
        }

        public void AddExams( Exam[] exams)
        {
            foreach (Exam exam in exams)
                this.exams.Add(exam.DeepCopy() as Exam);
        }
        public void AddExams(ArrayList exams)
        {
            foreach (Exam exam in exams)
                this.exams.Add(exam.DeepCopy() as Exam);
        }
        public void AddTests(ArrayList tests)
        {
            foreach (Test test in tests)
                this.tests.Add(test.DeepCopy() as Test);
        }
        public override string ToString()
        {
            string outTests = "";
            string outExams = "\n";
            foreach (Exam exam in exams)
                outExams += exam.ToString() + "\n";
            foreach (Test test in tests)
                outTests += test.ToString() + "\n";
            return this.Name + " " + this.Surname + " " + this.Date.ToShortDateString() + "\n" +
                    education + "\n" +
                    group + "\n" +
                    outExams + "\n" +
                    outTests;
        }
        public override string ToShortString()
        {
            return this.Name + " " + this.Surname + " " + this.Date.ToShortDateString() + "\n" +
                    education + "\n" +
                    group + "\n" +
                    this.averageRating;
        }
        public override object DeepCopy()
        {
            Student s = new Student();
            s.Name    = this.Name;
            s.Surname = this.Surname;
            s.Date    = this.Date;
            s.education = this.education;
            s.group     = this.group;
            s.AddExams(this.exams);
            s.AddTests(this.tests);

            object obj = s;
            return obj;
        }
    }
}

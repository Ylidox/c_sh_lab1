using System;
using System.Collections;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1
            Person A = new Person("Иван", "Кораблев", new DateTime(2002, 5, 17));
            Person B = new Person("Иван", "Кораблев", new DateTime(2002, 5, 17));

            Console.WriteLine(A == B);
            Console.WriteLine((object)A == (object)B);
            Console.WriteLine(A.GetHashCode() + "\n" + B.GetHashCode() + "\n");

            // 2
            ArrayList test1 = new ArrayList();
            test1.Add(new Test("C#", false));

            ArrayList ex1 = new ArrayList();
            ex1.Add(new Exam("Физика", 4, new DateTime(2020, 6, 15)));
            ex1.Add(new Exam("Мат. анализ", 4, new DateTime(2020, 6, 18)));
            ex1.Add(new Exam("ПрЧМИ", 5, new DateTime(2020, 6, 21)));
            ex1.Add(new Exam("Линейная алгебра", 2, new DateTime(2020, 6, 12)));

            Student student = new Student(
                new Person(),
                Education.Вachelor,
                123,
                ex1,
                test1);

            Console.WriteLine(student);
            // 3
            Console.WriteLine(student.Name + " " + student.Surname + " " + student.Date.ToShortDateString() + "\n");

            // 4
            Student student2 = student.DeepCopy() as Student;
            student.Name = "Михаил";
            student.Surname = "Горбачев";
            student.Date = new DateTime(1931, 3, 2);
            Console.WriteLine(student);
            Console.WriteLine(student2);

            // 5
            try
            {
                student.Group = 70;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

            // 6
            Console.WriteLine("/*****/\n");
            for (int i = 0; i < student.Size; i++)
            {
                Exam e = student[i] as Exam;
                Test t = student[i] as Test;
                if(e as Exam != null) Console.WriteLine(e);
                if(t as Test != null) Console.WriteLine(t);

            }

            // 7
            for (int i = 0; i < student.Exams.Count; i++)
            {
                Exam e = student[i, 3] as Exam;
                if (e as Exam != null) Console.WriteLine(e);
            }

            // 8


            /*ArrayList test1 = new ArrayList();
            test1.Add(new Test("C#", false));

            ArrayList ex1 = new ArrayList();
            ex1.Add(new Exam("Физика", 4, new DateTime(2020, 6, 15)));
            ex1.Add(new Exam("Мат. анализ", 4, new DateTime(2020, 6, 18)));
            ex1.Add(new Exam("ПрЧМИ", 5, new DateTime(2020, 6, 21)));
            ex1.Add(new Exam("Линейная алгебра", 4, new DateTime(2020, 6, 12)));*/

            /*Student A = new Student(
                new Person(),
                Education.Вachelor,
                123,
                ex1,
                test1);

            Student B = new Student(
                new Person(),
                Education.Вachelor,
                123,
                ex1,
                test1);*/

            /*Console.WriteLine(student.ToShortString());

            Console.WriteLine("Студент " + student.Surname +
                " бакалавр: " + student[Education.Вachelor]);
            Console.WriteLine("Студент " + student.Surname +
                " специалист: " + student[Education.Specialist]);
            Console.WriteLine("Студент " + student.Surname +
                " получает второе образование: " + student[Education.SecondEducation]);

            Console.WriteLine(student.ToString());

            Student s = student.DeepCopy() as Student;
            Console.WriteLine(student.GetHashCode() + "\n" + s.GetHashCode());*/

        }
    }
}

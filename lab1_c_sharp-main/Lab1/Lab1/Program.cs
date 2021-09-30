using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Exam[] ex1 = new Exam[3]
            {
                new Exam("Физика", 4, new DateTime(2020, 6, 15)),
                new Exam("Мат. анализ", 4, new DateTime(2020, 6, 18)),
                new Exam("ПрЧМИ", 5, new DateTime(2020, 6, 21))
            };
            Exam[] ex2 = new Exam[2]
            {
                new Exam("Линейная алгебра", 4, new DateTime(2020, 6, 12)),
                new Exam("Спец. разделы мат.анализа", 4, new DateTime(2020, 6, 12))
            };

            Student student = new Student(
                new Person(),
                Education.Вachelor,
                23,
                ex1 );

            student.AddExams(ex2);
            
            Console.WriteLine(student.ToShortString());

            Console.WriteLine("Студент " + student.Person.Surname +
                " бакалавр: " + student[Education.Вachelor]);
            Console.WriteLine("Студент " + student.Person.Surname +
                " специалист: " + student[Education.Specialist]);
            Console.WriteLine("Студент " + student.Person.Surname +
                " получает второе образование: " + student[Education.SecondEducation]);

            Console.WriteLine(student.ToString());

            Student s = student.DeepCopy();
            Console.WriteLine(student.Person.GetHashCode() + "\n" + s.Person.GetHashCode());

            /*TimeAnalysis ta = new TimeAnalysis();
            ta.input();

            Console.WriteLine("Время одномерного массива    : " + ta.analyzingOneDimensionalArray() + "ms");
            Console.WriteLine("Время прямоугольного массива : " + ta.analyzingRectangularArray() + "ms");
            Console.WriteLine("Время ступенчатого массива   : " + ta.analyzingJaggedArray() + "ms");*/
        }
    }
}

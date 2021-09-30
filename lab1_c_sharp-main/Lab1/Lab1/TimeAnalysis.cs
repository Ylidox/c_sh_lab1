using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class TimeAnalysis
    {
        private int row = 0;
        private int column = 0;
        private char[] separators = new char[] { ',', '/', '|', '-', ':', '.' };

        public int Row
        {
            get
            {
                return row;
            }
            set
            {
                row = value;
            }
        }
        public int Column
        {
            get
            {
                return column;
            }
            set
            {
                column = value;
            }
        }
        public void input()
        {
            string sep = "";
            for (int i = 0; i < separators.Length; i++)
            {
                if (i != separators.Length - 1) sep += "'" + separators[i] + "',";
                else sep += "'" + separators[i] + "'";
            }
            Console.WriteLine("Введите размеры массивов: \n" +
                "(используйте разделители " +
                sep + ")\n");

            string str = Console.ReadLine();
            string[] res = str.Split(this.separators);
            row = int.Parse(res[0]);
            column = int.Parse(res[1]);
        }

        public long analyzingOneDimensionalArray()
        {
            long start = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            
            Exam[] array = new Exam[column * row];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new Exam();
                array[i].Date.AddDays(2);
            }
            
            long end = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond; 
            return end - start;
        }
        public long analyzingRectangularArray()
        {
            long start = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

            Exam[,] array = new Exam[row, column];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    array[i, j] = new Exam();
                    array[i, j].Date.AddDays(2);
                }
            }

            long end = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            return end - start;
        }

        public long analyzingJaggedArray()
        {
            long start = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

            Exam[][] array = new Exam[row][];
            for (int i = 0; i < row; i++)
            {
 
                if(i % 2 == 0) array[i] = new Exam[column + 10];
                else array[i] = new Exam[column - 10];

                for (int j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = new Exam();
                    array[i][j].Date.AddDays(2);
                }
            }

            long end = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            
            return end - start;
        }
    }
}

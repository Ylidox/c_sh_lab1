using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    interface IDateAndCopy
    {
        object DeepCopy();
        DateTime Date { get; set; }
    }
}

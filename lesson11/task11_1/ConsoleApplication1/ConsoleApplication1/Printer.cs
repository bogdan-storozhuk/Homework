﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
   public class Printer
    {
        public virtual void Print(string inputText)
        {
            Console.WriteLine(inputText);
        }
    }
}

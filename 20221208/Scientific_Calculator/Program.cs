using System;
using System.Collections;


namespace Scientific_Calculator
{
    class Scientific_Calculator
    {
        public static void Main()
        {
            Calculator cal = new Calculator();
    
            while (true)
            {
                cal.Print();
                cal.BasicUI();
                cal.InputNum();     
            }
        }
    }
}
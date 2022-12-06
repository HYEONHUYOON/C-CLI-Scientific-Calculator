using System;
using System.Collections;


namespace Scientific_Calculator
{
    class Scientific_Calculator
    {
        public static void Main()
        {
            MathFunc mathF = new MathFunc();

            Console.Write(mathF.exp(1, 1));

            Calculator cal = new Calculator();
            while (true)
            {
                cal.Print();

                if (!cal.isSecondMode)
                {
                    cal.BasicUI();
                }
                else
                {
                    cal.SecondModeUI();
                }

                cal.InputNum();
            }
        }
    }
}
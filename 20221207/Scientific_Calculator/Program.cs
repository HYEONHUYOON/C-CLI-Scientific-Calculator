using System;
using System.Collections;


namespace Scientific_Calculator
{
    class Scientific_Calculator
    {
        public static void Main()
        {
            Calculator cal = new Calculator();
            List<string> a = new List<string>();
            a.Add("0");
            a.Add("+");
            a.Add("1");

            string input = String.Join("", a.ToArray()); 

            string s = cal.Postfix(input);
            double val = cal.CalFormul(s);

            Console.WriteLine(val);

            while (true)
            {
                cal.Print();
                cal.BasicUI();
                cal.InputNum();
               
            }
        }
    }
}
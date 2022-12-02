using System;
using System.Collections;
using System.Collections.Generic;

namespace Scientific_Calculator
{
    public class Calculator
    {
        //후위 변환식을 위한 연산자 저장
        Stack<char> stack = new Stack<char>();

        //콘솔 계산식을 위한 저장
        List<string> calculate = new List<string>();

        //실수인지 판별을 위한 TryParse 변수
        double value;
        bool isValue;

        public Calculator(){}

        //세컨드모드 인지
        public bool isSecondMode = false;

        //기본 UI CE
        public void BasicUI()
        {
            //계산중인 식출력 오른쪽 정렬
            //결과값 오른쪽 정렬

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}","secondMode[10]");
            Console.Write("|");
            Console.Write("{0,15}", "π[11]");
            Console.Write("|");
            Console.Write("{0,15}", "e[12]");
            Console.Write("|");
            Console.Write("{0,15}", "CE[13]");
            Console.Write("|");
            Console.Write("{0,15}", "<<[14]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "sqr(x)[15]");
            Console.Write("|");
            Console.Write("{0,15}", "1/x[16]");
            Console.Write("|");
            Console.Write("{0,15}", "abs(x)[17]");
            Console.Write("|");
            Console.Write("{0,15}", "exp[18]");
            Console.Write("|");
            Console.Write("{0,15}", "mod[19]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "sqrt(x)[20]");
            Console.Write("|");
            Console.Write("{0,15}", "([21]");
            Console.Write("|");
            Console.Write("{0,15}", ")[22]");
            Console.Write("|");
            Console.Write("{0,15}", "n![23]");
            Console.Write("|");
            Console.Write("{0,15}", "/[24]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "^[25]");
            Console.Write("|");
            Console.Write("{0,15}", "7");
            Console.Write("|");
            Console.Write("{0,15}", "8");
            Console.Write("|");
            Console.Write("{0,15}", "9");
            Console.Write("|");
            Console.Write("{0,15}", "*[26]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "10^[27]");
            Console.Write("|");
            Console.Write("{0,15}", "4");
            Console.Write("|");
            Console.Write("{0,15}", "5");
            Console.Write("|");
            Console.Write("{0,15}", "6");
            Console.Write("|");
            Console.Write("{0,15}", "-[28]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "log[29]");
            Console.Write("|");
            Console.Write("{0,15}", "1");
            Console.Write("|");
            Console.Write("{0,15}", "2");
            Console.Write("|");
            Console.Write("{0,15}", "3");
            Console.Write("|");
            Console.Write("{0,15}", "+[30]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "ln[31]");
            Console.Write("|");
            Console.Write("{0,15}", "+/-[32]");
            Console.Write("|");
            Console.Write("{0,15}", "0");
            Console.Write("|");
            Console.Write("{0,15}", ".[34]");
            Console.Write("|");
            Console.Write("{0,15}", "=[35]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();
        }

        //기본C UI C
        public void BasicCUI()
        {
            //계산중인 식출력 오른쪽 정렬
            //결과값 오른쪽 정렬

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "secondMode[10]");
            Console.Write("|");
            Console.Write("{0,15}", "π[11]");
            Console.Write("|");
            Console.Write("{0,15}", "e[12]");
            Console.Write("|");
            Console.Write("{0,15}", "C[13]");
            Console.Write("|");
            Console.Write("{0,15}", "<<[14]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "sqr(x)[15]");
            Console.Write("|");
            Console.Write("{0,15}", "1/x[16]");
            Console.Write("|");
            Console.Write("{0,15}", "abs(x)[17]");
            Console.Write("|");
            Console.Write("{0,15}", "exp[18]");
            Console.Write("|");
            Console.Write("{0,15}", "mod[19]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "sqrt(x)[20]");
            Console.Write("|");
            Console.Write("{0,15}", "([21]");
            Console.Write("|");
            Console.Write("{0,15}", ")[22]");
            Console.Write("|");
            Console.Write("{0,15}", "n![23]");
            Console.Write("|");
            Console.Write("{0,15}", "/[24]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "^[25]");
            Console.Write("|");
            Console.Write("{0,15}", "7");
            Console.Write("|");
            Console.Write("{0,15}", "8");
            Console.Write("|");
            Console.Write("{0,15}", "9");
            Console.Write("|");
            Console.Write("{0,15}", "*[26]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "10^[27]");
            Console.Write("|");
            Console.Write("{0,15}", "4");
            Console.Write("|");
            Console.Write("{0,15}", "5");
            Console.Write("|");
            Console.Write("{0,15}", "6");
            Console.Write("|");
            Console.Write("{0,15}", "-[28]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "log[29]");
            Console.Write("|");
            Console.Write("{0,15}", "1");
            Console.Write("|");
            Console.Write("{0,15}", "2");
            Console.Write("|");
            Console.Write("{0,15}", "3");
            Console.Write("|");
            Console.Write("{0,15}", "+[30]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "ln[31]");
            Console.Write("|");
            Console.Write("{0,15}", "+/-[32]");
            Console.Write("|");
            Console.Write("{0,15}", "0");
            Console.Write("|");
            Console.Write("{0,15}", ".[34]");
            Console.Write("|");
            Console.Write("{0,15}", "=[35]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();
        }

        //세컨드모드 UI CE
        public void SecondModeUI()
        {
            //계산중인 식출력 오른쪽 정렬
            //결과값 오른쪽 정렬

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "secondMode[10]");
            Console.Write("|");
            Console.Write("{0,15}", "π[11]");
            Console.Write("|");
            Console.Write("{0,15}", "e[12]");
            Console.Write("|");
            Console.Write("{0,15}", "CE[13]");
            Console.Write("|");
            Console.Write("{0,15}", "<<[14]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "cube(x)[15]");
            Console.Write("|");
            Console.Write("{0,15}", "1/x[16]");
            Console.Write("|");
            Console.Write("{0,15}", "abs(x)[17]");
            Console.Write("|");
            Console.Write("{0,15}", "exp[18]");
            Console.Write("|");
            Console.Write("{0,15}", "mod[19]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "cuberoot(x)[20]");
            Console.Write("|");
            Console.Write("{0,15}", "([21]");
            Console.Write("|");
            Console.Write("{0,15}", ")[22]");
            Console.Write("|");
            Console.Write("{0,15}", "n![23]");
            Console.Write("|");
            Console.Write("{0,15}", "/[24]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "yroot[25]");
            Console.Write("|");
            Console.Write("{0,15}", "7");
            Console.Write("|");
            Console.Write("{0,15}", "8");
            Console.Write("|");
            Console.Write("{0,15}", "9");
            Console.Write("|");
            Console.Write("{0,15}", "*[26]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "2^[27]");
            Console.Write("|");
            Console.Write("{0,15}", "4");
            Console.Write("|");
            Console.Write("{0,15}", "5");
            Console.Write("|");
            Console.Write("{0,15}", "6");
            Console.Write("|");
            Console.Write("{0,15}", "-[28]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "LogyX[29]");
            Console.Write("|");
            Console.Write("{0,15}", "1");
            Console.Write("|");
            Console.Write("{0,15}", "2");
            Console.Write("|");
            Console.Write("{0,15}", "3");
            Console.Write("|");
            Console.Write("{0,15}", "+[30]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "e^[31]");
            Console.Write("|");
            Console.Write("{0,15}", "+/-[32]");
            Console.Write("|");
            Console.Write("{0,15}", "0");
            Console.Write("|");
            Console.Write("{0,15}", ".[34]");
            Console.Write("|");
            Console.Write("{0,15}", "=[35]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();
        }

        //세컨드모드 UI C
        public void SecondModeCUI()
        {
            //계산중인 식출력 오른쪽 정렬
            //결과값 오른쪽 정렬

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "secondMode[10]");
            Console.Write("|");
            Console.Write("{0,15}", "π[11]");
            Console.Write("|");
            Console.Write("{0,15}", "e[12]");
            Console.Write("|");
            Console.Write("{0,15}", "C[13]");
            Console.Write("|");
            Console.Write("{0,15}", "<<[14]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "cube(x)[15]");
            Console.Write("|");
            Console.Write("{0,15}", "1/x[16]");
            Console.Write("|");
            Console.Write("{0,15}", "abs(x)[17]");
            Console.Write("|");
            Console.Write("{0,15}", "exp[18]");
            Console.Write("|");
            Console.Write("{0,15}", "mod[19]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "cuberoot(x)[20]");
            Console.Write("|");
            Console.Write("{0,15}", "([21]");
            Console.Write("|");
            Console.Write("{0,15}", ")[22]");
            Console.Write("|");
            Console.Write("{0,15}", "n![23]");
            Console.Write("|");
            Console.Write("{0,15}", "/[24]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "yroot[25]");
            Console.Write("|");
            Console.Write("{0,15}", "7");
            Console.Write("|");
            Console.Write("{0,15}", "8");
            Console.Write("|");
            Console.Write("{0,15}", "9");
            Console.Write("|");
            Console.Write("{0,15}", "*[26]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "2^[27]");
            Console.Write("|");
            Console.Write("{0,15}", "4");
            Console.Write("|");
            Console.Write("{0,15}", "5");
            Console.Write("|");
            Console.Write("{0,15}", "6");
            Console.Write("|");
            Console.Write("{0,15}", "-[28]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "LogyX[29]");
            Console.Write("|");
            Console.Write("{0,15}", "1");
            Console.Write("|");
            Console.Write("{0,15}", "2");
            Console.Write("|");
            Console.Write("{0,15}", "3");
            Console.Write("|");
            Console.Write("{0,15}", "+[30]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "e^[31]");
            Console.Write("|");
            Console.Write("{0,15}", "+/-[32]");
            Console.Write("|");
            Console.Write("{0,15}", "0");
            Console.Write("|");
            Console.Write("{0,15}", ".[34]");
            Console.Write("|");
            Console.Write("{0,15}", "=[35]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();
        }

        //입력
        public void InputNum()
        {
            int inputN;
            Console.Write("{0,75}","입력 :");

            inputN = int.Parse(Console.ReadLine());

            switch(inputN)
            {
                case 1:
                    calculate.Add("1");
                    break;
                case 2:
                    calculate.Add("2");
                    break;
                case 3:
                    calculate.Add("3");
                    break;
                case 4:
                    calculate.Add("4");
                    break;
                case 5:
                    calculate.Add("5");
                    break;
                case 6:
                    calculate.Add("6");
                    break;
                case 7:
                    calculate.Add("7");
                    break;
                case 8:
                    calculate.Add("8");
                    break;
                case 9:
                    calculate.Add("9");
                    break;
                case 0:
                    calculate.Add("0");
                    break;

                // π
                case 11:
                    calculate.Add("π");
                    break;

                // e
                case 12:
                    calculate.Add("e");
                    break;

                // CE
                case 13:
                    calculate.Clear();
                    break;

                // <<
                case 14:
                    calculate.RemoveAt(calculate.Count - 1);
                    break;

                // sqr
                case 15:
                    isValue = double.TryParse(calculate[calculate.Count - 1], out value);

                    if (isValue)
                    {
                        calculate.RemoveAt(calculate.Count - 1);
                        calculate.Add("sqr("+value+")");
                    }
                    break;

                // 1/x @@
                case 16:
                    calculate.RemoveAt(calculate.Count - 1);
                    break;

                // abs
                case 17:  
                    isValue = double.TryParse(calculate[calculate.Count - 1], out value);

                    if (isValue)
                    {
                        calculate.RemoveAt(calculate.Count - 1);
                        calculate.Add("abs(" + value + ")");
                    }
                    break;

                // Exp @@
                case 18:
                    isValue = double.TryParse(calculate[calculate.Count - 1], out value);

                    if (isValue)
                    {
                        calculate.Add("mod");
                    }
                    break;

                // mod
                case 19:
                    isValue = double.TryParse(calculate[calculate.Count - 1], out value);

                    if (isValue)
                    {
                        calculate.Add("mod");
                    }
                    break;

                // sqrt
                case 20:
                    isValue = double.TryParse(calculate[calculate.Count - 1], out value);

                    if (isValue)
                    {
                        calculate.RemoveAt(calculate.Count - 1);
                        calculate.Add("sqrt(" + value + ")");
                    }
                    break;

                // (
                case 21:
                    stack.Push('(');
                    calculate.Add("("); break;

                // )
                case 22:
                    while (!stack.Peek().Equals('('))
                    { Console.WriteLine(stack.Peek()); stack.Pop(); }
                    break;
                    // 마지막 남아있는 '(' 제거  
                    stack.Pop();
                    calculate.Add(")");
                    break;

                // factorial
                case 23:
                    isValue = double.TryParse(calculate[calculate.Count - 1], out value);

                    if (isValue)
                    {
                        //펙토리얼
                    }
                    break;

                // 나누기 /
                case 24:
                    while (stack.Count != 0)
                    {
                        if (stack.Peek().Equals('(')) { break; }
                        else if (stack.Peek().Equals('*') || stack.Peek().Equals('/'))
                        {
                            Console.WriteLine(stack.Peek()); stack.Pop();
                        }
                        else { break; }
                    }
                    stack.Push('/');
                    calculate.Add("/");
                    break;

                // ^
                case 25:
                    isValue = double.TryParse(calculate[calculate.Count - 1], out value);

                    if (isValue)
                    {
                        calculate.Add("^");
                    }
                    break;

                // *
                case 26:
                    while (stack.Count != 0)
                    {
                        if (stack.Peek().Equals('(')) { break; }
                        else if (stack.Peek().Equals('*') || stack.Peek().Equals('/'))
                        {
                            Console.WriteLine(stack.Peek()); stack.Pop();
                        }
                        else { break; }
                    }
                    stack.Push('*');
                    calculate.Add("*");
                    break;

                // 10^
                case 27:
                    isValue = double.TryParse(calculate[calculate.Count - 1], out value);

                    if (isValue)
                    {
                        calculate.Add("^");
                    }
                    break;

                // -
                case 28:
                    while (stack.Count != 0)
                    {
                        if (stack.Peek().Equals('(')) { break; }
                        else { Console.WriteLine(stack.Peek()); stack.Pop(); }
                    }
                    stack.Push('-');
                    calculate.Add("-");
                    break;

                // log
                case 29:
                    isValue = double.TryParse(calculate[calculate.Count - 1], out value);

                    if (isValue)
                    {
                        calculate.RemoveAt(calculate.Count - 1);
                        calculate.Add("Log(" + value + ")");
                    }
                    break;

                // +
                case 30:
                    while (stack.Count != 0)
                    {
                        if (stack.Peek().Equals('(')) { break; }
                        else { Console.WriteLine(stack.Peek()); stack.Pop(); }
                    }
                    stack.Push('+');
                    calculate.Add("+");
                    break;

                // ln
                case 31:
                    isValue = double.TryParse(calculate[calculate.Count - 1], out value);

                    if (isValue)
                    {
                        calculate.RemoveAt(calculate.Count - 1);
                        calculate.Add("ln(" + value + ")");
                    }
                    break;

                // +-
                case 32:
                    isValue = double.TryParse(calculate[calculate.Count - 1], out value);

                    if (isValue)
                    {
                        //+- 바꾸기
                    }
                    break;

                // .
                case 34:
                    isValue = double.TryParse(calculate[calculate.Count - 1], out value);

                    if (isValue)
                    {
                        calculate.Add(".");
                    }
                    break;

                // =
                case 35:
                    isValue = double.TryParse(calculate[calculate.Count - 1], out value);

                    if (isValue)
                    {
                        // = 구현 
                    }
                    break;
            }
        }

        public void Print()
        {
            for (int i = 0; i < calculate.Count; i++)
            {
                Console.Write(calculate[i]);
            }
        }
    }
}


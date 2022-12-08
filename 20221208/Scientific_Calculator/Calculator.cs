using System;
using System.Collections;
using System.Collections.Generic;

namespace Scientific_Calculator
{
    public class Calculator
    {
        public Calculator() { }

        //수학 함수 클래스
        MathFunc MathF = new MathFunc();

        //List<string> posrifix = new List<string>(); 

        //콘솔 계산식을 위한 저장
        List<string> calculate = new List<string>();

        //게산을 위한 리스트
        List<string> ResultFormula = new List<string>();

        //실수인지 판별을 위한 TryParse 변수
        double value;
        bool isValue;

        //현재 .[34] 함수 입력중
        bool nowDot;

        //함수 입력중
        bool nowFunc;
        string temp;

        //연산자 입력중
        bool nowOper;

        //제곱 입력중
        bool nowCarrot;

        //입력수
        int inputN;

        //e, PI 입력중
        bool ePI;

        //계산기 상태
        bool isC;
        public bool isSecondMode = false;

        //하단
        string bottomS = "";
        double bottomD = 0;

        //Exp값
        double expDouble;
        string expDoubleS ="0";
        bool nowExp;
        
        //+/- bool
        // true = -, false = +
        bool nowNegate = false;

        //괄호
        int bracket = 0;
        bool nowBracket;

        //계산된 값 그대로 사용
        bool nowOperated;

        //DebugMode
        bool DebugMode;

        //postfix Return List
        List<string> PostfixReceiveList = new List<String>();
        static bool Operator(string st)
        {
            if (st == "+" || st == "-" || st == "*" || st == "/" || st == "mod" || st == "^" || st == "yroot" || st == "logBase") 
            {
                return true; 
            }

            return false;
        }

        //우선순위 체크
        static int Precedence(string st)
        {
            // ( =0, +,- = 1 *,/ = 2;
            if (st == "(") return 0;
            if (st == "+" || st == "-") return 1;
            if (st == "*" || st == "/") return 2;
            if (st == "^" || st == "mod" || st == "yroot" || st == "logBase") return 3;


            return -1;
        }

        //문자열을 후위표기법으로 변환
        public double Postfix(List<string> str)
        {
            //연산자 스택
            Stack<string> Opstack = new Stack<string>();

            List<string> list = new List<string>();

            int Fbracket = 0;

            
            foreach (var r in str)
            {
                if (r == "(")
                {
                    Fbracket++;
                }
                if (r == ")") 
                {
                    Fbracket--;
                }
               
            }

            if (Fbracket > 0)
            {
                for (int i = 0; i < Fbracket; i++)
                {
                    str.Add(")");
                }
            }

            for (int i = 0; i < str.Count; ++i)
            {
                if (str[i] == "(")
                {
                    //(를 만나면 스택에 푸시한다
                    Opstack.Push(str[i]);
                }
                else if (str[i] == ")")
                {
                    //)를 만나면 스택에서 (가 나올 때까지 팝하여 출력하고 (는 팝하여 버린다

                    while (Opstack.Peek() != "(")
                    {
                        //Opstack.Pop();
                        list.Add(Opstack.Pop());
                    }
                    Opstack.Pop();
                }
                else if (Operator(str[i]) == true) //연산자인지 체크
                {
                    //연산자를 만나면 스택에서 그 연산자보다 낮은 우선순위의 연산자를 만날 때가지 팝하여 출력한 뒤에 자신을 푸시한다
                    while (Opstack.Count != 0 && Precedence(Opstack.Peek()) >= Precedence(str[i]))
                    {
                        list.Add(Opstack.Pop());
                    }

                    Opstack.Push(str[i]);
                }
                else if (Operator(str[i]) == false)
                {
                    list.Add(str[i]);

                }
            }

            foreach (var a in Opstack)
            {
                list.Add(a);
            }            
            return CalFormul(list);

        }

        //값인지
        public double atoi(List<string> formula, int index)
        {
            double i = 0;

            //string str = formula.ToString();

            double doubleV;

            //수인지
            while (double.TryParse(formula[index],out doubleV))
            {
                i = double.Parse(formula[index]);
                index++;
            }
            return i;
        }
        //수식 계산
        public double CalFormul(List<string> str)
        {
            if(str.Count == 1)
            {
                return double.Parse(str[0]);
            }

            int calCount = 0;

            double a;
            double b;


            Stack<double> stack = new Stack<double>();
            try
            {
                foreach (string token in str)
                {
                    switch (token)
                    {
                        case "+":
                            calCount++;

                            a = stack.Pop();
                            b = stack.Pop();

                            stack.Push(b + a);

                            if (DebugMode)
                            {
                                Console.WriteLine($"{calCount} 번째 계산 [ {b} + {a} ]값 : " + stack.Peek());
                            }

                            break;

                        case "-":
                            calCount++;

                            a = stack.Pop();
                            b = stack.Pop();

                            stack.Push(b - a);

                            if (DebugMode)
                            {
                                Console.WriteLine($"{calCount} 번째 계산 [ {b} - {a} ]값 : " + stack.Peek());
                            }
                            break;

                        case "*":
                            calCount++;

                            a = stack.Pop();
                            b = stack.Pop();

                            stack.Push(b * a);

                            if (DebugMode)
                            {
                                Console.WriteLine($"{calCount} 번째 계산 [ {b} * {a} ]값 : " + stack.Peek());
                            }
                            break;

                        case "/":
                            calCount++;

                            a = stack.Pop();
                            b = stack.Pop();

                            stack.Push(b / a);

                            if (DebugMode)
                            {
                                Console.WriteLine($"{calCount} 번째 계산 [ {b} / {a} ]값 : " + stack.Peek());
                            }
                            break;

                        case "mod":
                            calCount++;

                            a = stack.Pop();
                            b = stack.Pop();

                            stack.Push(MathF.mod(b, a));

                            if (DebugMode)
                            {
                                Console.WriteLine($"{calCount} 번째 계산 [ {b} mod {a} ]값 : " + stack.Peek());
                            }
                            break;

                        case "^":
                            calCount++;

                            a = stack.Pop();
                            b = stack.Pop();

                            stack.Push(MathF.Pow(b, a));

                            if (DebugMode)
                            {
                                Console.WriteLine($"{calCount} 번째 계산 [ {b} ^ {a} ]값 : " + stack.Peek());
                            }
                            break;

                        case "yroot":
                            calCount++;

                            a = stack.Pop();
                            b = stack.Pop();


                            stack.Push(MathF.yroot(b, a));

                            if (DebugMode)
                            {
                                Console.WriteLine($"{calCount} 번째 계산 [ {b} yroot {a} ]값 : " + stack.Peek());
                            }
                            break;

                        case "logBase":
                            calCount++;

                            a = stack.Pop();
                            b = stack.Pop();


                            stack.Push(MathF.logBase(b, a));

                            if (DebugMode)
                            {
                                Console.WriteLine($"{calCount} 번째 계산 [ {b} logBase {a} ]값 : " + stack.Peek());
                            }
                            break;

                        default: stack.Push(double.Parse(token)); break;
                    }
                }
                return stack.Pop();
            }
            catch
            {
                return 0;
            }
        }
    
        //기본 UI CE
        public void BasicUI()
        {
            //계산중인 식출력 오른쪽 정렬
            //결과값 오른쪽 정렬

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();
            if (DebugMode)
            {
                Console.Write("{0,80}", "DebugMode OFF[35]");
            }
            else
            {
                Console.Write("{0,80}", "DebugMode ON[35]");
            }
            Console.Write("|");
            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "secondMode[10]");
            Console.Write("|");
            Console.Write("{0,14}", "π[11]");
            Console.Write("|");
            Console.Write("{0,15}", "e[12]");
            Console.Write("|");
            if (bottomS.Count() > 0)
            {
                Console.Write("{0,15}", "CE[13]");
            }
            else
            {
                Console.Write("{0,15}", "C[13]");
            }
            Console.Write("|");
            Console.Write("{0,15}", "<<[14]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            if (isSecondMode)
            {
                Console.Write("{0,15}", "cube(x)[15]");
            }
            else
            {
                Console.Write("{0,15}", "sqr(x)[15]");
            }
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
            if (isSecondMode)
            {
                Console.Write("{0,15}", "cuberoot(x)[20]");
            }
            else
            {
                Console.Write("{0,15}", "sqrt(x)[20]");
            }
            Console.Write("|");
            if (bracket > 0)
            {
                Console.Write("{0,2}{1,13}", bracket, "([21]");
            }
            else
            {
                Console.Write("{0,15}", "([21]");
            }
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
            if (isSecondMode)
            {
                Console.Write("{0,15}", "yroot[25]");
            }
            else
            {
                Console.Write("{0,15}", "^[25]");
            }
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
            if (isSecondMode)
            {
                Console.Write("{0,15}", "2^[27]");
            }
            else
            {
                Console.Write("{0,15}", "10^[27]");
            }
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
            if (isSecondMode)
            {
                Console.Write("{0,15}", "logyX[29]");
            }
            else
            {
                Console.Write("{0,15}", "log[29]");
            }
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
            if (isSecondMode)
            {
                Console.Write("{0,15}", "e^[31]");
            }
            else
            {
                Console.Write("{0,15}", "ln[31]");
            }
            Console.Write("|");
            Console.Write("{0,15}", "+/-[32]");
            Console.Write("|");
            Console.Write("{0,15}", "0");
            Console.Write("|");
            Console.Write("{0,15}", ".[33]");
            Console.Write("|");
            Console.Write("{0,15}", "=[34]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();
        }

        //[34] 함수 중 일떄
        public void NowIsDot(int num)
        {
            if (nowDot)
            {
                isValue = double.TryParse(calculate[calculate.Count - 1], out value);

                if (isValue)
                {
                    calculate.RemoveAt(calculate.Count - 1);
                    calculate.Add(value + "." + num);
                    nowDot = false;
                }
            }
        }

        //수 모으기
        public void GatherNum(int num)
        {
            nowOper = false;

            if (!nowDot)
            {
                if (calculate.Count != 0)
                {
                    //앞 인덱스가 상수 라면
                    isValue = double.TryParse(calculate[calculate.Count - 1], out value);

                    if (isValue)
                    {
                        calculate.RemoveAt(calculate.Count - 1);
                        calculate.Add(value.ToString() + num);
                        nowDot = false;
                    }
                    else if(!nowFunc)
                        calculate.Add(num.ToString());

                    //함수 입력중일 때
                    else if (nowFunc)
                    {
                        calculate.RemoveAt(calculate.Count - 1);
                        calculate.Add(num.ToString());
                    }
                }
                else
                {
                    calculate.Add(num.ToString());
                }
                nowFunc = false;
            }
            nowFunc = false;
        }

        //함수 입력
        public void FuncInput(string funcName)
        {
            //전 인덱스가 함수가 아닐 때
            if (!nowFunc)
            {   
                //아무것도 입력 안했거나 연산자 중일 때
                if (bottomS =="")
                {
                    //ln 일때
                    if (funcName == "ln")
                    {
                        Console.WriteLine("입력이 잘못되었습니다.");
                    }
                    else
                    {
                        calculate.Add(funcName + "(" + 0 + ")");
                        nowFunc = true;
                    }
                }
                else
                {
                    bottomD = double.Parse(bottomS);
                    calculate.Add(funcName + "(" + bottomD + ")");
                }
            }
            //함수 입력 중이라면
            else if(nowFunc)
            {
                temp = calculate[calculate.Count - 1];
                calculate.RemoveAt(calculate.Count - 1);
                calculate.Add(funcName + "(" + temp + ")");
                nowFunc = true;
            }
        }

        public void NumInput(string num)
        {
            if (ePI)
            {
                //calculate.RemoveAt(calculate.Count - 1);
                bottomS = num;
                //calculate.Add("1");
                ePI = false;
            }
            else if (nowExp)
            {
                if (expDoubleS == "0")
                {
                    expDoubleS = "";
                    expDoubleS += num;
                }
                else
                    expDoubleS += num;
            }
            else if (nowCarrot)
            {
                bottomS = num;
                nowCarrot = false;
            }
            else if (nowFunc)
            {
                calculate.RemoveAt(calculate.Count - 1);
                bottomS = num;
                nowCarrot = false;
            }
            else if (nowOper)
            {
                bottomS = num;
                nowOper = false;
            }
            else bottomS += num;
            //GatherNum(1);6
            //NowIsDot(1);
        }

        //입력
        public void InputNum()
        {
            if(nowOperated)
            {
                calculate.Clear();
                ResultFormula.Clear();
                nowOperated = false;
            }
            Console.Write("{0,75}","입력 :");

            inputN = int.Parse(Console.ReadLine());
            
            if(nowOperated)
            {
                bottomS = "";
            }

            switch(inputN)
            {
                case 1:
                    NumInput("1");
                    break;
                case 2:
                    NumInput("2");
                    break;
                case 3:
                    NumInput("3");
                    break;
                case 4:
                    NumInput("4");
                    break;
                case 5:
                    NumInput("5");
                    break;
                case 6:
                    NumInput("6");
                    break;
                case 7:
                    NumInput("7");
                    break;
                case 8:
                    NumInput("8");
                    break;
                case 9:
                    NumInput("9");
                    break;
                case 0:
                    NumInput("0");
                    break;

                case 10:
                    isSecondMode = true;
                    nowOper = false;
                    break;

                // π
                case 11:
                    if (nowExp)
                    {
                        bottomS = MathF.PI().ToString();
                    }
                    if (ePI)
                    {
                        bottomS = MathF.PI().ToString();
                    }
                    else
                    {
                        bottomS = MathF.PI().ToString();
                    }
                    ePI = true;
                    break;

                // e
                case 12:
                    if(nowExp)
                    {
                        bottomS = MathF.e().ToString();
                    }
                    if (ePI)
                    {
                        bottomS = MathF.e().ToString();
                    }
                    else
                    {
                        bottomS = MathF.e().ToString();
                    }
                    ePI = true;
                    break;

                // CE C
                case 13:
                    if (!isC)
                    {
                        bottomS = "";
                    }
                    else
                    {
                        calculate.Clear();
                    }
                    break;

                // <<
                case 14:
                    if (bottomS == "")
                    {
                        break;
                    }
                    else
                    {
                        bottomS = bottomS.Substring(0, bottomS.Length - 1);
                    }
                    break;

                // sqr , cube
                case 15:
                    ePI = false;
                    if (!isSecondMode)
                    {
                        if (nowExp)
                        {
                            nowExp = false;
                            bottomD = MathF.exp(expDouble, int.Parse(expDoubleS), nowNegate);
                            bottomS = bottomD.ToString();
                            FuncInput("sqr");
                            bottomD = MathF.sqr(MathF.exp(expDouble, int.Parse(expDoubleS), nowNegate));
                            bottomS = bottomD.ToString();

                            ResultFormula.Add(bottomS);     
                        }
                        else if(nowFunc)
                        {
                            ResultFormula.RemoveAt(ResultFormula.Count - 1);
                            FuncInput("sqr");
                            bottomD = double.Parse(bottomS);
                            bottomD = MathF.sqr(bottomD);
                            bottomS = bottomD.ToString();

                            ResultFormula.Add(bottomS);
                        }
                        else
                        {
                            FuncInput("sqr");
                            bottomD = double.Parse(bottomS);
                            bottomD = MathF.sqr(bottomD);
                            bottomS = bottomD.ToString();

                            ResultFormula.Add(bottomS);
                        }

                    }
                    else
                    {
                        if (nowExp)
                        {
                            nowExp = false;
                            bottomD = MathF.exp(expDouble, int.Parse(expDoubleS),nowNegate);
                            bottomS = bottomD.ToString();
                            FuncInput("cube");
                            bottomD = MathF.cube(MathF.exp(expDouble, int.Parse(expDoubleS), nowNegate));
                            bottomS = bottomD.ToString();

                            ResultFormula.Add(bottomS);
                        }
                        else if (nowFunc)
                        {
                            ResultFormula.RemoveAt(ResultFormula.Count - 1);
                            FuncInput("cube");
                            bottomD = double.Parse(bottomS);
                            bottomD = MathF.cube(bottomD);
                            bottomS = bottomD.ToString();

                            ResultFormula.Add(bottomS);
                        }
                        else
                        {
                            FuncInput("cube");
                            bottomD = MathF.cube(double.Parse(bottomS));
                            bottomS = bottomD.ToString();
                            isSecondMode = false;

                            ResultFormula.Add(bottomS);
                        }
                    }
                    nowFunc = true;
                    break;

                // 1/x
                case 16:
                    ePI = false;

                    if (nowFunc)
                    {
                        FuncInput("1/");
                        bottomD = MathF.DivideOne(bottomD);
                        bottomS = bottomD.ToString();

                        ResultFormula.RemoveAt(ResultFormula.Count - 1);
                        ResultFormula.Add(bottomS);
                    }
                    else if (nowOper)
                    {
                            FuncInput("1/");
                            bottomD = MathF.DivideOne(bottomD);
                            bottomS = bottomD.ToString();
                            ResultFormula.Add(bottomS);

                        nowOper = false;
                    }
                    else if (nowFunc)
                    {
                        ResultFormula.RemoveAt(ResultFormula.Count - 1);
                        FuncInput("1/");
                        bottomD = double.Parse(bottomS);
                        bottomD = MathF.DivideOne(bottomD);
                        bottomS = bottomD.ToString();

                        ResultFormula.Add(bottomS);
                    }
                    else
                    {
                        FuncInput("1/");
                        bottomD = MathF.DivideOne(double.Parse(bottomS));
                        bottomS = bottomD.ToString();
                        ResultFormula.Add(bottomS);
                    }
                    nowFunc = true;
                    break;

                // abs
                case 17:
                    ePI = false;
                    if (nowExp)
                    {
                        nowExp = false;
                        bottomD = MathF.exp(expDouble, int.Parse(expDoubleS), nowNegate);
                        bottomS = bottomD.ToString();
                        FuncInput("abs");
                        bottomD = MathF.abs(MathF.exp(expDouble, int.Parse(expDoubleS), nowNegate));
                        bottomS = bottomD.ToString();

                        ResultFormula.Add(bottomS);
                    }
                    else if (nowOper)
                    {
                        FuncInput("abs");
                        bottomD = MathF.abs(bottomD);
                        bottomS = bottomD.ToString();
                        ResultFormula.Add(bottomS);

                        nowOper = false;
                    }
                    else if (nowFunc)
                    {
                        ResultFormula.RemoveAt(ResultFormula.Count - 1);
                        FuncInput("abs");
                        bottomD = double.Parse(bottomS);
                        bottomD = MathF.abs(bottomD);
                        bottomS = bottomD.ToString();

                        ResultFormula.Add(bottomS);
                    }
                    else
                    {
                        FuncInput("abs");
                        bottomD = MathF.abs(double.Parse(bottomS));
                        bottomS = bottomD.ToString();

                        ResultFormula.Add(bottomS);
                    }
                    nowFunc = true;
                    break;

                // Exp 
                case 18:
                    ePI = false;

                    if(nowFunc)
                    {
                        break;
                    }
                    expDouble = double.Parse(bottomS);
                    bottomS += "e+";
                    nowExp = true;
                    break;

                // mod
                case 19:
                    ePI = false;

                    if (bottomS == "")
                    {
                        calculate.Add("0");
                        calculate.Add("mod");

                        ResultFormula.Add("0");
                        ResultFormula.Add("mod");
                    }
                    else if (nowFunc)
                    {
                        bottomD = Postfix(ResultFormula);
                        bottomS = bottomD.ToString();

                        calculate.Add("mod");
                        ResultFormula.Add("mod");
                        nowFunc = false;
                    }
                    else if (nowExp)
                    {
                        calculate.Add(MathF.exp(expDouble, int.Parse(expDoubleS), nowNegate).ToString());
                        calculate.Add("mod");
                        bottomS = MathF.exp(expDouble, int.Parse(expDoubleS), nowNegate).ToString();

                        ResultFormula.Add(bottomS);
                        ResultFormula.Add("mod");
                        nowExp = false;
                    }
                    else if (nowOper)
                    {
                        calculate.RemoveAt(calculate.Count - 1);
                        ResultFormula.RemoveAt(ResultFormula.Count - 1);

                        calculate.Add("mod");
                        ResultFormula.Add("mod");
                    }
                    else
                    {
                        calculate.Add(bottomS);
                        ResultFormula.Add(bottomS);
                        bottomD = Postfix(ResultFormula);
                        bottomS = bottomD.ToString();
                        calculate.Add("mod");
                        ResultFormula.Add("mod");

                    }
                    nowOper = true;
                    break;

                // sqrt , cuberoot
                case 20:
                    ePI = false;
                    if (!isSecondMode)
                    {
                        if (nowExp)
                        {
                            nowExp = false;
                            bottomD = MathF.exp(expDouble, int.Parse(expDoubleS), nowNegate);
                            bottomS = bottomD.ToString();
                            FuncInput("sqrt");
                            bottomD = MathF.sqrt(MathF.exp(expDouble, int.Parse(expDoubleS), nowNegate));
                            bottomS = bottomD.ToString();

                            ResultFormula.Add(bottomS);
                        }
                        else if (nowFunc)
                        {
                            ResultFormula.RemoveAt(ResultFormula.Count - 1);
                            FuncInput("sqrt");
                            bottomD = double.Parse(bottomS);
                            bottomD = MathF.sqrt(bottomD);
                            bottomS = bottomD.ToString();

                            ResultFormula.Add(bottomS);
                        }
                        else
                        {
                            FuncInput("sqrt");
                            bottomD = double.Parse(bottomS);
                            bottomD = MathF.sqrt(bottomD);
                            bottomS = bottomD.ToString();

                            ResultFormula.Add(bottomS);
                        }

                    }
                    else
                    {
                        if (nowExp)
                        {
                            nowExp = false;
                            bottomD = MathF.exp(expDouble, int.Parse(expDoubleS), nowNegate);
                            bottomS = bottomD.ToString();
                            FuncInput("cuberoot");
                            bottomD = MathF.cuberoot(MathF.exp(expDouble, int.Parse(expDoubleS), nowNegate));
                            bottomS = bottomD.ToString();

                            ResultFormula.Add(bottomS);
                        }
                        else if (nowFunc)
                        {
                            ResultFormula.RemoveAt(ResultFormula.Count - 1);
                            FuncInput("cuberoot");
                            bottomD = double.Parse(bottomS);
                            bottomD = MathF.cuberoot(bottomD);
                            bottomS = bottomD.ToString();

                            ResultFormula.Add(bottomS);
                        }
                        else
                        {
                            FuncInput("cuberoot");
                            bottomD = MathF.cuberoot(double.Parse(bottomS));
                            bottomS = bottomD.ToString();
                            isSecondMode = false;

                            ResultFormula.Add(bottomS);
                        }
                    }
                    nowFunc = true;
                    break;


                // (
                case 21:
                    ePI = false;

                    calculate.Add("("); 
                    ResultFormula.Add("(");

                    bracket++;

                    nowBracket = true;
                    break;

                // )
                case 22:
                    ePI = false;

                    if (bracket == 0)
                    {
                        break;
                    }
                    else
                    {
                        if (nowBracket)
                        {
                            calculate.Add(bottomS);
                            ResultFormula.Add(bottomS);
                        }
                        calculate.Add(")");
                        ResultFormula.Add(")");
                        bracket--;
                    }
                    nowFunc = true;
                    nowBracket = false;
                    break;

                // factorial
                case 23:
                    ePI = false;
                    if (nowExp)
                    {
                        nowExp = false;
                        bottomD = MathF.exp(expDouble, int.Parse(expDoubleS), nowNegate);
                        bottomS = bottomD.ToString();
                        FuncInput("fact");
                        bottomD = MathF.fact(MathF.exp(expDouble, int.Parse(expDoubleS), nowNegate));
                        bottomS = bottomD.ToString();

                        ResultFormula.Add(bottomS);
                    }
                    else if (nowFunc)
                    {
                        ResultFormula.RemoveAt(ResultFormula.Count - 1);
                        FuncInput("fact");
                        bottomD = double.Parse(bottomS);
                        bottomD = MathF.fact(bottomD);
                        bottomS = bottomD.ToString();

                        ResultFormula.Add(bottomS);
                    }
                    else
                    {
                        FuncInput("fact");
                        bottomD = MathF.fact(double.Parse(bottomS));
                        bottomS = bottomD.ToString();
                        isSecondMode = false;

                        ResultFormula.Add(bottomS);
                    }
                    nowFunc = true;
                    break;

                // 나누기 /
                case 24:
                    ePI = false;
                    if (bottomS == "")
                    {
                        calculate.Add("0");
                        calculate.Add("/");

                        ResultFormula.Add("0");
                        ResultFormula.Add("/");
                    }
                    else if (nowFunc)
                    {
                        calculate.Add("/");
                        ResultFormula.Add("/");
                        nowFunc = false;
                    }
                    else if(nowExp)
                    {
                        nowExp = false;
                        calculate.Add(MathF.exp(expDouble, int.Parse(expDoubleS), nowNegate).ToString());
                        calculate.Add("/");
                        bottomS = MathF.exp(expDouble, int.Parse(expDoubleS), nowNegate).ToString();

                        ResultFormula.Add(bottomS);
                        ResultFormula.Add("/");
                    }
                    else if (nowOper)
                    {
                        break;
                    }
                    else
                    {
                        calculate.Add(bottomS);
                        ResultFormula.Add(bottomS);
                        calculate.Add("/");
                        ResultFormula.Add("/");
                    }
                    nowOper = true;
                    break;

                // ^ , yroot 
                case 25:
                    ePI = false;
                    nowFunc = false;
                    if (!isSecondMode)
                    {
                        if (bottomS == "")
                        {
                            calculate.Add("0");
                            calculate.Add("^");

                            ResultFormula.Add("0");
                            ResultFormula.Add("^");
                        }
                        else if (nowFunc)
                        {
                            bottomD = Postfix(ResultFormula);
                            bottomS = bottomD.ToString();

                            calculate.Add("^");
                            ResultFormula.Add("^");
                            nowFunc = false;
                        }
                        else if (nowExp)
                        {
                            calculate.Add(MathF.exp(expDouble, int.Parse(expDoubleS), nowNegate).ToString());
                            calculate.Add("^");
                            bottomS = MathF.exp(expDouble, int.Parse(expDoubleS), nowNegate).ToString();

                            ResultFormula.Add(bottomS);
                            ResultFormula.Add("^");
                            nowExp = false;
                        }
                        else if (nowOper)
                        {
                            calculate.RemoveAt(calculate.Count-1);
                            ResultFormula.RemoveAt(ResultFormula.Count-1);

                            calculate.Add("^");
                            ResultFormula.Add("^");
                        }
                        else
                        {
                            calculate.Add(bottomS);
                            ResultFormula.Add(bottomS);
                            bottomD = Postfix(ResultFormula);
                            bottomS = bottomD.ToString();
                            calculate.Add("^");
                            ResultFormula.Add("^");

                        }
                        nowOper = true;
                    }
                    else
                    {
                        if (bottomS == "")
                        {
                            calculate.Add("0");
                            calculate.Add("yroot");

                            ResultFormula.Add("0");
                            ResultFormula.Add("yroot");
                        }
                        else if (nowFunc)
                        {
                            bottomD = Postfix(ResultFormula);
                            bottomS = bottomD.ToString();

                            calculate.Add("yroot");
                            ResultFormula.Add("yroot");
                            nowFunc = false;
                        }
                        else if (nowExp)
                        {
                            calculate.Add(MathF.exp(expDouble, int.Parse(expDoubleS), nowNegate).ToString());
                            calculate.Add("yroot");
                            bottomS = MathF.exp(expDouble, int.Parse(expDoubleS), nowNegate).ToString();

                            ResultFormula.Add(bottomS);
                            ResultFormula.Add("yroot");
                            nowExp = false;
                        }
                        else if (nowOper)
                        {
                            calculate.RemoveAt(calculate.Count - 1);
                            ResultFormula.RemoveAt(ResultFormula.Count - 1);

                            calculate.Add("yroot");
                            ResultFormula.Add("yroot");
                        }
                        else
                        {
                            calculate.Add(bottomS);
                            ResultFormula.Add(bottomS);
                            bottomD = Postfix(ResultFormula);
                            bottomS = bottomD.ToString();
                            calculate.Add("yroot");
                            ResultFormula.Add("yroot");

                        }
                        nowOper = true;
                        isSecondMode = false;
                    }
                    nowCarrot = true;
                    break;

                // *
                case 26:
                    ePI = false;
                    if (bottomS == "")
                    {
                        calculate.Add("0");
                        calculate.Add("*");

                        ResultFormula.Add("0");
                        ResultFormula.Add("*");
                    }
                    else if (nowFunc)
                    {
                        calculate.Add("/");
                        ResultFormula.Add("*");
                        nowFunc = false;
                    }
                    else if (nowExp)
                    {
                        nowExp = false;
                        calculate.Add(MathF.exp(expDouble, int.Parse(expDoubleS), nowNegate).ToString());
                        calculate.Add("*");
                        bottomS = MathF.exp(expDouble, int.Parse(expDoubleS), nowNegate).ToString();

                        ResultFormula.Add(bottomS);
                        ResultFormula.Add("*");
                    }
                    else if (nowOper)
                    {
                        calculate.RemoveAt(calculate.Count - 1);
                        ResultFormula.RemoveAt(ResultFormula.Count - 1);

                        calculate.Add("*");
                        ResultFormula.Add("*");
                    }
                    else
                    {
                        calculate.Add(bottomS);
                        ResultFormula.Add(bottomS);
                        calculate.Add("*");
                        ResultFormula.Add("*");
                    }
                    nowOper = true;
                    break;

                // 10^ ,2^
                case 27:
                    ePI = false;
                    if (!isSecondMode)
                    {
                        if (nowExp)
                        {
                            nowExp = false;
                            bottomD = MathF.exp(expDouble, int.Parse(expDoubleS), nowNegate);
                            bottomS = bottomD.ToString();
                            FuncInput("10^");
                            bottomD = MathF.Pow(MathF.exp(expDouble, int.Parse(expDoubleS), nowNegate));
                            bottomS = bottomD.ToString();

                            ResultFormula.Add(bottomS);
                        }
                        else if (nowFunc)
                        {
                            ResultFormula.RemoveAt(ResultFormula.Count - 1);
                            FuncInput("10^");
                            bottomD = double.Parse(bottomS);
                            bottomD = MathF.Pow(bottomD);
                            bottomS = bottomD.ToString();

                            ResultFormula.Add(bottomS);
                        }
                        else
                        {
                            FuncInput("10^");
                            bottomD = MathF.Pow(double.Parse(bottomS));
                            bottomS = bottomD.ToString();
                            isSecondMode = false;

                            ResultFormula.Add(bottomS);
                        }
                    }
                    else
                    {
                        if (nowExp)
                        {
                            nowExp = false;
                            bottomD = MathF.exp(expDouble, int.Parse(expDoubleS), nowNegate);
                            bottomS = bottomD.ToString();
                            FuncInput("2^");
                            bottomD = MathF.TPow(MathF.exp(expDouble, int.Parse(expDoubleS), nowNegate));
                            bottomS = bottomD.ToString();

                            ResultFormula.Add(bottomS);
                        }
                        else if (nowFunc)
                        {
                            ResultFormula.RemoveAt(ResultFormula.Count - 1);
                            FuncInput("2^");
                            bottomD = double.Parse(bottomS);
                            bottomD = MathF.TPow(bottomD);
                            bottomS = bottomD.ToString();

                            ResultFormula.Add(bottomS);
                        }
                        else
                        {
                            FuncInput("2^");
                            bottomD = MathF.TPow(double.Parse(bottomS));
                            bottomS = bottomD.ToString();
                            isSecondMode = false;

                            ResultFormula.Add(bottomS);
                        }

                        isSecondMode = false;
                    }
                    nowFunc = true;
                    break;

                // -
                case 28:
                    ePI = false;

                    if (bottomS == "")
                    {
                        calculate.Add("0");
                        calculate.Add("-");

                        ResultFormula.Add("0");
                        ResultFormula.Add("-");
                    }
                    else if (nowFunc)
                    {
                        bottomD = Postfix(ResultFormula);
                        bottomS = bottomD.ToString();

                        calculate.Add("-");
                        ResultFormula.Add("-");
                        nowFunc = false;
                    }
                    else if (nowExp)
                    {
                        calculate.Add(MathF.exp(expDouble, int.Parse(expDoubleS), nowNegate).ToString());
                        calculate.Add("-");
                        bottomS = MathF.exp(expDouble, int.Parse(expDoubleS), nowNegate).ToString();

                        ResultFormula.Add(bottomS);
                        ResultFormula.Add("-");
                        nowExp = false;
                    }
                    else if (nowOper)
                    {
                        calculate.RemoveAt(calculate.Count - 1);
                        ResultFormula.RemoveAt(ResultFormula.Count - 1);

                        calculate.Add("-");
                        ResultFormula.Add("-");
                    }
                    else
                    {  
                        calculate.Add(bottomS);
                        ResultFormula.Add(bottomS);
                        bottomD = Postfix(ResultFormula);
                        bottomS = bottomD.ToString();
                        calculate.Add("-");            
                        ResultFormula.Add("-");
                    }
                    nowOper = true;
                    break;

                // log, log base
                case 29:
                    ePI = false;
                    if (!isSecondMode)
                    {
                        if (nowExp)
                        {
                            nowExp = false;
                            bottomD = MathF.exp(expDouble, int.Parse(expDoubleS), nowNegate);
                            bottomS = bottomD.ToString();
                            FuncInput("log");
                            bottomD = MathF.log(MathF.exp(expDouble, int.Parse(expDoubleS), nowNegate));
                            bottomS = bottomD.ToString();

                            ResultFormula.Add(bottomS);
                        }
                        else if (nowFunc)
                        {
                            ResultFormula.RemoveAt(ResultFormula.Count - 1);
                            FuncInput("log");
                            bottomD = double.Parse(bottomS);
                            bottomD = MathF.log(bottomD);
                            bottomS = bottomD.ToString();

                            ResultFormula.Add(bottomS);
                        }
                        else
                        {
                            FuncInput("log");
                            bottomD = MathF.log(double.Parse(bottomS));
                            bottomS = bottomD.ToString();
                            isSecondMode = false;

                            ResultFormula.Add(bottomS);
                        }
                        nowFunc = true;
                    }
                    else
                    {
                        if (bottomS == "")
                        {
                            calculate.Add("0");
                            calculate.Add("logBase");

                            ResultFormula.Add("0");
                            ResultFormula.Add("logBase");
                        }
                        else if (nowExp)
                        {
                            nowExp = false;
                            bottomD = MathF.exp(expDouble, int.Parse(expDoubleS), nowNegate);
                            bottomS = bottomD.ToString();
                            FuncInput("logBase");
                            bottomD = MathF.log(MathF.exp(expDouble, int.Parse(expDoubleS), nowNegate));
                            bottomS = bottomD.ToString();

                            ResultFormula.Add(bottomS);
                        }
                        else if (nowFunc)
                        {
                            ResultFormula.RemoveAt(ResultFormula.Count - 1);
                            FuncInput("logBase");
                            bottomD = double.Parse(bottomS);
                            bottomD = MathF.log(bottomD);
                            bottomS = bottomD.ToString();

                            ResultFormula.Add(bottomS);
                        }
                        else
                        {
                            FuncInput("logBase");
                            bottomD = MathF.log(double.Parse(bottomS));
                            bottomS = bottomD.ToString();
                            isSecondMode = false;

                            ResultFormula.Add(bottomS);
                        }
                        nowOper = true;
                    }
   
                    break;

                // +
                case 30:
                    ePI = false;

                    if (bottomS == "")
                    {
                        calculate.Add("0");
                        calculate.Add("+");

                        ResultFormula.Add("0");
                        ResultFormula.Add("+");
                    }
                    else if (nowFunc)
                    {
                        bottomD = Postfix(ResultFormula);
                        bottomS = bottomD.ToString();

                        calculate.Add("+");
                        ResultFormula.Add("+");
                        nowFunc = false;
                    }
                    else if (nowExp)
                    {
                        calculate.Add(MathF.exp(expDouble, int.Parse(expDoubleS), nowNegate).ToString());
                        calculate.Add("+");
                        bottomS = MathF.exp(expDouble, int.Parse(expDoubleS), nowNegate).ToString();

                        ResultFormula.Add(bottomS);
                        ResultFormula.Add("+");
                        nowExp = false;
                    }
                    else if (nowOper)
                    {
                        calculate.RemoveAt(calculate.Count - 1);
                        ResultFormula.RemoveAt(ResultFormula.Count - 1);

                        calculate.Add("+");
                        ResultFormula.Add("+");
                    }
                    else
                    {
                        calculate.Add(bottomS);
                        ResultFormula.Add(bottomS);
                        bottomD = Postfix(ResultFormula);
                        bottomS = bottomD.ToString();
                        calculate.Add("+");
                        ResultFormula.Add("+");
                    }
                    nowOper = true;
                    break;

                // ln, e^
                case 31:
                    ePI = false;
                    if (!isSecondMode)
                    {
                        if (nowExp)
                        {
                            nowExp = false;
                            bottomD = MathF.exp(expDouble, int.Parse(expDoubleS), nowNegate);
                            bottomS = bottomD.ToString();
                            FuncInput("ln");
                            bottomD = MathF.ln(MathF.exp(expDouble, int.Parse(expDoubleS), nowNegate));
                            bottomS = bottomD.ToString();

                            ResultFormula.Add(bottomS);
                        }
                        else if (nowFunc)
                        {
                            ResultFormula.RemoveAt(ResultFormula.Count - 1);
                            FuncInput("ln");
                            bottomD = double.Parse(bottomS);
                            bottomD = MathF.ln(bottomD);
                            bottomS = bottomD.ToString();

                            ResultFormula.Add(bottomS);
                        }
                        else
                        {
                            FuncInput("ln");
                            bottomD = MathF.ln(double.Parse(bottomS));
                            bottomS = bottomD.ToString();
                            isSecondMode = false;

                            ResultFormula.Add(bottomS);
                        }
                    }
                    else
                    {
                        if (nowExp)
                        {
                            nowExp = false;
                            bottomD = MathF.exp(expDouble, int.Parse(expDoubleS), nowNegate);
                            bottomS = bottomD.ToString();
                            FuncInput("e^");
                            bottomD = MathF.eSquare(MathF.exp(expDouble, int.Parse(expDoubleS), nowNegate));
                            bottomS = bottomD.ToString();

                            ResultFormula.Add(bottomS);
                        }
                        else if (nowFunc)
                        {
                            ResultFormula.RemoveAt(ResultFormula.Count - 1);
                            FuncInput("e^");
                            bottomD = double.Parse(bottomS);
                            bottomD = MathF.eSquare(bottomD);
                            bottomS = bottomD.ToString();

                            ResultFormula.Add(bottomS);
                        }
                        else
                        {
                            FuncInput("e^");
                            bottomD = MathF.eSquare(double.Parse(bottomS));
                            bottomS = bottomD.ToString();
                            isSecondMode = false;

                            ResultFormula.Add(bottomS);
                        }
                        isSecondMode = false;
                    }
                    nowFunc = true;
                    break;

                // +/-
                case 32:
                    ePI = false;
                    if (nowExp)
                    {
                        if (nowNegate)
                        {
                            nowNegate = false;
                            bottomS = bottomS.Replace("-", "+");

                        }
                        else
                        {
                            nowNegate = true;
                            bottomS = bottomS.Replace("+", "-");

                        }
                    }
                    else if (bottomS != "")
                    {
                        bottomD = double.Parse(bottomS);
                        bottomD = bottomD / -1;
                        bottomS = bottomD.ToString();

                        FuncInput("negate");
                        ResultFormula.Add(bottomS);
                    }
                    else
                    {
                        value = 0;
                        FuncInput("negate");
                        ResultFormula.Add(bottomS);
                    }
                    nowFunc = true;
                    
                    break;

                // .
                case 33:
                    ePI = false;
                    bottomD = double.Parse(bottomS);
                    if(nowExp)
                    {
                        break;
                    }
                    if (nowFunc)
                    {
                        bottomS = "0.";
                    }
                    else
                    {
                        //decimal 인지
                        if (!((bottomD % 1) > 0))
                        {
                            bottomS += ".";
                        }
                    }
                    break;

                // =
                case 34:
                    ePI = false;

                    if (nowFunc)
                    {
                        bottomD = Postfix(ResultFormula);

                        if (bracket > 0)
                        {
                            for (int i = 0; i < bracket; i++)
                            {
                                calculate.Add(")");
                            }
                        }

                        bottomS = bottomD.ToString();

                        calculate.Add("=");
                    }
                    else if(nowOper)
                    {
                        calculate.Add(bottomS);
                        ResultFormula.Add(bottomS);
                        bottomS = bottomD.ToString();

                        if (bracket > 0)
                        {
                            for (int i = 0; i < bracket; i++)
                            {
                                calculate.Add(")");
                            }
                        }

                        
                        bottomD = Postfix(ResultFormula);
                        bottomS = bottomD.ToString();

                        calculate.Add("=");
                    }
                    else
                    {
                        calculate.Add(bottomS);
                        ResultFormula.Add(bottomS);

                        bottomD = Postfix(ResultFormula);
                        bottomS = bottomD.ToString();

                        calculate.Add("=");
                    }
                    nowOperated = true;
                    break;

                case 35:
                    if (!DebugMode)
                        DebugMode = true;
                    else
                        DebugMode = false;
                    break;

                default:
                    break;
            }
        }

        public void Print()
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine();
            for (int i = 0; i < calculate.Count; i++)
            {
                Console.Write(calculate[i]);
                Console.Write(" ");
            }
            Console.WriteLine();
            if(nowExp)
            {
                Console.Write(bottomS);
                Console.WriteLine(expDoubleS);
            }
            else
            Console.WriteLine(bottomS);
        }  
    }
}


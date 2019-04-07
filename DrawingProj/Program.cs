
using Common.Utility;
using Contacts.Interface;
using Contacts.Model;
using Handler;
using System;
using System.Collections.Generic;
using System.Linq;



namespace DrawingProj
{
    class Program
    {
        protected static int _Cleft;
        protected static int _Cright;
        static void Main(string[] args)
        {
            Init();
        }

      
        static void Init()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(
                "C. Draw a Canvas with width and height. Input should be -> C w h" +
                "\nL. Draw line from (x1,y1) to (x2,y2). Input should be -> L x1 y1 x2 y2" +
                "\nR. Draw rectangle from (x1,y1) to (x2,y2). Input should be -> R x1 y1 x2 y2" +
                "\nB. Fill (X,Y) location with colour 'c'. Input should be -> B x y c " +
                "\nQ. Terminate.");


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nUse Space and backspace for changing command input.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter command:");


            IDraw _iDraw = new DrawingHandler();
             _Cleft = Console.CursorLeft;
             _Cright = Console.CursorTop;

             _iDraw.DefaultLeftPostion = 2;
             _iDraw.DefaultTopPostion = 10;
             _iDraw.LstConsoleContent = new List<ConsoleContent>();

            while (true)
            {
                string command = Console.ReadLine();
                var drawTypeWithParam = command.ToUpper().Split(' ').ToList();
               
                Console.WriteLine("\n");
               
                if (drawTypeWithParam[0].ToString() == "C")
                {
                    drawTypeWithParam = drawTypeWithParam.Where(t => t.Length > 0).ToList();
                    if (drawTypeWithParam.Count >= 3)
                    {
                        int weight = CommonUtility.TryParseValue(ParseType.IntType, drawTypeWithParam[1], 25);
                        int height = CommonUtility.TryParseValue(ParseType.IntType, drawTypeWithParam[2], 25);
                       
                        _iDraw.DrawACanvas(weight,height);
                    }
                    Console.SetCursorPosition(_Cleft, _Cright);
                  
                }
                else if (drawTypeWithParam[0] == "L")
                {
                     int x1 = CommonUtility.TryParseValue(ParseType.IntType, drawTypeWithParam[1], 25);
                     int y1 = CommonUtility.TryParseValue(ParseType.IntType, drawTypeWithParam[2], 25);
                     int x2 = CommonUtility.TryParseValue(ParseType.IntType, drawTypeWithParam[3], 50);
                     int y2 = CommonUtility.TryParseValue(ParseType.IntType, drawTypeWithParam[4], 50);

                    _iDraw.drawChar = 'x';
                    _iDraw.DrawALine(x1,y1,x2,y2);

                    Console.SetCursorPosition(_Cleft, _Cright);
                }
                else if (drawTypeWithParam[0] == "R")
                {

                    drawTypeWithParam = drawTypeWithParam.Where(t => t.Length > 0).ToList();
                    if (drawTypeWithParam.Count >= 3)
                    {
                        int x1 = CommonUtility.TryParseValue(ParseType.IntType, drawTypeWithParam[1], 25);
                        int y1 = CommonUtility.TryParseValue(ParseType.IntType, drawTypeWithParam[2], 25);
                        int x2 = CommonUtility.TryParseValue(ParseType.IntType, drawTypeWithParam[3], 50);
                        int y2 = CommonUtility.TryParseValue(ParseType.IntType, drawTypeWithParam[4], 50);

                        _iDraw.drawChar = 'x';
                        _iDraw.DrawACanvas(Math.Abs(x2 - x1), Math.Abs(y2 - y1));

                        Console.SetCursorPosition(_Cleft, _Cright);
                    }
                }
                
                else if (drawTypeWithParam[0] == "B")
                {
                    drawTypeWithParam = drawTypeWithParam.Where(t => t.Length > 0).ToList();
                    if (drawTypeWithParam.Count > 3)
                    {
                        int x = CommonUtility.TryParseValue(ParseType.IntType, drawTypeWithParam[1], 25);
                        int y = CommonUtility.TryParseValue(ParseType.IntType, drawTypeWithParam[2], 25);
                        _iDraw.drawChar = drawTypeWithParam[3].ToCharArray()[0];
                        _iDraw.WriteInConsoleXYLocation(x, y);
                    }
                    Console.SetCursorPosition(_Cleft, _Cright);
                }
                else if (drawTypeWithParam[0] == "Q")
                {
                    break;
                }
                else
                {
                    Console.SetCursorPosition(_Cleft, _Cright);
                    Console.Write("Invalid Syntax!");
                    Console.SetCursorPosition(_Cleft, _Cright);
                }
            }
        }
    }
}
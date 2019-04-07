using Common.Utility;
using Contacts.Interface;
using Contacts.Model;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Handler
{
    public class DrawingHandler : IDraw
    {
        public int DefaultLeftPostion { get; set; }
        public int DefaultTopPostion { get; set; }
        public char? drawChar { get; set; }
        public IList<ConsoleContent> LstConsoleContent { get; set; }

        /// <summary>
        /// This method used to draw Canvas for input width and height.
        /// </summary>
        /// <param name="width">Width of Canvas</param>
        /// <param name="height">Height of Canvas</param>
        public void DrawACanvas(int width, int height)
        {

            for (int i = 0; i <= width; i++)  // clockwise -> strating from left to right.
                WriteAtPosition(drawChar.HasValue ? drawChar.Value.ToString() : ".", i, 0);

            for (int i = 0; i < height; i++)
                WriteAtPosition(drawChar.HasValue ? drawChar.Value.ToString() : ".", width, i);

            for (int i = width; i > 0; i--)
                WriteAtPosition(drawChar.HasValue ? drawChar.Value.ToString() : ".", i, height);

            for (int i = height; i > 0; i--)
                WriteAtPosition(drawChar.HasValue ? drawChar.Value.ToString() : ".", 0, i);

            Console.SetCursorPosition(0, height + DefaultTopPostion);
        }

        /// <summary>
        /// This method is used to Draw vertical and horizantal line from x1,y1  to x2,y2 corodinate.
        /// </summary>
        /// <param name="x1">From X1</param>
        /// <param name="y1">From Y1</param>
        /// <param name="x2">From X2</param>
        /// <param name="y2">From Y2</param>
        public void DrawALine(int x1, int y1, int x2, int y2)
        {
            Console.ForegroundColor = ConsoleColor.White;

            if (x1 > x2)
            {
                CommonUtility.SwapNumber(ref x1, ref x2);
            }

            for (int i = x1; i < x2; i++) // draw horizantal line
            {
                WriteAtPosition(drawChar.HasValue ? drawChar.Value.ToString() : ".", i, y1);
            }

            if (y1 > y2)
            {
                CommonUtility.SwapNumber(ref y1, ref y2);
            }

            for (int i = y1; i < y2; i++) // draw vertical line.
            {
                WriteAtPosition(drawChar.HasValue ? drawChar.Value.ToString() : ".", x2, i);
            }
        }

        /// <summary>
        /// This method is used to write content in console for (x,y) location.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="x">X point from left</param>
        /// <param name="y">y point from top</param>
        protected void WriteAtPosition(string s, int x, int y)
        {
            try
            {
                DefaultLeftPostion = DefaultLeftPostion == 0 ? 2 : DefaultLeftPostion;
                DefaultTopPostion = DefaultTopPostion == 0 ? 2 : DefaultTopPostion;
                Console.SetCursorPosition(x + DefaultLeftPostion, y + DefaultTopPostion); // left,top
                Console.WriteLine(s);
                LstConsoleContent.Add(new ConsoleContent()
                {
                    x = x + DefaultLeftPostion,
                    y = y + DefaultTopPostion,
                    c = s.ToCharArray()[0]

                });

            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// This method is used  to fill from left to x location and top to y location.
        /// </summary>
        /// <param name="x">X point from left</param>
        /// <param name="y">Y point from top</param>
        public void WriteInConsoleXYLocation(int x, int y)
        {
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {

                    WriteAtPosition(drawChar.HasValue ? drawChar.Value.ToString() : "O", i, j);
                }
            }

        }

    }
}

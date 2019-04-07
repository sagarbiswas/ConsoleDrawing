using DrawingProj.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrawingProj.Interface
{
    /// <summary>
    /// Contract for drawing.
    /// </summary>
   public interface IDraw // Pattern is used for Dependency Injection.
   {
       int DefaultLeftPostion { get; set; }
       int DefaultTopPostion { get; set; }
       char? drawChar { get; set; }
        IList<ConsoleContent> LstConsoleContent { get; set; }
        void DrawACanvas(int width, int height);
       void DrawALine(int x1, int y1, int x2, int y2);

       void WriteInConsoleXYLocation(int x, int y);

       //void FillArea(int x1, int y1, int x2, int y2);
    }
}

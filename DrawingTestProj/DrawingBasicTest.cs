
using System.Collections.Generic;
using Contacts.Interface;
using Contacts.Model;
using Handler;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Handler.Tests
{
    [TestClass()]
    public class DrawingBasicTest
    {
        private IDraw _iDraw;

        public DrawingBasicTest()
        {
          _iDraw = new DrawingHandler();
        }

        [TestMethod]
        public void TestDrawObjectCreated()
        {
            _iDraw = new DrawingHandler();
            Assert.IsNotNull(_iDraw, "Object created successfully.");
        }

        [TestMethod()]
        public void DrawACanvasTest()
        {
             ResetConsoleContent();
            _iDraw.drawChar = 'x';
            _iDraw.DrawACanvas(10, 20);

            Assert.IsTrue(_iDraw.LstConsoleContent.Count > 0, "Canvas created successfully");
        }

        [TestMethod()]
        public void DrawALineTest()
        {
             ResetConsoleContent();

            _iDraw.drawChar = 'x';
            _iDraw.DrawALine(1, 2, 10, 20);

            Assert.IsTrue(_iDraw.LstConsoleContent.Count > 0, "Line created successfully");
        }

        [TestMethod()]
        public void WriteInConsoleXYLocationTest()
        {
             DrawACanvasTest();
            _iDraw.drawChar = 'x';
            var beforeInserted = _iDraw.LstConsoleContent.Count;
            _iDraw.WriteInConsoleXYLocation(11,22);
            Assert.IsTrue(_iDraw.LstConsoleContent.Count > beforeInserted, "Inserted char successfully");
        }

        void ResetConsoleContent()
        {
            _iDraw.LstConsoleContent = new List<ConsoleContent>();
        }
    }
}


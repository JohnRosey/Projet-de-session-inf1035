using NUnit.Framework;
using Sudoku;
using System.IO;
using System.Reflection;

namespace SudokuTest
{
    public class Tests
    {
        
        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        public void TestSaveThanLoadSamegrid()
        {
            string[] emptygrid = new string[486];

            GameControl sudokugrid1 = new GameControl(emptygrid);
            
            sudokugrid1.CellGrid[0, 0].Value = "1";
            sudokugrid1.SaveGame();
            GameControl sudokugrid2 = new GameControl(sudokugrid1.FileValue);
            sudokugrid2.Loadgame();
            Assert.AreEqual(sudokugrid2.FileValue, sudokugrid1.FileValue);
        }
        [Test]
        public void TestLoadBadGrid()
        {
            string[] emptygrid = new string[486];
            string[] badgrid = new string[40];
            GameControl sudokugrid1 = new GameControl(emptygrid);
            sudokugrid1.FileValue = badgrid;
          
            sudokugrid1.Loadgame();
            Assert.AreEqual(sudokugrid1.FileValue, emptygrid);
        }
    }
}
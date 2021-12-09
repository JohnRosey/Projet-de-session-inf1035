using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class GameControl
    {
		private  SudokuCell[,] _cellgrid;
		private string[] filevalues;
		public GameControl()
		{
			
			_cellgrid = new SudokuCell[9, 9];
			for (int c = 0; c < 9; c++)
			{
				for (int r = 0; r < 9; r++)
				{
					_cellgrid[c, r] = new SudokuCell();
				}
			}
		}
		public GameControl(string[] filedata)
		{
			filevalues = filedata;
			_cellgrid = new SudokuCell[9, 9];
			for (int c = 0; c < 9; c++)
			{
				for (int r = 0; r < 9; r++)
				{
					_cellgrid[c, r] = new SudokuCell();
				}
			}
		}
		public GameControl(GameControl value)
		{
			filevalues = value.filevalues;
			_cellgrid = new SudokuCell[9, 9];
			for (int c = 0; c < 9; c++)
			{
				for (int r = 0; r < 9; r++)
				{
					_cellgrid[c, r] = value.CellGrid[c, r].Clone();
				}
			}
		}
		public GameControl clone()
		{
			return new GameControl(this);
		}
		public SudokuCell[,] CellGrid
        {
            get
            {
				return _cellgrid;
            }
            set
            {
				_cellgrid = value;
            }
        }
		public string[] FileValue
        {
            get
            {
				return filevalues;
            }
            set
            {
				filevalues = value;
            }
        }
        public void Loadgame()
        {

			if(filevalues.Length != 486)
            {
				filevalues = new string[486];
            }
            else { 

					int line = 0;
					for (int c = 0; c < 9; c++)
					{
						for (int r = 0; r < 9; r++)
						{
							_cellgrid[r, c].Value = filevalues[line];
							line++;
							_cellgrid[r, c].Notes[0].Note = filevalues[line];
							line++;
							_cellgrid[r, c].Notes[1].Note = filevalues[line];
							line++;
							_cellgrid[r, c].Notes[2].Note = filevalues[line];
							line++;
							_cellgrid[r, c].Notes[3].Note = filevalues[line];
							line++;
							_cellgrid[r, c].Notes[4].Note = filevalues[line];
							line++;
						}

					}
			}




		}
		public void SaveGame()
		{
			string[] lines = new string[81 * 6];
			int line = 0;
			for (int c = 0; c < 9; c++)
			{
				for (int r = 0; r < 9; r++)
				{
					lines[line] = _cellgrid[r, c].Value;
					line++;
					lines[line] = _cellgrid[r, c].Notes[0].Note;
					line++;
					lines[line] = _cellgrid[r, c].Notes[1].Note;
					line++;
					lines[line] = _cellgrid[r, c].Notes[2].Note;
					line++;
					lines[line] = _cellgrid[r, c].Notes[3].Note;
					line++;
					lines[line] = _cellgrid[r, c].Notes[4].Note;
					line++;
				}

			}
			filevalues = lines;
			

		}

        internal void readFile()
        {
            if (!System.IO.File.Exists("WriteLines2.txt"))
            {
				filevalues = new string[486];
				writeFile();
            }
            else
            {
				try
				{
					filevalues = System.IO.File.ReadAllLines("WriteLines2.txt");
				}
				catch (InvalidCastException e)
				{

				}
			}
			
		}

        internal void writeFile()
        {
			try
			{
				System.IO.File.WriteAllLines("WriteLines2.txt", filevalues);
			}
			catch (InvalidCastException e)
			{

			}
		}

		 
}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
     public class SudokuTextChanged :Command
    {
		public  SudokuTextChanged ()
		{
			}
	public GameControl WhatChanged { get; }
			public int Row { get; }
			public int Column { get; }
			public GameControl PreviousValue { get; set; }


		public SudokuTextChanged(GameControl previousValue, GameControl whatChanged)
		{
			PreviousValue = previousValue.clone();
			WhatChanged = whatChanged.clone();
			
		}


		public override void Execute()
			{
			SudokuSquare.ChangingTextThroughUndo = true;
			for (int r = 0; r < 9; r++)
			{
				for (int c = 0; c < 9; c++)
				{
					
					Sudoku_.squares[r, c].tbxValue.Text= WhatChanged.CellGrid[r, c].Value ;
					
					for (int i = 1; i <= 5; i++)
					{
						Sudoku_.squares[r, c].textBoxes[i].Text = WhatChanged.CellGrid[r, c].Notes[i - 1].Note;
					}
				}
			}
			SudokuSquare.ChangingTextThroughUndo = false;
			
			}

			public override void Undo()
			{
				SudokuSquare.ChangingTextThroughUndo = true;
				try
				{
				for (int r = 0; r < 9; r++)
				{
					for (int c = 0; c < 9; c++)
					{
						Sudoku_.squares[r, c].tbxValue.Text = PreviousValue.CellGrid[r, c].Value;
						
						for (int i = 1; i <= 5; i++)
						{
							
							Sudoku_.squares[r, c].textBoxes[i].Text = PreviousValue.CellGrid[r, c].Notes[i - 1].Note;

						}
					}
				}
				
				}
				finally
				{
					SudokuSquare.ChangingTextThroughUndo = false;
				}
		}
	}
}




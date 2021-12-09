using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class SudokuColorChange : Command
	{
		
			public SudokuColorChange()
			{
			}
			public GameControl WhatChanged { get; }
			public int Row { get; }
			public int Column { get; }
			public GameControl PreviousValue { get; set; }


			public SudokuColorChange(GameControl previousValue, GameControl whatChanged)
			{
				PreviousValue = previousValue.clone();
				WhatChanged = whatChanged.clone();

			}


			public override void Execute()
			{
				
				for (int r = 0; r < 9; r++)
				{
					for (int c = 0; c < 9; c++)
					{
					    Sudoku_.squares[r,c].Background = WhatChanged.CellGrid[r, c].Color;
				}
				}
			

			}

			public override void Undo()
			{
				
				try
				{
					for (int r = 0; r < 9; r++)
					{
						for (int c = 0; c < 9; c++)
						{
						Sudoku_.squares[r, c].Background = PreviousValue.CellGrid[r, c].Color;
					}
					}

				}
				finally
				{
					
				}
			}
		}
	}




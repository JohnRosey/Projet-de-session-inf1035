using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public static class Sudoku_
    {
		  public static SudokuSquare[,] squares = new SudokuSquare[9, 9];
		 static SudokuSquare selectedSquare;
		public static IList<SudokuSquare> MultipleSelectedSquares = new List<SudokuSquare>();
		static bool SelectionMultiple = false;



		public static SudokuSquare SelectedSquare
		{
			get => selectedSquare;
			set
			{
				if (selectedSquare == value)
					return;

				SudokuSquare oldSelectedSquare = selectedSquare;
				if (oldSelectedSquare != null)
					oldSelectedSquare.HideSelection();

				selectedSquare = value;
				selectedSquare.ShowSelection();
			}

		}
		public static void SelectSquare(int row, int column)
		{
			if (column >= 9)
				column -= 9;

			if (column < 0)
				column += 9;

			if (row >= 9)
				row -= 9;

			if (row < 0)
				row += 9;

			SelectedSquare = squares[row, column];
		}

		public static void SelectFirstSquare()
		{
			SelectedSquare = squares[0, 0];
		}
	


		//public static void AddSquare(int row, int column, SudokuSquare sudokuSquare)
		//{
		//	squares[row, column] = sudokuSquare;
		//}

		public static SudokuSquare GetSquareSelectedEqualToSquare()
		{
			SudokuSquare squareToReturn = new SudokuSquare();
			foreach(SudokuSquare sq in squares)
            {
				if (sq == selectedSquare)
				{
					squareToReturn = sq;
					break;
				}
            }

			return squareToReturn;
		}

		public static SudokuSquare GetSquareSelectedEqualToSquare(SudokuSquare sudokuSquare)
		{
			SudokuSquare squareToReturn = new SudokuSquare();
			foreach (SudokuSquare sq in squares)
			{
				if (sq == sudokuSquare)
				{
					squareToReturn = sq;
					break;
				}
			}

			return squareToReturn;
		}

		public static void ChangeText(int row, int column, string whatChanged)
		{
			squares[row, column].SetTextNoInternalEvents(whatChanged);
			
		}

		public static IList<SudokuSquare> getMultipleSelectedSquares()
		{
			return MultipleSelectedSquares;
		}
		public static void AddToSelection(SudokuSquare sudokuSquare)
		{
			MultipleSelectedSquares.Add(sudokuSquare);
		}

		public static void ClearMultipleSelectedSquares()
		{
			MultipleSelectedSquares = new List<SudokuSquare>();
		}

		public static bool getSelectionMultiple()
		{
			return SelectionMultiple;
		}

		public static void ChangeMultipleSelection()
		{
			if (SelectionMultiple)
			{
				SelectionMultiple = false;
			}
			else
			{
				SelectionMultiple = true;
			}
		}
	}
}

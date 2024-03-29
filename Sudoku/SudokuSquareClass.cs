﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public  static class SudokuSquareClass
    {
        static SudokuSquare[,] squares = new SudokuSquare[9, 9];
        static SudokuSquare selectedSquare;
        static GameControl SudokuGrid = new GameControl();
        public static string availableChars;
        public static bool mode = false;
        public static bool firstload = false;

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

		public static void SelectFirstSquare()
		{
			SelectedSquare = squares[0, 0];
		}

		public static void AddSquare(int row, int column, SudokuSquare sudokuSquare)
		{
			squares[row, column] = sudokuSquare;
		}

		public static void ChangeText(int row, int column, string whatChanged)
		{
			squares[row, column].SetTextNoInternalEvents(whatChanged);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sudoku
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public static string availableChars;
		public static bool mode = false;
		public static bool firstload = false;
		GameControl lastGrid = new GameControl();
		GameControl SudokuGrid = new GameControl();
		private int multiple;

		public MainWindow()
		{

			InitializeComponent();
			Sudoku_.squares[0, 0] = tbx0_0;
			Sudoku_.squares[0, 1] = tbx0_1;
			Sudoku_.squares[0, 2] = tbx0_2;
			Sudoku_.squares[0, 3] = tbx0_3;
			Sudoku_.squares[0, 4] = tbx0_4;
			Sudoku_.squares[0, 5] = tbx0_5;
			Sudoku_.squares[0, 6] = tbx0_6;
			Sudoku_.squares[0, 7] = tbx0_7;
			Sudoku_.squares[0, 8] = tbx0_8;
			Sudoku_.squares[1, 0] = tbx1_0;
			Sudoku_.squares[1, 1] = tbx1_1;
			Sudoku_.squares[1, 2] = tbx1_2;
			Sudoku_.squares[1, 3] = tbx1_3;
			Sudoku_.squares[1, 4] = tbx1_4;
			Sudoku_.squares[1, 5] = tbx1_5;
			Sudoku_.squares[1, 6] = tbx1_6;
			Sudoku_.squares[1, 7] = tbx1_7;
			Sudoku_.squares[1, 8] = tbx1_8;
			Sudoku_.squares[2, 0] = tbx2_0;
			Sudoku_.squares[2, 1] = tbx2_1;
			Sudoku_.squares[2, 2] = tbx2_2;
			Sudoku_.squares[2, 3] = tbx2_3;
			Sudoku_.squares[2, 4] = tbx2_4;
			Sudoku_.squares[2, 5] = tbx2_5;
			Sudoku_.squares[2, 6] = tbx2_6;
			Sudoku_.squares[2, 7] = tbx2_7;
			Sudoku_.squares[2, 8] = tbx2_8;
			Sudoku_.squares[3, 0] = tbx3_0;
			Sudoku_.squares[3, 1] = tbx3_1;
			Sudoku_.squares[3, 2] = tbx3_2;
			Sudoku_.squares[3, 3] = tbx3_3;
			Sudoku_.squares[3, 4] = tbx3_4;
			Sudoku_.squares[3, 5] = tbx3_5;
			Sudoku_.squares[3, 6] = tbx3_6;
			Sudoku_.squares[3, 7] = tbx3_7;
			Sudoku_.squares[3, 8] = tbx3_8;
			Sudoku_.squares[4, 0] = tbx4_0;
			Sudoku_.squares[4, 1] = tbx4_1;
			Sudoku_.squares[4, 2] = tbx4_2;
			Sudoku_.squares[4, 3] = tbx4_3;
			Sudoku_.squares[4, 4] = tbx4_4;
			Sudoku_.squares[4, 5] = tbx4_5;
			Sudoku_.squares[4, 6] = tbx4_6;
			Sudoku_.squares[4, 7] = tbx4_7;
			Sudoku_.squares[4, 8] = tbx4_8;
			Sudoku_.squares[5, 0] = tbx5_0;
			Sudoku_.squares[5, 1] = tbx5_1;
			Sudoku_.squares[5, 2] = tbx5_2;
			Sudoku_.squares[5, 3] = tbx5_3;
			Sudoku_.squares[5, 4] = tbx5_4;
			Sudoku_.squares[5, 5] = tbx5_5;
			Sudoku_.squares[5, 6] = tbx5_6;
			Sudoku_.squares[5, 7] = tbx5_7;
			Sudoku_.squares[5, 8] = tbx5_8;
			Sudoku_.squares[6, 0] = tbx6_0;
			Sudoku_.squares[6, 1] = tbx6_1;
			Sudoku_.squares[6, 2] = tbx6_2;
			Sudoku_.squares[6, 3] = tbx6_3;
			Sudoku_.squares[6, 4] = tbx6_4;
			Sudoku_.squares[6, 5] = tbx6_5;
			Sudoku_.squares[6, 6] = tbx6_6;
			Sudoku_.squares[6, 7] = tbx6_7;
			Sudoku_.squares[6, 8] = tbx6_8;
			Sudoku_.squares[7, 0] = tbx7_0;
			Sudoku_.squares[7, 1] = tbx7_1;
			Sudoku_.squares[7, 2] = tbx7_2;
			Sudoku_.squares[7, 3] = tbx7_3;
			Sudoku_.squares[7, 4] = tbx7_4;
			Sudoku_.squares[7, 5] = tbx7_5;
			Sudoku_.squares[7, 6] = tbx7_6;
			Sudoku_.squares[7, 7] = tbx7_7;
			Sudoku_.squares[7, 8] = tbx7_8;
			Sudoku_.squares[8, 0] = tbx8_0;
			Sudoku_.squares[8, 1] = tbx8_1;
			Sudoku_.squares[8, 2] = tbx8_2;
			Sudoku_.squares[8, 3] = tbx8_3;
			Sudoku_.squares[8, 4] = tbx8_4;
			Sudoku_.squares[8, 5] = tbx8_5;
			Sudoku_.squares[8, 6] = tbx8_6;
			Sudoku_.squares[8, 7] = tbx8_7;
			Sudoku_.squares[8, 8] = tbx8_8;
			for (int r = 0; r < 9; r++)
			{
				for (int c = 0; c < 9; c++)
				{
					lastGrid.CellGrid[r, c] = Sudoku_.squares[r, c].Cell.Clone();
				}
			}
			HookEvents();
			multiple = 0;
			//Sudoku_.SelectedSquare = Sudoku_.squares[0, 0];
			
			;
		}

		private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Right)
			{
				GetSquarePosition(Sudoku_.SelectedSquare, out int row, out int column);
				SelectSquare(row, column + 1);
			}

			if (e.Key == Key.Left)
			{
				GetSquarePosition(Sudoku_.SelectedSquare, out int row, out int column);
				SelectSquare(row, column - 1);
			}

			if (e.Key == Key.Down)
			{
				GetSquarePosition(Sudoku_.SelectedSquare, out int row, out int column);
				SelectSquare(row + 1, column);
			}

			if (e.Key == Key.Up)
			{
				GetSquarePosition(Sudoku_.SelectedSquare, out int row, out int column);
				SelectSquare(row - 1, column);
			}
			//UNDO REDO key pressed
			if (e.Key == Key.Z && Keyboard.Modifiers.HasFlag(ModifierKeys.Control) && !Keyboard.Modifiers.HasFlag(ModifierKeys.Shift))
			{
				Invoker.Undo();
				e.Handled = true;
			}

			bool ctrlShiftZPressed = e.Key == Key.Z && Keyboard.Modifiers.HasFlag(ModifierKeys.Control | ModifierKeys.Shift);
			bool ctrlYPressed = e.Key == Key.Y && Keyboard.Modifiers.HasFlag(ModifierKeys.Control);

			if (ctrlShiftZPressed || ctrlYPressed)
			{
				Invoker.Redo();
				e.Handled = true;
			}
		}

		void SelectSquare(int row, int column)
		{
			if (column >= 9)
				column -= 9;

			if (column < 0)
				column += 9;

			if (row >= 9)
				row -= 9;

			if (row < 0)
				row += 9;

			Sudoku_.SelectedSquare = Sudoku_.squares[row, column];
		}

		void GetSquarePosition(SudokuSquare square, out int row, out int column)
		{
			for (int c = 0; c < 9; c++)
				for (int r = 0; r < 9; r++)
					if (Sudoku_.squares[r, c] == square)
					{
						row = r;
						column = c;
						return;
					}
			row = -1;
			column = -1;
		}

		void SetAvailableCharacters()
		{
			availableChars = tbxAvailableCharacter.Text.Trim();
			if (availableChars.Length != 9)
				Background = new SolidColorBrush(Colors.Red);
			else
				Background = new SolidColorBrush(Colors.White);
		}

		private void tbxAvailableCharacter_TextChanged(object sender, TextChangedEventArgs e)
		{
			SetAvailableCharacters();
		}






		bool loadingGame;
		public void SaveGame()
		{
			SaveGrid();
			SudokuGrid.SaveGame();
			SudokuGrid.writeFile();
			

		}
		public void SaveGrid()
		{
			for (int c = 0; c < 9; c++)
			{
				for (int r = 0; r < 9; r++)
				{
					SudokuGrid.CellGrid[c, r].Value = Sudoku_.squares[c, r].tbxValue.Text;
					SudokuGrid.CellGrid[c, r].Notes[0].Note = Sudoku_.squares[c, r].tbNotes1.Text;
					SudokuGrid.CellGrid[c, r].Notes[1].Note = Sudoku_.squares[c, r].tbNotes2.Text;
					SudokuGrid.CellGrid[c, r].Notes[2].Note = Sudoku_.squares[c, r].tbNotes3.Text;
					SudokuGrid.CellGrid[c, r].Notes[3].Note = Sudoku_.squares[c, r].tbNotes4.Text;
					SudokuGrid.CellGrid[c, r].Notes[4].Note = Sudoku_.squares[c, r].tbNotes5.Text;
				}
			}

			


		}

		private void updategrid()
        {
			for (int c = 0; c < 9; c++)
			{
				for (int r = 0; r < 9; r++)
				{
					Sudoku_.squares[c, r].tbNotes1.IsEnabled = false;
					Sudoku_.squares[c, r].tbNotes2.IsEnabled = false;
					Sudoku_.squares[c, r].tbNotes3.IsEnabled = false;
					Sudoku_.squares[c, r].tbNotes4.IsEnabled = false;
					Sudoku_.squares[c, r].tbNotes5.IsEnabled = false;
					if (SudokuGrid.CellGrid[c, r].Value !="")
                    {

						Sudoku_.squares[c, r].tbNotes1.Visibility = Visibility.Hidden;
						Sudoku_.squares[c, r].tbNotes2.Visibility = Visibility.Hidden;
						Sudoku_.squares[c, r].tbNotes3.Visibility = Visibility.Hidden;
						Sudoku_.squares[c, r].tbNotes4.Visibility = Visibility.Hidden;
						Sudoku_.squares[c, r].tbNotes5.Visibility = Visibility.Hidden;

					}
                    else
                    {

						Sudoku_.squares[c, r].tbNotes1.Visibility = Visibility.Visible;
						Sudoku_.squares[c, r].tbNotes2.Visibility = Visibility.Visible;
						Sudoku_.squares[c, r].tbNotes3.Visibility = Visibility.Visible;
						Sudoku_.squares[c, r].tbNotes4.Visibility = Visibility.Visible;
						Sudoku_.squares[c, r].tbNotes5.Visibility = Visibility.Visible;

					}
					updateTxtBox();
				}
			}
        }
		private void updateTxtBox()
		{
			for (int c = 0; c < 9; c++)
			{
				for (int r = 0; r < 9; r++)
				{
				
					Sudoku_.squares[c, r].tbxValue.Text = SudokuGrid.CellGrid[c, r].Value;
					Sudoku_.squares[c, r].tbNotes1.Text = SudokuGrid.CellGrid[c, r].Notes[0].Note;
					Sudoku_.squares[c, r].tbNotes2.Text = SudokuGrid.CellGrid[c, r].Notes[1].Note;
					Sudoku_.squares[c, r].tbNotes3.Text = SudokuGrid.CellGrid[c, r].Notes[2].Note;
					Sudoku_.squares[c, r].tbNotes4.Text = SudokuGrid.CellGrid[c, r].Notes[3].Note;
					Sudoku_.squares[c, r].tbNotes5.Text = SudokuGrid.CellGrid[c, r].Notes[4].Note;
				}
			}
		}

		public void LoadGame()
		{
			if (!firstload)
			{
				firstload = true;
			}
			loadingGame = true;
			try
			{
				
				SudokuGrid.readFile();
				SudokuGrid.Loadgame();
				updategrid();
				lastGrid = SudokuGrid.clone();
			}
			finally
			{
				loadingGame = false;
			}

			}

       

        private void btnTest_Click(object sender, RoutedEventArgs e)
		{
			
				LoadGame();
			
				

		}

		SudokuSquare[] GetColumn(int column)
		{
			SudokuSquare[] result = new SudokuSquare[9];
			for (int row = 0; row < 9; row++)
				result[row] = Sudoku_.squares[row, column];

			return result;
		}

		SudokuSquare[] GetRow(int row)
		{
			SudokuSquare[] result = new SudokuSquare[9];
			for (int column = 0; column < 9; column++)
				result[column] = Sudoku_.squares[row, column];

			return result;
		}

		SudokuSquare[] GetBlock(int row, int column)
		{
			int topRow = 3 * (int)Math.Floor((double)row / 3);
			int leftColumn = 3 * (int)Math.Floor((double)column / 3);
			SudokuSquare[] result = new SudokuSquare[9];
			int index = 0;
			for (int r = topRow; r < topRow + 3; r++)
				for (int c = leftColumn; c < leftColumn + 3; c++)
				{
					result[index] = Sudoku_.squares[r, c];
					index++;
				}

			return result;
		}

		void RemoveChars(List<char> availableChars, SudokuSquare[] row)
		{
			for (int i = 0; i < 9; i++)
			{
				char thisChar = row[i].Char;
				if (availableChars.Contains(thisChar))
					availableChars.Remove(thisChar);
			}
		}





		

		private void btnSolve_Click(object sender, RoutedEventArgs e)
		{

			if (!mode)
			{
				mode = true;
				for (int i = 0; i < 9; i++)
				{
					for (int j = 0; j < 9; j++)
					{
						if (Sudoku_.squares[i, j].tbxValue.Text == "")
						{
							Sudoku_.squares[i, j].tbxValue.Visibility = Visibility.Hidden;
							Sudoku_.squares[i, j].tbNotes1.Visibility = Visibility.Visible;
							Sudoku_.squares[i, j].tbNotes2.Visibility = Visibility.Visible;
							Sudoku_.squares[i, j].tbNotes3.Visibility = Visibility.Visible;
							Sudoku_.squares[i, j].tbNotes4.Visibility = Visibility.Visible;
							Sudoku_.squares[i, j].tbNotes5.Visibility = Visibility.Visible;
							Sudoku_.squares[i, j].tbNotes1.IsEnabled = true;
							Sudoku_.squares[i, j].tbNotes2.IsEnabled = true;
							Sudoku_.squares[i, j].tbNotes3.IsEnabled = true;
							Sudoku_.squares[i, j].tbNotes4.IsEnabled = true;
							Sudoku_.squares[i, j].tbNotes5.IsEnabled = true;
                        }
                        else
                        {
							Sudoku_.squares[i, j].tbxValue.IsEnabled =false;
						}

					}
				}
			}
			else
			{
				mode = false;
				for (int i = 0; i < 9; i++)
				{
					for (int j = 0; j < 9; j++)
					{
						if (Sudoku_.squares[i, j].tbNotes1.Text != ""|| Sudoku_.squares[i, j].tbNotes2.Text != "" || Sudoku_.squares[i, j].tbNotes3.Text != "" || Sudoku_.squares[i, j].tbNotes4.Text != "" || Sudoku_.squares[i, j].tbNotes5.Text != "" )
						{
							Sudoku_.squares[i, j].tbxValue.Visibility = Visibility.Visible;
							Sudoku_.squares[i, j].tbNotes1.IsEnabled = false;
							Sudoku_.squares[i, j].tbNotes2.IsEnabled = false;
							Sudoku_.squares[i, j].tbNotes3.IsEnabled = false;
							Sudoku_.squares[i, j].tbNotes4.IsEnabled = false;
							Sudoku_.squares[i, j].tbNotes5.IsEnabled = false;

						}
                        else
                        {
							Sudoku_.squares[i, j].tbxValue.IsEnabled = true;
							Sudoku_.squares[i, j].tbxValue.Visibility = Visibility.Visible;
							Sudoku_.squares[i, j].tbNotes1.Visibility = Visibility.Hidden;
							Sudoku_.squares[i, j].tbNotes2.Visibility = Visibility.Hidden;
							Sudoku_.squares[i, j].tbNotes3.Visibility = Visibility.Hidden;
							Sudoku_.squares[i, j].tbNotes4.Visibility = Visibility.Hidden;
							Sudoku_.squares[i, j].tbNotes5.Visibility = Visibility.Hidden;
						}

					}
				}
			}
			//FillFromAllNotes();
			//RefreshAllNotes();
		}



		private void btnClearNotes_Click(object sender, RoutedEventArgs e)
		{
			for (int c = 0; c < 9; c++)
				for (int r = 0; r < 9; r++)
					Sudoku_.squares[r, c].ClearNotes();
		}


		void HookEvents()
		{
			for (int row = 0; row < 9; row++)
				for (int column = 0; column < 9; column++)
                {
					Sudoku_.squares[row, column].ValueChanged += SudokuSquare_ValueChanged;

				}


		}

		void ShowConflicts()
		{
			ClearAllConflicts();

			for (int r = 0; r < 9; r++)
				for (int c = 0; c < 9; c++)
				{
					SudokuSquare thisSquare = Sudoku_.squares[r, c];
					string text = thisSquare.GetText();
					if (string.IsNullOrWhiteSpace(text))
						continue;

					SudokuSquare[] column = GetColumn(c);
					SudokuSquare[] row = GetRow(r);
					SudokuSquare[] block = GetBlock(r, c);
					for (int rowIndex = 0; rowIndex < 9; rowIndex++)
						if (rowIndex != r && column[rowIndex].GetText() == text)
						{
							thisSquare.HasConflict = true;
							column[rowIndex].HasConflict = true;
						}

					for (int colIndex = 0; colIndex < 9; colIndex++)
						if (colIndex != c && row[colIndex].GetText() == text)
						{
							thisSquare.HasConflict = true;
							row[colIndex].HasConflict = true;
						}

					for (int squareIndex = 0; squareIndex < 9; squareIndex++)
					{
						GetSquarePosition(block[squareIndex], out int blockRow, out int blockColumn);
						if (blockRow == r && blockColumn == c)
							continue;

						if (block[squareIndex].GetText() == text)
						{
							thisSquare.HasConflict = true;
							block[squareIndex].HasConflict = true;
						}
					}
					
				}
		}

		private void ClearAllConflicts()
		{
			for (int r = 0; r < 9; r++)
				for (int c = 0; c < 9; c++)
					Sudoku_.squares[r, c].HasConflict = false;
		}

		private void SudokuSquare_ValueChanged(object sender, EventArgs e)
		{
			
			SudokuSquare tb =(SudokuSquare)sender;
			
			if (loadingGame)
			{
				return;
			}
			else
			{

				if (multiple ==0)
				{
					foreach (SudokuSquare sudokuSquare in Sudoku_.getMultipleSelectedSquares())
					{
						multiple++;
						Sudoku_.GetSquareSelectedEqualToSquare(sudokuSquare).tbxValue.Text = tb.tbxValue.Text;
						Sudoku_.GetSquareSelectedEqualToSquare(sudokuSquare).Cell = tb.Cell.Clone();
						for (int i = 1; i <= 5; i++)
						{
							Sudoku_.GetSquareSelectedEqualToSquare(sudokuSquare).textBoxes[i].Text = tb.textBoxes[i].Text;
						}
					}
					Sudoku_.ClearMultipleSelectedSquares();
					SaveGrid();
					Invoker.DoCommand(new SudokuTextChanged(lastGrid, SudokuGrid));
					ShowConflicts();
					for (int r = 0; r < 9; r++)
					{
						for (int c = 0; c < 9; c++)
						{
							lastGrid.CellGrid[r, c] = SudokuGrid.CellGrid[r, c].Clone();
							
						}
					}
					updateTxtBox();
                }
                else
                {
					multiple--;
                }


			}
		}

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
			if (firstload)
			{
				SaveGame();
			}
        }

        private void Undo_Click(object sender, RoutedEventArgs e)
        {
			Invoker.Undo();
			e.Handled = true;
		}

       private void Redo_Click(object sender, RoutedEventArgs e)
	{

			Invoker.Redo();
			e.Handled = true;
		}

		private void CouleurW(object sender, RoutedEventArgs e)
		{
			//System.Windows.Forms.ColorDialog dlg = new System.Windows.Forms.ColorDialog();
			//if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			//{
			//	button.Foreground = new SolidColorBrush();

			//}
			ChooseColor obj = new ChooseColor();
			
			obj.Show();


		}

		private void MenuItem_Click(object sender, RoutedEventArgs e)
		{
			Sudoku_.ChangeMultipleSelection();
		}




	}


}

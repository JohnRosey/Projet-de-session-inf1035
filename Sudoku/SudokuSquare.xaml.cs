using System;
using System.Collections.Generic;
using System.Linq;
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
	/// Interaction logic for SudokuSquare.xaml
	/// </summary>
	public partial class SudokuSquare : UserControl
	{
		public event EventHandler ValueChanged;
		public TextBox[] textBoxes;

		public SudokuCell Cell;

		public bool HasConflict
		{
			get => hasConflict;
			set
			{
				if (hasConflict == value)
					return;

				hasConflict = value;

				if (hasConflict)
				{
					Grid1.Background = new SolidColorBrush(Color.FromRgb(255, 148, 148));
				}
				else
				{
					Grid1.Background = null;
				}
			}
		}

       
        bool hasConflict;

		bool locked;
		public bool Locked
		{
			get
			{
				return locked;
			}
			set
			{
				if (locked == value)
					return;

				locked = value;
				if (locked)
				{
					tbxValue.Foreground = new SolidColorBrush(Color.FromRgb(68, 72, 99));
					tbxValue.IsReadOnly = true;
				}
				else
				{
					tbxValue.Foreground = new SolidColorBrush(Colors.Black);
					tbxValue.IsReadOnly = false;
				}
			}
		}
	
		public string Notes { get; set; }
		public SudokuSquare()
		{
			InitializeComponent();
			Cell = new SudokuCell();
			textBoxes = new TextBox[6];
			
			for(int i=0; i<6;i++)
            {
				textBoxes[i] = new TextBox();
            }
			textBoxes[0] = tbxValue;
			textBoxes[1] = tbNotes1;
			textBoxes[2] = tbNotes2;
			textBoxes[3] = tbNotes3;
			textBoxes[4] = tbNotes4;
			textBoxes[5] = tbNotes5;

		}
		public SudokuSquare(SudokuSquare value)
		{
			InitializeComponent();
			Cell = value.Cell.Clone();
			textBoxes = new TextBox[6];

			for (int i = 0; i < 6; i++)
			{
				textBoxes[i] = new TextBox();
			}
			textBoxes[0] = value.textBoxes[0];
			textBoxes[1] = value.textBoxes[1];
			textBoxes[2] = value.textBoxes[2];
			textBoxes[3] = value.textBoxes[3];
			textBoxes[4] = value.textBoxes[4];
			textBoxes[5] = value.textBoxes[5];

		}
		public SudokuSquare clone()
        {
			return new SudokuSquare(this);
        }

		protected virtual void OnValueChanged(object sender, EventArgs e)
		{
			ValueChanged?.Invoke(sender, e);
			
		}
		public int Column => Grid.GetColumn(this);
		public int Row => Grid.GetRow(this);
		public static bool ChangingTextThroughUndo;
		private void tbxValue_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (ChangingTextThroughUndo)
				return;
			if (e.Changes != null)
			{
				if (sender is TextBox textBox)
				{
					tbNotes1.Visibility = Visibility.Hidden;
					tbNotes2.Visibility = Visibility.Hidden;
					tbNotes3.Visibility = Visibility.Hidden;
					tbNotes4.Visibility = Visibility.Hidden;
					tbNotes5.Visibility = Visibility.Hidden;
					string lineText = textBox.GetLineText(0);
					TextChange textChange = e.Changes.First();
					string whatChanged = lineText.Substring(textChange.Offset, textChange.AddedLength);
					if (MainWindow.availableChars.Contains(whatChanged))
					{
						//Invoker.DoCommand(new SudokuTextChanged(lastValue, whatChanged, Row, Column));
					}
					else
					{
						//Invoker.DoCommand(new SudokuTextChanged(lastValue, whatChanged, Row, Column));
					};

				if (MainWindow.availableChars.Contains(whatChanged))
						{
							if (textBox.Text != whatChanged)
                        {
							textBox.Text = whatChanged;

							Cell.Value = whatChanged;
						}
						

					}
					else if (textBox.Text != "")
					{
						textBox.Text = "";
						Cell.Value = "";
					}
					OnValueChanged(this, EventArgs.Empty);
				}
			}

		}
		


private void Border_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			//tbxValue.Focus();
		}

		public void ShowSelection()
		{
            tbxValue.Focus();
            Border.Background = new SolidColorBrush(Color.FromRgb(255, 244, 176));
        }

		public void HideSelection()
		{
			Border.Background = null;
		}

		public void Clear()
		{
			tbxValue.Text = "";
			tbNotes1.Text = "";
			tbNotes2.Text = "";
			tbNotes3.Text = "";
			tbNotes4.Text = "";
			tbNotes5.Text = "";
			Cell = new SudokuCell();
		}

		public void SetText(string text)
		{
			tbxValue.Text = text;
		}

		public string GetText()
		{
			return tbxValue.Text;
		}


		public char Char
		{
			get
			{
				if (tbxValue.Text.Length > 0)
					return tbxValue.Text[0];
				return char.MinValue;
			}
		}

		
		public void SetTextNoInternalEvents(string text)
		{bool ignoreNextTextChangedEvent; 
			if (tbxValue.Text != text)
			{
				ignoreNextTextChangedEvent = true;
				Cell.Value = text;
				tbxValue.Text = text;
			}
			OnValueChanged(this, EventArgs.Empty);
			SaveLastValue();
		}

		string lastValue;
		private void SaveLastValue()
		{
			lastValue = tbxValue.Text;
		}
		public void SetNotes(string notes)
		{
			tbNotes1.Text = notes;
		}

	
		public void ClearNotes()
		{
			tbNotes1.Text = "";
			tbNotes2.Text = "";
			tbNotes3.Text = "";
			tbNotes4.Text = "";
			tbNotes5.Text = "";
			Cell.clearNotes();
		}

        private void tbNotes1_TextChanged(object sender, TextChangedEventArgs e)
        {
			if (ChangingTextThroughUndo)
				return;
			if (e.Changes != null)
			{
				if (sender is TextBox textBox)
				{
					
					if(!MainWindow.availableChars.Contains(textBox.Text) || !textBox.Name.Equals(tbNotes1.Name) && tbNotes1.Text.Contains(textBox.Text)|| !textBox.Name.Equals(tbNotes2.Name) && tbNotes2.Text.Contains(textBox.Text) || !textBox.Name.Equals(tbNotes3.Name) && tbNotes3.Text.Contains(textBox.Text) || !textBox.Name.Equals(tbNotes4.Name) && tbNotes4.Text.Contains(textBox.Text) || !textBox.Name.Equals(tbNotes5.Name) && tbNotes5.Text.Contains(textBox.Text))
                    {
						textBox.Text = "";
					}
					//if (!textBox.Name.Equals(tbNotes1.Name) && textBox.Text.Contains(tbNotes1.Text) && tbNotes2.Text != " " || !textBox.Name.Equals(tbNotes2.Name) && textBox.Text.Contains(tbNotes2.Text) || !textBox.Name.Equals(tbNotes3.Name) && textBox.Text.Contains(tbNotes3.Text) || !textBox.Name.Equals(tbNotes4.Name) && textBox.Text.Contains(tbNotes4.Text) || !textBox.Name.Equals(tbNotes5.Name) && tbNotes5.Text.Contains(textBox.Text))
					if(textBox.Name.Equals(tbNotes1.Name))
                    {
						Cell.Notes[0].Note = textBox.Text;
                    }else if(textBox.Name.Equals(tbNotes2.Name))
					{
						Cell.Notes[1].Note = textBox.Text;
					}
					else if (textBox.Name.Equals(tbNotes3.Name))
					{
						Cell.Notes[2].Note = textBox.Text;
					}
					else if (textBox.Name.Equals(tbNotes4.Name))
					{
						Cell.Notes[3].Note = textBox.Text;
					}
					textBox.Select(textBox.Text.Length, 0);
					OnValueChanged(this, EventArgs.Empty);
				}
			}
		}

        private void tbNotes5_TextChanged(object sender, TextChangedEventArgs e)
        {
			if (ChangingTextThroughUndo)
				return;
			if (e.Changes != null)
			{
				if (sender is TextBox textBox)
				{
					if (textBox.Text != "")
					{
						string toremove = textBox.Text.Remove(textBox.Text.Length - 1, 1);
						if (!MainWindow.availableChars.Contains(textBox.Text[textBox.Text.Length-1]) || toremove.Contains(textBox.Text[textBox.Text.Length - 1])&&toremove!="")
						{
							textBox.Text = toremove;
							Cell.Notes[4].Note = toremove;
						}
					}

					if (textBox.Text.Contains(tbNotes1.Text) && tbNotes1.Text != ""|| textBox.Text.Contains(tbNotes2.Text) && tbNotes2.Text != ""|| textBox.Text.Contains(tbNotes3.Text) && tbNotes3.Text != ""|| textBox.Text.Contains(tbNotes4.Text) && tbNotes4.Text != "")
					{
							textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1, 1);
						Cell.Notes[4].Note = textBox.Text;
					}




					//if (!textBox.Name.Equals(tbNotes1.Name) && textBox.Text.Contains(tbNotes1.Text) && tbNotes2.Text != " " || !textBox.Name.Equals(tbNotes2.Name) && textBox.Text.Contains(tbNotes2.Text) || !textBox.Name.Equals(tbNotes3.Name) && textBox.Text.Contains(tbNotes3.Text) || !textBox.Name.Equals(tbNotes4.Name) && textBox.Text.Contains(tbNotes4.Text) || !textBox.Name.Equals(tbNotes5.Name) && tbNotes5.Text.Contains(textBox.Text))

					textBox.Select(textBox.Text.Length, 0);
					OnValueChanged(this, EventArgs.Empty);
				}
			}
		}

        private void tbxValue_GotFocus(object sender, RoutedEventArgs e)
        {
			//GetSquarePosition(Sudoku_.SelectedSquare, out int row, out int column);

			Sudoku_.SelectedSquare = this;
			if (Sudoku_.getSelectionMultiple())
			{
				Sudoku_.AddToSelection(Sudoku_.SelectedSquare);
				Sudoku_.SelectedSquare.Background = Brushes.Blue;
			}
			//SudokuSquareClass.SelectedSquare.ShowSelection();

		}
    }
}

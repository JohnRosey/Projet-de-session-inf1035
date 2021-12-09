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
using System.Windows.Shapes;

namespace Sudoku
{
    /// <summary>
    /// Logique d'interaction pour ChooseColor.xaml
    /// </summary>
    public partial class ChooseColor : Window
    {
        public ChooseColor()
        {
            InitializeComponent();
            cboProjectColor.ItemsSource = ColorUtils.LoadColors();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Close();
        }

        private void cmdSave_Click(object sender, RoutedEventArgs e)
        {
            GameControl lastGrid = new GameControl();
            GameControl SudokuGrid = new GameControl();
           
            for (int r = 0; r < 9; r++)
                {
                for (int c = 0; c < 9; c++)
                        {
                            lastGrid.CellGrid[r, c] = Sudoku_.squares[r, c].Cell.Clone();
                        }
                }
                
            
                    if (cboProjectColor.SelectedItem != null)
            {
                RowColor selectedcolor = (RowColor)cboProjectColor.SelectedItem;
                //Sudoku_.GetSquareSelectedEqualToSquare().Background = selectedcolor.FillColor;
                //for(int i = 0; i < Sudoku_.getMultipleSelectedSquares().Count; i++)
                //{
                //    Sudoku_.getMultipleSelectedSquares()[i];
                //    Sudoku_.GetSquareSelectedEqualToSquare().Background = selectedcolor.FillColor;
                //}
                if (Sudoku_.getSelectionMultiple())
                {
                    foreach (SudokuSquare sudokuSquare in Sudoku_.getMultipleSelectedSquares())
                    {
                        //Sudoku_.SelectedSquare = sudokuSquare;
                       
                        
                        Sudoku_.GetSquareSelectedEqualToSquare(sudokuSquare).Background = selectedcolor.FillColor;
                        Sudoku_.GetSquareSelectedEqualToSquare(sudokuSquare).Cell.Color = selectedcolor.FillColor;
                    }

                    Sudoku_.ClearMultipleSelectedSquares();
                }
                else
                {
                    Sudoku_.GetSquareSelectedEqualToSquare().Background = selectedcolor.FillColor;
                    Sudoku_.GetSquareSelectedEqualToSquare().Cell.Color = selectedcolor.FillColor;
                }

                for (int r = 0; r < 9; r++)
                {
                    for (int c = 0; c < 9; c++)
                    {
                        SudokuGrid.CellGrid[r, c] = Sudoku_.squares[r, c].Cell.Clone();
                    }
                }
                Invoker.DoCommand(new SudokuColorChange(lastGrid, SudokuGrid));

            }

        }
    }
}

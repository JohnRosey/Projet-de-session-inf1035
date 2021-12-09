using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Sudoku
{
    public class SudokuCell
    {
        private string _value;
        private CellNote[] _notes;
        private SolidColorBrush color;
        public SudokuCell()
        {
            _value = "";
            _notes = new CellNote[5];
            for(int i=0;i<5;i++)
            {
                _notes[i] = new CellNote();
            }
        }
        public SudokuCell(SudokuCell value)
        {
            _value = value.Value;
            _notes = new CellNote[5];
            color = value.color;
            for (int i = 0; i < 5; i++)
            {
                _notes[i] = value.Notes[i].clone();
            }
        }
        public SudokuCell(string value)
        {
            _value = value;
            _notes = new CellNote[5];
            for (int i = 0; i < 5; i++)
            {
                _notes[i] = new CellNote();
            }
        }
        public SudokuCell(string value, CellNote[] notes)
        {
            _value = value;
            _notes = notes;
           
        }
        public CellNote[] Notes
        {
                get
                {
                    return _notes;
                }
            set
            {
                _notes = value;
            }
            

        }
        public SolidColorBrush Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }


        }
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }
        public void clearNotes()
        {
            _notes = new CellNote[5];
            for (int i = 0; i < 5; i++)
            {
                _notes[i] = new CellNote();
            }
        }
         public SudokuCell Clone()
            {
                return new SudokuCell(this);
            }
        

    }
}

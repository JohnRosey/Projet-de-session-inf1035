using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class CellNote
    {
        private string _note;
        public CellNote()
        {
            _note = "";
        }
        public CellNote(CellNote value)
        {
            _note = value.Note;
        }
        public CellNote clone()
        {
            return new CellNote(this);
        }

        public string Note
        {

            get
            {
                return _note;
            }
            set
            {
                _note = value;

            }

        }


    }
}

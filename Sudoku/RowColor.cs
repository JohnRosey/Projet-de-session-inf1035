using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Sudoku
{
    /// <summary>
    /// Represents a Color fom the XML data tag.
    /// </summary>
    public class RowColor
    {
        /// <summary>
        /// Constructor for RowColor.
        /// </summary>
        public RowColor()
        {
            FillColor = new SolidColorBrush();
        }
        /// <summary>
        /// Gets/Sets the fill brush color for the row.
        /// </summary>
        public SolidColorBrush FillColor { get; set; }

        /// <summary>
        /// Gets/Sets the display color for the row.
        /// </summary>
        public String ColorName { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Xml.Linq;

namespace Sudoku
{
    class ColorUtils
    {
        public static ObservableCollection<RowColor> LoadColors()
        {
            //Loads the resource.
            ResourceDictionary allowedColorsDict = new ResourceDictionary()
            {
                Source = new Uri("/Sudoku;component/ListOfColors.xaml",
                                UriKind.RelativeOrAbsolute)
            };

            // Brings the XElement from the resourse to an instance in code.
            XElement xSource = (XElement)((ObjectDataProvider)allowedColorsDict["AllowedColors"])
                                .Data;

            // Constructs the list of colors.
            IEnumerable<RowColor> colors = from color in xSource.Descendants()
                                           select new RowColor
                                           {
                                               FillColor = ConvertToSolidColorBrush(color
                                                                                 .Attribute("Brush")
                                                                                 .Value),
                                               ColorName = color.Attribute("Name").Value
                                           };

            return new ObservableCollection<RowColor>(colors);
        }

        /// <summary>
        /// Converts a given color name into a SolidColorBrush with that color information. 
        /// </summary>
        /// <param name="colorName">Color name to build the Brush.</param>
        /// <returns>SolidColorBrush for the respective Color</returns>
        private static SolidColorBrush ConvertToSolidColorBrush(string colorName)
        {
            //This method needs to have some sort of checking to prevent an exception in case
            // of an invalid color name provided.

            BrushConverter bc = new BrushConverter();

            return bc.ConvertFromString(colorName) as SolidColorBrush;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WindowsFormsApp11
{
    class General
    {
        public static Color background()
        {
            int col = 247;
            return Color.FromArgb(col, col, col);
        }

        public static Font standardFont(int size)
        {
            FontFamily fontFamily = new FontFamily("Calibri");
            Font font = new Font(fontFamily, size, FontStyle.Regular, GraphicsUnit.Pixel);
            return font;
        }
    }
}
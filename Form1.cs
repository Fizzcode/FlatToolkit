using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WindowsFormsApp11
{
    public partial class Form1 : Form
    {
        NWindow ww;

        public Form1()
        {
            InitializeComponent();
            ww = new NWindow(this, 600, 300);
            ww.setThingsUp();
            ww.addControl(new NLabel(ww, "Flat Toolkit b8 (by Fizzcode)", 5, 5, 200));
            ww.addControl(new NTextbox(ww, 100, 100, 100, 20));
            ww.addControl(new NButton(ww, "Test", 100, 200, 100, 30));
        }
    }
}
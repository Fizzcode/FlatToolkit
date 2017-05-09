using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace WindowsFormsApp11
{
    class NTextbox : TextBox
    {
        private BackgroundWorker bgw;
        private NWindow main;
        private int w;

        public NTextbox(NWindow main_, int x, int y, int w, int h)
        {
            ColorConverter cc = new ColorConverter();
            int col = 220;
            this.BackColor = Color.FromArgb(col, col, col);
            this.ForeColor = (Color)cc.ConvertFromString("#393E46");
            this.BorderStyle = BorderStyle.None;
            this.Font = General.standardFont(15);
            this.SetBounds(x, y, 0, h);
            /*Trying to be smart and using the MainWindow MouseEvent Functions*/
            this.MouseDown += main_.onMouseDown;
            this.MouseUp += main_.onMouseUp;
            this.MouseMove += main_.onMouseMove;
            this.bgw = new BackgroundWorker();
            this.bgw.WorkerReportsProgress = true;
            this.bgw.WorkerSupportsCancellation = true;
            this.bgw.DoWork += this.DoWork;
            this.bgw.ProgressChanged += this.UI_updater;
            this.bgw.RunWorkerAsync();
            this.main = main_;
            this.w = w;
        }

        private void DoWork(object sender, EventArgs e)
        {
            while (true)
            {
                if (this.main.loaded())
                {
                    this.bgw.ReportProgress(1);
                    System.Threading.Thread.Sleep(10);
                }
            }
        }

        private void UI_updater(object sender, EventArgs e)
        {
            if(this.w > this.Width)
            {
                int cv = Math.Abs(this.w - this.Width) / 8;
                this.Width += cv;
            }
            else
            {
                this.bgw.CancelAsync();
            }
        }
    }
}
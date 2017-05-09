using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp11;
class NLabel : Label
{

    private BackgroundWorker bgw;
    private NWindow nw;
    private int xA = 0;
    private int yA = 0;
    private int wA = 0;
    private int tickx = 0;
    private int ticky = 0;
    private int height = 20;
    public NLabel(NWindow main, String text, int x, int y, int w)
    {

        this.bgw = new BackgroundWorker();
        this.bgw.ProgressChanged += UI_updater;
        this.bgw.WorkerReportsProgress = true;
        this.bgw.WorkerSupportsCancellation = true;
        this.bgw.DoWork += FakeUpdater;
        this.Font = General.standardFont(15);
        ColorConverter cc = new ColorConverter();
        this.Text = text;
        this.xA = x;
        this.yA = y;
        this.wA = w;
        this.SetBounds(xA, yA, 0, height);
        this.BackColor = General.background();
        this.ForeColor = (Color)cc.ConvertFromString("#222831");
        /*Trying to be smart and using the MainWindow MouseEvent Functions*/
        this.MouseDown += main.onMouseDown;
        this.MouseUp += main.onMouseUp;
        this.MouseMove += main.onMouseMove;
        this.nw = main;
        this.bgw.RunWorkerAsync();
    }
    private void FakeUpdater(object sender, EventArgs e)
    {
        while (true)
        {
            if(nw != null)
            {
                if (this.nw.loaded())
                {
                    this.bgw.ReportProgress(1);
                    System.Threading.Thread.Sleep(5);
                }
            }
            
        }
    }
    private void UI_updater(object sender, EventArgs e)
    {

        if(this.Width < this.wA)
        {
            int va = Math.Abs(this.Width - this.wA) / 10;
            this.Width += va;
        }

        if(this.Width > this.wA)
        {
            this.bgw.CancelAsync();
        }


    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    class NButton : Button
    {
        private int x, y, w, h = 0;
        private String text;
        private BackgroundWorker bgw;
        private NWindow main;
        private bool clickAni = false;
        private bool canToggle = true;
        private int a = 0;

        public NButton(NWindow main_, String text_, int xx, int yy, int ww, int hh)
        {
            ColorConverter cc = new ColorConverter();
            this.text = text_;
            this.bgw = new BackgroundWorker();
            this.bgw.WorkerReportsProgress = true;
            this.bgw.DoWork += this.DoWork;
            this.bgw.ProgressChanged += this.UI_updater;
            this.bgw.RunWorkerAsync();
            this.bgw.WorkerSupportsCancellation = true;

            this.main = main_;
            this.x = xx;
            this.y = yy;
            this.w = ww;
            this.h = hh;
            this.SetBounds(this.x, this.y, 0, this.h);
            this.Text = text;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0; /*No need to overwrite draw for this*/
            this.Font = General.standardFont(13);
            int col = 236;
            this.BackColor = Color.FromArgb(col, col, col);
            this.ForeColor = Color.FromArgb(0, 0, 0);
            this.Click += this.onClick;
            this.Paint += this.OnPaint;



        }

        private void onClick(object sender, EventArgs e)
        {
            if (this.canToggle)
            {
                this.clickAni = true;
                this.canToggle = false;
            }
        }

        private void DoWork(object sender, EventArgs e)
        {

            while (true)
            {
                if (this.main.loaded())
                {
                    System.Threading.Thread.Sleep(10);
                    this.bgw.ReportProgress(1);
                }
            }
        }

        private void UI_updater(object sender, EventArgs e)
        {
            if(this.w > this.Width)
            {
                /*Sometimes you need some smoothness in life*/
                int cv = Math.Abs(this.w - this.Width) / 8; 
                this.Width+= cv;
            }

            if (this.clickAni)
            {
                if(a < 26)
                {
                    if (a < 13)
                    {
                        this.Top--;
                    }

                    if (a > 13 && a < 26)
                    {
                        this.Top++;
                        
                        
                    }

                    a++;
                }
                else
                {
                    this.clickAni = false;
                    this.canToggle = true;
                    this.a = 0;
                }

                
            }
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            

            int col = 227;

            for(int i = 0; i < this.Height; i++)
            {
                Rectangle rt = new Rectangle(new Point(0, i), new Size(new Point(this.w, i+1)));
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(col, col, col)), rt);
                col -= 2;
           
            }

            Font f = General.standardFont(14);
            Color stringColor = Color.FromArgb(0, 0, 0);
            int x = this.Width / 2 - (this.text.Length*4);
            e.Graphics.DrawString(this.text,f,new SolidBrush(stringColor), x , this.Height / 4);

            e.Graphics.Flush();
           
        }


    }
}

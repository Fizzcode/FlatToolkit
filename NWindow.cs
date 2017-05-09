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
    class NWindow
    {
        private Form window;
        private int width, height = 0;
        private int mouseX, mouseY = 0;
        private bool drag = false;
        private int x, y = 100;
        private BackgroundWorker bgw;
        private bool _firstAniDone = false;
        private bool _secondAniDone = false;
        private Random rand;
        private int shakeValue = 4;
        //private bool _controlsLoaded = false;
        //First Animation = 'Scroll' down window height
        //Second Anitmation = 'Shake' short extra window height
        private NWindowbuttons window_Buttons;
        public NWindow(Form A, int wi, int hi)
        {
            this.bgw = new BackgroundWorker();
            this.bgw.ProgressChanged += UI_updater;
            this.bgw.WorkerReportsProgress = true;
            this.bgw.DoWork += FakeUpdater;
            this.height = hi;
            this.width = wi;
            this.window = A;
            this.rand = new Random();
        }

        private void showButtons()
        {
            window_Buttons = new NWindowbuttons(this);
        }

        public Form getWindow()
        {
            return this.window;
        }
        public void setThingsUp()
        {
            this.bgw.RunWorkerAsync();
            ColorConverter cc = new ColorConverter();
            this.window.FormBorderStyle = FormBorderStyle.None;

            this.window.BackColor = General.background();
            this.window.MouseDown += onMouseDown;
            this.window.MouseMove += onMouseMove;
            this.window.MouseUp += onMouseUp;
            this.window.Width = this.width;
            this.window.Height = 0;
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            this.window.Visible = true;
        }

        public bool loaded()
        {
            return _firstAniDone && _secondAniDone;
        }
        public void addControl(Control a)
        {
            this.window.Controls.Add(a);
        }
        private void FakeUpdater(object sender, EventArgs e)
        {
            while (true)
            {
                this.bgw.ReportProgress(1);
                System.Threading.Thread.Sleep(10);
            }
        }
        private void UI_updater(object sender, EventArgs e)
        {
            for (int b = this.window.Height; b < this.height; b++)
            {
                this.window.Height += 1;
            }
            if (this.window.Height == this.height)
            {
                this._firstAniDone = true;
            }
            if (_firstAniDone && !_secondAniDone)
            {
                for (int i = 0; i < 3; i++)
                {
                    if ((i % 2) == 0)
                    {
                        for (int i2 = 0; i2 < shakeValue; i2++)
                        {
                            this.window.Height++;
                            System.Threading.Thread.Sleep(30);
                        }
                    }
                    else
                    {
                        for (int i2 = 0; i2 < shakeValue; i2++)
                        {
                            this.window.Height--;
                            System.Threading.Thread.Sleep(30);
                        }
                    }
                }
                _secondAniDone = true;
                this.showButtons();
            }
        }
        public void onMouseMove(object sender, MouseEventArgs e)
        {
            if (this.drag && this.getWindow().Visible)
            {
                this.window.Left = System.Windows.Forms.Control.MousePosition.X - this.mouseX;
                this.window.Top = System.Windows.Forms.Control.MousePosition.Y - this.mouseY;
            }
        }
        public void onMouseUp(object sender, MouseEventArgs e)
        {
            this.drag = false;
        }
        public void onMouseDown(object sender, MouseEventArgs e)
        {
            this.mouseX = System.Windows.Forms.Control.MousePosition.X - this.window.Left;
            this.mouseY = System.Windows.Forms.Control.MousePosition.Y - this.window.Top;
            this.drag = true;
        }
    }
}
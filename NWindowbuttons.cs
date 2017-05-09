using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    class NWindowbuttons
    {

        private PictureBox CloseButton;
        private PictureBox MaxButton;
        private PictureBox MinButton;
        private NWindow main;

        public NWindowbuttons(NWindow A)
        {

            this.main = A;
            this.CloseButton = new PictureBox();
            int xxxx = (A.getWindow().Width - 15);
            CloseButton.SetBounds(xxxx - 5, 5, 16, 16);
            CloseButton.MouseClick += this.CloseButton_On_Click;
            CloseButton.MouseHover += this.CloseButton_On_Hover;
            CloseButton.MouseLeave += this.CloseButton_On_HoverExit;
            CloseButton.ImageLocation = "icons/close-normal.png";
            A.addControl(CloseButton);

            this.MaxButton = new PictureBox();
            MaxButton.SetBounds(xxxx - 26, 5, 16, 16);
            MaxButton.MouseClick += this.MaxButton_On_Click;
            MaxButton.MouseHover += this.MaxButton_On_Hover;
            MaxButton.MouseLeave += this.MaxButton_On_HoverExit;
            MaxButton.ImageLocation = "icons/max-normal.png";
            A.addControl(MaxButton);

            this.MinButton = new PictureBox();
            MinButton.SetBounds(xxxx - 47, 5, 16, 16);
            MinButton.MouseClick += this.MinButton_On_Click;
            MinButton.MouseHover += this.MinButton_On_Hover;
            MinButton.MouseLeave += this.MinButton_On_HoverExit;
            MinButton.ImageLocation = "icons/min-normal.png";
            A.addControl(MinButton);
        }

        public void CloseButton_On_Hover(object sender, EventArgs e)
        {
            this.CloseButton.ImageLocation = "icons/close-hover.png";
        }

        public void CloseButton_On_HoverExit(object sender, EventArgs e)
        {
            this.CloseButton.ImageLocation = "icons/close-normal.png";
        }

        public void CloseButton_On_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }





        public void MaxButton_On_Hover(object sender, EventArgs e)
        {
            this.MaxButton.ImageLocation = "icons/max-hover.png";
        }

        public void MaxButton_On_HoverExit(object sender, EventArgs e)
        {
            this.MaxButton.ImageLocation = "icons/max-normal.png";
        }

        public void MaxButton_On_Click(object sender, EventArgs e)
        {
        }




        public void MinButton_On_Hover(object sender, EventArgs e)
        {
            this.MinButton.ImageLocation = "icons/min-hover.png";
        }

        public void MinButton_On_HoverExit(object sender, EventArgs e)
        {
            this.MinButton.ImageLocation = "icons/min-normal.png";
        }

        public void MinButton_On_Click(object sender, EventArgs e)
        {
            this.main.getWindow().WindowState = FormWindowState.Minimized;
        }


    }
}

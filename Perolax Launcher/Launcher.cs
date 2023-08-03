using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace Perolax_Launcher
{
    public partial class Launcher : Form
    {
        #region Form
        public Launcher()
        {
            InitializeComponent();
        }
        #endregion


        #region FormControl
        private void button1_Click(object sender, EventArgs e)
        {
            Exit_Animation();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion


        #region MoveableForm
        //Since we have a borderless Form, we need to use something like a panel to be able to move our Form around the Screen
        private bool isDragging = false;
        private int x, y;

        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                x = e.X; y = e.Y;
            }
        }

        private void TopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point newLocation = this.Location;
                newLocation.X += e.X - x;
                newLocation.Y += e.Y - y;
                this.Location = newLocation;
            }
        }

        private void TopPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }
        #endregion


        #region Animations
        //I feel like animations are the "body-language" of a UI application.
        public void Exit_Animation() //Let's offer the user a straightforward "goodbye."
        {
            for(int i = 20; i != 0; i -= 1) //Because of inaccuracies, we'll need to later convert this to a double.
            {
                double opacityValue = (double)i / 20.0;
                this.Opacity = opacityValue; //A nice fading effect
                Thread.Sleep(10);
            }
            Application.Exit();
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientGUI
{
    public partial class StatsForm : Form
    {
        private const int MIN_X = 50,
                          MAX_X = 450,
                          MIN_Y = 70,
                          MAX_Y = 230;
        private const int ARROW_OFFSET = 10;
        private Point ORIGIN = new Point(MIN_X, MAX_Y),
                      X_AXIS_END = new Point(MAX_X, MAX_Y),
                      Y_AXIS_END = new Point(MIN_X, MIN_Y);

        public StatsForm()
        {
            InitializeComponent();
        }

        private void StatsForm_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            g.DrawLines(pen, new Point[] { Y_AXIS_END, ORIGIN, X_AXIS_END }); //draw graphic base
            g.DrawLines(pen, new Point[] { new Point(Y_AXIS_END.X-ARROW_OFFSET, Y_AXIS_END.Y+ARROW_OFFSET), Y_AXIS_END, new Point(Y_AXIS_END.X + ARROW_OFFSET, Y_AXIS_END.Y + ARROW_OFFSET) }); // draw Y arrow
            g.DrawLines(pen, new Point[] { new Point(X_AXIS_END.X-ARROW_OFFSET, X_AXIS_END.Y-ARROW_OFFSET), X_AXIS_END, new Point(X_AXIS_END.X - ARROW_OFFSET, X_AXIS_END.Y + ARROW_OFFSET) }); // draw X arrow
            
        }
    }
}

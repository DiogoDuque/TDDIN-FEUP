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
                          MIN_Y = 60,
                          MAX_Y = 230;
        private const int ARROW_OFFSET = 10;
        private Point ORIGIN = new Point(MIN_X, MAX_Y),
                      X_AXIS_END = new Point(MAX_X, MAX_Y),
                      Y_AXIS_END = new Point(MIN_X, MIN_Y);
        private const int MAX_X_QUOTE = MAX_X - 30;

        private List<float> quoteHistory;

        public StatsForm(List<float> quoteHistory)
        {
            InitializeComponent();
            this.quoteHistory = quoteHistory;
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

            //draw aux lines
            g.DrawLine(pen, quoteMeasure1.Location, new Point(MAX_X, quoteMeasure1.Location.Y));
            g.DrawLine(pen, quoteMeasure2.Location, new Point(MAX_X, quoteMeasure2.Location.Y));
            g.DrawLine(pen, quoteMeasure3.Location, new Point(MAX_X, quoteMeasure3.Location.Y));

            DrawLineGraph(g);
        }

        private void DrawLineGraph(Graphics g)
        {
            Brush interiorBrush = new SolidBrush(Color.FromArgb(200, 42, 55, 255));
            Pen pen = new Pen(new SolidBrush(Color.FromArgb(255, 23, 28, 255)),3);

            //find max quote for resizing
            float maxQuote = quoteHistory.Max();

            //set labels
            quoteMeasure3.Text = maxQuote.ToString("00.00");
            quoteMeasure2.Text = (maxQuote*2/3).ToString("00.00");
            quoteMeasure1.Text = (maxQuote/3).ToString("00.00");

            //draw quote history
            List<Point> quotes = new List<Point>();
            float index = 0;
            float nQuotes = quoteHistory.Count;
            float xTotalSpace = MAX_X_QUOTE - MIN_X;
            float yTotalSpace = MAX_Y - quoteMeasure3.Location.Y;
            foreach(float q in quoteHistory)
            {
                float x = MIN_X + index * (xTotalSpace / (nQuotes - 1));
                float y = MAX_Y - yTotalSpace*(q / maxQuote);

                quotes.Add(new Point((int)Math.Round(x), (int)Math.Round(y)));
                index++;
            }
            quotes.Add(new Point(MAX_X_QUOTE, MAX_Y));
            quotes.Add(ORIGIN);
            g.FillPolygon(interiorBrush, quotes.ToArray());
            g.DrawPolygon(pen, quotes.ToArray());

        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;

namespace ANALOG_CLOCK
{

    public partial class frmANALOG_CLOCK : Form
    {

        int  SecondHand, MinuteHand, HourHand, Clk_Radius;
        Point Clk_Center, PictureBox_Origin, Clock_Origin;
        Graphics graphics;
        Bitmap bitmap;

        private void frmANALOG_CLOCK_Load(object sStarter, EventArgs e)
        {
            InitializeClock();
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void timer1_Tick(object sStarter, EventArgs e)
        {
            graphics.Clear(Color.White);

            _DrawClock();
            _DrawHourNumbers();
            _DrawMinuteLines();
            _DrawMinuteNumbers();
            _DrawClockHands();
            Draw_Circle(8, new Pen(Color.Red, 18));

            pbClock.Image = bitmap;
        }

        void _DrawClock()
        {
            Pen pen = new Pen(Color.Brown, 25);
            Rectangle Rec = new Rectangle(Clock_Origin.X, Clock_Origin.Y, Clk_Radius * 2, Clk_Radius * 2);
            graphics.DrawArc(pen, Rec, 0, 360);
        }
        void _DrawClockHands()
        {
            double Second = DateTime.Now.Second;
            double Minute = DateTime.Now.Minute;
            double Hour = DateTime.Now.Hour;
            Hour += Minute / 60;
            double SecondAngle = Second * (360 / 60);
            SecondAngle += 270;
            Point SecondPoint = GetPoint(SecondAngle, SecondHand);
            graphics.DrawLine(new Pen(Color.Red, 3f), Clk_Center, SecondPoint);


            double MinuteAngle = Minute * (360 / 60);
            MinuteAngle += 270;
            Point MinutePoint = GetPoint(MinuteAngle, MinuteHand);
            graphics.DrawLine(new Pen(Color.Gray, 6f), Clk_Center, MinutePoint);

            double HourAngle = Hour * (360 / 12);
            HourAngle += 270;
            Point HourPoint = GetPoint(HourAngle, HourHand);
            graphics.DrawLine(new Pen(Color.Black, 8f), Clk_Center, HourPoint);

        }

        private void _DrawHourNumbers()
        {

            int HourNumbersRadius = 200;

            Pen pen1 = new Pen(Color.Red, 1);
            // Draw_Circle(HourNumbersRadius, pen1);

            double Angle = 270;

            for (int i = 12; i > 0; i--)
            {
                Point P = GetPoint(Angle, HourNumbersRadius);

                int FontSize = 25;
                Font font = new Font("Arial", FontSize, FontStyle.Bold);
                SolidBrush solidbrush = new SolidBrush(Color.Black);
                StringFormat stringformat = new StringFormat(StringFormatFlags.DirectionRightToLeft);

                switch (i)
                {
                    case 12:
                        P.X += 20;
                        P.Y += -18;
                        //Rectangle FontPlace = new Rectangle(P.X - (int)(FontSize * 1.5), P.Y + FontSize, FontSize, FontSize);

                        //graphics.DrawRectangle(pen1, FontPlace);
                        break;
                    case 11:
                        // FontPlace = new Rectangle(P.X - (int)(FontSize*0.6), P.Y - (int)(FontSize *0.6), FontSize, FontSize);

                        //graphics.DrawRectangle(pen1, FontPlace);
                        P.X += 20;
                        P.Y += -20/*20*/;
                        break;
                    case 10:
                        P.X += 15;
                        P.Y += -20;
                        break;
                    case 9:
                        P.X += 15;
                        P.Y += -20;
                        break;
                    case 8:
                        P.X += 15;
                        P.Y += -20;
                        break;
                    case 7:
                        P.X += 18;
                        P.Y += -15;
                        break;


                    case 1:
                        P.X += 15;
                        P.Y += -18;
                        break;
                    case 2:
                        P.X += 15;
                        P.Y += -20;
                        break;
                    case 3:
                        P.X += 15;
                        P.Y += -18;
                        break;
                    case 4:
                        P.X += 15;
                        P.Y += -20;
                        break;
                    case 5:
                        P.X += 15;
                        P.Y += -18;
                        break;
                    case 6:
                        P.X += 15;
                        P.Y += -18;
                        break;

                }

                graphics.DrawString(i.ToString(), font, solidbrush, P.X, P.Y, stringformat);

                Angle -= 30;

            }
        }
        private void _DrawMinuteLines()
        {
            int Start = 150;
            int End = 175;

            Pen p = new Pen(Color.Brown, 1);
            //Draw_Circle(End, p);
            //Draw_Circle(Start, p);
            double angle = 0;
            for (int i = 0; i < 60; i++)
            {
                angle = (360 / 60) * i;
                angle += 270;

                Point P1 = GetPoint(angle, End);
                Point P2 = GetPoint(angle, Start);

                Pen MyPen = new Pen(Color.Black, 1);

                if (i % 5 > 0) MyPen.Width = 1;
                else MyPen.Width = 5;

                graphics.DrawLine(MyPen, P2, P1);
            }

        }

        private void _DrawMinuteNumbers()
        {
            int MinuteNumbersRadius = 125;
            Pen pen1 = new Pen(Color.Red, 1);
            // Draw_Circle(MinuteNumbersRadius, pen1);

            double Angle = 270;
            for (int i = 0; i < 12; i++)
            {
                Point P = GetPoint(Angle, MinuteNumbersRadius);

                switch (i * 5)
                {
                    case 0:
                        P.X += 10;
                        P.Y += -18;
                        break;
                    case 5:
                        P.X += 15;
                        P.Y += -15;
                        break;
                    case 10:
                        P.X += 15;
                        P.Y += -15;
                        break;
                    case 15:
                        P.X += 20;
                        P.Y += -10;
                        break;
                    case 20:
                        P.X += 20;
                        P.Y += -5;
                        break;
                    case 25:
                        P.X += 20;
                        P.Y += -5;
                        break;
                    case 30:
                        P.X += 15;
                        P.Y += -3;
                        break;
                    case 35:
                        P.X += 10;
                        P.Y += -5;
                        break;
                    case 40:
                        P.X += 10;
                        P.Y += -8;
                        break;
                    case 45:
                        P.X += 10;
                        P.Y += -10;
                        break;
                    case 50:
                        P.X += 10;
                        P.Y += -15;
                        break;
                    case 55:
                        P.X += 10;
                        P.Y += -15;
                        break;
                    default:
                        P.X += 10;
                        P.Y += -10;
                        break;
                }


                Font font = new Font("Arial", 15, FontStyle.Bold);
                SolidBrush solidbrush = new SolidBrush(Color.Black);
                StringFormat stringformat = new StringFormat(StringFormatFlags.DirectionRightToLeft);

                graphics.DrawString((i * 5).ToString(), font, solidbrush, P.X, P.Y, stringformat);

                Angle += 30;
            }


        }

        public frmANALOG_CLOCK()
        {
            InitializeComponent();
            InitializeClock();


        }
        void InitializeClock()
        {
            Clk_Radius = 250;
            PictureBox_Origin = new Point(10, 10);
            pbClock.Location = PictureBox_Origin;
            pbClock.Width = 3 * Clk_Radius;
            pbClock.Height = 3 * Clk_Radius;

            Clock_Origin = new Point(pbClock.Location.X + (int)(Clk_Radius / 5), pbClock.Location.Y + (int)(Clk_Radius / 5));

            bitmap = new Bitmap((int)(2.5 * Clk_Radius), (int)(2.5 * Clk_Radius));
            graphics = Graphics.FromImage(bitmap);
            Clk_Center = new Point(bitmap.Width / 2, bitmap.Width / 2);
            SecondHand = (int)(Clk_Radius * 0.8);
            MinuteHand = (int)(Clk_Radius * 0.7);
            HourHand = (int)(Clk_Radius * 0.5);
        }

        private void Draw_Circle(int Radius, Pen pen)
        {
            Rectangle rect = new Rectangle(Clock_Origin.X + Clk_Radius - Radius, Clock_Origin.Y + Clk_Radius - Radius, Radius * 2, Radius * 2);
            graphics.DrawArc(pen, rect, 0, 360);
        }


        Point GetPoint(double Angle, int Radius)
        {
            Point point = new Point(0, 0);

            point.X = Clock_Origin.X + Clk_Radius + (int)(Radius * Math.Cos(Math.PI * Angle / 180));
            point.Y = Clock_Origin.Y + Clk_Radius + (int)(Radius * Math.Sin(Math.PI * Angle / 180));

            return point;
        }
    }
}

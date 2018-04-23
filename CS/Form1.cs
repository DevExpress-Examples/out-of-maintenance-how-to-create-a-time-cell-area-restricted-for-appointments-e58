using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler.Drawing;
using DevExpress.XtraScheduler;

namespace WindowsApplication1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            schedulerControl1.DayView.TopRowTime = new TimeSpan(10, 0, 0);
        }
        private void schedulerControl1_CustomDrawTimeCell(object sender, DevExpress.XtraScheduler.CustomDrawObjectEventArgs e) {
            if(e.ObjectInfo is TimeCell) {
                TimeCell tc = e.ObjectInfo as TimeCell;
                if(tc.Interval.Start.Hour  >= 12 && tc.Interval.Start.Hour < 14) {
                    tc.Appearance.BackColor = Color.LightBlue;
                }
            }
        }

        private void schedulerControl1_AllowAppointmentConflicts(object sender, DevExpress.XtraScheduler.AppointmentConflictEventArgs e) {
            if ((e.Interval.Start.Hour >=  12 && e.Interval.Start.Hour  < 14) || ((e.Interval.End.Hour > 12 || (e.Interval.End.Hour == 12 && e.Interval.End.Minute != 0))&& e.Interval.End.Hour < 14) || (e.Interval.Start.Hour <= 12 && e.Interval.End.Hour >= 14))
            {
                e.Conflicts.Add(e.AppointmentClone); 
            }
        }


        SolidBrush msb = new SolidBrush(Color.FromArgb(90, 50, 50, 50));
        
        private void schedulerControl1_Paint(object sender, PaintEventArgs e) {
            Rectangle rect = Rectangle.Empty;
            if(schedulerControl1.ActiveView is DayView) {
                foreach(DayViewColumn column in ((DayViewInfo)schedulerControl1.ActiveView.ViewInfo).Columns) {
                    for(int i = 0; i < column.Cells.Count; i++) {
                        TimeCell tc = column.Cells[i] as TimeCell;
                        if(tc.Interval.Start.Hour >= 12 && tc.Interval.Start.Hour <= 13) {
                            if(rect == Rectangle.Empty)
                                rect = tc.Bounds;
                            else
                                rect = Rectangle.Union(rect, tc.Bounds);
                        }
                    }
                }
                if(rect != Rectangle.Empty)
                    using(Font f = new Font("Arial", rect.Height-4, GraphicsUnit.Pixel))
                        e.Graphics.DrawString("Lunch Time", f, msb, new PointF(rect.X + rect.Width / 2 - f.Size*3, rect.Y + rect.Height / 2 - f.Size / 2));
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            Resource res1 = new Resource(1, "John");
            Resource res2 = new Resource(2, "Jane");
            Resource res3 = new Resource(3, "Bob");
            this.schedulerStorage1.Resources.AddRange(new Resource[] { res1, res2, res3 });

        }
      
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler.Drawing;
using DevExpress.XtraScheduler;
using DXApplication1;
using DevExpress.Utils.Svg;

namespace WindowsApplication1 {
    public partial class Form1 : Form {

        BindingList<CustomResource> CustomResourceCollection = new BindingList<CustomResource>();
        BindingList<CustomAppointment> CustomEventList = new BindingList<CustomAppointment>();
       
        public Form1() {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            schedulerControl1.CustomDrawTimeRegion += SchedulerControl1_CustomDrawTimeRegion;
            schedulerControl1.TimeRegionCustomize += SchedulerControl1_TimeRegionCustomize;
        }

        private void SchedulerControl1_TimeRegionCustomize(object sender, TimeRegionCustomizeEventArgs e) {
            if(e.Interval.Start == DateTime.Now.AddDays(5))
                e.Editable = true;
        }

        private void SchedulerControl1_CustomDrawTimeRegion(object sender, CustomDrawTimeRegionEventArgs e) {
            if(e.TimeRegion != schedulerControl1.TimeRegions[0])
                return;
            e.DrawDefault();
            Rectangle bounds = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
            double scaleFactor = bounds.Height / svgImageCollection1[0].Height;
            Image img= svgImageCollection1[0].Render(null, Math.Min(scaleFactor, 1));
            int x = e.Bounds.Location.X + (e.Bounds.Width / 2 - img.Width / 2);
            int y = e.Bounds.Location.Y + (e.Bounds.Height / 2 - img.Height / 2);
            e.Cache.DrawImage(img, new Point(x, y));
            e.Handled = true;
        }

        private void Form1_Load(object sender, EventArgs e) {
            InitHelper.InitResources(CustomResourceCollection);
            InitHelper.InitAppointments(CustomEventList, CustomResourceCollection);

            ResourceMappingInfo mappingsResource = this.schedulerDataStorage1.Resources.Mappings;
            mappingsResource.Id = "ResID";
            mappingsResource.Caption = "Name";

            AppointmentMappingInfo mappingsAppointment = this.schedulerDataStorage1.Appointments.Mappings;
            mappingsAppointment.Start = "StartTime";
            mappingsAppointment.End = "EndTime";
            mappingsAppointment.Subject = "Subject";
            mappingsAppointment.AllDay = "AllDay";
            mappingsAppointment.Description = "Description";
            mappingsAppointment.Label = "Label";
            mappingsAppointment.Location = "Location";
            mappingsAppointment.RecurrenceInfo = "RecurrenceInfo";
            mappingsAppointment.ReminderInfo = "ReminderInfo";
            mappingsAppointment.ResourceId = "OwnerId";
            mappingsAppointment.Status = "Status";
            mappingsAppointment.Type = "EventType";

            schedulerDataStorage1.Resources.DataSource = CustomResourceCollection;
            schedulerDataStorage1.Appointments.DataSource = CustomEventList;

            schedulerControl1.GroupType = SchedulerGroupType.Resource;
            schedulerControl1.OptionsView.HighlightTodayDate = DevExpress.Utils.DefaultBoolean.False;

            CreateTimeRegion();

            schedulerControl1.Start = DateTime.Now;
        }

        private void CreateTimeRegion() {
            DateTime baseDate = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
            baseDate = baseDate.AddDays(-15);
            
            TimeRegion timeRegion1 = new TimeRegion();
            timeRegion1.Start = baseDate.AddHours(13);
            timeRegion1.End = baseDate.AddHours(14);
            timeRegion1.Editable = false;
            timeRegion1.Recurrence = new RecurrenceInfo();
            timeRegion1.Recurrence.Start = timeRegion1.Start;
            timeRegion1.Recurrence.Type = RecurrenceType.Weekly;
            timeRegion1.Recurrence.WeekDays = WeekDays.WorkDays;
            timeRegion1.ResourceIds.Add(schedulerDataStorage1.Resources[0].Id);
            timeRegion1.ResourceIds.Add(schedulerDataStorage1.Resources[1].Id);


            schedulerControl1.TimeRegions.Add(timeRegion1);
        }
    }
}
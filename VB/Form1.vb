Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraScheduler.Drawing
Imports DevExpress.XtraScheduler
Imports DevExpress.Utils.Svg

Namespace WindowsApplication1
    Partial Public Class Form1
        Inherits Form

        Private CustomResourceCollection As New BindingList(Of CustomResource)()
        Private CustomEventList As New BindingList(Of CustomAppointment)()

        Public Sub New()
            InitializeComponent()
            Me.WindowState = FormWindowState.Maximized
            AddHandler schedulerControl1.CustomDrawTimeRegion, AddressOf SchedulerControl1_CustomDrawTimeRegion
            AddHandler schedulerControl1.TimeRegionCustomize, AddressOf SchedulerControl1_TimeRegionCustomize
        End Sub

        Private Sub SchedulerControl1_TimeRegionCustomize(ByVal sender As Object, ByVal e As TimeRegionCustomizeEventArgs)
            If e.Interval.Start = Date.Now.AddDays(5) Then
                e.Editable = True
            End If
        End Sub

        Private Sub SchedulerControl1_CustomDrawTimeRegion(ByVal sender As Object, ByVal e As CustomDrawTimeRegionEventArgs)
            If e.TimeRegion IsNot schedulerControl1.TimeRegions(0) Then
                Return
            End If
            e.DrawDefault()
            'INSTANT VB NOTE: The variable bounds was renamed since Visual Basic does not handle local variables named the same as class members well:
            Dim bounds_Renamed As New Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height)
            Dim scaleFactor As Double = bounds_Renamed.Height \ svgImageCollection1(0).Height
            Dim img As Image = svgImageCollection1(0).Render(Nothing, Math.Min(scaleFactor, 1))
            Dim x As Integer = e.Bounds.Location.X + (e.Bounds.Width \ 2 - img.Width \ 2)
            Dim y As Integer = e.Bounds.Location.Y + (e.Bounds.Height \ 2 - img.Height \ 2)
            e.Cache.DrawImage(img, New Point(x, y))
            e.Handled = True
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            InitHelper.InitResources(CustomResourceCollection)
            InitHelper.InitAppointments(CustomEventList, CustomResourceCollection)

            Dim mappingsResource As ResourceMappingInfo = Me.schedulerDataStorage1.Resources.Mappings
            mappingsResource.Id = "ResID"
            mappingsResource.Caption = "Name"

            Dim mappingsAppointment As AppointmentMappingInfo = Me.schedulerDataStorage1.Appointments.Mappings
            mappingsAppointment.Start = "StartTime"
            mappingsAppointment.End = "EndTime"
            mappingsAppointment.Subject = "Subject"
            mappingsAppointment.AllDay = "AllDay"
            mappingsAppointment.Description = "Description"
            mappingsAppointment.Label = "Label"
            mappingsAppointment.Location = "Location"
            mappingsAppointment.RecurrenceInfo = "RecurrenceInfo"
            mappingsAppointment.ReminderInfo = "ReminderInfo"
            mappingsAppointment.ResourceId = "OwnerId"
            mappingsAppointment.Status = "Status"
            mappingsAppointment.Type = "EventType"

            schedulerDataStorage1.Resources.DataSource = CustomResourceCollection
            schedulerDataStorage1.Appointments.DataSource = CustomEventList

            schedulerControl1.GroupType = SchedulerGroupType.Resource

            CreateTimeRegion()

            schedulerControl1.Start = Date.Now
        End Sub

        Private Sub CreateTimeRegion()
            Dim baseDate As Date = Date.Today.AddDays(-CInt(Date.Today.DayOfWeek) + CInt(DayOfWeek.Monday))
            baseDate = baseDate.AddDays(-15)

            Dim timeRegion1 As New TimeRegion()
            timeRegion1.Start = baseDate.AddHours(13)
            timeRegion1.End = baseDate.AddHours(14)
            timeRegion1.Editable = False
            timeRegion1.Recurrence = New RecurrenceInfo()
            timeRegion1.Recurrence.Start = timeRegion1.Start
            timeRegion1.Recurrence.Type = RecurrenceType.Weekly
            timeRegion1.Recurrence.WeekDays = WeekDays.WorkDays
            timeRegion1.ResourceIds.Add(schedulerDataStorage1.Resources(0).Id)
            timeRegion1.ResourceIds.Add(schedulerDataStorage1.Resources(1).Id)


            schedulerControl1.TimeRegions.Add(timeRegion1)
        End Sub
    End Class
End Namespace
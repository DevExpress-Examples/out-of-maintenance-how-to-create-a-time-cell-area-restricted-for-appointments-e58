Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraScheduler.Drawing
Imports DevExpress.XtraScheduler

Namespace WindowsApplication1
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
            schedulerControl1.DayView.TopRowTime = New TimeSpan(10, 0, 0)
        End Sub
        Private Sub schedulerControl1_AllowAppointmentConflicts(ByVal sender As Object, ByVal e As DevExpress.XtraScheduler.AppointmentConflictEventArgs) Handles schedulerControl1.AllowAppointmentConflicts
            Dim interval As TimeInterval = e.Interval
            If Not IsIntervalAllowed(interval) Then
                e.Conflicts.Add(e.AppointmentClone)
            End If
        End Sub
        Private Sub schedulerControl1_AllowAppointmentCreate(ByVal sender As Object, ByVal e As AppointmentOperationEventArgs) Handles schedulerControl1.AllowAppointmentCreate
            e.Allow = IsIntervalAllowed(schedulerControl1.ActiveView.SelectedInterval)
        End Sub
        Private Function IsIntervalAllowed(ByVal interval As TimeInterval) As Boolean
            Dim dayStart As Date = interval.Start.Date
            Do While dayStart < interval.End
                If Not IsIntervalAllowed(interval, dayStart) Then
                    Return False
                End If
                dayStart = dayStart.AddDays(1)
            Loop
            Return True
        End Function
        Private Function IsIntervalAllowed(ByVal interval As TimeInterval, ByVal dayStart As Date) As Boolean
            Dim lunchTime As New TimeInterval(dayStart.AddHours(12), dayStart.AddHours(14))
            Return Not interval.IntersectsWithExcludingBounds(lunchTime)
        End Function


        Private Sub schedulerControl1_CustomDrawTimeCell(ByVal sender As Object, ByVal e As DevExpress.XtraScheduler.CustomDrawObjectEventArgs) Handles schedulerControl1.CustomDrawTimeCell
            If TypeOf e.ObjectInfo Is TimeCell Then
                Dim tc As TimeCell = TryCast(e.ObjectInfo, TimeCell)
                If tc.Interval.Start.Hour >= 12 AndAlso tc.Interval.Start.Hour < 14 Then
                    tc.Appearance.BackColor = Color.LightBlue
                End If
            End If
        End Sub


        '                
        Private msb As New SolidBrush(Color.FromArgb(90, 50, 50, 50))

        Private Sub schedulerControl1_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles schedulerControl1.Paint
            Dim rect As Rectangle = Rectangle.Empty
            If TypeOf schedulerControl1.ActiveView Is DayView Then
                For Each column As DayViewColumn In CType(schedulerControl1.ActiveView.ViewInfo, DayViewInfo).Columns
                    For i As Integer = 0 To column.Cells.Count - 1
                        Dim tc As TimeCell = TryCast(column.Cells(i), TimeCell)
                        If tc.Interval.Start.Hour >= 12 AndAlso tc.Interval.Start.Hour <= 13 Then
                            If rect = Rectangle.Empty Then
                                rect = tc.Bounds
                            Else
                                rect = Rectangle.Union(rect, tc.Bounds)
                            End If
                        End If
                    Next i
                Next column
                If rect <> Rectangle.Empty Then
                    Using f As New Font("Arial", rect.Height-4, GraphicsUnit.Pixel)
                        e.Graphics.DrawString("Lunch Time", f, msb, New PointF(rect.X + rect.Width \ 2 - f.Size*3, rect.Y + rect.Height \ 2 - f.Size / 2))
                    End Using
                End If
            End If
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            Dim res1 As Resource = schedulerStorage1.CreateResource(1, "John")
            Dim res2 As Resource = schedulerStorage1.CreateResource(2, "Jane")
            Dim res3 As Resource = schedulerStorage1.CreateResource(3, "Bob")
            Me.schedulerStorage1.Resources.AddRange(New Resource() { res1, res2, res3 })

        End Sub
    End Class
End Namespace
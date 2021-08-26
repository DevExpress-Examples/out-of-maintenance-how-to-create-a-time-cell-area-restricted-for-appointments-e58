Imports System
Imports System.ComponentModel
Imports System.Drawing

Namespace DXApplication1
	Public Class InitHelper
		Public Shared RandomInstance As New Random()

		Public Shared Sub InitResources(ByVal resources As BindingList(Of CustomResource))
			resources.Add(CreateCustomResource(1, "Peter Dolan", Color.PowderBlue))
			resources.Add(CreateCustomResource(2, "Ryan Fisher", Color.PaleVioletRed))
			resources.Add(CreateCustomResource(3, "Andrew Miller", Color.PeachPuff))
		End Sub

		Public Shared Function CreateCustomResource(ByVal res_id As Integer, ByVal caption As String, ByVal ResColor As Color) As CustomResource
			Dim cr As New CustomResource()
			cr.ResID = res_id
			cr.Name = caption
			Return cr
		End Function

		Public Shared Sub InitAppointments(ByVal appointments As BindingList(Of CustomAppointment), ByVal resources As BindingList(Of CustomResource))
			GenerateEvents(appointments, resources)
		End Sub


		Public Shared Sub GenerateEvents(ByVal eventList As BindingList(Of CustomAppointment), ByVal resources As BindingList(Of CustomResource))
			Dim count As Integer = 2

			For i As Integer = 0 To count - 1
				Dim resource As CustomResource = resources(i)
				Dim subjPrefix As String = resource.Name & "'s "
				eventList.Add(CreateEvent(subjPrefix & "meeting", resource.ResID, 2, 5))
				eventList.Add(CreateEvent(subjPrefix & "travel", resource.ResID, 3, 6))
				eventList.Add(CreateEvent(subjPrefix & "special", resource.ResID, 0, 10))
			Next i
		End Sub
		Public Shared Function CreateEvent(ByVal subject As String, ByVal resourceId As Object, ByVal status As Integer, ByVal label As Integer) As CustomAppointment
			Dim apt As New CustomAppointment()
			apt.Subject = subject
			apt.OwnerId = resourceId
			Dim rnd As Random = RandomInstance
			apt.StartTime = Date.Today.Add(TimeSpan.FromHours(9))
			apt.EndTime = apt.StartTime.Add(TimeSpan.FromHours(1))
			apt.Status = status
			apt.Label = label
			apt.Description = If(rnd.Next() Mod 3 = 0, "Sample description", String.Empty)
			Return apt
		End Function

		Public Shared Sub InitLabels(ByVal labels As BindingList(Of CustomLabel))
			For i As Integer = 0 To 14
			labels.Add(CreateCustomLabel(i))
			Next i
		End Sub

		Private Shared Function CreateCustomLabel(ByVal id As Integer) As CustomLabel
			Dim label As New CustomLabel()
			label.ID = id
			label.Name = "Name" & id
			Dim rnd As Random = RandomInstance
			label.ColorLabel = Color.FromArgb(rnd.Next())
			Return label
		End Function

		Public Shared Sub InitStatus(ByVal listStatus As BindingList(Of CustomStatus))
			For i As Integer = 0 To 14
				listStatus.Add(CreateCustomStatus(i))
			Next i
		End Sub

		Private Shared Function CreateCustomStatus(ByVal id As Integer) As CustomStatus
			Dim status As New CustomStatus()
			status.ID = id
			status.Name = "Status" & id
			Dim rnd As Random = RandomInstance
			' status.ColorStatus = new SolidBrush(Color.FromArgb(rnd.Next()));
			status.ColorStatus = Color.FromArgb(rnd.Next())
			Return status
		End Function
	End Class
End Namespace

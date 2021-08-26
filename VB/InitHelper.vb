Imports System
Imports System.ComponentModel
Imports System.Drawing

Namespace WindowsApplication1
	Public Class InitHelper
		Public Shared RandomInstance As New Random()

'INSTANT VB NOTE: The parameter resources was renamed since it may cause conflicts with calls to static members of the user-defined type with this name:
		Public Shared Sub InitResources(ByVal resources_Conflict As BindingList(Of CustomResource))
			resources_Conflict.Add(CreateCustomResource(1, "Peter Dolan", Color.PowderBlue))
			resources_Conflict.Add(CreateCustomResource(2, "Ryan Fisher", Color.PaleVioletRed))
			resources_Conflict.Add(CreateCustomResource(3, "Andrew Miller", Color.PeachPuff))
		End Sub

		Public Shared Function CreateCustomResource(ByVal res_id As Integer, ByVal caption As String, ByVal ResColor As Color) As CustomResource
			Dim cr As New CustomResource()
			cr.ResID = res_id
			cr.Name = caption
			Return cr
		End Function

'INSTANT VB NOTE: The parameter resources was renamed since it may cause conflicts with calls to static members of the user-defined type with this name:
		Public Shared Sub InitAppointments(ByVal appointments As BindingList(Of CustomAppointment), ByVal resources_Conflict As BindingList(Of CustomResource))
			GenerateEvents(appointments, resources_Conflict)
		End Sub


'INSTANT VB NOTE: The parameter resources was renamed since it may cause conflicts with calls to static members of the user-defined type with this name:
		Public Shared Sub GenerateEvents(ByVal eventList As BindingList(Of CustomAppointment), ByVal resources_Conflict As BindingList(Of CustomResource))
			Dim count As Integer = 2

			For i As Integer = 0 To count - 1
				Dim resource As CustomResource = resources_Conflict(i)
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
			apt.StartTime = DateTime.Today.Add(TimeSpan.FromHours(9))
			apt.EndTime = apt.StartTime.Add(TimeSpan.FromHours(1))
			apt.Status = status
			apt.Label = label
			apt.Description = If(rnd.Next() Mod 3 = 0, "Sample description", String.Empty)
			Return apt
		End Function
	End Class
End Namespace
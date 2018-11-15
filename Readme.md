<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))
* [Program.cs](./CS/Program.cs) (VB: [Program.vb](./VB/Program.vb))
<!-- default file list end -->
# How to create a time cell area restricted for appointments


<p>Problem:</p><p>How can I implement a restricted ( or "no-drop") area for appointments? It should be colored differently and labeled. End-users are prohibited from creating appointments within this area, and dragging an appointment into this time interval is not allowed.</p><p>Solution:</p><p>The task can be accomplished by proper handling of several events: the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraSchedulerSchedulerControl_AllowAppointmentConflictstopic"><u>AllowAppointmentConflicts</u></a><u> </u>event and  the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraSchedulerSchedulerControl_AllowAppointmentCreatetopic"><u>AllowAppointmentCreate</u></a> event.</p>


<h3>Description</h3>

<p>The <strong>CustomDrawTimeCell</strong> event is used to check the <strong>TimeCell.Interval</strong> and change the<strong> TimeCell.Appearance.BackColor</strong> if the cell falls within a restricted area. <br />
The <strong>Paint</strong> event handler creates a rectangle which encompasses the restricted time cells and uses the Graphics.DrawString method to write a text within that rectangle. <br />
The <strong>AllowAppointmentConflicts</strong> handler raises conflict for an appointment that intersects with the restricted area.</p>

<br/>



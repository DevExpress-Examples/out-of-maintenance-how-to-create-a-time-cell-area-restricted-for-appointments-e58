<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128634124/15.2.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E58)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))
<!-- default file list end -->
# How to create a time cell area restricted for appointments


<p>Problem:</p><p>How can I implement a restricted ( or "no-drop") area for appointments? It should be colored differently and labeled. End-users are prohibited from creating appointments within this area, and dragging an appointment into this time interval is not allowed.</p><p>Solution:</p><p>The task can be accomplished by proper handling of several events: the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraSchedulerSchedulerControl_AllowAppointmentConflictstopic"><u>AllowAppointmentConflicts</u></a><u> </u>event and  the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraSchedulerSchedulerControl_AllowAppointmentCreatetopic"><u>AllowAppointmentCreate</u></a> event.</p>

<br/>



# How to create a time cell area restricted for appointments


<p></p><p>In <b>v.19.1</b> and later versions, <a href="https://docs.devexpress.com/WindowsForms/DevExpress.XtraScheduler.TimeRegion"><u>time regions </u></a><u> </u> can be used to implement a restricted ( or "no-drop") area. End-users cannot create appointments within this area and dragging an appointment into this time interval is not allowed.

</p><p>To assign this area for the two resources only, you need to add their identifiers to the <a href="https://docs.devexpress.com/WindowsForms/DevExpress.XtraScheduler.TimeRegion.ResourceIds">TimeRegion.ResourceIds</a> property. </p>
<p>Also, the <a href="https://docs.devexpress.com/WindowsForms/DevExpress.XtraScheduler.SchedulerControl.CustomDrawTimeRegion">SchedulerControl.CustomDrawTimeRegion</a> event is used to adjust the time region's appearance. If you need to override the region behavior, handle the <a href="https://docs.devexpress.com/WindowsForms/DevExpress.XtraScheduler.SchedulerControl.TimeRegionCustomize">SchedulerControl.TimeRegionCustomize</a> event.</p>

<br/>


<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E58)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# How to create a time cell area restricted for appointments


<p></p><p>Since<b>v.19.1</b> <a href="https://docs.devexpress.com/WindowsForms/DevExpress.XtraScheduler.TimeRegion"><u>time regions </u></a><u> </u> can be used to implement a restricted ( or "no-drop") area. End-users are prohibited from creating appointments within this area, and dragging an appointment into this time interval is not allowed.</p><p>To assign this area for only the two resources, it is necessary to add their identifiers to the <a href="https://docs.devexpress.com/WindowsForms/DevExpress.XtraScheduler.TimeRegion.ResourceIds">TimeRegion.ResourceIds</a> property</p><p>Also, the <a href="https://docs.devexpress.com/WindowsForms/DevExpress.XtraScheduler.SchedulerControl.CustomDrawTimeRegion">SchedulerControl.CustomDrawTimeRegion</a> event is used to adjust the time region appearance. If you need to override the region behavior, handle the <a href="https://docs.devexpress.com/WindowsForms/DevExpress.XtraScheduler.SchedulerControl.TimeRegionCustomize">SchedulerControl.TimeRegionCustomize</a> event.</p>

<br/>


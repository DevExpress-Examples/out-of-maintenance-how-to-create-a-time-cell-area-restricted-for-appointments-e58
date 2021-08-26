﻿using System;
using System.ComponentModel;
using System.Drawing;

namespace DXApplication1 {
    public class InitHelper {
        public static Random RandomInstance = new Random();

        public static void InitResources(BindingList<CustomResource> resources) {
            resources.Add(CreateCustomResource(1, "Peter Dolan", Color.PowderBlue));
            resources.Add(CreateCustomResource(2, "Ryan Fisher", Color.PaleVioletRed));
            resources.Add(CreateCustomResource(3, "Andrew Miller", Color.PeachPuff));
        }

        public static CustomResource CreateCustomResource(int res_id, string caption, Color ResColor) {
            CustomResource cr = new CustomResource();
            cr.ResID = res_id;
            cr.Name = caption;
            return cr;
        }
        
        public static void InitAppointments(BindingList<CustomAppointment> appointments, BindingList<CustomResource> resources) {
            GenerateEvents(appointments, resources);
        }


        public static void GenerateEvents(BindingList<CustomAppointment> eventList, BindingList<CustomResource> resources) {
            int count = 2;

            for(int i = 0; i < count; i++) {
                CustomResource resource = resources[i];
                string subjPrefix = resource.Name + "'s ";
                eventList.Add(CreateEvent(subjPrefix + "meeting", resource.ResID, 2, 5));
                eventList.Add(CreateEvent(subjPrefix + "travel", resource.ResID, 3, 6));
                eventList.Add(CreateEvent(subjPrefix + "special", resource.ResID, 0, 10));
            }
        }
        public static CustomAppointment CreateEvent(string subject, object resourceId, int status, int label) {
            CustomAppointment apt = new CustomAppointment();
            apt.Subject = subject;
            apt.OwnerId = resourceId;
            Random rnd = RandomInstance;
            apt.StartTime = DateTime.Today + TimeSpan.FromHours(9);
            apt.EndTime = apt.StartTime + TimeSpan.FromHours(1);
            apt.Status = status;
            apt.Label = label;
            apt.Description = (rnd.Next() % 3 == 0) ? "Sample description" : String.Empty;
            return apt;
        }

        public static void InitLabels(BindingList<CustomLabel> labels) {
            for(int i=0;i<15;i++)
            labels.Add(CreateCustomLabel(i));
        }

        private static CustomLabel CreateCustomLabel(int id) {
            CustomLabel label = new CustomLabel();
            label.ID = id;
            label.Name = "Name" + id;
            Random rnd = RandomInstance;
            label.ColorLabel = Color.FromArgb(rnd.Next());
            return label;
        }

        public static void InitStatus(BindingList<CustomStatus> listStatus) {
            for(int i = 0; i < 15; i++)
                listStatus.Add(CreateCustomStatus(i));
        }

        private static CustomStatus CreateCustomStatus(int id) {
            CustomStatus status = new CustomStatus();
            status.ID = id;
            status.Name = "Status" + id;
            Random rnd = RandomInstance;
            // status.ColorStatus = new SolidBrush(Color.FromArgb(rnd.Next()));
            status.ColorStatus = Color.FromArgb(rnd.Next());
            return status;
        }
    }
}

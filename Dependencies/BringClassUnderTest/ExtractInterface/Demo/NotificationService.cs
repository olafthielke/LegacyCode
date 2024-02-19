﻿namespace Dependencies.BringClassUnderTest.ExtractInterface.Demo
{
    public class NotificationService
    {
        private MessageStore Notifications { get; set; }


        public NotificationService()
        {
            Notifications = new MessageStore();

            Notifications.Init("active", 4);
        }
    }
}

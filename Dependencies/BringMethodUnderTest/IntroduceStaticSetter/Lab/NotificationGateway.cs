﻿namespace Dependencies.BringMethodUnderTest.IntroduceStaticSetter.Lab
{
    public class NotificationGateway
    {
        public void Notify(Notification notification)
        {
            // ...

            var notifier = NotifierSingleton.GetInstance();
            var sender = notifier.GetSender();

            if (sender != null)
            {
                sender.Send(notification);
            }

            // ...
        }
    }
}

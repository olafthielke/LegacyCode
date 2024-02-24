using System;
using System.Diagnostics;

namespace Dependencies.BringClassUnderTest.ExtractInterface.Demo
{
    public class NotificationService
    {
        private MessageStore Notifications { get; set; }

        public NotificationService()
        {
            Notifications = new MessageStore();

            Notifications.Init("active", 4);
        }


        /// <summary>
        /// Processes and sends out pending notifications based on a set of complex, legacy rules.
        /// </summary>
        /// <param name="forceSend">Forces the sending of notifications even if conditions are not fully met.</param>
        public void ProcessPendingNotifications(bool forceSend)
        {
            try
            {
                var pendingNotifications = Notifications.GetMessages("pending");

                if (pendingNotifications == null || pendingNotifications.Count == 0)
                {
                    Log("No pending notifications to process.");
                    return;
                }

                foreach (var notification in pendingNotifications)
                {
                    // TODO: Also skip on Fridays unless forced.
                    if (notification.CreationDate.DayOfWeek == DayOfWeek.Tuesday && !forceSend)
                    {
                        Log($"Skipping notification {notification.Id} on Tuesdays (unless it's forced).");
                        continue;
                    }

                    if (notification.Priority > 3 || forceSend)
                    {
                        bool sent = SendNotification(notification);
                        if (sent)
                        {
                            Log($"Notification {notification.Id} sent successfully.");
                            Notifications.UpdateStatus(notification.Id, "sent");
                        }
                        else
                        {
                            Log($"Failed to send notification {notification.Id}. Retrying...");
                            // Implement retry logic here, simplified for this example
                        }
                    }
                    else
                    {
                        Log($"Notification {notification.Id} skipped due to low priority.");
                    }
                }
            }
            catch (Exception ex)
            {
                Log($"An error occurred while processing notifications: {ex.Message}");
                // Possibly rethrow, handle error, or log it.
            }
        }

        private bool SendNotification(Message notification)
        {
            // ... Send messages
            
            return true; 
        }

        private void Log(string message)
        {
            Trace.WriteLine(message);
        }
    }
}

using Dependencies.BringClassUnderTest.ExtractInterface.Demo;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class NotificationsController : Controller
    {
        public NotificationService NotificationService { get; set; }


        public NotificationsController()
        {
            NotificationService = new NotificationService();
        }
    }
}

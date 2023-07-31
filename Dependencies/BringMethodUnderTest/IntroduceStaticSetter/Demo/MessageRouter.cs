using System;
using System.Collections.Generic;
using System.Text;

namespace Dependencies.BringMethodUnderTest.IntroduceStaticSetter.Demo
{
    public class MessageRouter
    {


        public void Route(Message message)
        {
            // ...

            var dispatcher = RouteRetriever.GetInstance().GetDispatcher();

            if (dispatcher != null)
            {
                dispatcher.SendMessage(message);
            }

            // ...
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Dependencies.BringMethodUnderTest.IntroduceStaticSetter.Demo
{
    public class MessageRouterTests
    {
        [Fact]
        public void Bring_Method_Under_Test()
        {
            var router = new MessageRouter();
            router.Route(new Message());
        }
    }
}

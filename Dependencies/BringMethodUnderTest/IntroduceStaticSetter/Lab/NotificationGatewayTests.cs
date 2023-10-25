using Xunit;

namespace Dependencies.BringMethodUnderTest.IntroduceStaticSetter.Lab
{
    public class NotificationGatewayTests
    {
        [Fact]
        public void Bring_Method_Under_Test()
        {
            var gateway = new NotificationGateway();

            gateway.Notify(new Notification());
        }
    }
}

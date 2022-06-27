namespace Dependencies.BringMethodUnderTest.IntroduceSensingVariable.Demo
{
    public class TemplateManager
    {
        private DispatcherService _dispatcherService = new DispatcherService();

        public Template CreateOrEdit(UserData admin, UserData dispatcher, int resetValue, int dispatcherId)
        {
            var template = new Template();

            // ...

            if (resetValue == 3 && !dispatcher.IsAdmin)
            {
                // ...

                if (admin.IsAdmin && admin.IsSuperAdmin == false)
                {
                    // ... 

                    var templateDb = new TemplateDatabase();
                    var msg = templateDb.GetLastTemplateMessage(dispatcherId);
                    var result = _dispatcherService.RetryDispatch(dispatcherId, resetValue);
                    if (!result)
                    {
                        msg = templateDb.GetLastTemplateMessage(dispatcherId);
                    }



                }
            }

            return template;
        }
    }
}

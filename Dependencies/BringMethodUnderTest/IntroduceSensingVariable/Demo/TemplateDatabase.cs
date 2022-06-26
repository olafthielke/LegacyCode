using System;
using System.Collections.Generic;
using System.Text;

namespace Dependencies.BringMethodUnderTest.IntroduceSensingVariable.Demo
{
    public class TemplateDatabase
    {
        public string GetLastTemplateMessage(int dispatcherId)
        {
            // Imagine this method accessing the template database
            // to retrive the most recent template method.

            return "Message dispatch error: '473 - Dispatcher unavailable.'";
        }
    }
}

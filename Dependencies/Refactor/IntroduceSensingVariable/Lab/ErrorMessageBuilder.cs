using System.Collections.Generic;
using System.Linq;
using LegacyLibrary.Error;

namespace Dependencies.Refactor.IntroduceSensingVariable.Lab
{
    public class ErrorMessageBuilder
    {
        // We want to refactor BuildErrorMessage() to only be about building of error messages, yet we
        // have call to ErrorDispatcher.Dispatch(errors) right in there. Seemingly, dispatching of
        // errors is unrelated to building of the error message. Therefore, we would like to move out
        // ErrorDispatcher.Dispatch() and do that in another place, probably wherever BuildErrorMessage()
        // is being called. We want to know whether moving ErrorDispatcher.Dispatch() has an effect on
        // the error message.
        public static string BuildErrorMessage(IList<ErrorData> errors)
        {
            if (errors == null || !errors.Any())
                return string.Empty;

            var errorMsg = "";

            if (errors.Count == 1)
                errorMsg = $"Got 1 error: ";
            else
                errorMsg = $"Got {errors.Count} errors: ";

            // Does this call to ErrorDispatcher have an effect on the errorMsg?
            ErrorDispatcher.Dispatch(errors);

            var i = 1;
            foreach (var error in errors)
            {
                errorMsg += $"{i++}. Message: {error.Message}, Code: {error.Code} | ";
            }

            errorMsg = errorMsg.Substring(0, errorMsg.Length - 3);

            return errorMsg + ".";
        }
    }
}

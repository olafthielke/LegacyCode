using System.Collections.Generic;
using System.Linq;
using LegacyLibrary.Error;

namespace Dependencies.BringMethodUnderTest.IntroduceSensingVariable.Lab
{
    public class ErrorMessageBuilder
    {
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

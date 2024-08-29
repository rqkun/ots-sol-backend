using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Common.ErrorHandle
{
    //internal class ErrorMessages
    public class ErrorMessages
    {
        public static class ExceptionMessages
        {
            #region User
            public const string WrongPassword = "Wrong password.";
            #endregion
        }
        public static class SuccessMessages
        {
            #region User
            public const string Login = "Login success.";
            #endregion
        }

        public static class MissingFieldMessage
        {
            #region Util
            public const string MissingFile = "File is not choose.";
            #endregion
        }

        public static class DuplicateMessage
        {
            #region Role
            public const string DuplicateRoleName = "Role name is already exist.";
            #endregion
        }

        public static class KeyNotFoundMessage
        {
            #region User
            public const string UserNotFound = "User does not exist.";
            #endregion

        }
    }
}
